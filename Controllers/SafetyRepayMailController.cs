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
using VipcoSafety.Models.SafetyData;
using VipcoSafety.Helpers;
using VipcoSafety.Services;
using VipcoSafety.ViewModels;
using VipcoSafety.Helper;

namespace VipcoSafety.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SafetyRepayMailController : GenericSafetyController<SafetyRepayMail>
    {
        // GET: api/SafetyRepayMail
        public SafetyRepayMailController(IRepositorySafety<SafetyRepayMail> repo,IMapper mapper)
            : base(repo, mapper)
        { }

        // POST: api/SafetyRepayMail/GetScroll
        [HttpPost("GetScroll")]
        public async Task<IActionResult> GetScroll([FromBody] ScrollViewModel Scroll)
        {
            if (Scroll == null)
                return BadRequest();
            // Filter
            var filters = string.IsNullOrEmpty(Scroll.Filter) ? new string[] { "" }
                                : Scroll.Filter.Split(null);

            var predicate = PredicateBuilder.False<SafetyRepayMail>();

            foreach (string temp in filters)
            {
                string keyword = temp;
                predicate = predicate.Or(x => x.SafetyName.ToLower().Contains(keyword) ||
                                              x.SafetyMail.ToLower().Contains(keyword) ||
                                              x.EmpCode.ToLower().Contains(keyword));
            }
            if (!string.IsNullOrEmpty(Scroll.Where))
                predicate = predicate.And(p => p.Creator == Scroll.Where);
            //Order by
            Func<IQueryable<SafetyRepayMail>, IOrderedQueryable<SafetyRepayMail>> order;
            // Order
            switch (Scroll.SortField)
            {
                case "SafetyName":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.SafetyName);
                    else
                        order = o => o.OrderBy(x => x.SafetyName);
                    break;
                case "SafetyMail":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.SafetyMail);
                    else
                        order = o => o.OrderBy(x => x.SafetyMail);
                    break;
                case "EmpCode":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.EmpCode);
                    else
                        order = o => o.OrderBy(x => x.EmpCode);
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

            //var mapDatas = new List<ConfinedSpaceWorkPermit>();
            //foreach (var item in QueryData)
            //{
            //    var MapItem = this.mapper.Map<JobCardMaster, JobCardMasterViewModel>(item);
            //    mapDatas.Add(MapItem);
            //}

            return new JsonResult(new ScrollDataViewModel<SafetyRepayMail>(Scroll, QueryData.ToList()), this.DefaultJsonSettings);
        }
    }
}
