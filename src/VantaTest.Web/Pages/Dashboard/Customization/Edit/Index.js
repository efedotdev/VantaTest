document.getElementById('headerImageInput').addEventListener('change', function (event) {
    var file = event.target.files[0];

    if (file) {
        var reader = new FileReader();

        // Dosya okunduğunda çalışacak fonksiyon
        reader.onload = function (e) {
            var imgPreview = document.getElementById('imagePreviewBox');
            imgPreview.src = e.target.result; // Yeni resmin base64 verisini src'ye ata
        }

        // Dosyayı okumaya başla
        reader.readAsDataURL(file);
    }
});