using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmmasBlogg.Models
{
    public class DbInitializer
    {
        public static void Initialize(InläggsContext context)
        {
            context.Database.EnsureCreated();

            if (context.Poster.Any())
            {
                return;
            }

            //var kategori = new List<Kategori>()
            //{
            //     new Kategori
            //     {
            //         KategoriID = 1,
            //         Namn = "Mat"
            //     },
            //     new Kategori
            //     {
            //         KategoriID = 2,
            //         Namn = "Mode"
            //     },
            //     new Kategori
            //     {
            //         KategoriID = 3,
            //         Namn = "Övrigt"
            //     }
            //};

            //kategori.ForEach(x => context.Kategorier.Add(x));
            //context.SaveChanges();

            //var användare = new List<Användare>()
            //{
            //    new Användare
            //    {
            //        AnvändarID = 1,
            //        Namn = "Emma Karlsson",
            //        Epostadress = "Emma_Karlsson_93@hotmail.com"
            //    }
            //};

            //användare.ForEach(x => context.Användaren.Add(x));
            //context.SaveChanges();

            //var inlägg = new List<Inlägg>()
            //{
            //    new Inlägg()
            //    {
            //        InläggsID = 1,
            //        Titel = "Hej",
            //        Text = "Text till databasen....",
            //        Datum = Convert.ToDateTime("2017/12/25"),
            //        Användare = användare.FirstOrDefault(x => x.AnvändarID == 1),
            //        Kategori = kategori.FirstOrDefault(x => x.KategoriID == 3 )
            //    }
            //};

            //inlägg.ForEach(x => context.Poster.Add(x));
        }  
    }
}
