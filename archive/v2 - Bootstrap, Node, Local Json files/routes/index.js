var express = require('express');
var router = express.Router();


/* GET home page. */
router.get('/', function(req, res, next) {
  res.render('index', { title: 'The UK Tories' });
});

/* GET covid page. */
router.get('/covid', function(req, res, next) {
    res.render('covid', { title: 'UK Government Coronavirus Response'});
});

/* GET report page. */
router.get('/report', function(req, res, next) {
  res.render('report', { title: 'ISC Report: Russia' });
});
module.exports = router;
