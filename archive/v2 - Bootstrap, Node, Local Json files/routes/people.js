var express = require('express');
var router = express.Router();

/* GET home page. */
router.get('/', function(req, res, next) {
  res.render('people', { title: 'The UK Tories - People' });
});

module.exports = router;
