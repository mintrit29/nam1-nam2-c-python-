function show_hide() {
    if (document.getElementById("full").style.display != 'block') {
        document.getElementById("full").style.display = 'block';
        document.getElementById("1ink").innerHTML = 'Rat gon';
        document.getElementById("1ink").className =
    }
    else {
        document.getElementById("full").style.display = 'none';
        document.getElementById("link").innerHTML = 'Xem diy di';
        document.getElementById("link").className = 'open';
    }
    return false;
}