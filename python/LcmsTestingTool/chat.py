from selenium import webdriver
from selenium.webdriver.firefox.service import Service
from selenium.webdriver.common.by import By
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
import time

# --- CẤU HÌNH ---
# Thay thế bằng thông tin đăng nhập của bạn
YOUR_USERNAME = "2200004759"
YOUR_PASSWORD = "tongminh1"
MESSAGE_TO_SEND = "Đây là tin nhắn tự động được gửi bởi Selenium!"

# Đường dẫn đến geckodriver.exe (chỉ cần nếu không nằm trong PATH)
# GECKO_DRIVER_PATH = r"C:\duong\dan\toi\geckodriver.exe" # Ví dụ trên Windows
GECKO_DRIVER_PATH = None # Để trống nếu geckodriver đã nằm trong PATH

# XPaths bạn cung cấp (LƯU Ý VỀ ID ĐỘNG!)
XPATH_MESSAGE_DRAWER_TOGGLE = "/html/body/div[3]/nav/div[2]/div[2]/a/i"
# LƯU Ý: ID trên có thể động. Một cách tiếp cận tốt hơn có thể là:
# XPATH_MESSAGE_DRAWER_TOGGLE_ALT = "//button[contains(@aria-label, 'Toggle messaging drawer')]"
# Hoặc nếu có class đặc trưng: "//button[contains(@class, 'drawer-toggler') and @data-region='message-drawer-toggle']"
# Bạn cần kiểm tra lại trên trang để tìm XPath ổn định hơn nếu cái trên không hoạt động.

XPATH_CONTACT_LINK = "/html/body/div[3]/div[5]/div/div[3]/div[5]/div/div[1]/div[2]/div[2]/a"
# LƯU Ý: Đây là XPath tuyệt đối, rất dễ hỏng.
# Bạn nên tìm cách xác định người nhận cụ thể hơn, ví dụ dựa vào tên người nhận hoặc ID người dùng nếu có.
# Ví dụ: "//div[contains(@class,'contact') and .//h3[contains(text(),'Tên Người Nhận')]]//a"

XPATH_TEXTAREA = "/html/body/div[3]/div[5]/div/div[4]/div[1]/div[1]/div[2]/textarea"
# LƯU Ý: XPath tuyệt đối. Thử tìm dựa trên placeholder hoặc aria-label
# Ví dụ: "//textarea[@placeholder='Write a message...']"

XPATH_SEND_BUTTON = "/html/body/div[3]/div[5]/div/div[4]/div[1]/div[1]/div[2]/div/button[2]"
# LƯU Ý: XPath tuyệt đối. Thử tìm dựa trên aria-label hoặc icon
# Ví dụ: "//button[@aria-label='Send message']" hoặc "//button[contains(@data-action, 'send-message')]"

# --- KHỞI TẠO WEBDRIVER ---
if GECKO_DRIVER_PATH:
    service = Service(executable_path=GECKO_DRIVER_PATH)
    driver = webdriver.Firefox(service=service)
else:
    driver = webdriver.Firefox() # Geckodriver phải nằm trong PATH

driver.maximize_window()
wait = WebDriverWait(driver, 20) # Chờ tối đa 20 giây

