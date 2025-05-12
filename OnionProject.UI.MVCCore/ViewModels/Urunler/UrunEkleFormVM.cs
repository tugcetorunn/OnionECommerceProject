using Microsoft.AspNetCore.Mvc.Rendering;

namespace OnionProject.UI.MVCCore.ViewModels.Urunler
{
    public class UrunEkleFormVM
    {
        public SelectList Kategoriler { get; set; }
        public UrunEkleVM Urun { get; set; }
    }
}
