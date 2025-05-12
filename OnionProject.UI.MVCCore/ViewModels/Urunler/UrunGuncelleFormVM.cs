using Microsoft.AspNetCore.Mvc.Rendering;

namespace OnionProject.UI.MVCCore.ViewModels.Urunler
{
    public class UrunGuncelleFormVM
    {
        public SelectList Kategoriler { get; set; }
        public UrunGuncelleVM Urun { get; set; }
    }
}
