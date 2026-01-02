from selenium import webdriver
from selenium.webdriver.common.by import By
from selenium.webdriver.firefox.service import Service as FirefoxService
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
import time

# --- CẤU HÌNH ---
# Thay thế bằng thông tin đăng nhập thực tế của bạn
YOUR_USERNAME = "2200004759"  # Ví dụ: "123456789"
YOUR_PASSWORD = "tongminh1"

LOGIN_URL = "https://lcms.ntt.edu.vn/login/index.php"

# (TÙY CHỌN) Đường dẫn đến geckodriver nếu nó không nằm trong PATH
# GECKODRIVER_PATH = r"C:\duong\dan\toi\geckodriver.exe" # Ví dụ cho Windows
# GECKODRIVER_PATH = "/duong/dan/toi/geckodriver"      # Ví dụ cho Linux/macOS

# --- KHỞI TẠO TRÌNH ĐIỀU KHIỂN ---
try:
    # Nếu geckodriver nằm trong PATH, bạn có thể bỏ qua service
    # driver = webdriver.Firefox()

    # Nếu bạn muốn chỉ định đường dẫn đến geckodriver:
    # service = FirefoxService(executable_path=GECKODRIVER_PATH)
    # driver = webdriver.Firefox(service=service)

    # Cách đơn giản nhất nếu geckodriver đã trong PATH
    driver = webdriver.Firefox()
    driver.maximize_window() # Mở cửa sổ trình duyệt lớn nhất

    # Mở trang đăng nhập
    driver.get(LOGIN_URL)
    print(f"Đã mở trang: {LOGIN_URL}")

    # Sử dụng WebDriverWait để đảm bảo các phần tử đã tải xong
    wait = WebDriverWait(driver, 20) # Chờ tối đa 20 giây

    # --- ĐIỀN THÔNG TIN ĐĂNG NHẬP ---
    # Tìm trường username bằng ID
    username_field = wait.until(EC.presence_of_element_located((By.ID, "username")))
    username_field.clear() # Xóa nội dung cũ nếu có
    username_field.send_keys(YOUR_USERNAME)
    print(f"Đã nhập username: {YOUR_USERNAME}")

    # Tìm trường password bằng ID
    password_field = wait.until(EC.presence_of_element_located((By.ID, "password")))
    password_field.clear()
    password_field.send_keys(YOUR_PASSWORD)
    print("Đã nhập password.")

    # Tìm nút đăng nhập bằng ID và click
    login_button = wait.until(EC.element_to_be_clickable((By.ID, "loginbtn")))
    login_button.click()
    print("Đã nhấn nút đăng nhập.")

    # --- KIỂM TRA ĐĂNG NHẬP THÀNH CÔNG ---
    # Chờ một phần tử nào đó chỉ xuất hiện sau khi đăng nhập thành công
    # Ví dụ: chờ menu người dùng (thường có ID là 'user-menu-toggle' hoặc tương tự)
    # Hoặc chờ URL thay đổi sang trang dashboard
    # Bạn cần kiểm tra trang web sau khi đăng nhập để tìm một ID hoặc class phù hợp
    try:
        # Thử chờ phần tử user-menu-toggle, là một dấu hiệu tốt cho việc đăng nhập thành công
        wait.until(EC.presence_of_element_located((By.ID, "user-menu-toggle")))
        print("Đăng nhập thành công! Bạn đã vào được trang chủ sau đăng nhập.")
        # (TÙY CHỌN) Giữ trình duyệt mở trong vài giây để xem kết quả
        time.sleep(10)
    except Exception:
        # Kiểm tra xem có thông báo lỗi đăng nhập không
        try:
            error_message = driver.find_element(By.CSS_SELECTOR, ".loginerrors .alert.alert-danger")
            if error_message.is_displayed():
                print(f"Đăng nhập thất bại! Thông báo lỗi: {error_message.text}")
        except:
            print("Đăng nhập có thể đã thất bại hoặc không tìm thấy dấu hiệu thành công/thất bại cụ thể.")


    # --- CÁC HÀNH ĐỘNG KHÁC SAU KHI ĐĂNG NHẬP (NẾU CẦN) ---
    # Ví dụ: driver.get("https://lcms.ntt.edu.vn/course/index.php")
    # time.sleep(5) # Chờ trang tải

except Exception as e:
    print(f"Đã xảy ra lỗi: {e}")

finally:
    # Đóng trình duyệt sau khi hoàn tất (hoặc nếu có lỗi)
    if 'driver' in locals() and driver is not None:
        print("Đóng trình duyệt.")
        driver.quit()