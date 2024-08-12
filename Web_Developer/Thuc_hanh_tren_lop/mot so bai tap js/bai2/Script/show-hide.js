function show_hide() {
    var fullDiv = document.getElementById("full");
    var link = document.getElementById("link");
    if (fullDiv.style.display != 'block') {
        fullDiv.style.display = 'block';
        link.innerHTML = 'Rút gọn';
        link.className = 'close';
    } else {
        fullDiv.style.display = 'none';
        link.innerHTML = 'Xem đầy đủ';
        link.className = 'open';
    }
    return false;
}
