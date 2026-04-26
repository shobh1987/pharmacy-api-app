namespace PharmacyApi.Models
{
    public abstract class BaseModel
    {
        public long Id { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedDate { get; set; }

        public int CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual long SetId()
        {
            return DateTimeOffset.Now.ToUnixTimeMilliseconds() * 1000 + new Random().Next(0, 999);
        }
    }
}
