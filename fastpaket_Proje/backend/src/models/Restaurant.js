const mongoose = require('mongoose');

const restaurantSchema = new mongoose.Schema({
    ad: {
        type: String,
        required: true
    },
    adres: {
        type: String,
        required: true
    },
    telefon: {
        type: String,
        required: true
    },
    kategori: {
        type: String,
        required: true
    },
    menu: [{
        isim: String,
        fiyat: Number,
        aciklama: String,
        resim: String
    }],
    calisma_saatleri: {
        baslangic: String,
        bitis: String
    },
    durum: {
        type: String,
        enum: ['açık', 'kapalı'],
        default: 'kapalı'
    }
});

module.exports = mongoose.model('Restaurant', restaurantSchema);