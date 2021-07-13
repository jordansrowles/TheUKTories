var express = require('express');
var router = express.Router();
const fetch = require('node-fetch');

router.get('/', function(req, res, next) {
  let request = fetch('https://theuktories-api.azurewebsites.net/api/people')
    .then(response => response.json())
    .then(items => {
        res.render('people/index', { title: 'Alt-Right Tactics', people: items })
    });
});

router.get('/', function(req, res, next) {
  let request = fetch('https://theuktories-api.azurewebsites.net/api/people')
    .then(response => response.json())
    .then(items => {
        res.render('people/person', { title: 'Alt-Right Tactics', people: items })
    });
});

module.exports = router;