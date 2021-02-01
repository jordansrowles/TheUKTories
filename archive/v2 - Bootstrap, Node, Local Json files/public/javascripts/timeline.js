// button code
var show = true;
var reverse = false;

var createWikiLink = (slug) => 'https://en.wikipedia.org/wiki/' + slug;
var getYearFromSlug = (slug) => slug.substr(0, 4); // unused...
var makeSlugReadable = (slug) => slug.replace('_', ' ');

document.getElementById('toggle').onclick = function () {
    if (show) {
        $('.noelection').hide();
    } else {
        $('.noelection').show();
    }
    show = !show;
}

function reverseList() {
    var list = $('.timeline');
    var listItems = list.children('li');
    list.append(listItems.get().reverse());
}

$.getJSON("resources/data/premiers.json", function(json) {
    var json = JSON.parse(JSON.stringify(json));

    // used for no election li's
    var lastParty = '';
    var lastPM = '';

    for (var item = 0; item < json.electionyears.length; item++) {

        // if there is an election year
        if (json.electionyears[item].election !== undefined) {
            // create the list item
            var li = document.createElement('li');

            // style the circle based on the party
            if (json.electionyears[item].party === 'Conservative') {
                li.setAttribute('class', 'tory');
                lastParty = "tory";
            } else {
                li.setAttribute('class', 'labour');
                lastParty = "labour";
            }

            // create the date link
            var left = document.createElement('a');
            left.setAttribute('href', createWikiLink(json.electionyears[item].election));
            left.setAttribute('target', '_blank');
            left.innerText = json.electionyears[item].year;

            // create the person link
            var right = document.createElement('a');
            right.setAttribute('href', createWikiLink(json.electionyears[item].who));
            right.setAttribute('target', '_blank');
            right.setAttribute('class', 'float-right');
            right.innerText = makeSlugReadable(json.electionyears[item].who);
            lastPM = json.electionyears[item].who;

            // append links to list item, append li to ul
            li.append(left);
            li.append(right);
            $('.timeline').append(li);
        }
        else {
            // create nonelection year li
            var li = document.createElement('li');

            li.setAttribute('class', lastParty + " noelection");
            li.innerText = json.electionyears[item].year;

            var a = document.createElement('a');
            a.innerText = makeSlugReadable(lastPM);
            a.setAttribute('href', createWikiLink(lastPM));
            a.setAttribute('class', 'float-right');

            li.append(a);
            $('.timeline').append(li);
        }
    }
});

$('#toggle').attr('checked', true);