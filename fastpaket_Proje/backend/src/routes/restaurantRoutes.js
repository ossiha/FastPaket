const express = require('express');
const router = express.Router();
const Restaurant = require('../models/Restaurant');

// Tüm restoranları getir
router.get('/', async (req, res) => {
    try {
        const restoranlar = await Restaurant.find();
        res.status(200).json(restoranlar);
    } catch (error) {
        res.status(500).json({ message: 'Restoranlar alınırken bir hata oluştu.', error });
    }
});

// Yeni restoran ekle
router.post('/', async (req, res) => {
    const yeniRestoran = new Restaurant(req.body);
    try {
        const kaydedilenRestoran = await yeniRestoran.save();
        res.status(201).json(kaydedilenRestoran);
    } catch (error) {
        res.status(400).json({ message: 'Restoran eklenirken bir hata oluştu.', error });
    }
});

// Restoran güncelle
router.put('/:id', async (req, res) => {
    try {
        const guncellenenRestoran = await Restaurant.findByIdAndUpdate(req.params.id, req.body, { new: true });
        res.status(200).json(guncellenenRestoran);
    } catch (error) {
        res.status(400).json({ message: 'Restoran güncellenirken bir hata oluştu.', error });
    }
});

// Restoran sil
router.delete('/:id', async (req, res) => {
    try {
        await Restaurant.findByIdAndDelete(req.params.id);
        res.status(200).json({ message: 'Restoran başarıyla silindi.' });
    } catch (error) {
        res.status(500).json({ message: 'Restoran silinirken bir hata oluştu.', error });
    }
});

module.exports = router;