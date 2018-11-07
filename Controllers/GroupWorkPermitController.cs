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
    public class GroupWorkPermitController : GenericSafetyController<GroupWorkPermit>
    {
        private readonly IRepositorySafety<GroupPermitHasCheckList> repositoryHasCheck;
        private readonly IRepositorySafety<GroupPermitHasEquipment> repositoryHasEquip;
        public GroupWorkPermitController(IRepositorySafety<GroupWorkPermit> repo,
            IRepositorySafety<GroupPermitHasCheckList> repoHasCheck,
            IRepositorySafety<GroupPermitHasEquipment> repoHasEquip,
            IMapper mapper) : base(repo, mapper)
        {
            this.repositoryHasCheck = repoHasCheck;
            this.repositoryHasEquip = repoHasEquip;
        }

        // POST: api/GroupWorkPermit/GetScroll
        [HttpPost("GetScroll")]
        public async Task<IActionResult> GetScroll([FromBody] ScrollViewModel Scroll)
        {
            if (Scroll == null)
                return BadRequest();
            // Filter
            var filters = string.IsNullOrEmpty(Scroll.Filter) ? new string[] { "" }
                                : Scroll.Filter.Split(null);

            var predicate = PredicateBuilder.False<GroupWorkPermit>();

            foreach (string temp in filters)
            {
                string keyword = temp;
                predicate = predicate.Or(x => x.Description.ToLower().Contains(keyword) ||
                                              x.Name.ToLower().Contains(keyword));
            }
            if (!string.IsNullOrEmpty(Scroll.Where))
                predicate = predicate.And(p => p.Creator == Scroll.Where);
            //Order by
            Func<IQueryable<GroupWorkPermit>, IOrderedQueryable<GroupWorkPermit>> order;
            // Order
            switch (Scroll.SortField)
            {
                case "Name":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.Name);
                    else
                        order = o => o.OrderBy(x => x.Name);
                    break;
                case "Description":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.Description);
                    else
                        order = o => o.OrderBy(x => x.Description);
                    break;
                case "CreateDate":
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
                                    include: null, // Include
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

            return new JsonResult(new ScrollDataViewModel<GroupWorkPermit>(Scroll, QueryData.ToList()), this.DefaultJsonSettings);
        }

        // POST: api/GroupWorkPermit/
        [HttpPost]
        public override async Task<IActionResult> Create([FromBody] GroupWorkPermit record)
        {
            // Set date for CrateDate Entity
            if (record == null)
                return BadRequest();
            // +7 Hour
            record = this.helper.AddHourMethod(record);

            if (record.GetType().GetProperty("CreateDate") != null)
                record.GetType().GetProperty("CreateDate").SetValue(record, DateTime.Now);

            if (record.GroupPermitHasCheckList != null && record.GroupPermitHasCheckList.Any())
            {
                foreach (var item in record.GroupPermitHasCheckList)
                {
                    item.CreateDate = DateTime.Now;
                    item.Creator = record.Creator;
                    item.CheckList = null;
                }
            }

            if (record.GroupPermitHasEquipments != null && record.GroupPermitHasEquipments.Any())
            {
                foreach (var item in record.GroupPermitHasEquipments)
                {
                    item.CreateDate = DateTime.Now;
                    item.Creator = record.Creator;
                    item.SafetyEquipment = null;
                }
            }

            if (await this.repository.AddAsync(record) == null)
                return BadRequest();
            return new JsonResult(record, this.DefaultJsonSettings);
        }

        // Put: api/GroupWorkPermit/
        [HttpPut]
        public override async Task<IActionResult> Update(int key, [FromBody] GroupWorkPermit record)
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

            if (record.GroupPermitHasCheckList.Any())
            {
                foreach (var item in record.GroupPermitHasCheckList)
                {
                    item.CheckList = null;
                    if (item.GroupHasCheckId > 0)
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

            if (record.GroupPermitHasEquipments.Any())
            {
                foreach (var item in record.GroupPermitHasEquipments)
                {
                    item.SafetyEquipment = null;
                    if (item.GroupHasEquipId > 0)
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
                if (record.GroupPermitHasCheckList.Any())
                {
                    // filter
                    var dbDetails = await this.repositoryHasCheck.GetToListAsync(x => x, x => x.GroupWorkPermitId == key);
                    //Remove ApprovedFlowDetails if edit remove it
                    foreach (var dbDetail in dbDetails)
                    {
                        if (!record.GroupPermitHasCheckList.Any(x => x.GroupHasCheckId == dbDetail.GroupHasCheckId))
                            await this.repositoryHasCheck.DeleteAsync(dbDetail.GroupHasCheckId);
                    }
                    //Update ApprovedFlowDetails or New ApprovedFlowDetails
                    foreach (var uDetail in record.GroupPermitHasCheckList)
                    {
                        if (uDetail.GroupHasCheckId > 0)
                            await this.repositoryHasCheck.UpdateAsync(uDetail, uDetail.GroupHasCheckId);
                        else
                        {
                            uDetail.GroupWorkPermitId = record.GroupWorkPermitId;
                            await this.repositoryHasCheck.AddAsync(uDetail);
                        }
                    }
                }

                if (record.GroupPermitHasEquipments.Any())
                {
                    // filter
                    var dbDetails = await this.repositoryHasEquip.GetToListAsync(x => x, x => x.GroupWorkPermitId == key);
                    //Remove ApprovedFlowDetails if edit remove it
                    foreach (var dbDetail in dbDetails)
                    {
                        if (!record.GroupPermitHasEquipments.Any(x => x.GroupHasEquipId == dbDetail.GroupHasEquipId))
                            await this.repositoryHasEquip.DeleteAsync(dbDetail.GroupHasEquipId);
                    }
                    //Update ApprovedFlowDetails or New ApprovedFlowDetails
                    foreach (var uDetail in record.GroupPermitHasEquipments)
                    {
                        if (uDetail.GroupHasEquipId > 0)
                            await this.repositoryHasEquip.UpdateAsync(uDetail, uDetail.GroupHasEquipId);
                        else
                        {
                            uDetail.GroupWorkPermitId = record.GroupWorkPermitId;
                            await this.repositoryHasEquip.AddAsync(uDetail);
                        }
                    }
                }
            }
            return new JsonResult(record, this.DefaultJsonSettings);
        }
    }
}
