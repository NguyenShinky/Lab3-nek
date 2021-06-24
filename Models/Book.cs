namespace lab3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        [Display(Name = "Ma Sach")]
        [Required(ErrorMessage = "Id khong duoc trong")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Ten sach khong duoc trong")]
        [StringLength(100, ErrorMessage = "ten sach khong duoc qua 100 ky tu")]
        [Display(Name = "Ten sach")]
        public string Title { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }


        [Required(ErrorMessage = "Tac gia khong duoc qua 30")]
        [StringLength(30, ErrorMessage = "Tieu de khong duoc qua 30 ky tu")]
        public string Author { get; set; }

        [Required(ErrorMessage = "noi dung khong duoc trong")]
        [StringLength(255)]
        public string Images { get; set; }

        [Required(ErrorMessage = "Gia khong duoc trong")]
        [Range(1000, 1000000, ErrorMessage = "Giá sách từ 1000- 1000000")]
        [Display(Name = "Gia sach")]
        public int Price { get; set; }
    }
}
