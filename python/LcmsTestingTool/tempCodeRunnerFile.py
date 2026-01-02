from selenium import webdriver
from selenium.webdriver.firefox.service import Service as FirefoxService
from webdriver_manager.firefox import GeckoDriverManager
from selenium.webdriver.common.by import By
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
from selenium.common.exceptions import TimeoutException
import time

# --- CẤU HÌNH ---
LOGIN_URL = "https://lcms.ntt.edu.vn/login/index.php"
DASHBOARD_URL = "https://lcms.ntt.edu.vn/my/"

USERNAME = "2200004759" # Thay thế bằng username của bạn
PASSWORD = "tongminh1" # Thay thế bằng password của bạn

# XPaths bạn cung cấp (CẢNH BÁO: Có thể không ổn định)
USER_MENU_XPATH = '//*[@id="user-menu-toggle"]' # ID động này rất có thể sẽ thay đổi
# (NẾU USER_MENU_XPATH không hoạt động, thử: "//a[contains(@class, 'usermenu')]//span[contains(@class, 'avatar')]/parent::a"
# hoặc "//div[contains(@class,'usermenu')]//a[@id='user-menu-toggle']" )


# XPATH cho nút "Ngôn ngữ" (dựa trên vị trí, không ổn định)
LANGUAGE_MENU_ITEM_XPATH_ABSOLUTE = "/html/body/div[3]/nav/div[2]/div[3]/div/div/div/div/div/div[1]/a[7]"
# Gợi ý XPATH ổn định hơn cho "Ngôn ngữ":
# 1. Dựa vào text: "//div[@id='user-action-menu']//a[normalize-space()='Ngôn ngữ']" (nếu menu có id 'user-action-menu')
# 2. Dựa vào icon hoặc class đặc trưng nếu có: "//div[@id='user-action-menu']//a[contains(@class, 'lang') or .//i[contains(@class, 'fa-language')]]"

# XPATH cho tùy chọn "English" (dựa trên vị trí, không ổn định)
ENGLISH_OPTION_XPATH_ABSOLUTE = "/html/body/div[3]/nav/div[2]/div[3]/div/div/div/div/div/div[2]/div/div[3]/a[1]"
# Gợi ý XPATH ổn định hơn cho "English":
# 1. Dựa vào text: "//div[contains(@class, 'dropdown-item') and normalize-space()='English']"
# 2. Dựa vào thuộc tính lang: "//a[@role='menuitem'][@lang='en']"
# 3. Dựa vào text và là con của menu ngôn ngữ: "//div[contains(@data-region, 'user-action-menu')]//a[normalize-space()='English']"
#    (cần kiểm tra data-region của menu ngôn ngữ sau khi nó hiện ra)


# --- KHỞI TẠO WEBDRIVER ---
service = FirefoxService(GeckoDriverManager().install())
driver = webdriver.Firefox(service=service)
driver.maximize_window() # Mở rộng cửa sổ để đảm bảo các element không bị ẩn
wait = WebDriverWait(driver, 20)

