from selenium import webdriver
from selenium.webdriver.firefox.service import Service as FirefoxService
from webdriver_manager.firefox import GeckoDriverManager # Tự động quản lý geckodriver
from selenium.webdriver.common.by import By
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
import time

# --- CẤU HÌNH ---
LOGIN_URL = "https://lcms.ntt.edu.vn/login/index.php" # Trang đăng nhập
DASHBOARD_URL = "https://lcms.ntt.edu.vn/my/" # Trang dashboard sau khi đăng nhập

# Thay thế bằng thông tin đăng nhập của bạn
USERNAME = "2200004759"
PASSWORD = "tongminh1"

# XPaths bạn cung cấp (CẢNH BÁO: Có thể không ổn định)
USER_MENU_XPATH = '//*[@id="user-menu-toggle"]' # ID động này rất có thể sẽ thay đổi
LOGOUT_BUTTON_XPATH = "/html/body/div[3]/nav/div[2]/div[3]/div/div/div/div/div/div[1]/a[8]" # XPath tuyệt đối này cũng không ổn định

# --- KHỞI TẠO WEBDRIVER ---
# Sử dụng webdriver_manager để tự động tải và cài đặt geckodriver
service = FirefoxService(GeckoDriverManager().install())
driver = webdriver.Firefox(service=service)
wait = WebDriverWait(driver, 20) # Tăng thời gian chờ nếu mạng chậm

try:
    # 1. Đăng nhập
    print(f"Đang truy cập trang đăng nhập: {LOGIN_URL}")
    driver.get(LOGIN_URL)

    # Kiểm tra xem có phải điền username/password không
    if USERNAME != "TEN_DANG_NHAP_CUA_BAN" and PASSWORD != "MAT_KHAU_CUA_BAN":
        print("Đang tiến hành đăng nhập...")
        wait.until(EC.presence_of_element_located((By.ID, "username"))).send_keys(USERNAME)
        driver.find_element(By.ID, "password").send_keys(PASSWORD)
        driver.find_element(By.ID, "loginbtn").click() # Nút đăng nhập thường có ID là 'loginbtn' trên Moodle
        
        # Đợi trang dashboard được tải
        print(f"Đợi chuyển hướng đến trang dashboard: {DASHBOARD_URL}")
        wait.until(EC.url_to_be(DASHBOARD_URL))
        print("Đăng nhập thành công!")
    else:
        print("Vui lòng cung cấp USERNAME và PASSWORD để tự động đăng nhập.")
        print("Script sẽ giả định bạn đã đăng nhập thủ công và đang ở trang /my/.")
        print(f"Đang truy cập: {DASHBOARD_URL}")
        driver.get(DASHBOARD_URL)
        # Có thể thêm một khoảng dừng nhỏ để đảm bảo trang đã tải nếu bạn đăng nhập thủ công
        # time.sleep(5)


    # 2. Click vào menu người dùng để mở dropdown
    print(f"Đang tìm và click vào menu người dùng bằng XPath: {USER_MENU_XPATH}")
    # CẢNH BÁO: XPath này rất có thể sẽ không hoạt động nếu ID 'yui_...' thay đổi.
    # Nếu không hoạt động, bạn cần tìm một XPath ổn định hơn.
    # Gợi ý: thử tìm thẻ <a> hoặc <span> có chứa tên người dùng của bạn, hoặc thẻ <img> là avatar.
    # Ví dụ, XPath ổn định hơn có thể là: //a[contains(@class, 'userbutton')] hoặc //span[@id='user-menu-toggle']
    
    user_menu_toggle = wait.until(EC.element_to_be_clickable((By.XPATH, USER_MENU_XPATH)))
    # Đôi khi click thông thường không hoạt động với các menu phức tạp, thử dùng JavaScript click
    driver.execute_script("arguments[0].click();", user_menu_toggle)
    # user_menu_toggle.click() # Thử click thông thường trước
    print("Đã click vào menu người dùng.")

    # Thêm một khoảng chờ nhỏ để menu xổ xuống (nếu cần)
    time.sleep(1) # Điều chỉnh nếu menu xuất hiện chậm hơn

    # 3. Click vào nút "Đăng xuất"
    print(f"Đang tìm và click vào nút 'Đăng xuất' bằng XPath: {LOGOUT_BUTTON_XPATH}")
    # CẢNH BÁO: XPath tuyệt đối này không ổn định.
    # Gợi ý: thử tìm thẻ <a> có text là "Đăng xuất" hoặc có href chứa "logout".
    # Ví dụ, XPath ổn định hơn có thể là: //a[normalize-space()='Đăng xuất'] hoặc //a[contains(@href, 'logout.php')]
    
    logout_button = wait.until(EC.element_to_be_clickable((By.XPATH, LOGOUT_BUTTON_XPATH)))
    driver.execute_script("arguments[0].click();", logout_button)
    # logout_button.click()
    print("Đã click vào nút 'Đăng xuất'.")

    # 4. Đợi và xác nhận đã logout
    # Sau khi logout, thường sẽ được chuyển hướng về trang login hoặc trang chủ
    print("Đang đợi xác nhận logout (chuyển về trang login)...")
    wait.until(EC.url_contains("login")) # Kiểm tra URL có chứa 'login'
    print("Logout thành công! Đã được chuyển hướng về trang đăng nhập.")

except Exception as e:
    print(f"Đã xảy ra lỗi: {e}")
    # driver.save_screenshot("error_logout.png") # Chụp ảnh màn hình khi lỗi để debug
    # print("Đã lưu ảnh chụp lỗi vào error_logout.png")

finally:
    print("Đóng trình duyệt sau 5 giây...")
    time.sleep(5)
    driver.quit()