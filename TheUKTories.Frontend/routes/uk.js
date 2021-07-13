var express = require('express');
var router = express.Router();
const fetch = require('node-fetch');

router.get('/', function(req, res, next) {
    res.render('uk/index', { title: 'Home' });
});

router.get('/covid', async function(req, res, next) {
    let contracts, responses;
    await fetch('https://theuktories-api.azurewebsites.net/api/uk/coronavirus/contracts')
        .then(response => response.json())
        .then (items => {
            contracts = items;
        });
    await fetch('https://theuktories-api.azurewebsites.net/api/uk/coronavirus')
        .then(response => response.json())
        .then(items => {
            responses = items;
        });

    // todo does this even work? do i need to reverse array?
    responses = responses.sort(function(a,b) {
        return new Date(a.date) - new Date(b.date);
    });

    res.render('uk/covid', { title: 'GOV Covid Response', data: responses, contracts: contracts });
});

router.get('/iscreport', async function(req, res, next) {
    let report, links;
    await fetch('https://theuktories-api.azurewebsites.net/api/uk/russia/report')
        .then(response => response.json())
        .then (items => {
            report = items;
        });
    await fetch('https://theuktories-api.azurewebsites.net/api/links/isc_russia_report')
        .then(response => response.json())
        .then(items => {
            links = items;
        });
    res.render('uk/iscreport', { title: 'ISC Russia Report', report: report, links: links });
});
  
module.exports = router;