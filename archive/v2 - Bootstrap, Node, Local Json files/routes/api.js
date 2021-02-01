var express = require('express');
var router = express.Router();
var mongoClient = require('mongodb').MongoClient;

router.get('/people', function(req, res) {
    db.collection("name").find({}, function(err, docs) {
        docs.each(function(err, doc) {
            if (doc) console.log(doc);
            else res.end();
        });
    })
});

router.get('/people/:id', (req, res) => {
    try {

    }
    catch (err) { res.status(500).json({message: err.message}); }
});

module.exports = router;