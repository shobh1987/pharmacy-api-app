using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace PharmacyApi.Models
{
    public class MedicineModel : BaseAuditModel
    {
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;
        [StringLength(500)]
        public string Notes { get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set; }
        public int Quantity { get; set; }

        public decimal Price { get; set; }

        [StringLength(150)]
        public string Brand { get; set; } = string.Empty;

        public Color? RowColor { get; set; }

        public bool Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new ArgumentException("Medicine name is required.");
            }
            if (Price < 0)
            {
                throw new ArgumentException("Price cannot be negative.");
            }
            if (Quantity < 0)
            {
                throw new ArgumentException("Quantity cannot be negative.");
            }
            return true;
        }
    }
}