try:
    # 1. Đăng nhập
    print(f"Đang truy cập trang đăng nhập: {LOGIN_URL}")
    driver.get(LOGIN_URL)

    if USERNAME and PASSWORD and USERNAME != "TEN_DANG_NHAP_CUA_BAN":
        print("Đang tiến hành đăng nhập...")
        wait.until(EC.presence_of_element_located((By.ID, "username"))).send_keys(USERNAME)
        driver.find_element(By.ID, "password").send_keys(PASSWORD)
        driver.find_element(By.ID, "loginbtn").click()
        
        print(f"Đợi chuyển hướng đến trang dashboard: {DASHBOARD_URL}")
        wait.until(EC.url_to_be(DASHBOARD_URL))
        print("Đăng nhập thành công!")
    else:
        print("USERNAME hoặc PASSWORD chưa được cung cấp. Script sẽ giả định bạn đã đăng nhập.")
        print(f"Đang truy cập: {DASHBOARD_URL}")
        driver.get(DASHBOARD_URL)
        wait.until(EC.url_to_be(DASHBOARD_URL)) # Đảm bảo URL đúng là dashboard
        print("Đã ở trang dashboard (giả định đã đăng nhập).")

    # 2. Click vào menu người dùng để mở dropdown
    print(f"Đang tìm và click vào menu người dùng bằng XPath: {USER_MENU_XPATH}")
    # Thử sử dụng một XPATH ổn định hơn nếu ID động không hoạt động
    # user_menu_toggle_xpath_stable = "//a[contains(@class, 'usermenu') and @role='button']"
    try:
        user_menu_toggle = wait.until(EC.element_to_be_clickable((By.XPATH, USER_MENU_XPATH)))
    except TimeoutException:
        print(f"Không tìm thấy menu người dùng với XPATH động: {USER_MENU_XPATH}. Thử XPATH ổn định hơn...")
        # Thay thế bằng XPATH ổn định hơn bạn tìm được. Ví dụ:
        user_menu_toggle_xpath_stable = "//a[@id='user-menu-toggle']" # Hoặc XPATH khác bạn tìm thấy
        user_menu_toggle = wait.until(EC.element_to_be_clickable((By.XPATH, user_menu_toggle_xpath_stable)))
        print(f"Đã tìm thấy menu người dùng với XPATH ổn định: {user_menu_toggle_xpath_stable}")

    driver.execute_script("arguments[0].click();", user_menu_toggle)
    print("Đã click vào menu người dùng.")
    time.sleep(1) # Chờ menu xổ xuống

    # 3. Click vào mục "Ngôn ngữ"
    print(f"Đang tìm và click vào mục 'Ngôn ngữ' bằng XPath: {LANGUAGE_MENU_ITEM_XPATH_ABSOLUTE}")
    # Sử dụng XPATH ổn định hơn nếu bạn tìm được
    # language_menu_item_xpath_stable = "//div[@id='user-action-menu']//a[normalize-space()='Ngôn ngữ']"
    
    # CHÚ Ý: Mục "Ngôn ngữ" có thể không phải là link trực tiếp mà là một mục mở ra submenu
    # Kiểm tra xem nó có thuộc tính 'aria-haspopup="true"' hoặc class 'dropdown-toggle' không
    
    try:
        language_menu_item = wait.until(EC.element_to_be_clickable((By.XPATH, LANGUAGE_MENU_ITEM_XPATH_ABSOLUTE)))
        # Kiểm tra xem đây có phải là mục mở submenu không
        if language_menu_item.get_attribute("aria-expanded") == "false" or \
           "dropdown-toggle" in language_menu_item.get_attribute("class"):
            print("Mục 'Ngôn ngữ' có vẻ là một submenu. Đang click để mở...")
            driver.execute_script("arguments[0].click();", language_menu_item)
            time.sleep(1) # Chờ submenu ngôn ngữ xuất hiện
        else:
            # Nếu đây là link trực tiếp đến trang chọn ngôn ngữ (ít khả năng)
            print("Mục 'Ngôn ngữ' có vẻ là link trực tiếp. Đang click...")
            driver.execute_script("arguments[0].click();", language_menu_item)
            # Bạn có thể cần đợi trang mới tải nếu nó điều hướng
            # wait.until(EC.url_contains("lang"))
    except Exception as e_lang_menu:
        print(f"Không tìm thấy hoặc không click được mục 'Ngôn ngữ' bằng XPATH: {LANGUAGE_MENU_ITEM_XPATH_ABSOLUTE}")
        print(f"Lỗi: {e_lang_menu}")
        # THỬ XPATH ỔN ĐỊNH HƠN CHO MỤC "NGÔN NGỮ" (nếu XPATH tuyệt đối thất bại)
        print("Thử tìm 'Ngôn ngữ' bằng văn bản...")
        try:
            # Giả sử menu dropdown có ID là 'user-action-menu-menu' hoặc class 'dropdown-menu show'
            language_menu_item_stable = wait.until(EC.element_to_be_clickable(
                (By.XPATH, "//div[contains(@class, 'dropdown-menu') and contains(@class, 'show')]//a[normalize-space()='Ngôn ngữ']")
            ))
            print("Đã tìm thấy 'Ngôn ngữ' bằng văn bản. Đang click...")
            driver.execute_script("arguments[0].click();", language_menu_item_stable)
            time.sleep(1) # Chờ submenu ngôn ngữ xuất hiện
        except Exception as e_lang_stable:
            print(f"Không tìm thấy 'Ngôn ngữ' bằng văn bản. Lỗi: {e_lang_stable}")
            raise # Ném lỗi để dừng script nếu không tìm thấy

    print("Đã click vào mục 'Ngôn ngữ'.")
    

    # 4. Click vào tùy chọn "English"
    print(f"Đang tìm và click vào tùy chọn 'English' bằng XPath: {ENGLISH_OPTION_XPATH_ABSOLUTE}")
    # Sử dụng XPATH ổn định hơn nếu bạn tìm được
    # english_option_xpath_stable = "//div[contains(@class, 'dropdown-menu') and contains(@class, 'show')]//a[@role='menuitem'][normalize-space()='English']"
    # Hoặc: "//a[@role='menuitem'][@lang='en'][normalize-space()='English']"
    
    try:
        english_option = wait.until(EC.element_to_be_clickable((By.XPATH, ENGLISH_OPTION_XPATH_ABSOLUTE)))
    except Exception as e_eng_abs:
        print(f"Không tìm thấy 'English' bằng XPATH tuyệt đối: {ENGLISH_OPTION_XPATH_ABSOLUTE}. Lỗi: {e_eng_abs}")
        print("Thử tìm 'English' bằng văn bản và thuộc tính lang...")
        try:
            # Đảm bảo tìm trong submenu ngôn ngữ đang hiển thị
            english_option = wait.until(EC.element_to_be_clickable(
                (By.XPATH, "//div[contains(@class, 'dropdown-menu') and contains(@class, 'show')]//a[@role='menuitem'][@lang='en' and normalize-space()='English']")
            ))
            print("Đã tìm thấy 'English' bằng văn bản và @lang.")
        except Exception as e_eng_stable:
            print(f"Không tìm thấy 'English' bằng cách ổn định hơn. Lỗi: {e_eng_stable}")
            raise # Ném lỗi để dừng script nếu không tìm thấy

    driver.execute_script("arguments[0].click();", english_option)
    print("Đã click vào tùy chọn 'English'.")

    # 5. Đợi và xác nhận ngôn ngữ đã thay đổi
    # Cách xác nhận: Kiểm tra một đoạn text nào đó trên trang đã chuyển sang tiếng Anh,
    # hoặc URL có thể thay đổi (ví dụ: ?lang=en)
    print("Đang đợi xác nhận ngôn ngữ đã thay đổi...")
    # Ví dụ: tìm nút "Dashboard" hoặc "My courses" bằng tiếng Anh
    try:
        # Chờ cho một phần tử có văn bản tiếng Anh xuất hiện, ví dụ "Dashboard"
        # Hoặc nếu URL thay đổi: wait.until(EC.url_contains("lang=en"))
        wait.until(EC.visibility_of_element_located(
            (By.XPATH, "//*[self::a or self::span or self::div][normalize-space()='Dashboard' or normalize-space()='My courses']")
        ))
        print("Ngôn ngữ đã được thay đổi sang English thành công!")
    except TimeoutException:
        print("Không thể xác nhận ngôn ngữ đã thay đổi sang English (không tìm thấy 'Dashboard' hoặc 'My courses').")
        print("Tuy nhiên, hành động click đã được thực hiện.")

except Exception as e:
    print(f"Đã xảy ra lỗi: {e}")
    timestamp = time.strftime("%Y%m%d-%H%M%S")
    try:
        driver.save_screenshot(f"error_change_language_{timestamp}.png")
        print(f"Đã lưu ảnh chụp lỗi vào error_change_language_{timestamp}.png")
    except Exception as e_ss:
        print(f"Không thể lưu screenshot: {e_ss}")


finally:
    print("Đóng trình duyệt sau 5 giây...")
    time.sleep(5)
    if 'driver' in locals():
        driver.quit()