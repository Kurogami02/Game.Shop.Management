using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NetCRUD2.Models
{
    public class SanPham
    {
        [Key]
        public int ID { get; set; }
        public int LoaiGameID { get; set; }
        public string Nhaphathanh { get; set; }
        public string Tensp { get; set; }
        public int Giatien { get; set; }
        public string Mota { get; set; }
        public LoaiGame? LoaiGame  { get; set; }
       

        [DisplayName("Anh bia")]
        public string? Anhbia { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }
    }
}
