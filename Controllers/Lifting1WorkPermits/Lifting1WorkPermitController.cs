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
using VipcoSafety.Models.Machines;
using VipcoSafety.Models.LiftingWorkPermits;
using VipcoSafety.Models.SafetyData;
using VipcoSafety.Helpers;
using VipcoSafety.Services;
using VipcoSafety.ViewModels;
using VipcoSafety.Helper;
using System.Globalization;

using ClosedXML.Excel;
using Microsoft.AspNetCore.Hosting;
using System.Reflection;
using System.IO;

namespace VipcoSafety.Controllers.Lifting1WorkPermits
{
    [Route("api/[controller]")]
    [ApiController]
    public class Lifting1WorkPermitController : GenericSafetyController<Lifting1WorkPermit>
    {
        private readonly IRepositorySafety<LiftingHasEquip> repositoryHasEquip;
        private readonly IRepositorySafety<LiftingHasCheckList> repositoryHasCheck;
        private readonly IRepositorySafety<LiftingHasPercaution> repositoryHasPercaution;
        private readonly IRepositorySafety<GroupPermitHasCheckList> repositoryGroupHasCheck;
        private readonly IRepositorySafety<GroupPermitHasEquipment> repositoryGroupEquip;
        private readonly IRepositorySafety<ApprovedFlowDetail> repositoryApproved;
        private readonly IRepositoryMachine<Employee> repositoryEmployee;
        private readonly IRepositorySafety<SafetyRepayMail> repositorySafetyMail;
        // IHostingEnvironment
        private readonly IHostingEnvironment hosting;
        //Email
        private readonly EmailClass EmailClass;// Private 
        public Lifting1WorkPermitController(IRepositorySafety<Lifting1WorkPermit> repo,
            IRepositorySafety<LiftingHasEquip> repoHasEquip,
            IRepositorySafety<LiftingHasCheckList> repoHasCheck,
            IRepositorySafety<LiftingHasPercaution> repoHasPercaution,
            IRepositorySafety<GroupPermitHasCheckList> repoGroupHasCheck,
            IRepositorySafety<GroupPermitHasEquipment> repoGroupEquip,
            IRepositorySafety<ApprovedFlowDetail> repoApproved,
            IRepositorySafety<SafetyRepayMail> repoSafetyMail,
            IRepositoryMachine<Employee> repoEmployee,
            IHostingEnvironment hosting,
            IMapper mapper):base(repo,mapper)
        {
            this.repositoryHasCheck = repoHasCheck;
            this.repositoryHasEquip = repoHasEquip;
            this.repositoryHasPercaution = repoHasPercaution;
            this.repositoryGroupHasCheck = repoGroupHasCheck;
            this.repositoryGroupEquip = repoGroupEquip;
            this.repositoryApproved = repoApproved;
            this.repositoryEmployee = repoEmployee;
            this.repositorySafetyMail = repoSafetyMail;
            //Helper
            this.EmailClass = new EmailClass();
            //Host
            this.hosting = hosting;
        }

