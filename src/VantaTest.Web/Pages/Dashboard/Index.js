const imageInput = document.getElementById('productImageInput');
const imagePreviewBox = document.getElementById('imagePreviewBox');
const uploadContainerText = document.querySelector('.image-upload-container p');

if (imageInput) {
    imageInput.addEventListener('change', function (event) {
        const file = event.target.files[0];
        if (file) {
            const reader = new FileReader();
            reader.onload = function (e) {
                imagePreviewBox.src = e.target.result;
                imagePreviewBox.style.display = 'block';
                uploadContainerText.textContent = "Görseli değiştirmek için tıklayın";
            }
            reader.readAsDataURL(file);
        }
    });
}

// 2. Form Gönderme Simülasyonu ve Toast Bildirimi
const productForm = document.getElementById('productForm');
// ABP projenizde global bootstrap scriptleri yüklü varsayılarak Toast çağrılıyor
const successToastElement = document.getElementById('successToast');
let successToast;
if (successToastElement && typeof bootstrap !== 'undefined') {
    successToast = bootstrap.Toast.getOrCreateInstance(successToastElement);
}

if (productForm) {
    productForm.addEventListener('submit', function (event) {
        event.preventDefault(); // Sayfanın yenilenmesini engelle

        // Formu temizle
        productForm.reset();
        if (imagePreviewBox) imagePreviewBox.style.display = 'none';
        if (uploadContainerText) uploadContainerText.textContent = "Fotoğraf yüklemek için tıklayın";

        // Başarı mesajını göster
        if (successToast) {
            successToast.show();
        }
    });
}

// 3. Tablodan Satır Silme Simülasyonu
function deleteRow(btn) {
    if (confirm('Bu kaydı silmek istediğinize emin misiniz?')) {
        const row = btn.closest('tr');
        if (row) row.remove();
    }
}