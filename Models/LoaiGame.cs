using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCRUD2.Models
{
    public class LoaiGame
    {
        [Key]
        public int ID { get; set; }
        public string Tenloaigame { get; set; }
        public string? Anhloaigame { get; set; }
        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }
    }
}
