var express = require('express');
var router = express.Router();
const fetch = require('node-fetch');

router.get('/', function(req, res, next) {
    res.render('altright/index', { title: 'Alt-Right' });
});

router.get('/tactics', function(req, res, next) {
  let request = fetch('https://theuktories-api.azurewebsites.net/api/misinformation')
    .then(response => response.json())
    .then(items => {
        res.render('altright/tactics', { title: 'Alt-Right Tactics', data: items })
    });
});

module.exports = router;
