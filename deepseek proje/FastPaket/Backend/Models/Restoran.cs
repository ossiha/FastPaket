namespace FastPaket.Backend.Models
{
    public class Restoran
    {
        public int RestoranID { get; set; }
        public string RestoranAdi { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Durum { get; set; } // Aktif, Pasif
    }
}