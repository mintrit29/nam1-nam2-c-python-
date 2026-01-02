from selenium import webdriver
from selenium.webdriver.firefox.service import Service as FirefoxService
from webdriver_manager.firefox import GeckoDriverManager
from selenium.webdriver.common.by import By
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
from selenium.common.exceptions import TimeoutException, NoSuchElementException
from selenium.webdriver.common.action_chains import ActionChains # Để gửi phím
import time

# --- Cấu hình ---
forum_url = "https://lcms.ntt.edu.vn/mod/forum/discuss.php?d=2542"
reply_content = "Nội dung được nhập tự động khi textbox đã focus. Cảm ơn!"

# XPATH cho nút gửi (thẻ button cha của span bạn cung cấp)
# Chúng ta sẽ cố gắng tìm nút này bằng cách ổn định hơn, nhưng XPATH này là dự phòng
submit_button_xpath_from_user_parent = "/html/body/div[3]/div[4]/div/div[2]/div/section/div[2]/div/article/div[1]/div/div[2]/div/form/div[2]/button[1]"

# --- Khởi tạo WebDriver ---
service = FirefoxService(GeckoDriverManager().install())
driver = webdriver.Firefox(service=service)
driver.maximize_window()

try:
    driver.get(forum_url)
    print(f"Đã mở trang: {forum_url}")

    input("Vui lòng ĐĂNG NHẬP vào trang web trên trình duyệt vừa mở, sau đó nhấn Enter ở đây để tiếp tục...")
    print("Đang tiếp tục sau khi đăng nhập...")

    # 2. Nhấp vào nút "Phúc đáp"
    print("Đang tìm nút 'Phúc đáp' dựa trên văn bản...")
    possible_reply_xpaths = [
        "(//a[normalize-space()='Phúc đáp'])[1]",
        "(//button[normalize-space()='Phúc đáp'])[1]",
        "(//a[contains(translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), 'phúc đáp')])[1]",
        "(//button[contains(translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), 'phúc đáp')])[1]",
    ]
    reply_button = None
    found_xpath_for_reply = ""
    for xpath_str in possible_reply_xpaths:
        try:
            print(f"Đang thử tìm nút 'Phúc đáp' với XPATH: {xpath_str}")
            element = WebDriverWait(driver, 10).until(
                EC.element_to_be_clickable((By.XPATH, xpath_str))
            )
            if element.is_displayed():
                reply_button = element
                found_xpath_for_reply = xpath_str
                print(f"Đã tìm thấy nút 'Phúc đáp' hiển thị và có thể click với XPATH: {found_xpath_for_reply}")
                break
        except TimeoutException:
            print(f"Không tìm thấy nút 'Phúc đáp' với XPATH: {xpath_str} trong 10 giây.")
        except Exception as e_find:
            print(f"Lỗi khác khi tìm nút 'Phúc đáp' với {xpath_str}: {e_find}")

    if not reply_button:
        print("LỖI: Không thể tìm thấy nút 'Phúc đáp' nào phù hợp trên trang bằng văn bản.")
        driver.save_screenshot(f"error_no_reply_button_found_{time.strftime('%Y%m%d%H%M%S')}.png")
        raise NoSuchElementException("Không tìm thấy nút 'Phúc đáp' nào bằng các XPATH đã thử.")

    print(f"Sử dụng nút 'Phúc đáp' tìm thấy bằng XPATH: {found_xpath_for_reply}")
    driver.execute_script("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", reply_button)
    time.sleep(0.5)
    driver.execute_script("arguments[0].click();", reply_button)
    print("Đã nhấp vào nút 'Phúc đáp'.")

    # Chờ một chút để form phúc đáp và editor (nếu có) tải hoàn toàn
    # và con trỏ được focus vào textbox
    print("Đợi một chút để editor tải và focus...")
    time.sleep(3) # Điều chỉnh thời gian này nếu cần

    # 3. Nhập nội dung vào textbox (giả định đã focus)
    # Để an toàn hơn, chúng ta vẫn nên chuyển vào iframe nếu editor nằm trong đó
    print("Đang cố gắng nhập nội dung vào editor (có thể trong iframe)...")
    try:
        # Thử chuyển vào iframe của editor (Moodle thường dùng ID chứa 'message_ifr')
        # Ngay cả khi đã focus, send_keys vẫn cần đúng context
        WebDriverWait(driver, 10).until(
            EC.frame_to_be_available_and_switch_to_it((By.XPATH, "//iframe[contains(@id, 'message_ifr')]"))
        )
        print("Đã chuyển vào iframe của editor.")
        
        # Bây giờ, phần tử đang focus bên trong iframe chính là editor
        # Sử dụng ActionChains để gửi keys đến phần tử đang active
        actions = ActionChains(driver)
        actions.send_keys(reply_content)
        actions.perform()
        print(f"Đã gửi nội dung (hy vọng vào editor đang focus): '{reply_content}'")

        # Chuyển ra khỏi iframe để tương tác với nút Gửi
        driver.switch_to.default_content()
        print("Đã chuyển ra khỏi iframe.")

    except TimeoutException:
        print("Không tìm thấy iframe editor (ví dụ: 'message_ifr').")
        print("Thử gửi keys trực tiếp vào trang (ít tin cậy hơn nếu editor trong iframe).")
        driver.switch_to.default_content() # Đảm bảo đang ở context chính
        actions = ActionChains(driver)
        actions.send_keys(reply_content)
        actions.perform()
        print(f"Đã gửi nội dung trực tiếp (hy vọng vào editor đang focus): '{reply_content}'")
    except Exception as e_editor:
        print(f"Lỗi khi cố gắng nhập liệu vào editor: {e_editor}")
        # Cố gắng chuyển ra khỏi iframe nếu có lỗi bên trong
        try: driver.switch_to.default_content()
        except: pass
        raise


    # 4. Gửi nội dung bằng cách nhấn nút Gửi
    print("Đang tìm nút 'Gửi bài viết'...")

    # Ưu tiên các XPATH ổn định hơn trước, sau đó đến XPATH bạn cung cấp
    possible_submit_xpaths = [
        "//button[@type='submit'][normalize-space()='Gửi bài viết lên diễn đàn']",
        "//button[@type='submit'][normalize-space()='Gửi bài viết']",
        "//button[normalize-space()='Gửi bài viết lên diễn đàn']",
        "//button[normalize-space()='Gửi bài viết']",
        "//button[contains(text(),'Gửi bài viết') and not(ancestor::*[contains(@style, 'display: none')]) and not(ancestor::*[contains(@class, 'hidden')])]",
        "//button[@name='submitbutton' and not(ancestor::*[contains(@style, 'display: none')]) and not(ancestor::*[contains(@class, 'hidden')])]",
        submit_button_xpath_from_user_parent # XPATH nút button cha từ bạn
    ]

    submit_button = None
    found_xpath_for_submit = ""
    for xpath_str in possible_submit_xpaths:
        try:
            print(f"Đang thử tìm nút 'Gửi bài viết' với XPATH: {xpath_str}")
            element = WebDriverWait(driver, 10).until(
                EC.element_to_be_clickable((By.XPATH, xpath_str))
            )
            if element.is_displayed():
                submit_button = element
                found_xpath_for_submit = xpath_str
                print(f"Đã tìm thấy nút 'Gửi bài viết' hiển thị và có thể click với XPATH: {found_xpath_for_submit}")
                break
            else:
                print(f"Nút 'Gửi bài viết' tìm thấy với XPATH: {xpath_str} nhưng không hiển thị.")
        except TimeoutException:
            print(f"Không tìm thấy nút 'Gửi bài viết' với XPATH: {xpath_str} trong 10 giây.")
        except Exception as e_submit_find:
            print(f"Lỗi khác khi tìm nút 'Gửi bài viết' với {xpath_str}: {e_submit_find}")

    if not submit_button:
        print("LỖI: Không thể tìm thấy nút 'Gửi bài viết' nào phù hợp trên trang.")
        driver.save_screenshot(f"error_no_submit_button_found_{time.strftime('%Y%m%d%H%M%S')}.png")
        raise NoSuchElementException("Không tìm thấy nút 'Gửi bài viết' bằng các XPATH đã thử.")

    print(f"Sử dụng nút 'Gửi bài viết' tìm thấy bằng XPATH: {found_xpath_for_submit}")
    driver.execute_script("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", submit_button)
    time.sleep(0.5)
    driver.execute_script("arguments[0].click();", submit_button)
    print("Đã gửi nội dung phúc đáp lên diễn đàn!")

    print("Hoàn thành! Đợi 10 giây trước khi đóng trình duyệt...")
    time.sleep(10)

except TimeoutException as e_timeout:
    print(f"LỖI TimeoutException: {e_timeout}")
    if driver.window_handles: driver.save_screenshot(f"error_timeout_{time.strftime('%Y%m%d%H%M%S')}.png")
except NoSuchElementException as e_no_such:
    print(f"LỖI NoSuchElementException: {e_no_such}")
    if driver.window_handles: driver.save_screenshot(f"error_nosuch_{time.strftime('%Y%m%d%H%M%S')}.png")
except Exception as e:
    print(f"Đã xảy ra lỗi không xác định: {e}")
    if driver.window_handles: driver.save_screenshot(f"error_unknown_{time.strftime('%Y%m%d%H%M%S')}.png")

finally:
    if 'driver' in locals() and driver.window_handles:
        driver.quit()
        print("Đã đóng trình duyệt.")
    elif 'driver' in locals():
        print("Trình duyệt có thể đã đóng hoặc không thể truy cập.")