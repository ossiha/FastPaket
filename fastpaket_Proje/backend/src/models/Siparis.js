const mongoose = require('mongoose');

const siparisSchema = new mongoose.Schema({
    musteri_id: {
        type: mongoose.Schema.Types.ObjectId,
        ref: 'User',
        required: true
    },
    restoran_id: {
        type: mongoose.Schema.Types.ObjectId,
        ref: 'Restaurant',
        required: true
    },
    urunler: [{
        urun_id: mongoose.Schema.Types.ObjectId,
        adet: Number,
        fiyat: Number
    }],
    toplam_tutar: {
        type: Number,
        required: true
    },
    durum: {
        type: String,
        enum: ['hazırlanıyor', 'yolda', 'teslim edildi'],
        default: 'hazırlanıyor'
    },
    odeme_durumu: {
        type: String,
        enum: ['bekliyor', 'ödendi'],
        default: 'bekliyor'
    },
    created_at: {
        type: Date,
        default: Date.now
    }
});

module.exports = mongoose.model('Siparis', siparisSchema);