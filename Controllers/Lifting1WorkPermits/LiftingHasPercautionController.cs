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
using VipcoSafety.Models.LiftingWorkPermits;
using VipcoSafety.Helpers;
using VipcoSafety.Services;
using VipcoSafety.ViewModels;
using VipcoSafety.Helper;


namespace VipcoSafety.Controllers.Lifting1WorkPermits
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiftingHasPercautionController : GenericSafetyController<LiftingHasPercaution>
    {
        public LiftingHasPercautionController(IRepositorySafety<LiftingHasPercaution> repo,IMapper mapper)
            : base(repo, mapper)
        { }

        // GET: api/LiftingHasPercaution/GetByMaster/5
        [HttpGet("GetByMaster")]
        public async Task<IActionResult> GetByMaster(int key)
        {
            var HasData = await this.repository.GetToListAsync(
                            x => x, e => e.Lifting1WorkPermitId == key);
            if (HasData.Any())
                return new JsonResult(HasData, this.DefaultJsonSettings);
            else
                return NoContent();
        }
    }
}
