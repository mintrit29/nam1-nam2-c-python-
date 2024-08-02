document.addEventListener('DOMContentLoaded', function () {

    // Hàm kiểm tra tính hợp lệ của form
    function validateForm(event) {
        let isValid = true;
        let errorMessage = "";

        // Lấy các phần tử của form
        const nameInput = document.querySelector('input[name="name"]');
        const emailInput = document.querySelector('input[name="email"]');
        const messageInput = document.getElementById('message');
        
        // Kiểm tra họ tên
        if (nameInput.value.trim() === "") {
            isValid = false;
            errorMessage += "Yêu cầu nhập họ tên\n";
        }

        // Kiểm tra địa chỉ email
        if (emailInput.value.trim() === "") {
            isValid = false;
            errorMessage += "Yêu cầu nhập địa chỉ email\n";
        } else {
            // Kiểm tra định dạng email bằng Regular Expression
            const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
            if (!emailPattern.test(emailInput.value)) {
                isValid = false;
                errorMessage += "Yêu cầu nhập đúng định dạng địa chỉ email\n";
            }
        }

        // Kiểm tra nội dung yêu cầu
        if (messageInput.value.trim() === "") {
            isValid = false;
            errorMessage += "Yêu cầu nhập nội dung\n";
        }

        // Nếu form không hợp lệ, hiển thị thông báo lỗi
        if (!isValid) {
            alert(errorMessage);
            event.preventDefault();
        } else {
            alert("Cám ơn bạn đã đăng ký!");
        }
    }

    // Hàm xử lý sự kiện cho nút "Nhập lại"
    function handleResetClick(event) {
        // Hiển thị hộp thoại xác nhận
        const confirmation = confirm("Có chắc là bạn muốn xoá toàn bộ thông tin và nhập lại không?");
        
        // Nếu người dùng chọn Yes, xóa các textbox
        if (confirmation) {
            // Lấy tất cả các trường input kiểu text
            const textInputs = document.querySelectorAll('input[type="text"]');
            textInputs.forEach(input => input.value = "");

            // Xóa giá trị của trường input kiểu email
            const emailInput = document.querySelector('input[type="email"]');
            if (emailInput) {
                emailInput.value = "";
            }

            // Xóa nội dung của textarea
            const messageInput = document.getElementById('message');
            if (messageInput) {
                messageInput.value = "";
            }
        } else {
            // Nếu người dùng chọn Cancel, không làm gì hết
            event.preventDefault();
        }
    }

    // Gán sự kiện cho nút submit của form
    const form = document.getElementById('registrationForm');
    if (form) {
        form.addEventListener('submit', validateForm);
    }

    // Gán sự kiện cho nút "Nhập lại"
    const resetButton = document.querySelector('.buttons input[type="reset"]');
    if (resetButton) {
        resetButton.addEventListener('click', handleResetClick);
    }
});
