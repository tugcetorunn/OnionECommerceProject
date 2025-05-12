namespace OnionProject.UI.MVCCore.ViewModels.Urunler
{
    public class UrunGuncelleVM
    {
        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public decimal Fiyat { get; set; }
        public string Aciklama { get; set; }
        public IFormFile? UrunResmiDosya { get; set; }
        public string? UrunResmi { get; set; }
        public int StokAdedi { get; set; }
        public int KategoriId { get; set; }
    }
}