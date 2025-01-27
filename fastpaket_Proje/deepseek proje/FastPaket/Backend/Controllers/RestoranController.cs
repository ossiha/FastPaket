using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using FastPaket.Backend.Models;

namespace FastPaket.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestoranController : ControllerBase
    {
        // Örnek restoran listesi (geçici veri)
        private static List<Restoran> RestoranListesi = new List<Restoran>
        {
            new Restoran { RestoranID = 1, RestoranAdi = "Restoran A", Adres = "İstanbul", Telefon = "5551112233", Email = "restoranA@example.com", Durum = "Aktif" },
            new Restoran { RestoranID = 2, RestoranAdi = "Restoran B", Adres = "Ankara", Telefon = "5554445566", Email = "restoranB@example.com", Durum = "Aktif" }
        };

        // Tüm restoranları getir
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(RestoranListesi);
        }

        // ID'ye göre restoran getir
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var restoran = RestoranListesi.Find(r => r.RestoranID == id);
            if (restoran == null)
            {
                return NotFound();
            }
            return Ok(restoran);
        }

        // Yeni restoran ekle
        [HttpPost]
        public IActionResult Post([FromBody] Restoran restoran)
        {
            if (restoran == null)
            {
                return BadRequest();
            }

            restoran.RestoranID = RestoranListesi.Count + 1;
            RestoranListesi.Add(restoran);

            return CreatedAtAction(nameof(GetById), new { id = restoran.RestoranID }, restoran);
        }

        // Restoran güncelle
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Restoran restoran)
        {
            var mevcutRestoran = RestoranListesi.Find(r => r.RestoranID == id);
            if (mevcutRestoran == null)
            {
                return NotFound();
            }

            mevcutRestoran.RestoranAdi = restoran.RestoranAdi;
            mevcutRestoran.Adres = restoran.Adres;
            mevcutRestoran.Telefon = restoran.Telefon;
            mevcutRestoran.Email = restoran.Email;
            mevcutRestoran.Durum = restoran.Durum;

            return NoContent();
        }

        // Restoran sil
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var restoran = RestoranListesi.Find(r => r.RestoranID == id);
            if (restoran == null)
            {
                return NotFound();
            }

            RestoranListesi.Remove(restoran);
            return NoContent();
        }
    }
}