try:
    # 1. Mở trang web
    driver.get("https://lcms.ntt.edu.vn/my/")
    print("Đã mở trang web.")

    # 2. Đăng nhập (Cần điều chỉnh locators nếu cần)
    # Kiểm tra xem trang đã chuyển đến trang đăng nhập của trường hay chưa
    # Trang đăng nhập có thể là lcms.ntt.edu.vn/login/index.php hoặc một URL khác
    if "login.microsoftonline.com" in driver.current_url or "fs.ntt.edu.vn" in driver.current_url:
        print("Đang ở trang đăng nhập Microsoft/Trường...")
        # Xử lý đăng nhập qua Microsoft (có thể cần nhiều bước hơn)
        try:
            # Trường username
            username_field = wait.until(EC.visibility_of_element_located((By.XPATH, "//input[@type='email']")))
            username_field.send_keys(YOUR_USERNAME)
            print(f"Đã nhập username: {YOUR_USERNAME}")
            # Nút "Next" hoặc tương đương
            wait.until(EC.element_to_be_clickable((By.XPATH, "//input[@type='submit']"))).click()
            print("Đã nhấn Next sau khi nhập username.")
            time.sleep(2) # Chờ trang chuyển

            # Trường password
            password_field = wait.until(EC.visibility_of_element_located((By.XPATH, "//input[@type='password']")))
            password_field.send_keys(YOUR_PASSWORD)
            print("Đã nhập password.")
            # Nút "Sign in" hoặc tương đương
            wait.until(EC.element_to_be_clickable((By.XPATH, "//input[@type='submit'][@value='Sign in'] | //button[@type='submit'][contains(.,'Sign in')]"))).click()
            print("Đã nhấn Sign in.")

            # Xử lý màn hình "Stay signed in?" (Nếu có)
            time.sleep(3) # Chờ màn hình "Stay signed in?"
            if "Stay signed in?" in driver.page_source or "Duy trì đăng nhập?" in driver.page_source:
                try:
                    # Nhấn "No" hoặc "Không"
                    stay_signed_in_no_button = wait.until(EC.element_to_be_clickable((By.XPATH, "//input[@id='idBtn_Back'] | //button[contains(.,'No')] | //button[contains(.,'Không')]")))
                    stay_signed_in_no_button.click()
                    print("Đã chọn 'No/Không' cho 'Stay signed in?'.")
                except Exception as e:
                    print(f"Không tìm thấy nút 'No/Không' cho 'Stay signed in?': {e}")
            else:
                print("Không có màn hình 'Stay signed in?'.")

        except Exception as e:
            print(f"Lỗi trong quá trình đăng nhập Microsoft/Trường: {e}")
            driver.save_screenshot("login_error.png")
            raise # Dừng script nếu đăng nhập thất bại

    elif "lcms.ntt.edu.vn/login/index.php" in driver.current_url:
        print("Đang ở trang đăng nhập LCMS...")
        # Trường username
        username_field = wait.until(EC.visibility_of_element_located((By.ID, "username")))
        username_field.send_keys(YOUR_USERNAME)
        print(f"Đã nhập username: {YOUR_USERNAME}")

        # Trường password
        password_field = wait.until(EC.visibility_of_element_located((By.ID, "password")))
        password_field.send_keys(YOUR_PASSWORD)
        print("Đã nhập password.")

        # Nút đăng nhập
        login_button = wait.until(EC.element_to_be_clickable((By.ID, "loginbtn")))
        login_button.click()
        print("Đã nhấn nút đăng nhập.")
    else:
        print("Không nhận diện được trang đăng nhập. Giả sử đã đăng nhập hoặc đang ở trang chủ.")


    # Chờ cho trang dashboard/my load hoàn toàn sau khi đăng nhập
    wait.until(EC.url_to_be("https://lcms.ntt.edu.vn/my/"))
    wait.until(EC.visibility_of_element_located((By.ID, "page-header"))) # Chờ một element đặc trưng của trang my
    print("Đăng nhập thành công và đã vào trang 'my'.")
    time.sleep(3) # Cho phép các script trên trang tải xong

    # 3. Nhấp vào nút mở ngăn tin nhắn
    print(f"Đang tìm nút mở ngăn tin nhắn bằng XPath: {XPATH_MESSAGE_DRAWER_TOGGLE}")
    # Hãy thử XPath bạn cung cấp trước
    try:
        message_drawer_toggle = wait.until(EC.element_to_be_clickable((By.XPATH, XPATH_MESSAGE_DRAWER_TOGGLE)))
    except:
        print(f"Không tìm thấy nút bằng XPath gốc: {XPATH_MESSAGE_DRAWER_TOGGLE}. Thử XPath thay thế...")
        # Thử XPath thay thế nếu có (ví dụ: dựa trên aria-label)
        XPATH_MESSAGE_DRAWER_TOGGLE_ALT = "//button[@data-action='toggle-drawer'][contains(@aria-controls,'message-drawer')]"
        try:
            message_drawer_toggle = wait.until(EC.element_to_be_clickable((By.XPATH, XPATH_MESSAGE_DRAWER_TOGGLE_ALT)))
            print(f"Đã tìm thấy nút bằng XPath thay thế: {XPATH_MESSAGE_DRAWER_TOGGLE_ALT}")
        except Exception as e:
            print(f"Không thể tìm thấy nút mở ngăn tin nhắn bằng cả hai XPath. Lỗi: {e}")
            driver.save_screenshot("error_opening_message_drawer.png")
            raise

    message_drawer_toggle.click()
    print("Đã nhấp vào nút mở ngăn tin nhắn.")
    time.sleep(2) # Chờ ngăn tin nhắn mở ra

    # 4. Nhấp vào một liên hệ/cuộc trò chuyện
    print(f"Đang tìm liên hệ bằng XPath: {XPATH_CONTACT_LINK}")
    # CẢNH BÁO: XPath này rất có thể không đúng người bạn muốn nhắn!
    # Bạn cần một cách tốt hơn để chọn đúng người nhận.
    # Ví dụ: tìm người dùng theo tên hiển thị hoặc ID
    # contact_link_xpath_better = f"//div[contains(@class,'list-group-item-action')][.//h3[contains(text(),'Tên Người Nhận')]]"
    # contact_link = wait.until(EC.element_to_be_clickable((By.XPATH, contact_link_xpath_better)))
    try:
        contact_link = wait.until(EC.element_to_be_clickable((By.XPATH, XPATH_CONTACT_LINK)))
        contact_link.click()
        print("Đã nhấp vào liên hệ.")
        time.sleep(2) # Chờ khung chat của người đó mở ra
    except Exception as e:
        print(f"Không thể tìm thấy liên hệ bằng XPath: {XPATH_CONTACT_LINK}. Lỗi: {e}")
        print("Kiểm tra lại XPath này, nó có thể chỉ đến người dùng không mong muốn hoặc không tồn tại.")
        driver.save_screenshot("error_clicking_contact.png")
        raise


    # 5. Nhấp vào ô văn bản và nhập tin nhắn
    print(f"Đang tìm ô nhập tin nhắn bằng XPath: {XPATH_TEXTAREA}")
    try:
        message_textbox = wait.until(EC.visibility_of_element_located((By.XPATH, XPATH_TEXTAREA)))
    except:
        print(f"Không tìm thấy ô nhập tin nhắn bằng XPath gốc: {XPATH_TEXTAREA}. Thử XPath thay thế...")
        XPATH_TEXTAREA_ALT = "//textarea[contains(@placeholder,'Viết tin nhắn...') or contains(@aria-label,'Viết tin nhắn')]"
        try:
            message_textbox = wait.until(EC.visibility_of_element_located((By.XPATH, XPATH_TEXTAREA_ALT)))
            print(f"Đã tìm thấy ô nhập tin nhắn bằng XPath thay thế: {XPATH_TEXTAREA_ALT}")
        except Exception as e:
            print(f"Không thể tìm thấy ô nhập tin nhắn. Lỗi: {e}")
            driver.save_screenshot("error_finding_textbox.png")
            raise

    message_textbox.click() # Click để focus nếu cần
    message_textbox.send_keys(MESSAGE_TO_SEND)
    print(f"Đã nhập tin nhắn: '{MESSAGE_TO_SEND}'")
    time.sleep(1)

    # 6. Nhấp vào nút gửi tin nhắn
    print(f"Đang tìm nút gửi tin nhắn bằng XPath: {XPATH_SEND_BUTTON}")
    try:
        send_button = wait.until(EC.element_to_be_clickable((By.XPATH, XPATH_SEND_BUTTON)))
    except:
        print(f"Không tìm thấy nút gửi bằng XPath gốc: {XPATH_SEND_BUTTON}. Thử XPath thay thế...")
        XPATH_SEND_BUTTON_ALT = "//button[@aria-label='Gửi tin nhắn'] | //button[contains(@data-action,'send-message')]"
        # Hoặc nếu nút gửi là button thứ 2 trong một div cụ thể:
        # XPATH_SEND_BUTTON_ALT = "(//div[contains(@class,'d-flex')]/button)[2]" # kiểm tra cẩn thận
        try:
            send_button = wait.until(EC.element_to_be_clickable((By.XPATH, XPATH_SEND_BUTTON_ALT)))
            print(f"Đã tìm thấy nút gửi bằng XPath thay thế: {XPATH_SEND_BUTTON_ALT}")
        except Exception as e:
            print(f"Không thể tìm thấy nút gửi tin nhắn. Lỗi: {e}")
            driver.save_screenshot("error_finding_send_button.png")
            raise

    send_button.click()
    print("Đã nhấp nút gửi tin nhắn.")

    print("Hoàn thành gửi tin nhắn!")
    time.sleep(5) # Chờ xem kết quả

except Exception as e:
    print(f"Đã xảy ra lỗi: {e}")
    driver.save_screenshot("general_error.png")

finally:
    # Đóng trình duyệt
    if driver:
        print("Đang đóng trình duyệt...")
        driver.quit()