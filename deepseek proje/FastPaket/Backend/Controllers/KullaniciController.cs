using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using FastPaket.Backend.Models;

namespace FastPaket.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KullaniciController : ControllerBase
    {
        // Örnek kullanıcı listesi (geçici veri)
        private static List<Kullanici> KullaniciListesi = new List<Kullanici>
        {
            new Kullanici { KullaniciID = 1, Ad = "Ahmet", Soyad = "Yılmaz", Email = "ahmet@example.com", Sifre = "sifre123", Rol = "Müşteri" },
            new Kullanici { KullaniciID = 2, Ad = "Ayşe", Soyad = "Kaya", Email = "ayse@example.com", Sifre = "sifre123", Rol = "Restoran" }
        };

        // Tüm kullanıcıları getir
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(KullaniciListesi);
        }

        // ID'ye göre kullanıcı getir
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var kullanici = KullaniciListesi.Find(k => k.KullaniciID == id);
            if (kullanici == null)
            {
                return NotFound();
            }
            return Ok(kullanici);
        }

        // Yeni kullanıcı ekle
        [HttpPost]
        public IActionResult Post([FromBody] Kullanici kullanici)
        {
            if (kullanici == null)
            {
                return BadRequest();
            }

            kullanici.KullaniciID = KullaniciListesi.Count + 1;
            KullaniciListesi.Add(kullanici);

            return CreatedAtAction(nameof(GetById), new { id = kullanici.KullaniciID }, kullanici);
        }

        // Kullanıcı güncelle
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Kullanici kullanici)
        {
            var mevcutKullanici = KullaniciListesi.Find(k => k.KullaniciID == id);
            if (mevcutKullanici == null)
            {
                return NotFound();
            }

            mevcutKullanici.Ad = kullanici.Ad;
            mevcutKullanici.Soyad = kullanici.Soyad;
            mevcutKullanici.Email = kullanici.Email;
            mevcutKullanici.Sifre = kullanici.Sifre;
            mevcutKullanici.Rol = kullanici.Rol;

            return NoContent();
        }

        // Kullanıcı sil
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var kullanici = KullaniciListesi.Find(k => k.KullaniciID == id);
            if (kullanici == null)
            {
                return NotFound();
            }

            KullaniciListesi.Remove(kullanici);
            return NoContent();
        }
    }
}