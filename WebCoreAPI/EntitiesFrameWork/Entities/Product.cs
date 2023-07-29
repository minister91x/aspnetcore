using System.ComponentModel.DataAnnotations;

namespace WebCoreAPI.EntitiesFrameWork.Entities
{
    public class Product
    {
        [Key]
        public string? MaSP { get; set; }
        public string? TenSP { get; set; }
        public string? DonViTinh { get; set; }
        public int DonGia { get; set; }

    }
}
