using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using FastPaket.Backend.Models;

namespace FastPaket.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SiparisController : ControllerBase
    {
        // Örnek sipariş listesi (geçici veri)
        private static List<Siparis> SiparisListesi = new List<Siparis>
        {
            new Siparis { SiparisID = 1, MusteriID = 1, RestoranID = 1, ToplamTutar = 80.00m, Durum = "Hazırlanıyor" },
            new Siparis { SiparisID = 2, MusteriID = 1, RestoranID = 2, ToplamTutar = 40.00m, Durum = "Yolda" }
        };

        // Tüm siparişleri getir
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(SiparisListesi);
        }

        // ID'ye göre sipariş getir
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var siparis = SiparisListesi.Find(s => s.SiparisID == id);
            if (siparis == null)
            {
                return NotFound();
            }
            return Ok(siparis);
        }

        // Yeni sipariş ekle
        [HttpPost]
        public IActionResult Post([FromBody] Siparis siparis)
        {
            if (siparis == null)
            {
                return BadRequest();
            }

            siparis.SiparisID = SiparisListesi.Count + 1;
            SiparisListesi.Add(siparis);

            return CreatedAtAction(nameof(GetById), new { id = siparis.SiparisID }, siparis);
        }

        // Sipariş güncelle
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Siparis siparis)
        {
            var mevcutSiparis = SiparisListesi.Find(s => s.SiparisID == id);
            if (mevcutSiparis == null)
            {
                return NotFound();
            }

            mevcutSiparis.MusteriID = siparis.MusteriID;
            mevcutSiparis.RestoranID = siparis.RestoranID;
            mevcutSiparis.ToplamTutar = siparis.ToplamTutar;
            mevcutSiparis.Durum = siparis.Durum;

            return NoContent();
        }

        // Sipariş sil
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var siparis = SiparisListesi.Find(s => s.SiparisID == id);
            if (siparis == null)
            {
                return NotFound();
            }

            SiparisListesi.Remove(siparis);
            return NoContent();
        }
    }
}