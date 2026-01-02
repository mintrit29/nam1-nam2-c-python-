from selenium import webdriver
from selenium.webdriver.firefox.service import Service as FirefoxService
from webdriver_manager.firefox import GeckoDriverManager
from selenium.webdriver.common.by import By
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
import time

# --- THÔNG TIN ĐĂNG NHẬP ---
# !!! THAY THẾ BẰNG THÔNG TIN CỦA BẠN !!!
USERNAME = "2200004759"
PASSWORD = "tongminh1"
# --------------------------

# Khởi tạo Firefox WebDriver sử dụng webdriver-manager
# Điều này sẽ tự động tải xuống và quản lý geckodriver
try:
    driver = webdriver.Firefox(service=FirefoxService(GeckoDriverManager().install()))
except Exception as e:
    print(f"Lỗi khởi tạo Firefox driver: {e}")
    print("Hãy đảm bảo bạn đã cài đặt Firefox và có kết nối internet để tải GeckoDriver.")
    exit()

# Mở trang đăng nhập (thường là trang chủ rồi redirect)
LOGIN_URL = "https://lcms.ntt.edu.vn/login/index.php"
COURSES_URL = "https://lcms.ntt.edu.vn/my/courses.php" # Trang đích sau khi đăng nhập

try:
    driver.get(LOGIN_URL)
    print(f"Đã mở trang: {LOGIN_URL}")

    # Chờ và điền thông tin đăng nhập
    # ID của các trường input có thể thay đổi, kiểm tra lại nếu cần
    username_field = WebDriverWait(driver, 20).until(
        EC.presence_of_element_located((By.ID, "username"))
    )
    password_field = WebDriverWait(driver, 20).until(
        EC.presence_of_element_located((By.ID, "password"))
    )
    login_button = WebDriverWait(driver, 20).until(
        EC.element_to_be_clickable((By.ID, "loginbtn")) # ID của nút đăng nhập
    )

    username_field.send_keys(USERNAME)
    password_field.send_keys(PASSWORD)
    print("Đã điền thông tin đăng nhập.")
    login_button.click()
    print("Đã nhấp nút đăng nhập.")

    # Chờ cho việc đăng nhập hoàn tất và trang được tải
    # Có thể kiểm tra URL đã chuyển sang trang /my/ hoặc một phần tử đặc trưng của trang dashboard
    WebDriverWait(driver, 30).until(
        EC.url_contains("/my/") # Chờ đến khi URL chứa "/my/"
    )
    print("Đăng nhập thành công! Đang chuyển đến trang khóa học.")

    # Đi đến trang danh sách khóa học nếu chưa ở đó
    if driver.current_url != COURSES_URL:
        driver.get(COURSES_URL)
        print(f"Đã mở trang: {COURSES_URL}")

    # Chờ trang khóa học tải xong
    WebDriverWait(driver, 20).until(
        EC.presence_of_element_located((By.XPATH, "/html/body")) # Chờ body tải
    )
    print("Trang khóa học đã tải.")

    # === HÀNH ĐỘNG NHẤP VÀO KHÓA HỌC ===
    # Sử dụng XPath bạn cung cấp.
    # Nếu XPath này trỏ tới span, có thể bạn muốn nhấp vào thẻ <a> cha của nó.
    # XPath của thẻ a có thể là: /html/body/div[3]/div[3]/div/div[2]/div/section/div/aside/section/div/div/div[1]/div[2]/div/div/div[1]/div/div/div[1]/div[1]/div/div/a
    
    target_xpath = "/html/body/div[3]/div[3]/div/div[2]/div/section/div/aside/section/div/div/div[1]/div[2]/div/div/div[1]/div[2]/div/div[1]/div[1]/div/div/a/span[3]"
    # Hoặc thử nhấp vào thẻ <a>:
    # target_xpath = "/html/body/div[3]/div[3]/div/div[2]/div/section/div/aside/section/div/div/div[1]/div[2]/div/div/div[1]/div/div/div[1]/div[1]/div/div/a"

    print(f"Đang tìm phần tử với XPath: {target_xpath}")

    # Chờ cho phần tử có thể nhấp được
    view_course_element = WebDriverWait(driver, 30).until(
        EC.element_to_be_clickable((By.XPATH, target_xpath))
    )
    print("Đã tìm thấy phần tử 'Vào xem khóa học'.")

    # Thực hiện nhấp
    # view_course_element.click()
    # Sử dụng JavaScript click nếu click thông thường không hoạt động (do bị che phủ hoặc lý do khác)
    driver.execute_script("arguments[0].click();", view_course_element)

    print("Đã nhấp vào 'Vào xem khóa học' thành công!")

    # Giữ trình duyệt mở một lúc để xem kết quả
    time.sleep(10)

except Exception as e:
    print(f"Đã xảy ra lỗi: {e}")
    # Chụp ảnh màn hình khi có lỗi để dễ debug
    driver.save_screenshot("error_screenshot.png")
    print("Đã lưu ảnh chụp màn hình lỗi vào error_screenshot.png")

finally:
    # Đóng trình duyệt
    if 'driver' in locals() and driver is not None:
        print("Đang đóng trình duyệt...")
        driver.quit()