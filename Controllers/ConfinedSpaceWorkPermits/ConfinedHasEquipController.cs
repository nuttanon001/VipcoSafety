﻿// 3rd party
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
using VipcoSafety.Models.ConfinedSpaceWorkPermits;
using VipcoSafety.Helper;

namespace VipcoSafety.Controllers.ConfinedSpaceWorkPermits
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfinedHasEquipController : GenericSafetyController<ConfinedHasEquip>
    {
        public ConfinedHasEquipController(IRepositorySafety<ConfinedHasEquip> repo,
            IMapper mapper) : base(repo, mapper)
        { }

        // GET: api/ConfinedHasEquip/GetByMaster/5
        [HttpGet("GetByMaster")]
        public async Task<IActionResult> GetByMaster(int key)
        {
            var HasData = await this.repository.GetToListAsync(
                            x => x, e => e.ConfinedSpacePermitId == key,z => z.OrderBy(x => x.SafetyEquipmentId));
            if (HasData.Any())
                return new JsonResult(HasData, this.DefaultJsonSettings);
            else
                return NoContent();
        }
    }
}
