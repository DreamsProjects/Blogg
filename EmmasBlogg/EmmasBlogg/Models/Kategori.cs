using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace EmmasBlogg.Models
{
    public class Kategori
    {
        [Key]
        public int KategoriID { get; set; }
        public string Namn { get; set; }    
    }
}
