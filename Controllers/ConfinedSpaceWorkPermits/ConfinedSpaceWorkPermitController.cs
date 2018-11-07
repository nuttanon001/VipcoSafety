// 3rd party
using AutoMapper;
using Newtonsoft.Json;
// Microsoft
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
// System
using System;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
// VipcoMaintenance
using VipcoSafety.Models;
using VipcoSafety.Helpers;
using VipcoSafety.Services;
using VipcoSafety.ViewModels;
using VipcoSafety.Models.Machines;
using VipcoSafety.Models.ConfinedSpaceWorkPermits;
using VipcoSafety.Models.SafetyData;
using VipcoSafety.Helper;
using Microsoft.AspNetCore.Hosting;
// 3rd Party
using ClosedXML.Excel;

namespace VipcoSafety.Controllers.ConfinedSpaceWorkPermits
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfinedSpaceWorkPermitController : GenericSafetyController<ConfinedSpaceWorkPermit>
    {
        private readonly IRepositorySafety<ConfinedHasEmpHelp> repositoryConHasEmpHelp;
        private readonly IRepositorySafety<ConfinedHasEmpWork> repositoryConHasEmpWork;
        private readonly IRepositorySafety<ConfinedHasEquip> repositoryHasEquip;
        private readonly IRepositorySafety<ConfinedHasCheckList> repositoryHasCheck;
        private readonly IRepositorySafety<ConfinedHasPrecaution> repositoryHasPercaution;
        private readonly IRepositorySafety<GroupPermitHasCheckList> repositoryGroupHasCheck;
        private readonly IRepositorySafety<GroupPermitHasEquipment> repositoryGroupEquip;
        private readonly IRepositorySafety<ApprovedFlowDetail> repositoryApproved;
        private readonly IRepositoryMachine<Employee> repositoryEmployee;
        private readonly IRepositorySafety<SafetyRepayMail> repositorySafetyMail;
        // IHostingEnvironment
        private readonly IHostingEnvironment hosting;
        //Email
        private readonly EmailClass EmailClass;// Private 
        public ConfinedSpaceWorkPermitController(
            IRepositorySafety<ConfinedSpaceWorkPermit> repo,
            IRepositorySafety<ConfinedHasEmpHelp> repoConHasEmpHelp,
            IRepositorySafety<ConfinedHasEmpWork> repoConHasEmpWork,
            IRepositorySafety<GroupPermitHasCheckList> repoGroupHasCheck,
            IRepositorySafety<GroupPermitHasEquipment> repoGroupEquip,
            IRepositorySafety<ConfinedHasEquip> repoHasEquip,
            IRepositorySafety<ConfinedHasCheckList> repoHasCheck,
            IRepositorySafety<ConfinedHasPrecaution> repoHasPercaution,
            IRepositorySafety<ApprovedFlowDetail> repoApproved,
            IRepositorySafety<SafetyRepayMail> repoSafetyMail,
            IRepositoryMachine<Employee> repoEmployee,
            IHostingEnvironment hosting,
            IMapper mapper) : base(repo, mapper)
        {
            //IRepository Safety
            this.repositoryConHasEmpHelp = repoConHasEmpHelp;
            this.repositoryConHasEmpWork = repoConHasEmpWork;
            this.repositoryHasCheck = repoHasCheck;
            this.repositoryHasEquip = repoHasEquip;
            this.repositoryHasPercaution = repoHasPercaution;
            this.repositoryGroupEquip = repoGroupEquip;
            this.repositoryGroupHasCheck = repoGroupHasCheck;
            this.repositoryApproved = repoApproved;
            this.repositoryEmployee = repoEmployee;
            this.repositorySafetyMail = repoSafetyMail;
            //Helper
            this.EmailClass = new EmailClass();
            // Host
            this.hosting = hosting;
        }

        private async Task<MemoryStream> CreateReport(int key)
        {
            var Message = "Not been found data.";
            try
            {
                if (key > 0)
                {
                    var HasData = await this.repository.GetFirstOrDefaultAsync(
                        select => select,
                        x => x.ConfinedSpaceWorkPermitId == key,
                        null, x => x.Include(z => z.ConfinedHasCheckLists)
                                    .Include(z => z.ConfinedHasEquips)
                                    .Include(z => z.ConfinedHasEmpHelps)
                                    .Include(z => z.ConfinedHasEmpWorks)
                                    .Include(z => z.ConfinedHasPrecautions));

                    if (HasData != null)
                    {
                        var templateFolder = this.hosting.WebRootPath + "/reports/";
                        var fileExcel = templateFolder + $"ConfinedSpaceWorkPermit.xlsx";
                        var SaveAsExcel = templateFolder + $"ConfinedSpaceWorkPermitModified.xlsx";
                        using (var workbook = new XLWorkbook(fileExcel))
                        {
                            var ws = workbook.Worksheet(1);

                            // SET VALUE TO EXCEL
                            if (HasData.InstallWork.HasValue && HasData.InstallWork.Value)
                                ws.Cell(9, "G").Value = "P";
                            else if (HasData.RepairWork != null && HasData.RepairWork.Value)
                                ws.Cell(9, "O").Value = "P";

                            // SET VALUE TO HOT WORKPERMIT
                            if (HasData.HasHotPermit.HasValue && HasData.HasHotPermit.Value)
                                ws.Cell(18, "K").Value = "P";
                            else
                                ws.Cell(18, "S").Value = "P";

                            // SET VALUE TO HOTWORKGRINDING
                            if (HasData.HotWorkGrinding.HasValue && HasData.HotWorkGrinding.Value)
                                ws.Cell(20, "K").Value = "P";

                            // SET VALUE TO HOTWORKGRINDING
                            if (HasData.HotWorkCutting.HasValue && HasData.HotWorkCutting.Value)
                                ws.Cell(20, "N").Value = "P";

                            // SET VALUE TO HOTWORKGRINDING
                            if (HasData.HotWorkWelding.HasValue && HasData.HotWorkWelding.Value)
                                ws.Cell(20, "P").Value = "P";

                            // SET VALUE TO HOTWORKOTHER
                            if (HasData.HotWorkOther.HasValue && HasData.HotWorkOther.Value)
                                ws.Cell(20, "T").Value = "P";

                            //SET DATE
                            var FullDateS = "-";
                            var FullDataE = "-";
                            if (HasData.WpStartDate.HasValue)
                            {
                                FullDateS = HasData.WpStartDate.Value.ToString("dd/MMM/") +
                                    (HasData.WpStartDate.Value.Year < 2550 ? (HasData.WpStartDate.Value.Year + 543).ToString() : HasData.WpStartDate.Value.ToString("yyyy"));
                            }

                            if (HasData.WpEndDate.HasValue)
                            {
                                FullDataE = HasData.WpEndDate.Value.ToString("dd/MMM/") +
                                    (HasData.WpEndDate.Value.Year < 2550 ? (HasData.WpEndDate.Value.Year + 543).ToString() : HasData.WpEndDate.Value.ToString("yyyy"));
                            }

                            ws.Cell(16, "G").Value = "'" + FullDateS;
                            ws.Cell(16, "G").DataType = XLDataType.Text;

                            ws.Cell(16, "O").Value = "'" + FullDateS;
                            ws.Cell(16, "O").DataType = XLDataType.Text;

                            ws.Cell(16, "L").Value = !string.IsNullOrEmpty(HasData.WpStartTimeString) ? $"'{HasData.WpStartTimeString}" : "";
                            ws.Cell(16, "L").DataType = XLDataType.Text;

                            if (HasData.WorkComplate.HasValue)
                            {
                                if (HasData.WorkComplate.Value)
                                    ws.Cell(58, "X").Value = "P";
                                else
                                    ws.Cell(58, "Z").Value = "P";
                            }

                            if (HasData.AreaClear.HasValue)
                            {
                                if (HasData.AreaClear.Value)
                                    ws.Cell(61, "X").Value = "P";
                                else
                                    ws.Cell(61, "Z").Value = "P";
                            }

                            if (HasData.KeepOutClear.HasValue)
                            {
                                if (HasData.KeepOutClear.Value)
                                    ws.Cell(64, "X").Value = "P";
                                else
                                    ws.Cell(64, "Z").Value = "P";
                            }

                            // TEXT OPTION 2
                            foreach (var field in HasData.GetType().GetProperties()) // Loop through fields
                            {
                                string name = field.Name; // Get string name
                                var value = field.GetValue(HasData, null);

                                if (name == "ComplateBy")
                                    continue;

                                if (value is DateTime && value != null)
                                {
                                    DateTime temp = (DateTime)value;
                                    value = $"'{temp.ToString("dd/MMM/")}" + (temp.Year < 2550 ? (temp.Year + 543).ToString() : temp.ToString("yyyy"));
                                }

                                if (name.IndexOf("ApprovedByEmpName") != -1)
                                {
                                    if (HasData.StatusWorkPermit != StatusWorkPermit.Approved)
                                        value = "";
                                }

                                var filter = $"data:{name}";
                                var cell = ws.Search(filter, CompareOptions.Ordinal).ToList();
                                cell.ForEach(item =>
                                {
                                    if (item != null)
                                    {
                                        item.Value = value ?? "";
                                        item.DataType = XLDataType.Text;
                                    }
                                });
                            }

                            foreach (var item in HasData.ConfinedHasCheckLists)
                            {
                                if (item.HasCheck.HasValue && item.HasCheck.Value)
                                {
                                    var checkList = await this.repositoryGroupHasCheck.GetFirstOrDefaultAsync(x => x, x => x.CheckListId == item.CheckListId);
                                    if (checkList != null)
                                    {
                                        var row = checkList.SequenceNo ?? 1;
                                        ws.Cell(37 + row, "A").Value = "P";
                                    }
                                }
                            }

                            foreach (var item in HasData.ConfinedHasEquips)
                            {
                                if (item.HasCheck.HasValue && item.HasCheck.Value)
                                {
                                    var equipment = await this.repositoryGroupEquip.GetFirstOrDefaultAsync(x => x, x => x.SafetyEquipmentId == item.SafetyEquipmentId);
                                    if (equipment != null)
                                    {
                                        if (equipment.SequenceNo < 8)
                                        {
                                            var row = equipment.SequenceNo ?? 1;
                                            if (equipment.SequenceNo > 3 && equipment.SequenceNo < 8)
                                                row += 1;
                                            ws.Cell(26 + row, "A").Value = "P";
                                        }
                                        else
                                        {
                                            var row = (equipment.SequenceNo ?? 1) - 7;
                                            ws.Cell(26 + row, "K").Value = "P";
                                        }
                                    }
                                }
                            }

                            var index = 1;
                            foreach (var item in HasData.ConfinedHasEmpWorks)
                            {
                                if (!string.IsNullOrEmpty(item.EmpNameThai))
                                {
                                    if (index < 4)
                                    {
                                        ws.Cell(26 + index, "S").Value = item.EmpNameThai;
                                        ws.Cell(26 + index, "S").DataType = XLDataType.Text;
                                    }
                                    else
                                    {
                                        ws.Cell(26 + (index - 3), "Y").Value = item.EmpNameThai;
                                        ws.Cell(26 + (index - 3), "Y").DataType = XLDataType.Text;
                                    }
                                }
                                index++;
                            }

                            index = 1;
                            foreach (var item in HasData.ConfinedHasEmpHelps)
                            {
                                if (!string.IsNullOrEmpty(item.EmpNameThai))
                                {
                                    if (index < 4)
                                    {
                                        ws.Cell(30 + index, "S").Value = item.EmpNameThai;
                                        ws.Cell(30 + index, "S").DataType = XLDataType.Text;
                                    }
                                    else
                                    {
                                        ws.Cell(30 + (index - 3), "Y").Value = item.EmpNameThai;
                                        ws.Cell(30 + (index - 3), "Y").DataType = XLDataType.Text;
                                    }
                                }
                                index++;
                            }

                            index = 1;
                            foreach (var item in HasData.ConfinedHasPrecautions)
                            {
                                if (!string.IsNullOrEmpty(item.Risk))
                                {
                                    // Risk
                                    ws.Cell(38 + (index), "R").Value = item.Risk;
                                    ws.Cell(38 + (index), "R").DataType = XLDataType.Text;
                                    // Measure
                                    ws.Cell(38 + (index), "V").Value = item.Measure;
                                    ws.Cell(38 + (index), "V").DataType = XLDataType.Text;
                                }
                                index++;
                            }

                            var protection = ws.Protect("77465");
                            // IF SET Allow Insert row and insert columns
                            //protection.InsertRows = true;
                            //protection.InsertColumns = true;

                            workbook.SaveAs(SaveAsExcel);
                        }

                        var memory = new MemoryStream();
                        using (var stream = new FileStream(SaveAsExcel, FileMode.Open))
                        {
                            await stream.CopyToAsync(memory);
                        }
                        memory.Position = 0;

                        return memory;
                    }
                }
            }
            catch (Exception ex)
            {
                Message = $"Has error {ex.ToString()}";
            }
            return null;
        }
        /// <summary>
        /// Send Mail
        /// </summary>
        /// <param name="HasData"></param>
        /// <param name="Option"> 1 or def = ToApproved | 2 = ToRequire</param>
        /// <returns></returns>
        private async Task<bool> SendMail(ConfinedSpaceWorkPermit HasData, int Option = 1)
        {
            if (HasData != null)
            {
                var ListMail = new List<string>();
                if (!string.IsNullOrEmpty(HasData.RepayMail))
                {
                    if (HasData.RepayMail.IndexOf(',') != -1)
                        ListMail = HasData.RepayMail.Split(',').ToList();
                    else if (HasData.RepayMail.IndexOf(';') != -1)
                        ListMail = HasData.RepayMail.Split(';').ToList();
                    else
                        ListMail.Add(HasData.RepayMail);
                }

                if (ListMail.Any())
                {
                    if (Option == 1)
                    {
                        var GroupMis = await this.repositoryEmployee.GetFirstOrDefaultAsync(x => x.GroupMis, x => x.EmpCode == HasData.RequireByEmpCode);
                        var MailTo = await this.repositoryApproved.GetToListAsync(x => x.ApprovedFlowMaster, x => x.GroupMis == GroupMis);
                        var listMail = new List<SendMail>();
                        if (MailTo != null && MailTo.Any())
                        {
                            foreach (var item in MailTo)
                            {
                                listMail.Add(new ViewModels.SendMail()
                                {
                                    MailAddress = item.ApprovedByMail,
                                    Name = item.ApprovedByNameThai
                                });
                            }
                        }
                        var SafetyMails = await this.repositorySafetyMail.GetToListAsync(x => x);
                        foreach (var item in SafetyMails)
                        {
                            listMail.Add(new ViewModels.SendMail()
                            {
                                MailAddress = item.SafetyMail,
                                Name = item.SafetyName
                            });
                        }

                        if (listMail.Any())
                        {
                            var Report = await this.CreateReport(HasData.ConfinedSpaceWorkPermitId);
                            foreach (var item in listMail)
                            {
                                var BodyMessage = "<body style=font-size:11pt;font-family:Tahoma>" +
                                                    "<h4 style='color:steelblue;'>เมล์ฉบับนี้เป็นแจ้งเตือนจากระบบงาน VIPCO SAFETY SYSTEM</h4>" +
                                                    $"เรียน คุณ{item.Name}" +
                                                    $"<p>เรื่อง คำขออนุมัติ \"Confined Space Workpermit\"</p><hr></hr>" +
                                                    $"<p>โดยทาง \"{HasData.RequireByEmpName}\" ได้ทำการส่งคำขอ Workpermit เพื่อให้ทาง \"คุณ{item.Name}\" </p>" +
                                                    $"<p>เห็นสมควรในการ \"<a href='http://{Request.Host}/safety/api/ConfinedSpaceWorkPermit/approved/{HasData.ConfinedSpaceWorkPermitId}'>อนุมัติ</a>\"" +
                                                    $"  หรือ  \"<a style='color:red;' href='http://{Request.Host}/safety/api/ConfinedSpaceWorkPermit/reject/{HasData.ConfinedSpaceWorkPermitId}'>ยกเลิก</a>\" คำขอนี้ พร้อมทั้งนี้ยังได้แนบเอกสารคำขอ Workpermit มากับอีเมล์ฉบับนี้</p>" +
                                                    $"<p>\"คุณ{item.Name}\" " +
                                                    $"สามารถเข้าไปตรวจติดตามข้อมูลได้ <a href='http://{Request.Host}/safety/confined-space/{HasData.ConfinedSpaceWorkPermitId}'>ที่นี้</a> </p>" +
                                                    "<span style='color:steelblue;'>This mail auto generated by VIPCO MACHINE SYSTEM. Do not reply this email.</span>" +
                                                  "</body>";

                                await this.EmailClass.SendMailMessage(ListMail[0], item.Name,
                                                      new List<string>() { item.MailAddress },
                                                      BodyMessage, "Notification mail from VIPCO Safety system.", Report, "ConfinedSpaceWorkPermit.xlsx");
                            }
                            return true;
                        }
                    }
                    else if (Option == 2)
                    {
                        var isApproved = HasData.StatusWorkPermit == StatusWorkPermit.Approved;
                        #region SafetyMail

                        var listMail = new List<SendMail>();
                        var SafetyMails = await this.repositorySafetyMail.GetToListAsync(x => x);
                        foreach (var item in SafetyMails)
                        {
                            listMail.Add(new ViewModels.SendMail()
                            {
                                MailAddress = item.SafetyMail,
                                Name = item.SafetyName
                            });
                        }

                        var BodyMessageSf = "<body style=font-size:11pt;font-family:Tahoma>" +
                                              "<h4 style='color:steelblue;'>เมล์ฉบับนี้เป็นแจ้งเตือนจากระบบงาน VIPCO SAFETY SYSTEM</h4>" +
                                              $"เรียน หน่วยงานความปลอดภัย" +
                                              $"<p>เรื่อง คำขออนุมัติ \"Confined Space Workpermit\"จากทาง \"{HasData.RequireByEmpName}\"</p><hr></hr>" +
                                              $"<p>ณ ขณะนี้คำขอดังกล่าวได้รับการ \" {(isApproved ? "<span style='color:blue;'>อนุมัติตามคำขอ</span>" : "<span style='color:red;'>ยกเลิกคำขอ</span>")}\"</p>" +
                                              $"<p>จึงแจ้งมาเพื่อทราบ</p>" +
                                              $"สามารถเข้าไปตรวจติดตามข้อมูลได้ <a href='http://{Request.Host}/safety/confined-space/{HasData.ConfinedSpaceWorkPermitId}'>ที่นี้</a> </p>" +
                                              "<span style='color:steelblue;'>This mail auto generated by VIPCO MACHINE SYSTEM. Do not reply this email.</span>" +
                                            "</body>";

                        await this.EmailClass.SendMailMessage(ListMail[0], HasData.RequireByEmpName, listMail.Select(z => z.MailAddress).ToList(),
                                             BodyMessageSf, "Notification mail from VIPCO Safety system.");
                        #endregion

                        var BodyMessage = "<body style=font-size:11pt;font-family:Tahoma>" +
                                                "<h4 style='color:steelblue;'>เมล์ฉบับนี้เป็นแจ้งเตือนจากระบบงาน VIPCO SAFETY SYSTEM</h4>" +
                                                $"เรียน {HasData.RequireByEmpName}" +
                                                $"<p>เรื่อง คำขออนุมัติ \"Confined Space Workpermit\"</p><hr></hr>" +
                                                $"<p>ณ ขณะนี้คำขอดังกล่าวได้รับการ \" {(isApproved ? "<span style='color:blue;'>อนุมัติตามคำขอ</span>" : "<span style='color:red;'>ยกเลิกคำขอ</span>")}\"</p>" +
                                                $"<p>หากมีขอสงสัยใดโปรดติดต่อกับทางหน่วยงานความปลอดภัย</p>" +
                                                $"<p>\"{HasData.RequireByEmpName}\" " +
                                                $"สามารถเข้าไปตรวจติดตามข้อมูลได้ <a href='http://{Request.Host}/safety/confined-space/{HasData.ConfinedSpaceWorkPermitId}'>ที่นี้</a> </p>" +
                                                "<span style='color:steelblue;'>This mail auto generated by VIPCO MACHINE SYSTEM. Do not reply this email.</span>" +
                                              "</body>";
                        MemoryStream Report = null;

                        if (isApproved)
                            Report = await this.CreateReport(HasData.ConfinedSpaceWorkPermitId);

                        return await this.EmailClass.SendMailMessage(ListMail[0], HasData.RequireByEmpName, ListMail,
                                             BodyMessage, "Notification mail from VIPCO Safety system.",
                                             isApproved ? Report : null,
                                             isApproved ? "ConfinedSpaceWorkPermit.xlsx" : "");
                    }
                }
            }

            return false;
        }
        private async Task<Tuple<bool,ConfinedSpaceWorkPermit>> UpdateStatus(int key, StatusWorkPermit statusWork)
        {
            var HasData = await this.repository.GetFirstOrDefaultAsync(x => x, x => x.ConfinedSpaceWorkPermitId == key);

            if (HasData != null && HasData.StatusWorkPermit == StatusWorkPermit.Require)
            {
                if (statusWork == StatusWorkPermit.Approved)
                    HasData.ApprovedDate = DateTime.Now;

                HasData.StatusWorkPermit = statusWork;
                HasData.ModifyDate = DateTime.Now;
                HasData.Modifyer = "FromMail";

                await this.repository.UpdateAsync(HasData, key);
                return new Tuple<bool, ConfinedSpaceWorkPermit>(true,HasData);
            }
            return new Tuple<bool, ConfinedSpaceWorkPermit>(false,null);
        }

        // GET: api/ConfinedSpaceWorkPermit/approved/5
        [HttpGet("approved/{key}")]
        public async Task<IActionResult> ApprovedWorkPermit(int key)
        {
            var Result = await this.UpdateStatus(key, StatusWorkPermit.Approved);
            if (Result.Item1)
                await this.SendMail(Result.Item2, 2);
            return new JsonResult(new { Status = (Result.Item1 ? "Workpermit ได้รับการอนุมัติ" : "Workpermit นี้ได้ดำเนินการไปแล้ว") }, this.DefaultJsonSettings);
        }
        // GET: api/ConfinedSpaceWorkPermit/reject/5
        [HttpGet("reject/{key}")]
        public async Task<IActionResult> RejectWorkPermit(int key)
        {
            var Result = await this.UpdateStatus(key, StatusWorkPermit.Cancelled);
            if (Result.Item1)
                await this.SendMail(Result.Item2, 2);
            return new JsonResult(new { Status = (Result.Item1 ? "Workpermit ได้รับการยกเลิก" : "Workpermit นี้ได้ดำเนินการไปแล้ว") }, this.DefaultJsonSettings);
        }
        // GET: api/ConfinedSpaceWorkPermit/ResendMail/5
        [HttpGet("ResendMail")]
        public async Task<IActionResult> ResendMail(int key)
        {
            if (key > 0)
            {
                var HasData = await this.repository.GetFirstOrDefaultAsync(x => x, x => x.ConfinedSpaceWorkPermitId == key);
                if (await this.SendMail(HasData))
                {
                    HasData.IsSendMail = true;
                    await this.repository.UpdateAsync(HasData, key);
                }
                return NoContent();
            }
            return BadRequest();
        }
        // GET: api/ConfinedSpaceWorkPermit/5
        [HttpGet("GetKeyNumber")]
        public override async Task<IActionResult> Get(int key)
        {
            var HasData = await this.repository.GetFirstOrDefaultAsync(x => x,x => x.ConfinedSpaceWorkPermitId == key);
            var MapData = this.mapper.Map<ConfinedSpaceWorkPermit, ConfinedSpaceWorkPermitViewModel>(HasData);
            return new JsonResult(MapData, this.DefaultJsonSettings);
        }
        // POST: api/ConfinedSpaceWorkPermit/GetScroll
        [HttpPost("GetScroll")]
        public async Task<IActionResult> GetScroll([FromBody] ScrollViewModel Scroll)
        {
            if (Scroll == null)
                return BadRequest();
            // Filter
            var filters = string.IsNullOrEmpty(Scroll.Filter) ? new string[] { "" }
                                : Scroll.Filter.Split(null);

            var predicate = PredicateBuilder.False<ConfinedSpaceWorkPermit>();

            foreach (string temp in filters)
            {
                string keyword = temp;
                predicate = predicate.Or(x => x.RequireByEmpName.ToLower().Contains(keyword) ||
                                              x.SubContractor.ToLower().Contains(keyword) ||
                                              x.Location.ToLower().Contains(keyword));
            }
            if (!string.IsNullOrEmpty(Scroll.Where))
                predicate = predicate.And(p => p.Creator == Scroll.Where);
            //Order by
            Func<IQueryable<ConfinedSpaceWorkPermit>, IOrderedQueryable<ConfinedSpaceWorkPermit>> order;
            // Order
            switch (Scroll.SortField)
            {
                case "RequireBy":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.RequireByEmpName);
                    else
                        order = o => o.OrderBy(x => x.RequireByEmpName);
                    break;
                case "SubContractor":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.SubContractor);
                    else
                        order = o => o.OrderBy(x => x.SubContractor);
                    break;
                case "Location":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.Location);
                    else
                        order = o => o.OrderBy(x => x.Location);
                    break;
                case "WorkingDate":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.WpStartDate);
                    else
                        order = o => o.OrderBy(x => x.WpStartDate);
                    break;
                default:
                    order = o => o.OrderByDescending(x => x.WpStartDate);
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

            return new JsonResult(new ScrollDataViewModel<ConfinedSpaceWorkPermit>(Scroll, QueryData.ToList()), this.DefaultJsonSettings);
        }
        // POST: api/ConfinedSpaceWorkPermit
        [HttpPost]
        public override async Task<IActionResult> Create([FromBody] ConfinedSpaceWorkPermit record)
        {
            // Set date for CrateDate Entity
            if (record == null)
                return BadRequest();

            // +7 Hour
            if (record.GetType().GetProperty("CreateDate") != null)
                record.GetType().GetProperty("CreateDate").SetValue(record, DateTime.Now);
         
            record = this.helper.AddHourMethod(record);

            var GroupMis = await this.repositoryEmployee.GetFirstOrDefaultAsync(x => x.GroupMis, x => x.EmpCode == record.RequireByEmpCode);
            var ApprovedBy = await this.repositoryApproved.GetFirstOrDefaultAsync(x => x.ApprovedFlowMaster, x => x.GroupMis == GroupMis);
            if (ApprovedBy != null)
                record.ApprovedByEmpName = "คุณ" + ApprovedBy.ApprovedByNameThai;

            if (!string.IsNullOrEmpty(record.WpStartTimeString) && record.WpStartDate != null)
            {
                if (DateTime.TryParseExact(record.WpStartTimeString, "HH:mm", CultureInfo.InvariantCulture,
                                              DateTimeStyles.None, out DateTime dt))
                    record.WpStartDate = new DateTime(record.WpStartDate.Value.Year, record.WpStartDate.Value.Month, record.WpStartDate.Value.Day,
                                                    dt.Hour, dt.Minute, 0);
            }

            if (!string.IsNullOrEmpty(record.WpEndTimeString) && record.WpEndDate != null)
            {
                if (DateTime.TryParseExact(record.WpEndTimeString, "HH:mm", CultureInfo.InvariantCulture,
                                             DateTimeStyles.None, out DateTime dt))
                    record.WpEndDate = new DateTime(record.WpEndDate.Value.Year, record.WpEndDate.Value.Month, record.WpEndDate.Value.Day,
                                                    dt.Hour, dt.Minute, 0);
            }

            if (!string.IsNullOrEmpty(record.ComplateTimeString) && record.ComplateDate != null)
            {
                if (DateTime.TryParseExact(record.ComplateTimeString, "HH:mm", CultureInfo.InvariantCulture,
                                             DateTimeStyles.None, out DateTime dt))
                    record.ComplateDate = new DateTime(record.ComplateDate.Value.Year, record.ComplateDate.Value.Month, record.ComplateDate.Value.Day,
                                                    dt.Hour, dt.Minute, 0);
            }

            #region Date for list
            // ConfinedHasCheckLists
            if (record.ConfinedHasCheckLists != null && record.ConfinedHasCheckLists.Any())
            {
                foreach (var item in record.ConfinedHasCheckLists)
                {
                    item.CreateDate = DateTime.Now;
                    item.Creator = record.Creator;
                }
            }
            // ConfinedHasEmpHelps
            if (record.ConfinedHasEmpHelps != null && record.ConfinedHasEmpHelps.Any())
            {
                foreach (var item in record.ConfinedHasEmpHelps)
                {
                    item.CreateDate = DateTime.Now;
                    item.Creator = record.Creator;
                }
            }
            // ConfinedHasEmpWorks
            if (record.ConfinedHasEmpWorks != null && record.ConfinedHasEmpWorks.Any())
            {
                foreach (var item in record.ConfinedHasEmpWorks)
                {
                    item.CreateDate = DateTime.Now;
                    item.Creator = record.Creator;
                }
            }
            // ConfinedHasEquips
            if (record.ConfinedHasEquips != null && record.ConfinedHasEquips.Any())
            {
                foreach (var item in record.ConfinedHasEquips)
                {
                    item.CreateDate = DateTime.Now;
                    item.Creator = record.Creator;
                }
            }
            // ConfinedHasPrecaution
            if (record.ConfinedHasPrecautions != null && record.ConfinedHasPrecautions.Any())
            {
                foreach (var item in record.ConfinedHasPrecautions)
                {
                    item.CreateDate = DateTime.Now;
                    item.Creator = record.Creator;
                }
            }
            #endregion

            if (await this.repository.AddAsync(record) == null)
                return BadRequest();
            return new JsonResult(record, this.DefaultJsonSettings);
        }
        // PUT: api/ConfinedSpaceWorkPermit
        [HttpPut]
        public override async Task<IActionResult> Update(int key, [FromBody] ConfinedSpaceWorkPermit record)
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

            if (!string.IsNullOrEmpty(record.WpStartTimeString) && record.WpStartDate != null)
            {
                if (!DateTime.TryParseExact(record.WpStartTimeString, "HH:mm", CultureInfo.InvariantCulture,
                                              DateTimeStyles.None, out DateTime dt))
                    record.WpStartDate = new DateTime(record.WpStartDate.Value.Year, record.WpStartDate.Value.Month, record.WpStartDate.Value.Day,
                                                    dt.Hour, dt.Minute, 0);
            }

            if (!string.IsNullOrEmpty(record.WpEndTimeString) && record.WpEndDate != null)
            {
                if (!DateTime.TryParseExact(record.WpEndTimeString, "HH:mm", CultureInfo.InvariantCulture,
                                             DateTimeStyles.None, out DateTime dt))
                    record.WpEndDate = new DateTime(record.WpEndDate.Value.Year, record.WpEndDate.Value.Month, record.WpEndDate.Value.Day,
                                                    dt.Hour, dt.Minute, 0);
            }

            if (!string.IsNullOrEmpty(record.ComplateTimeString) && record.ComplateDate != null)
            {
                if (DateTime.TryParseExact(record.ComplateTimeString, "HH:mm", CultureInfo.InvariantCulture,
                                             DateTimeStyles.None, out DateTime dt))
                    record.ComplateDate = new DateTime(record.ComplateDate.Value.Year, record.ComplateDate.Value.Month, record.ComplateDate.Value.Day,
                                                    dt.Hour, dt.Minute, 0);
            }

            #region Date for list

            // ConfinedHasCheckLists
            if (record.ConfinedHasCheckLists != null && record.ConfinedHasCheckLists.Any())
            {
                foreach (var item in record.ConfinedHasCheckLists)
                {
                    if (item.ConfinedHasCheckListId > 0)
                    {
                        item.CreateDate = DateTime.Now;
                        item.Creator = record.Modifyer;
                    }
                    else
                    {
                        item.ModifyDate = DateTime.Now;
                        item.Modifyer = record.Modifyer;
                    }
                }
            }
            // ConfinedHasEmpHelps
            if (record.ConfinedHasEmpHelps != null && record.ConfinedHasEmpHelps.Any())
            {
                foreach (var item in record.ConfinedHasEmpHelps)
                {
                    if (item.ConfinedHasEmpHelpId > 0)
                    {
                        item.CreateDate = DateTime.Now;
                        item.Creator = record.Modifyer;
                    }
                    else
                    {
                        item.ModifyDate = DateTime.Now;
                        item.Modifyer = record.Modifyer;
                    }
                }
            }
            // ConfinedHasEmpWorks
            if (record.ConfinedHasEmpWorks != null && record.ConfinedHasEmpWorks.Any())
            {
                foreach (var item in record.ConfinedHasEmpWorks)
                {
                    if (item.ConfinedHasEmpWorkId > 0)
                    {
                        item.CreateDate = DateTime.Now;
                        item.Creator = record.Modifyer;
                    }
                    else
                    {
                        item.ModifyDate = DateTime.Now;
                        item.Modifyer = record.Modifyer;
                    }
                }
            }
            // ConfinedHasEquips
            if (record.ConfinedHasEquips != null && record.ConfinedHasEquips.Any())
            {
                foreach (var item in record.ConfinedHasEquips)
                {
                    if (item.ConfinedHasEquipId > 0)
                    {
                        item.CreateDate = DateTime.Now;
                        item.Creator = record.Modifyer;
                    }
                    else
                    {
                        item.ModifyDate = DateTime.Now;
                        item.Modifyer = record.Modifyer;
                    }
                }
            }
            // ConfinedHasPrecautions
            if (record.ConfinedHasPrecautions != null && record.ConfinedHasPrecautions.Any())
            {
                foreach (var item in record.ConfinedHasPrecautions)
                {
                    if (item.ConfinedHasPreId > 0)
                    {
                        item.CreateDate = DateTime.Now;
                        item.Creator = record.Modifyer;
                    }
                    else
                    {
                        item.ModifyDate = DateTime.Now;
                        item.Modifyer = record.Modifyer;
                    }
                }
            }

            #endregion

            if (await this.repository.UpdateAsync(record, key) == null)
                return BadRequest();

            if (record != null)
            {

                #region UpdateEmpHelp
                // filter
                var dbEmpHelps = await this.repositoryConHasEmpHelp.GetToListAsync(x => x, x => x.ConfinedSpacePermitId == key);
                //Remove ConfinedHasEmpHelps if edit remove it
                foreach (var dbEmpHelp in dbEmpHelps)
                {
                    if (!record.ConfinedHasEmpHelps.Any(x => x.ConfinedHasEmpHelpId == dbEmpHelp.ConfinedHasEmpHelpId))
                        await this.repositoryConHasEmpHelp.DeleteAsync(dbEmpHelp.ConfinedHasEmpHelpId);
                }
                //Update ConfinedHasEmpHelps or New ConfinedHasEmpHelps
                foreach (var uConHasEmpHelp in record.ConfinedHasEmpHelps)
                {
                    if (uConHasEmpHelp.ConfinedHasEmpHelpId > 0)
                        await this.repositoryConHasEmpHelp.UpdateAsync(uConHasEmpHelp, uConHasEmpHelp.ConfinedHasEmpHelpId);
                    else
                    {
                        uConHasEmpHelp.ConfinedSpacePermitId = record.ConfinedSpaceWorkPermitId;
                        await this.repositoryConHasEmpHelp.AddAsync(uConHasEmpHelp);
                    }
                }
                #endregion

                #region UpdateEmpWork
                // filter
                var dbEmpWorks = await this.repositoryConHasEmpWork.GetToListAsync(x => x, x => x.ConfinedSpacePermitId == key);
                //Remove ConfinedHasEmpHelps if edit remove it
                foreach (var dbEmpWork in dbEmpWorks)
                {
                    if (!record.ConfinedHasEmpWorks.Any(x => x.ConfinedHasEmpWorkId == dbEmpWork.ConfinedHasEmpWorkId))
                        await this.repositoryConHasEmpWork.DeleteAsync(dbEmpWork.ConfinedHasEmpWorkId);
                }
                //Update ConfinedHasEmpHelps or New ConfinedHasEmpHelps
                foreach (var uConHasEmpWork in record.ConfinedHasEmpWorks)
                {
                    if (uConHasEmpWork.ConfinedHasEmpWorkId > 0)
                        await this.repositoryConHasEmpWork.UpdateAsync(uConHasEmpWork, uConHasEmpWork.ConfinedHasEmpWorkId);
                    else
                    {
                        uConHasEmpWork.ConfinedSpacePermitId = record.ConfinedSpaceWorkPermitId;
                        await this.repositoryConHasEmpWork.AddAsync(uConHasEmpWork);
                    }
                }
                #endregion

                #region UpdateCheckList
                // filter
                var dbCheckLists = await this.repositoryHasCheck.GetToListAsync(x => x, x => x.ConfinedSpacePermitId == key);
                //Remove ConfinedHasEmpHelps if edit remove it
                foreach (var dbCheckList in dbCheckLists)
                {
                    if (!record.ConfinedHasCheckLists.Any(x => x.ConfinedHasCheckListId == dbCheckList.ConfinedHasCheckListId))
                        await this.repositoryHasCheck.DeleteAsync(dbCheckList.ConfinedHasCheckListId);
                }
                //Update ConfinedHasEmpHelps or New ConfinedHasEmpHelps
                foreach (var uConHasCheck in record.ConfinedHasCheckLists)
                {
                    if (uConHasCheck.ConfinedHasCheckListId > 0)
                        await this.repositoryHasCheck.UpdateAsync(uConHasCheck, uConHasCheck.ConfinedHasCheckListId);
                    else
                    {
                        uConHasCheck.ConfinedSpacePermitId = record.ConfinedSpaceWorkPermitId;
                        await this.repositoryHasCheck.AddAsync(uConHasCheck);
                    }
                }
                #endregion

                #region UpdateEquipment
                // filter
                var dbEquipments = await this.repositoryHasEquip.GetToListAsync(x => x, x => x.ConfinedSpacePermitId == key);
                //Remove ConfinedHasEmpHelps if edit remove it
                foreach (var dbEquipment in dbEquipments)
                {
                    if (!record.ConfinedHasEquips.Any(x => x.ConfinedHasEquipId == dbEquipment.ConfinedHasEquipId))
                        await this.repositoryHasEquip.DeleteAsync(dbEquipment.ConfinedHasEquipId);
                }
                //Update ConfinedHasEmpHelps or New ConfinedHasEmpHelps
                foreach (var uConHasCheck in record.ConfinedHasEquips)
                {
                    if (uConHasCheck.ConfinedHasEquipId > 0)
                        await this.repositoryHasEquip.UpdateAsync(uConHasCheck, uConHasCheck.ConfinedHasEquipId);
                    else
                    {
                        uConHasCheck.ConfinedSpacePermitId = record.ConfinedSpaceWorkPermitId;
                        await this.repositoryHasEquip.AddAsync(uConHasCheck);
                    }
                }
                #endregion

                #region UpdatePrecautions
                // filter
                var dbPrecautions = await this.repositoryHasPercaution.GetToListAsync(x => x, x => x.ConfinedSpaceWorkPermitId == key);
                //Remove ConfinedHasEmpHelps if edit remove it
                foreach (var dbPrecaution in dbPrecautions)
                {
                    if (!record.ConfinedHasPrecautions.Any(x => x.ConfinedHasPreId == dbPrecaution.ConfinedHasPreId))
                        await this.repositoryHasPercaution.DeleteAsync(dbPrecaution.ConfinedHasPreId);
                }
                //Update ConfinedHasEmpHelps or New ConfinedHasEmpHelps
                foreach (var uConHasPer in record.ConfinedHasPrecautions)
                {
                    if (uConHasPer.ConfinedHasPreId > 0)
                        await this.repositoryHasPercaution.UpdateAsync(uConHasPer, uConHasPer.ConfinedHasPreId);
                    else
                    {
                        uConHasPer.ConfinedSpaceWorkPermitId = record.ConfinedSpaceWorkPermitId;
                        await this.repositoryHasPercaution.AddAsync(uConHasPer);
                    }
                }
                #endregion

            }
            return new JsonResult(record, this.DefaultJsonSettings);
        }
        // GET: api/ConfinedSpaceWorkPermit/GetReport
        [HttpGet("GetReport")]
        public async Task<IActionResult> GetReport(int key)
        {
            var Message = "Not been found data.";
            try
            {

                var memory = await this.CreateReport(key);
                // "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Reports.xlsx"
                // "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "Reports.docx"
                // stream.Position = 0;
                // return File(byteArray, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Reports.xlsx");

                return File(memory, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "lifting.xlsx");
            }
            catch (Exception ex)
            {
                Message = $"Has error {ex.ToString()}";
            }

            return BadRequest(new { Error = Message });
        }
        // DELETE: api/ConfinedSpaceWorkPermit
        [HttpDelete]
        public override async Task<IActionResult> Delete(int key)
        {
            if (key > 0)
            {
                var HasData = await this.repository.GetFirstOrDefaultAsync(x => x, x => x.ConfinedSpaceWorkPermitId == key);
                if (HasData != null)
                {
                    if (HasData.StatusWorkPermit == StatusWorkPermit.Require)
                    {
                        HasData.StatusWorkPermit = StatusWorkPermit.Cancelled;
                        HasData.Modifyer = HasData.Creator;
                        HasData.ModifyDate = DateTime.Now;

                        await this.repository.UpdateAsync(HasData, key);
                        return new JsonResult(new { Complate = true }, this.DefaultJsonSettings);
                    }
                }
            }
            return NoContent();
        }
    }
}
