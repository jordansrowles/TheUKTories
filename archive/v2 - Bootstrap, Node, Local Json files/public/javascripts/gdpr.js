$(document).ready(function() {
    if (getCookie('mode')) { // search for most basic cookie
        console.log('cookie found: mode'); // debug

        checkAndEmbedAnalytics();

    } else { // if we need to initialise the cookies
        console.log('no cookie: acceptAnalyticalCookie'); // debug

        displayCookieBanner();
        setCookie('mode', 'light');
        setCookie('acceptAnalyticalCookie', true);
        setCookie('acceptSocialCookie', false);

        document.getElementById('btnAcceptAllCookies').addEventListener('click', function() {
            setCookie('acceptAnalyticalCookie', true);
            setCookie('acceptSocialCookie', true);
            checkAndEmbedAnalytics();
            document.getElementById('alertCookies').style.display = "none";
        }, false);

    }
    checkAndEmbedAnalytics();
});

function checkAndEmbedAnalytics(){
    console.log('check analytics cookie: ' + getCookie('acceptAnalyticalCookie'));
    if (getCookie('acceptAnalyticalCookie') == "true") {
        $("body").append('<script src="https://www.googletagmanager.com/gtag/js?id=UA-55062061-4"></script>');
        $("body").append(`<script>
        window.dataLayer = window.dataLayer || [];
        function gtag(){dataLayer.push(arguments);}
        gtag('js', new Date());
        gtag('config', 'UA-55062061-4');  
        </script>`);
    }
}

function getCookie(c_name) {
    var c_value = document.cookie,
        c_start = c_value.indexOf(" " + c_name + "=");
    if (c_start == -1) c_start = c_value.indexOf(c_name + "=");
    if (c_start == -1) {
        c_value = null;
    } else {
        c_start = c_value.indexOf("=", c_start) + 1;
        var c_end = c_value.indexOf(";", c_start);
        if (c_end == -1) {
            c_end = c_value.length;
        }
        c_value = unescape(c_value.substring(c_start, c_end));
    }
    return c_value;
}

var setCookie = (key, cookie) => document.cookie = key + "=" + cookie + "; expires=Fri, 31 Dec 9999 23:59:59 GMT";

function displayCookieBanner() {
    var alert = document.createElement('div');
    alert.setAttribute('id', "alertCookies");
    alert.setAttribute('class', 'alert alert-success alert-dismissible fade show');
    alert.setAttribute('role', 'alert');

    alert.innerHTML = "<strong>This site uses cookies!</strong> This website uses cookies for preferences, social media and analytical purposes. More information can be found on the <a href='/about' target='_blank'>cookies</a> section of our About page. By pressing 'Accept' you agree to all cookies. We do not use cookies for Ads or marketing.<br><br>";

    var btnAccept = document.createElement('button');
    btnAccept.setAttribute('id', 'btnAcceptAllCookies');
    btnAccept.setAttribute('type', 'button');
    btnAccept.setAttribute('class', 'btn btn-info');

    var btnAcceptText = document.createElement('span');
    btnAcceptText.innerText = "Accept";

    btnAccept.appendChild(btnAcceptText);
    alert.appendChild(btnAccept);

    var btnClose = document.createElement('button');
    btnClose.setAttribute('class', 'close');
    btnClose.setAttribute('data-dismiss', 'alert');
    btnClose.setAttribute('aria-close', 'Close');

    var btnCloseText = document.createElement('span');
    btnCloseText.id = "btnCancelCookies"
    btnCloseText.innerHTML = "&times;";
    btnCloseText.setAttribute('aria-hidden', 'true');

    btnClose.appendChild(btnCloseText);
    alert.appendChild(btnClose);

    var body = document.getElementsByTagName("body")[0];
    body.insertBefore(alert, body.firstChild);
}

/*
  <div class="alert alert-success alert-dismissible fade show" role="alert">
    <strong>This site uses cookies!</strong> This website uses essential cookies, and analytical tracking cookies. We use a cookie to save the preference of night / day mode colour schemes. We use Google Analytics to monitor activity and audiences. By pressing 'Accept', you agree to the use of analytical cookies, as well as essential. You can change this on the mycookies page. We also use cookies to connect to our social media page.
    <br>
    <button type="button" class="btn btn-info">
      <span>Accept</span>
    </button>

    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
      <span aria-hidden="true">&times;</span>
    </button>
  </div>
*/