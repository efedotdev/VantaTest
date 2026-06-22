document.getElementById('headerImageInput').addEventListener('change', function (event) {
    var file = event.target.files[0];

    if (file) {
        var reader = new FileReader();

        reader.onload = function (e) {
            var imgPreview = document.getElementById('imagePreviewBox');
            imgPreview.src = e.target.result; 
        }

        reader.readAsDataURL(file);
    }
});