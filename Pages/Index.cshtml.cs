using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace basitIslemler.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        //sadece formdan veri alırken
        public string girilen { get; set; } = "ilk girilen";
        //post ve get için ortak değişken
        public string sonuc { get; set; } = "ilk sonuç";

        //adres çubuğuna 2 isteğe bağlı parametre yollanabilir
        public IActionResult OnGet(string parametre1 = null, string parametre2 = null)
        {//ilk açılış veya adresten veri alınırken
            sonuc += "\nOnGet çalıştı\n";

            if (parametre1 != null)
            {
                sonuc += "\n Parametre1 (gogl girilebilir): " + parametre1;

                //gelen bilgi birçok iş için değerlendirilebilir
                for (int i = 5; i < 10; i++)
                {
                    sonuc += "\n" + i.ToString();
                }
            }
            if (parametre2 != null)
            {
                sonuc += "\n Parametre2 (piriv girilebilir): " + parametre2;
            }
            if (parametre1 == "gogl")
            {
                return Redirect("http://www.google.com");
            }
            if (parametre2 == "piriv")
            {
                return RedirectToPage("Privacy");
            }
            if (parametre1 == null && parametre2 == null)
            {
                //hiç parametre girilmemiş ise
                sonuc += "\nHoş Geldiniz";
            }

            //Title yerine başka değer de yapılabilir
            ViewData["Title"] = sonuc;

            return null; //eğer bir yere yönlenmiyor ise
        }

        public IActionResult OnPost()
        {//sadece post yani formdan veri alınırken
            string gelen = Request.Form["girilen"].ToString();
            //böylece gönderilen form bilgisi korunur
            girilen = gelen;

            if (gelen == "")
            {
                sonuc += "\nmetin kutusu boş bırakıldı";
            }
            else
            {
                //özellikle br ile yeni satır yapmadık
                // \n yeni satır yapar
                sonuc += "\nOnPost çalıştı\n" + gelen;

                //gelen bilgi birçok iş için değerlendirilebilir
                for (int i = 15; i < 20; i++)
                {
                    sonuc += "\n" + i.ToString();
                }
            }
            if (gelen == "gogl")
            {
                return Redirect("http://www.google.com");
            }
            if (gelen == "piriv")
            {
                return RedirectToPage("Privacy");
            }

            //Title yerine başka değer de yapılabilir
            ViewData["Title"] = sonuc;

            return null;
        }
    }
}
