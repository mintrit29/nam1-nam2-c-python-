function show_hide() {
    if (document.getElementById("full").style.display != 'block') {
        document.getElementById("full").style.display = 'block';
        document.getElementById("1ink").innerHTML = 'Rút gọn';
        document.getElementById("1ink").className = 'close';
    }
    else {
        document.getElementById("full").style.display = 'none';
        document.getElementById("link").innerHTML = 'Xem đầy đủ';
        document.getElementById("link").className = 'open';
    }
    return false;
}