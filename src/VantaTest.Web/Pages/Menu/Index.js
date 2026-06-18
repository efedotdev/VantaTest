document.addEventListener("DOMContentLoaded", function () {
    var acc = document.getElementsByClassName("accordion");
    for (var i = 0; i < acc.length; i++) {
        acc[i].addEventListener("click", function () {
            // Tıklanan butona 'active' sınıfını ekle/çıkar
            this.classList.toggle("active");

            // Butonun hemen altındaki '.panel' div'ini bul
            var panel = this.nextElementSibling;

            // Eğer açıksa kapat, kapalıysa yüksekliği kadar aç
            if (panel.style.maxHeight) {
                panel.style.maxHeight = null;
            } else {
                panel.style.maxHeight = panel.scrollHeight + "px";
            }
        });
    }
});