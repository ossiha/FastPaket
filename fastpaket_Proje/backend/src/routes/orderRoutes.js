const express = require('express');
const router = express.Router();
const Siparis = require('../models/Siparis');

// Tüm siparişleri getir
router.get('/', async (req, res) => {
    try {
        const siparisler = await Siparis.find().populate('musteri_id restoran_id');
        res.status(200).json(siparisler);
    } catch (error) {
        res.status(500).json({ message: 'Siparişler alınırken bir hata oluştu.', error });
    }
});

// Yeni sipariş oluştur
router.post('/', async (req, res) => {
    const yeniSiparis = new Siparis(req.body);
    try {
        const kaydedilenSiparis = await yeniSiparis.save();
        res.status(201).json(kaydedilenSiparis);
    } catch (error) {
        res.status(400).json({ message: 'Sipariş oluşturulurken bir hata oluştu.', error });
    }
});

// Sipariş durumunu güncelle
router.put('/:id', async (req, res) => {
    try {
        const guncellenenSiparis = await Siparis.findByIdAndUpdate(req.params.id, req.body, { new: true });
        res.status(200).json(guncellenenSiparis);
    } catch (error) {
        res.status(400).json({ message: 'Sipariş güncellenirken bir hata oluştu.', error });
    }
});

// Sipariş sil
router.delete('/:id', async (req, res) => {
    try {
        await Siparis.findByIdAndDelete(req.params.id);
        res.status(200).json({ message: 'Sipariş başarıyla silindi.' });
    } catch (error) {
        res.status(500).json({ message: 'Sipariş silinirken bir hata oluştu.', error });
    }
});

module.exports = router;