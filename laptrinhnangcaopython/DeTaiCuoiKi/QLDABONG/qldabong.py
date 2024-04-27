from tkinter import *
from tkinter import messagebox

def check_login():
    # Lấy giá trị tài khoản và mật khẩu từ entry widgets
    username = username_entry.get()
    password = password_entry.get()

    # Kiểm tra tài khoản và mật khẩu
    if username == "admin" and password == "123":
        messagebox.showinfo("Thông báo", "Đăng nhập thành công!")
        open_new_window()
    else:
        messagebox.showerror("Lỗi", "Tài khoản hoặc mật khẩu không chính xác.")

def open_new_window():
    # Tạo một cửa sổ mới
    new_window = Toplevel(root)
    new_window.title("Cửa sổ mới")

    # Thêm các phần tử vào cửa sổ mới
    label = Label(new_window, text="Chào mừng bạn đã đăng nhập thành công!")
    label.pack()

    # Tạo một Text widget để hiển thị nội dung có thể cuộn
    text = Text(new_window, wrap="word", height=10, width=40)
    text.pack(side="left", fill="both", expand=True)

    # Tạo một Scrollbar
    scrollbar = Scrollbar(new_window, orient="vertical", command=text.yview)
    scrollbar.pack(side="right", fill="y")

    # Liên kết Scrollbar với Text widget
    text.config(yscrollcommand=scrollbar.set)


# Tạo cửa sổ gốc
root = Tk()
root.title("Đăng nhập")

# Tạo các phần tử trên cửa sổ gốc
username_label = Label(root, text="Tài khoản:")
username_label.grid(row=0, column=0, padx=10, pady=5)
username_entry = Entry(root)
username_entry.grid(row=0, column=1, padx=10, pady=5)

password_label = Label(root, text="Mật khẩu:")
password_label.grid(row=1, column=0, padx=10, pady=5)
password_entry = Entry(root, show="*")
password_entry.grid(row=1, column=1, padx=10, pady=5)

login_button = Button(root, text="Đăng nhập", command=check_login)
login_button.grid(row=2, columnspan=2, padx=10, pady=5)


root.mainloop()