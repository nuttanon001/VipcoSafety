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
    public class GroupPermitHasCheckListController : GenericSafetyController<GroupPermitHasCheckList>
    {
        public GroupPermitHasCheckListController(IRepositorySafety<GroupPermitHasCheckList> repo,
           IMapper mapper) : base(repo, mapper)
        { }

        // GET: api/GroupPermitHasCheckList/GetByMaster/5
        [HttpGet("GetByMaster")]
        public async Task<IActionResult> GetByMaster(int key)
        {
            var HasData = await this.repository.GetToListAsync(
                            x => x, e => e.GroupWorkPermitId == key,null,x => x.Include(z => z.CheckList));
            var MapDatas = new List<GroupPermitHasCheckListViewModel>();
            if (HasData.Any())
            {
                foreach (var item in HasData.OrderBy(z => z.SequenceNo))
                    MapDatas.Add(this.mapper.Map<GroupPermitHasCheckList, GroupPermitHasCheckListViewModel>(item));
                return new JsonResult(MapDatas, this.DefaultJsonSettings);
            }
            else
                return NoContent();
        }
    }
}