        #region PrivateMethod
        private async Task<MemoryStream> CreateReport(int key)
        {
            var Message = "Not been found data.";
            try
            {
                if (key > 0)
                {
                    var HasData = await this.repository.GetFirstOrDefaultAsync(
                        select => select,
                        x => x.Lifting1WorkPermitId == key,
                        null, x => x.Include(z => z.LiftingHasCheckLists)
                                    .Include(z => z.LiftingHasEquips)
                                    .Include(z => z.LiftingHasPercautions));

                    if (HasData != null)
                    {
                        var templateFolder = this.hosting.WebRootPath + "/reports/";
                        var fileExcel = templateFolder + $"LiftingWorkPermit.xlsx";
                        var SaveAsExcel = templateFolder + $"LiftingWorkPermitModified.xlsx";
                        using (var workbook = new XLWorkbook(fileExcel))
                        {
                            var ws = workbook.Worksheet(1);

                            // SET VALUE TO EXCEL
                            if (HasData.OverTenTon.HasValue && HasData.OverTenTon.Value)
                                ws.Cell(7, "G").Value = "P";
                            if (HasData.LengthOverTwelveMeter != null && HasData.LengthOverTwelveMeter.Value)
                                ws.Cell(7, "O").Value = "P";
                            if (HasData.WidthOverThreeMeter != null && HasData.WidthOverThreeMeter.Value)
                                ws.Cell(9, "G").Value = "P";
                            if (HasData.TwoCraneLift != null && HasData.TwoCraneLift.Value)
                                ws.Cell(9, "O").Value = "P";

                            //SET DATE

                            ws.Cell(11, "E").Value = HasData.LiftDate.HasValue ? HasData.LiftDate.Value.ToString("dd") : "";
                            ws.Cell(11, "E").DataType = XLDataType.Text;

                            ws.Cell(11, "G").Value = HasData.LiftDate.HasValue ? HasData.LiftDate.Value.ToString("MMMM") : "";
                            ws.Cell(11, "G").DataType = XLDataType.Text;

                            ws.Cell(11, "J").Value = HasData.LiftDate.HasValue ? (HasData.LiftDate.Value.Year < 2550 ?
                                (HasData.LiftDate.Value.Year + 543).ToString() :
                                HasData.LiftDate.Value.Year.ToString()) : "";
                            ws.Cell(11, "J").DataType = XLDataType.Text;

                            ws.Cell(11, "M").Value = !string.IsNullOrEmpty(HasData.LiftDateTimeString) ? $"'{HasData.LiftDateTimeString}" : "";
                            ws.Cell(11, "M").DataType = XLDataType.Text;


                            ws.Cell(11, "Q").Value = HasData.LiftFinishDate.HasValue ? HasData.LiftFinishDate.Value.ToString("dd") : "";
                            ws.Cell(11, "Q").DataType = XLDataType.Text;

                            ws.Cell(11, "S").Value = HasData.LiftFinishDate.HasValue ? HasData.LiftFinishDate.Value.ToString("MMMM") : "";
                            ws.Cell(11, "S").DataType = XLDataType.Text;

                            ws.Cell(11, "V").Value = HasData.LiftFinishDate.HasValue ? (HasData.LiftFinishDate.Value.Year < 2550 ?
                                (HasData.LiftFinishDate.Value.Year + 543).ToString() :
                                HasData.LiftFinishDate.Value.Year.ToString()) : "";
                            ws.Cell(11, "V").DataType = XLDataType.Text;

                            ws.Cell(11, "Y").Value = !string.IsNullOrEmpty(HasData.LiftFinishDateTimeString) ? $"'{HasData.LiftFinishDateTimeString}" : "";
                            ws.Cell(11, "Y").DataType = XLDataType.Text;
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

                            foreach (var item in HasData.LiftingHasCheckLists)
                            {
                                if (item.HasCheck.HasValue && item.HasCheck.Value)
                                {
                                    var checkList = await this.repositoryGroupHasCheck.GetFirstOrDefaultAsync(x => x, x => x.CheckListId == item.CheckListId);
                                    if (checkList != null)
                                    {
                                        var row = checkList.SequenceNo ?? 1;
                                        ws.Cell(31 + row, "J").Value = "P";
                                    }
                                }
                            }

                            foreach (var item in HasData.LiftingHasEquips)
                            {
                                if (item.HasCheck.HasValue && item.HasCheck.Value)
                                {
                                    var equipment = await this.repositoryGroupEquip.GetFirstOrDefaultAsync(x => x, x => x.SafetyEquipmentId == item.SafetyEquipmentId);
                                    if (equipment != null)
                                    {
                                        var col = (equipment.SequenceNo ?? 1) * 2;
                                        ws.Cell(37, 14 + col).Value = "P";
                                    }
                                }
                            }

                            var index = 1;
                            foreach (var item in HasData.LiftingHasPercautions)
                            {
                                if (!string.IsNullOrEmpty(item.Risk))
                                {
                                    // Risk
                                    ws.Cell(47 + (index), "A").Value = item.Risk;
                                    ws.Cell(47 + (index), "A").DataType = XLDataType.Text;
                                    // Measure
                                    ws.Cell(47 + (index), "I").Value = item.Measure;
                                    ws.Cell(47 + (index), "I").DataType = XLDataType.Text;
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

                        // "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Reports.xlsx"
                        // "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "Reports.docx"
                        // stream.Position = 0;
                        // return File(byteArray, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Reports.xlsx");

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
        private async Task<bool> SendMail(Lifting1WorkPermit HasData, int Option = 1)
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
                        foreach(var item in SafetyMails)
                        {
                            listMail.Add(new ViewModels.SendMail()
                            {
                                MailAddress = item.SafetyMail,
                                Name = item.SafetyName
                            });
                        }

                        if (listMail.Any())
                        {
                            var Report = await this.CreateReport(HasData.Lifting1WorkPermitId);
                            foreach (var item in listMail)
                            {
                                var BodyMessage = "<body style=font-size:11pt;font-family:Tahoma>" +
                                                  "<h4 style='color:steelblue;'>เมล์ฉบับนี้เป็นแจ้งเตือนจากระบบงาน VIPCO SAFETY SYSTEM</h4>" +
                                                  $"เรียน คุณ{item.Name}" +
                                                  $"<p>เรื่อง คำขออนุมัติ \"Lifting Over 10Ton Workpermit\"</p><hr></hr>" +
                                                  $"<p>โดยทาง \"{HasData.RequireByEmpName}\" ได้ทำการส่งคำขอ Workpermit เพื่อให้ทาง \"คุณ{item.Name}\" </p>" +
                                                  $"<p>เห็นสมควรในการ \"<a href='http://{Request.Host}/safety/api/Lifting1WorkPermit/approved/{HasData.Lifting1WorkPermitId}'>อนุมัติ</a>\"" +
                                                  $"  หรือ  \"<a style='color:red;' href='http://{Request.Host}/safety/api/Lifting1WorkPermit/reject/{HasData.Lifting1WorkPermitId}'>ยกเลิก</a>\" คำขอนี้ พร้อมทั้งนี้ยังได้แนบเอกสารคำขอ Workpermit มากับอีเมล์ฉบับนี้</p>" +
                                                  $"<p>\"คุณ{item.Name}\" " +
                                                  $"สามารถเข้าไปตรวจติดตามข้อมูลได้ <a href='http://{Request.Host}/safety/lifting/{HasData.Lifting1WorkPermitId}'>ที่นี้</a> </p>" +
                                                  "<span style='color:steelblue;'>This mail auto generated by VIPCO MACHINE SYSTEM. Do not reply this email.</span>" +
                                                  "</body>";

                               await this.EmailClass.SendMailMessage(ListMail[0], item.Name,
                                                    new List<string>() { item.MailAddress },
                                                    BodyMessage, "Notification mail from VIPCO Safety system.", Report, "LiftingWorkPermit.xlsx");
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
                                              $"<p>เรื่อง คำขออนุมัติ \"Lifting Over 10Ton Workpermit\"จากทาง \"{HasData.RequireByEmpName}\"</p><hr></hr>" +
                                              $"<p>ณ ขณะนี้คำขอดังกล่าวได้รับการ \" {(isApproved ? "<span style='color:blue;'>อนุมัติตามคำขอ</span>" : "<span style='color:red;'>ยกเลิกคำขอ</span>")}\"</p>" +
                                              $"<p>จึงแจ้งมาเพื่อทราบ</p>" +
                                              $"สามารถเข้าไปตรวจติดตามข้อมูลได้ <a href='http://{Request.Host}/safety/lifting/{HasData.Lifting1WorkPermitId}'>ที่นี้</a> </p>" +
                                              "<span style='color:steelblue;'>This mail auto generated by VIPCO MACHINE SYSTEM. Do not reply this email.</span>" +
                                            "</body>";

                        await this.EmailClass.SendMailMessage(ListMail[0], HasData.RequireByEmpName, listMail.Select(z => z.MailAddress).ToList(),
                                             BodyMessageSf, "Notification mail from VIPCO Safety system.");
                        #endregion

                        var BodyMessage = "<body style=font-size:11pt;font-family:Tahoma>" +
                                            "<h4 style='color:steelblue;'>เมล์ฉบับนี้เป็นแจ้งเตือนจากระบบงาน VIPCO SAFETY SYSTEM</h4>" +
                                            $"เรียน {HasData.RequireByEmpName}" +
                                            $"<p>เรื่อง คำขออนุมัติ \"Lifting Over 10Ton Workpermit\"</p><hr></hr>" +
                                            $"<p>ณ ขณะนี้คำขอดังกล่าวได้รับการ \" {(isApproved ? "<span style='color:blue;'>อนุมัติตามคำขอ</span>" : "<span style='color:red;'>ยกเลิกคำขอ</span>")}\"</p>" +
                                            $"<p>หากมีขอสงสัยใดโปรดติดต่อกับทางหน่วยงานความปลอดภัย</p>" +
                                            $"<p>\"{HasData.RequireByEmpName}\" " +
                                            $"สามารถเข้าไปตรวจติดตามข้อมูลได้ <a href='http://{Request.Host}/safety/lifting/{HasData.Lifting1WorkPermitId}'>ที่นี้</a> </p>" +
                                            "<span style='color:steelblue;'>This mail auto generated by VIPCO MACHINE SYSTEM. Do not reply this email.</span>" +
                                          "</body>";
                        MemoryStream Report = null;

                        if (isApproved)
                            Report = await this.CreateReport(HasData.Lifting1WorkPermitId);

                        await this.EmailClass.SendMailMessage(ListMail[0], HasData.RequireByEmpName, ListMail,
                                             BodyMessage, "Notification mail from VIPCO Safety system.",
                                             isApproved ? Report : null,
                                             isApproved ? "LiftingWorkPermit.xlsx" : "");
                    }
                }
            }

            return false;
        }
        private async Task<Tuple<bool,Lifting1WorkPermit>> UpdateStatus(int key, StatusWorkPermit statusWork)
        {
            var HasData = await this.repository.GetFirstOrDefaultAsync(x => x, x => x.Lifting1WorkPermitId == key);
            if (HasData != null && HasData.StatusWorkPermit == StatusWorkPermit.Require)
            {
                if (statusWork == StatusWorkPermit.Approved)
                    HasData.ApprovedDate = DateTime.Now;

                HasData.StatusWorkPermit = statusWork;
                HasData.ModifyDate = DateTime.Now;
                HasData.Modifyer = "FromMail";

                await this.repository.UpdateAsync(HasData, key);
                return new Tuple<bool, Lifting1WorkPermit>(true, HasData);
            }
            return new Tuple<bool, Lifting1WorkPermit>(false, null);
        }
        #endregion

        // GET: api/Lifting1WorkPermit/approved/5
        [HttpGet("approved/{key}")]
        public async Task<IActionResult> ApprovedWorkPermit(int key)
        {
            var Result = await this.UpdateStatus(key, StatusWorkPermit.Approved);
            if (Result.Item1)
                await this.SendMail(Result.Item2, 2);
            return new JsonResult(new { Status = (Result.Item1 ? "Workpermit ได้รับการอนุมัติ" : "Workpermit นี้ได้ดำเนินการไปแล้ว") }, this.DefaultJsonSettings);
        }
        // GET: api/Lifting1WorkPermit/reject/5
        [HttpGet("reject/{key}")]
        public async Task<IActionResult> RejectWorkPermit(int key)
        {
            var Result = await this.UpdateStatus(key, StatusWorkPermit.Cancelled);
            if (Result.Item1)
                await this.SendMail(Result.Item2, 2);
            return new JsonResult(new { Status = (Result.Item1 ? "Workpermit ได้รับการยกเลิก" : "Workpermit นี้ได้ดำเนินการไปแล้ว") }, this.DefaultJsonSettings);
        }
        // GET: api/Lifting1WorkPermit/ResendMail/5
        [HttpGet("ResendMail")]
        public async Task<IActionResult> ResendMail(int key)
        {
            if (key > 0)
            {
                var HasData = await this.repository.GetFirstOrDefaultAsync(x => x, x => x.Lifting1WorkPermitId == key);
                if (await this.SendMail(HasData))
                {
                    HasData.IsSendMail = true;
                    await this.repository.UpdateAsync(HasData, key);
                }
                return NoContent();
            }
            return BadRequest();
        }
        // GET: api/Lifting1WorkPermit/GetKeyNumber/5
        [HttpGet("GetKeyNumber")]
        public override async Task<IActionResult> Get(int key)
        {
            var HasData = await this.repository.GetFirstOrDefaultAsync(x => x, x => x.Lifting1WorkPermitId == key);
            var MapData = this.mapper.Map<Lifting1WorkPermit, Lifting1WorkPermitViewModel>(HasData);
            return new JsonResult(MapData, this.DefaultJsonSettings);
        }
        // POST: api/Lifting1WorkPermit/GetScroll
        [HttpPost("GetScroll")]
        public async Task<IActionResult> GetScroll([FromBody] ScrollViewModel Scroll)
        {
            if (Scroll == null)
                return BadRequest();
            // Filter
            var filters = string.IsNullOrEmpty(Scroll.Filter) ? new string[] { "" }
                                : Scroll.Filter.Split(null);

            var predicate = PredicateBuilder.False<Lifting1WorkPermit>();

            foreach (string temp in filters)
            {
                string keyword = temp;
                predicate = predicate.Or(x => x.RequireByEmpName.ToLower().Contains(keyword) ||
                                              x.WorkGroup.ToLower().Contains(keyword) ||
                                              x.Location.ToLower().Contains(keyword));
            }
            if (!string.IsNullOrEmpty(Scroll.Where))
                predicate = predicate.And(p => p.Creator == Scroll.Where);
            //Order by
            Func<IQueryable<Lifting1WorkPermit>, IOrderedQueryable<Lifting1WorkPermit>> order;
            // Order
            switch (Scroll.SortField)
            {
                case "RequireBy":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.RequireByEmpName);
                    else
                        order = o => o.OrderBy(x => x.RequireByEmpName);
                    break;
                case "WorkGroup":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.WorkGroup);
                    else
                        order = o => o.OrderBy(x => x.WorkGroup);
                    break;
                case "Location":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.Location);
                    else
                        order = o => o.OrderBy(x => x.Location);
                    break;
                case "WorkingDate":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.LiftDate);
                    else
                        order = o => o.OrderBy(x => x.LiftDate);
                    break;
                default:
                    order = o => o.OrderByDescending(x => x.LiftDate);
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

            return new JsonResult(new ScrollDataViewModel<Lifting1WorkPermit>(Scroll, QueryData.ToList()), this.DefaultJsonSettings);
        }
        // POST: api/Lifting1WorkPermit/
        [HttpPost]
        public override async Task<IActionResult> Create([FromBody] Lifting1WorkPermit record)
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

            if (!string.IsNullOrEmpty(record.LiftDateTimeString) && record.LiftDate != null)
            {
                if (DateTime.TryParseExact(record.LiftDateTimeString, "HH:mm", CultureInfo.InvariantCulture,
                                              DateTimeStyles.None, out DateTime dt))
                    record.LiftDate = new DateTime(record.LiftDate.Value.Year, record.LiftDate.Value.Month, record.LiftDate.Value.Day,
                                                    dt.Hour, dt.Minute, 0);
            }

            if (!string.IsNullOrEmpty(record.ComplateTimeString) && record.ComplateDate != null)
            {
                if (DateTime.TryParseExact(record.ComplateTimeString, "HH:mm", CultureInfo.InvariantCulture,
                                             DateTimeStyles.None, out DateTime dt))
                    record.ComplateDate = new DateTime(record.ComplateDate.Value.Year, record.ComplateDate.Value.Month, record.ComplateDate.Value.Day,
                                                    dt.Hour, dt.Minute, 0);
            }

            #region Data for list
            // ConfinedHasCheckLists
            if (record.LiftingHasCheckLists != null && record.LiftingHasCheckLists.Any())
            {
                foreach (var item in record.LiftingHasCheckLists)
                {
                    item.CreateDate = DateTime.Now;
                    item.Creator = record.Creator;
                }
            }
            // ConfinedHasEquips
            if (record.LiftingHasEquips != null && record.LiftingHasEquips.Any())
            {
                foreach (var item in record.LiftingHasEquips)
                {
                    item.CreateDate = DateTime.Now;
                    item.Creator = record.Creator;
                }
            }
            // ConfinedHasPercaution
            if (record.LiftingHasPercautions != null && record.LiftingHasPercautions.Any())
            {
                foreach (var item in record.LiftingHasPercautions)
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
        // PUT: api/Lifting1WorkPermit/
        [HttpPut]
        public override async Task<IActionResult> Update(int key, [FromBody] Lifting1WorkPermit record)
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

            if (!string.IsNullOrEmpty(record.LiftDateTimeString) && record.LiftDate != null)
            {
                if (!DateTime.TryParseExact(record.LiftDateTimeString, "HH:mm", CultureInfo.InvariantCulture,
                                              DateTimeStyles.None, out DateTime dt))
                    record.LiftDate = new DateTime(record.LiftDate.Value.Year, record.LiftDate.Value.Month, record.LiftDate.Value.Day,
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
            // LiftingHasCheckLists
            if (record.LiftingHasCheckLists != null && record.LiftingHasCheckLists.Any())
            {
                foreach (var item in record.LiftingHasCheckLists)
                {
                    if (item.LiftingHasCheckListId > 0)
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

            // LiftingHasEquips
            if (record.LiftingHasEquips != null && record.LiftingHasEquips.Any())
            {
                foreach (var item in record.LiftingHasEquips)
                {
                    if (item.LiftingHasEquipId > 0)
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

            // LiftingHasPercautions
            if (record.LiftingHasPercautions != null && record.LiftingHasPercautions.Any())
            {
                foreach (var item in record.LiftingHasPercautions)
                {
                    if (item.LiftingHasPerId > 0)
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
                #region UpdateCheckList
                // filter
                var dbCheckLists = await this.repositoryHasCheck.GetToListAsync(x => x, x => x.LiftingHasCheckListId == key);
                //Remove LiftingHasCheckLists if edit remove it
                foreach (var dbCheckList in dbCheckLists)
                {
                    if (!record.LiftingHasCheckLists.Any(x => x.LiftingHasCheckListId == dbCheckList.LiftingHasCheckListId))
                        await this.repositoryHasCheck.DeleteAsync(dbCheckList.LiftingHasCheckListId);
                }
                //Update LiftingHasCheckLists or New LiftingHasCheckLists
                foreach (var uLiftingHasCheck in record.LiftingHasCheckLists)
                {
                    if (uLiftingHasCheck.LiftingHasCheckListId > 0)
                        await this.repositoryHasCheck.UpdateAsync(uLiftingHasCheck, uLiftingHasCheck.LiftingHasCheckListId);
                    else
                    {
                        uLiftingHasCheck.Lifting1WorkPermitId = record.Lifting1WorkPermitId;
                        await this.repositoryHasCheck.AddAsync(uLiftingHasCheck);
                    }
                }
                #endregion

                #region UpdateEquipment
                // filter
                var dbEquipments = await this.repositoryHasEquip.GetToListAsync(x => x, x => x.LiftingHasEquipId == key);
                //Remove LiftingHasEquips if edit remove it
                foreach (var dbEquipment in dbEquipments)
                {
                    if (!record.LiftingHasEquips.Any(x => x.LiftingHasEquipId == dbEquipment.LiftingHasEquipId))
                        await this.repositoryHasEquip.DeleteAsync(dbEquipment.LiftingHasEquipId);
                }
                //Update LiftingHasEquips or New LiftingHasEquips
                foreach (var uLiftHasEquip in record.LiftingHasEquips)
                {
                    if (uLiftHasEquip.LiftingHasEquipId > 0)
                        await this.repositoryHasEquip.UpdateAsync(uLiftHasEquip, uLiftHasEquip.LiftingHasEquipId);
                    else
                    {
                        uLiftHasEquip.Lifting1WorkPermitId = record.Lifting1WorkPermitId;
                        await this.repositoryHasEquip.AddAsync(uLiftHasEquip);
                    }
                }
                #endregion

                #region UpdatePercautions
                // filter
                var dbPercautions = await this.repositoryHasPercaution.GetToListAsync(x => x, x => x.LiftingHasPerId == key);
                //Remove LiftingHasPercautions if edit remove it
                foreach (var dbPercaution in dbPercautions)
                {
                    if (!record.LiftingHasPercautions.Any(x => x.LiftingHasPerId == dbPercaution.LiftingHasPerId))
                        await this.repositoryHasPercaution.DeleteAsync(dbPercaution.LiftingHasPerId);
                }
                //Update LiftingHasPercautions or New LiftingHasPercautions
                foreach (var uLiftHasPercaution in record.LiftingHasPercautions)
                {
                    if (uLiftHasPercaution.LiftingHasPerId > 0)
                        await this.repositoryHasPercaution.UpdateAsync(uLiftHasPercaution, uLiftHasPercaution.LiftingHasPerId);
                    else
                    {
                        uLiftHasPercaution.Lifting1WorkPermitId = record.Lifting1WorkPermitId;
                        await this.repositoryHasPercaution.AddAsync(uLiftHasPercaution);
                    }
                }
                #endregion
            }
            return new JsonResult(record, this.DefaultJsonSettings);
        }
        // GET: api/Lifting1WorkPermit/GetReport
        [HttpGet("GetReport")]
        public async Task<IActionResult> GetReport(int key)
        {
            var Message = "Not been found data.";
            try
            {
                if(key > 0)
                {
                    var memory = await this.CreateReport(key);

                    return File(memory, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "lifting.xlsx");
                }
            }
            catch(Exception ex)
            {
                Message = $"Has error {ex.ToString()}";
            }

            return BadRequest(new { Error = Message });
        }
        [HttpDelete()]
        public override async Task<IActionResult> Delete(int key)
        {
            if (key > 0)
            {
                var HasData = await this.repository.GetFirstOrDefaultAsync(x => x, x => x.Lifting1WorkPermitId == key);
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
