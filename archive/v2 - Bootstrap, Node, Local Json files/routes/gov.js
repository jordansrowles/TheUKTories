var express = require('express');
var router = express.Router();

/* GET home page. */
router.get('/', function(req, res, next) {
  res.render('gov/index', { title: 'The UK Government Open APIs' });
});

router.get('/gov', function(req, res, next) {
  res.render('gov/index', { title: 'The UK Government Open APIs' });
});

router.get('/divisions', function(req, res, next) {
    res.render('gov/divisions', { title: "Recent Parliamentary Divisions" });
  });
  
module.exports = router;
