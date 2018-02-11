using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace EmmasBlogg.Models
{
    public class Inlägg
    {
        [Key]
        public int InläggsID { get; set; }
        [Required(ErrorMessage ="Titeln är obligatorisk")]
        [MaxLength(50, ErrorMessage = "Max 50 tecken på titeln")]
        public string Titel { get; set; }
        [Required(ErrorMessage ="Texten är obligatorisk")]
        [MaxLength(2000, ErrorMessage ="Max 2000 tecken på texten")]
        public string Text { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = false)]
        public DateTime Datum { get; set; }         
        public Kategori Kategori { get; set; }
        public int? KategoriId { set; get; }
    }
}