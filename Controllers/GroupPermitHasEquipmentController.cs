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
using VipcoSafety.Helper;
using VipcoSafety.Models;
using VipcoSafety.Helpers;
using VipcoSafety.Services;
using VipcoSafety.ViewModels;

namespace VipcoSafety.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupPermitHasEquipmentController : GenericSafetyController<GroupPermitHasEquipment>
    {
        public GroupPermitHasEquipmentController(IRepositorySafety<GroupPermitHasEquipment> repo,
           IMapper mapper) : base(repo, mapper)
        { }

        // GET: api/GroupPermitHasEquipment/GetByMaster/5
        [HttpGet("GetByMaster")]
        public async Task<IActionResult> GetByMaster(int key)
        {
            var HasData = await this.repository.GetToListAsync(
                            x => x, e => e.GroupWorkPermitId == key, null, x => x.Include(z => z.SafetyEquipment));
            var MapDatas = new List<GroupPermitHasEquipmentViewModel>();
            if (HasData.Any())
            {
                foreach (var item in HasData.OrderBy(z => z.SequenceNo))
                    MapDatas.Add(this.mapper.Map<GroupPermitHasEquipment, GroupPermitHasEquipmentViewModel>(item));
                return new JsonResult(MapDatas, this.DefaultJsonSettings);
            }
            else
                return NoContent();
        }
    }
}
