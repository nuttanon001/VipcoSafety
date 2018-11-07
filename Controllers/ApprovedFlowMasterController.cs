// 3rd party
using AutoMapper;
using Newtonsoft.Json;
// Microsoft
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
// System
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
// VipcoMaintenance
using VipcoSafety.Models;
using VipcoSafety.Helpers;
using VipcoSafety.Services;
using VipcoSafety.ViewModels;
using VipcoSafety.Helper;

namespace VipcoSafety.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ApprovedFlowMasterController : GenericSafetyController<ApprovedFlowMaster>
    {
        // Private
        private readonly IRepositorySafety<ApprovedFlowDetail> repositoryFlowDetail;
        public ApprovedFlowMasterController(IRepositorySafety<ApprovedFlowMaster> repo,
            IRepositorySafety<ApprovedFlowDetail> repoFlowDetail,
            IMapper mapper) : base(repo, mapper)
        {
            this.repositoryFlowDetail = repoFlowDetail;
        }

        // POST: api/ApprovedFlowMaster/GetScroll
        [HttpPost("GetScroll")]
        public async Task<IActionResult> GetScroll([FromBody] ScrollViewModel Scroll)
        {
            if (Scroll == null)
                return BadRequest();
            // Filter
            var filters = string.IsNullOrEmpty(Scroll.Filter) ? new string[] { "" }
                                : Scroll.Filter.Split(null);

            var predicate = PredicateBuilder.False<ApprovedFlowMaster>();

            foreach (string temp in filters)
            {
                string keyword = temp;
                predicate = predicate.Or(x => x.ApprovedByNameThai.ToLower().Contains(keyword) ||
                                               x.ApprovedByEmp.ToLower().Contains(keyword) ||
                                               x.ApprovedFlowDetails.Any(z => z.GroupMis.ToLower().Contains(keyword)) ||
                                               x.ApprovedFlowDetails.Any(z => z.GroupMisName.ToLower().Contains(keyword)));
            }
            if (!string.IsNullOrEmpty(Scroll.Where))
                predicate = predicate.And(p => p.Creator == Scroll.Where);
            //Order by
            Func<IQueryable<ApprovedFlowMaster>, IOrderedQueryable<ApprovedFlowMaster>> order;
            // Order
            switch (Scroll.SortField)
            {
                case "ApprovedBy":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.ApprovedByNameThai);
                    else
                        order = o => o.OrderBy(x => x.ApprovedByNameThai);
                    break;
                case "Date":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.CreateDate);
                    else
                        order = o => o.OrderBy(x => x.CreateDate);
                    break;
                default:
                    order = o => o.OrderByDescending(x => x.CreateDate);
                    break;
            }

            var QueryData = await this.repository.GetToListAsync(
                                    selector: selected => selected,  // Selected
                                    predicate: predicate, // Where
                                    orderBy: order, // Order
                                    include: z => z.Include(x => x.ApprovedFlowDetails), // Include
                                    skip: Scroll.Skip ?? 0, // Skip
                                    take: Scroll.Take ?? 10); // Take

            // Get TotalRow
            Scroll.TotalRow = await this.repository.GetLengthWithAsync(predicate: predicate);

            //var mapDatas = new List<ApprovedFlowMaster>();
            //foreach (var item in QueryData)
            //{
            //    var MapItem = this.mapper.Map<JobCardMaster, JobCardMasterViewModel>(item);
            //    mapDatas.Add(MapItem);
            //}

            return new JsonResult(new ScrollDataViewModel<ApprovedFlowMaster>(Scroll, QueryData.ToList()), this.DefaultJsonSettings);
        }

        [HttpPost]
        public override async Task<IActionResult> Create([FromBody] ApprovedFlowMaster record)
        {
            // Set date for CrateDate Entity
            if (record == null)
                return BadRequest();
            // +7 Hour
            record = this.helper.AddHourMethod(record);

            if (record.GetType().GetProperty("CreateDate") != null)
                record.GetType().GetProperty("CreateDate").SetValue(record, DateTime.Now);

            if (record.ApprovedFlowDetails.Any())
            {
                foreach (var item in record.ApprovedFlowDetails)
                {
                    item.CreateDate = DateTime.Now;
                    item.Creator = record.Creator;
                }
            }

            if (await this.repository.AddAsync(record) == null)
                return BadRequest();
            return new JsonResult(record, this.DefaultJsonSettings);
        }

        [HttpPut]
        public override async Task<IActionResult> Update(int key, [FromBody] ApprovedFlowMaster record)
        {
            if (key < 1)
                return BadRequest();
            if (record == null)
                return BadRequest();

            // +7 Hour
            record = this.helper.AddHourMethod(record);

            // Set date for CrateDate Entity
            if (record.GetType().GetProperty("ModifyDate") != null)
                record.GetType().GetProperty("ModifyDate").SetValue(record, DateTime.Now);

            if (record.ApprovedFlowDetails.Any())
            {
                foreach (var item in record.ApprovedFlowDetails)
                {
                    if (item.ApprovedFlowDetailId > 0)
                    {
                        item.ModifyDate = record.ModifyDate;
                        item.Modifyer = record.Modifyer;
                    }
                    else
                    {
                        item.CreateDate = record.ModifyDate;
                        item.Creator = record.Modifyer;
                    }
                }
            }

            if (await this.repository.UpdateAsync(record, key) == null)
                return BadRequest();
            
            if (record != null)
            {
                // filter
                var dbDetails = await this.repositoryFlowDetail.GetToListAsync(x => x,x => x.ApprovedFlowMasterId == key);
                //Remove ApprovedFlowDetails if edit remove it
                foreach (var dbDetail in dbDetails)
                {
                    if (!record.ApprovedFlowDetails.Any(x => x.ApprovedFlowDetailId == dbDetail.ApprovedFlowDetailId))
                        await this.repositoryFlowDetail.DeleteAsync(dbDetail.ApprovedFlowDetailId);
                }
                //Update ApprovedFlowDetails or New ApprovedFlowDetails
                foreach (var uDetail in record.ApprovedFlowDetails)
                {
                    if (uDetail.ApprovedFlowDetailId > 0)
                        await this.repositoryFlowDetail.UpdateAsync(uDetail, uDetail.ApprovedFlowDetailId);
                    else
                    {
                        uDetail.ApprovedFlowMasterId = record.ApprovedFlowMasterId;
                        await this.repositoryFlowDetail.AddAsync(uDetail);
                    }
                }
            }
            return new JsonResult(record, this.DefaultJsonSettings);
        }
        
        [HttpDelete()]
        public override async Task<IActionResult> Delete(int key)
        {
            if (key > 0)
            {
                var details = await this.repositoryFlowDetail.GetToListAsync(x => x, x => x.ApprovedFlowMasterId == key);
                if (details != null && details.Any())
                {
                    foreach (var item in details)
                        await this.repositoryFlowDetail.DeleteAsync(item.ApprovedFlowDetailId);
                }

                if (await this.repository.DeleteAsync(key) == 0)
                    return BadRequest();
            }
            return NoContent();
        }
    }
}
