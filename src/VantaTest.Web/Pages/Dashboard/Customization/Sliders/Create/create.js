// Fotoğraf yükleme alanı 
document.getElementById('sliderImageInput').addEventListener('change', function (event) {
    const input = event.target;
    const previewBox = document.getElementById('imagePreviewBox');
    const placeholder = document.getElementById('uploadPlaceholder');
    const container = document.getElementById('uploadContainer');

    if (input.files && input.files[0]) {
        const reader = new FileReader();

        reader.onload = function (e) {

            previewBox.src = e.target.result;
            previewBox.style.display = 'block';
            placeholder.style.display = 'none';
            container.style.borderStyle = 'solid';
            container.style.borderColor = '#ced4da';
        };

        reader.readAsDataURL(input.files[0]);
    } else {
        previewBox.src = '';
        previewBox.style.display = 'none';
        placeholder.style.display = 'block';
        container.style.borderStyle = 'dashed';
        container.style.borderColor = '#dee2e6';
    }
});