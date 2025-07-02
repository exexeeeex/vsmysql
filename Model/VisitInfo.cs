using InterfaceDB.Entities;

namespace InterfaceDB.Model
{
    public class VisitInfo : BaseEntity
    {
        public string FullNameOwner { get; set; } = null!;
        public string DateTimeVisit { get; set; } = null!;
    }
}
