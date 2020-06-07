using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Student_info.Models
{
    public class Item
    {
       
        [Key]
        public int Id { get; set; }

        [Required]
        public string FName { get; set; }

        [Required]
        public string LName { get; set; }

        [Required]
        public string Index { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string TelNumber { get; set; }

        [Required]
        public string ImgUrl { get; set; }

    }
}
