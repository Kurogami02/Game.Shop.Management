using System.ComponentModel.DataAnnotations;
namespace NetCRUD2.Models
{
    public class Account
    {
        [Key] 
        public int ID { get; set; }
        
        [Required(ErrorMessage ="Ban phai nhap vao User name")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Ban phai nhap vao Password")]
        public string? Password { get; set; }
		public string? Hoten { get; set; }
		public int? Quyen { get; set; }
	}
}
