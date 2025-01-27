using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using FastPaket.Backend.Models;

namespace FastPaket.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KuryeController : ControllerBase
    {
        // Örnek kurye listesi (geçici veri)
        private static List<Kurye> KuryeListesi = new List<Kurye>
        {
            new Kurye { KuryeID = 1, Ad = "Mehmet", Soyad = "Demir", Telefon = "5556667788", Durum = "Müsait" },
            new Kurye { KuryeID = 2, Ad = "Ali", Soyad = "Yıldız", Telefon = "5559998877", Durum = "Meşgul" }
        };

        // Tüm kuryeleri getir
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(KuryeListesi);
        }

        // ID'ye göre kurye getir
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var kurye = KuryeListesi.Find(k => k.KuryeID == id);
            if (kurye == null)
            {
                return NotFound();
            }
            return Ok(kurye);
        }

        // Yeni kurye ekle
        [HttpPost]
        public IActionResult Post([FromBody] Kurye kurye)
        {
            if (kurye == null)
            {
                return BadRequest();
            }

            kurye.KuryeID = KuryeListesi.Count + 1;
            KuryeListesi.Add(kurye);

            return CreatedAtAction(nameof(GetById), new { id = kurye.KuryeID }, kurye);
        }

        // Kurye güncelle
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Kurye kurye)
        {
            var mevcutKurye = KuryeListesi.Find(k => k.KuryeID == id);
            if (mevcutKurye == null)
            {
                return NotFound();
            }

            mevcutKurye.Ad = kurye.Ad;
            mevcutKurye.Soyad = kurye.Soyad;
            mevcutKurye.Telefon = kurye.Telefon;
            mevcutKurye.Durum = kurye.Durum;

            return NoContent();
        }

        // Kurye sil
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var kurye = KuryeListesi.Find(k => k.KuryeID == id);
            if (kurye == null)
            {
                return NotFound();
            }

            KuryeListesi.Remove(kurye);
            return NoContent();
        }
    }
}