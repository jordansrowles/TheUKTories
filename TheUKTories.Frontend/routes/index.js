var express = require('express');
var router = express.Router();
const fetch = require('node-fetch');

/* GET home page. */
router.get('/', function(req, res, next) {
  let request = fetch('https://theuktories-api.azurewebsites.net/api/uk/austerity')
    .then(response => response.json())
    .then(items => {
        res.render('index', { title: 'Home', data: items })
    });
});

router.get('/about', function(req, res, next) {
      res.render('about', { title: 'Home' });
});

module.exports = router;
