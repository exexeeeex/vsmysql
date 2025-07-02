using InterfaceDB.Entities;

namespace InterfaceDB.Model
{
    public class PassInfo : BaseEntity
    {
        public string FullNameOwner { get; set; } = null!;
        public string PassType { get; set; } = null!;
        public string Department { get; set; } = null!;
        public string IsActive { get; set; } = null!;
    }
}
