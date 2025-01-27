namespace FastPaket.Backend.Models
{
    public class Siparis
    {
        public int SiparisID { get; set; }
        public int MusteriID { get; set; }
        public int RestoranID { get; set; }
        public decimal ToplamTutar { get; set; }
        public string Durum { get; set; } // Hazırlanıyor, Yolda, Teslim Edildi
    }
}