namespace FastPaket.Backend.Models
{
    public class Kurye
    {
        public int KuryeID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Telefon { get; set; }
        public string Durum { get; set; } // Müsait, Meşgul
    }
}