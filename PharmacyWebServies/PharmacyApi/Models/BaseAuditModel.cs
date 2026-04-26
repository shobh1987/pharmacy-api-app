namespace PharmacyApi.Models
{
    public class BaseAuditModel : BaseModel
    {
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? DeletedBy { get; set; }
    }
}
