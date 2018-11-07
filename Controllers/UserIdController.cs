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
using VipcoSafety.Models.Machines;
using VipcoSafety.Helpers;
using VipcoSafety.Services;
using VipcoSafety.ViewModels;
using VipcoSafety.Helper;

namespace VipcoSafety.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserIdController : GenericMachineController<User>
    {

        private readonly IRepositorySafety<Permission> repositoryPermission;
        // GET: api/UserId
        public UserIdController(IRepositoryMachine<User> repo,
            IRepositorySafety<Permission> repoPermission,
            IMapper mapper) : base(repo, mapper)
        {
            this.repositoryPermission = repoPermission;
        }

        // GET: api/UserId/GetKeyNumber/5
        [HttpGet("GetKeyNumber")]
        public override async Task<IActionResult> Get(int key)
        {
            var HasData = await this.repository.GetFirstOrDefaultAsync(
                x => x, x => x.UserId == key,null,
                x => x.Include(z => z.EmpCodeNavigation));
            var MapData = this.mapper.Map<User, UserViewModel>(HasData);
            return new JsonResult(MapData, this.DefaultJsonSettings);
        }

        // POST: api/UserId/GetScroll
        [HttpPost("GetScroll")]
        public async Task<IActionResult> GetScroll([FromBody] ScrollViewModel Scroll)
        {
            if (Scroll == null)
                return BadRequest();
            // Filter
            var filters = string.IsNullOrEmpty(Scroll.Filter) ? new string[] { "" }
                                : Scroll.Filter.Split(null);

            var predicate = PredicateBuilder.False<User>();

            foreach (string temp in filters)
            {
                string keyword = temp;
                predicate = predicate.Or(x => x.EmpCode.ToLower().Contains(keyword) ||
                                              x.UserName.ToLower().Contains(keyword) ||
                                              x.EmpCodeNavigation.NameThai.ToLower().Contains(keyword) ||
                                              x.EmpCodeNavigation.GroupCode.ToLower().Contains(keyword) ||
                                              x.EmpCodeNavigation.GroupName.ToLower().Contains(keyword));
            }

            //if (!string.IsNullOrEmpty(Scroll.Where))
            //    predicate = predicate.And(p => p.Creator == Scroll.Where);

            //Order by
            Func<IQueryable<User>, IOrderedQueryable<User>> order;
            // Order
            switch (Scroll.SortField)
            {
                case "EmpCode":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.EmpCode);
                    else
                        order = o => o.OrderBy(x => x.EmpCode);
                    break;
                case "Name":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.EmpCodeNavigation.NameThai);
                    else
                        order = o => o.OrderBy(x => x.EmpCodeNavigation.NameThai);
                    break;
                case "GroupCode":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.EmpCodeNavigation.GroupCode);
                    else
                        order = o => o.OrderBy(x => x.EmpCodeNavigation.GroupCode);
                    break;
                case "GroupName":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.EmpCodeNavigation.GroupName);
                    else
                        order = o => o.OrderBy(x => x.EmpCodeNavigation.GroupName);
                    break;
                default:
                    order = o => o.OrderByDescending(x => x.EmpCode);
                    break;
            }

            var QueryData = await this.repository.GetToListAsync(
                                    selector: selected => selected,  // Selected
                                    predicate: predicate, // Where
                                    orderBy: order, // Order
                                    include: x => x.Include(z => z.EmpCodeNavigation), // Include
                                    skip: Scroll.Skip ?? 0, // Skip
                                    take: Scroll.Take ?? 10); // Take
            // Get TotalRow
            Scroll.TotalRow = await this.repository.GetLengthWithAsync(predicate: predicate);
            var mapDatas = new List<UserViewModel>();
            foreach (var item in QueryData)
            {
                var MapItem = this.mapper.Map<User, UserViewModel>(item);
                mapDatas.Add(MapItem);
            }
            return new JsonResult(new ScrollDataViewModel<UserViewModel>(Scroll, mapDatas), this.DefaultJsonSettings);
        }

        // POST: api/LoginName/Login
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] User login)
        {

            var Message = "Login has error.";
            try
            {
                var HasData = await this.repository.GetFirstOrDefaultAsync(x => x,
                    m => m.UserName.ToLower() == login.UserName.ToLower() &&
                         m.PassWord.ToLower() == login.PassWord.ToLower(),
                    null,x => x.Include(z => z.EmpCodeNavigation));

                if (HasData != null)
                {
                    //For Demo
                    // HasData.LevelUser = 2;
                    // Unmark if in Production
                    if (HasData.LevelUser < 3)
                    {
                        var DataPermission = await this.repositoryPermission.GetFirstOrDefaultAsync(x => x, x => x.UserId == HasData.UserId);
                        if (DataPermission != null)
                            HasData.LevelUser = DataPermission.LevelPermission;
                        else
                            HasData.LevelUser = 0;
                    }
                    return new JsonResult(this.mapper.Map<User, UserViewModel>(HasData), this.DefaultJsonSettings);
                }
                else
                    return NotFound(new { Error = "user or password not match" });
            }
            catch (Exception ex)
            {
                Message = $"Has error {ex.ToString()}";
            }
            return NotFound(new { Error = Message });
        }

        // Put: api/UserId
        [HttpPut]
        public override async Task<IActionResult> Update(int key, [FromBody] User record)
        {
            if (key < 1)
                return BadRequest();
            if (record == null)
                return BadRequest();

            var hasPermission = await this.repositoryPermission.GetFirstOrDefaultAsync(x => x, x => x.UserId == record.UserId);
            if (hasPermission == null)
            {
                hasPermission = new Permission()
                {
                    CreateDate = DateTime.Now,
                    LevelPermission = record.LevelUser,
                    UserId = record.UserId
                };

                if (await this.repositoryPermission.AddAsync(hasPermission) == null)
                    return BadRequest();
            }
            else
            {
                hasPermission.ModifyDate = DateTime.Now;
                hasPermission.Modifyer = record.Modifyer;
                hasPermission.LevelPermission = record.LevelUser;

                if (await this.repositoryPermission.UpdateAsync(hasPermission, hasPermission.PremissionId) == null)
                    return BadRequest();
            }

            var hasUser = await this.repository.GetFirstOrDefaultAsync(x => x, x => x.UserId == record.UserId);
            if (hasUser != null)
            {
                hasUser.MailAddress = record.MailAddress;
                hasUser.ModifyDate = DateTime.Now;
                hasUser.Modifyer = record.Modifyer;

                await this.repository.UpdateAsync(hasUser, record.UserId);
            }
            
            return new JsonResult(record, this.DefaultJsonSettings);
        }
    }
}
