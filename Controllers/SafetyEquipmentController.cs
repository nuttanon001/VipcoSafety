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
    public class SafetyEquipmentController : GenericSafetyController<SafetyEquipment>
    {
        // GET: api/SafetyEquipment
        public SafetyEquipmentController(IRepositorySafety<SafetyEquipment> repo,
           IMapper mapper) : base(repo, mapper)
        { }

        // POST: api/SafetyEquipment/GetScroll
        [HttpPost("GetScroll")]
        public async Task<IActionResult> GetScroll([FromBody] ScrollViewModel Scroll)
        {
            if (Scroll == null)
                return BadRequest();
            // Filter
            var filters = string.IsNullOrEmpty(Scroll.Filter) ? new string[] { "" }
                                : Scroll.Filter.Split(null);

            var predicate = PredicateBuilder.False<SafetyEquipment>();

            foreach (string temp in filters)
            {
                string keyword = temp;
                predicate = predicate.Or(x => x.NameEng.ToLower().Contains(keyword) ||
                                               x.NameThai.ToLower().Contains(keyword) ||
                                               x.Description.ToLower().Contains(keyword));
            }
            if (!string.IsNullOrEmpty(Scroll.Where))
                predicate = predicate.And(p => p.Creator == Scroll.Where);
            //Order by
            Func<IQueryable<SafetyEquipment>, IOrderedQueryable<SafetyEquipment>> order;
            // Order
            switch (Scroll.SortField)
            {
                case "NameThai":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.NameThai);
                    else
                        order = o => o.OrderBy(x => x.NameThai);
                    break;

                case "NameEng":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.NameEng);
                    else
                        order = o => o.OrderBy(x => x.NameEng);
                    break;

                case "Description":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.Description);
                    else
                        order = o => o.OrderBy(x => x.Description);
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
                                    include: null, // Include
                                    skip: Scroll.Skip ?? 0, // Skip
                                    take: Scroll.Take ?? 10); // Take

            // Get TotalRow
            Scroll.TotalRow = await this.repository.GetLengthWithAsync(predicate: predicate);

            //var mapDatas = new List<SafetyEquipment>();
            //foreach (var item in QueryData)
            //{
            //    var MapItem = this.mapper.Map<JobCardMaster, JobCardMasterViewModel>(item);
            //    mapDatas.Add(MapItem);
            //}

            return new JsonResult(new ScrollDataViewModel<SafetyEquipment>(Scroll, QueryData.ToList()), this.DefaultJsonSettings);
        }
    }
}
