using VipcoSafety.Models.Machines;

namespace VipcoSafety.ViewModels
{
    public class UserViewModel : User
    {
        public string NameThai { get; set; }
        public string GroupName { get; set; }
        public string GroupCode { get; set; }
    }
}