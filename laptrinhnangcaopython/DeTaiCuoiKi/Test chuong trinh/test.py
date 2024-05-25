import tkinter as tk
from tkinter import messagebox, ttk
from PIL import Image, ImageTk

# Giả sử bạn có dữ liệu đội bóng từ database
teams = ["Đội A", "Đội B", "Đội C"]  # Thay thế bằng dữ liệu thực tế

class LoginApp(tk.Tk):
    def __init__(self):
        super().__init__()
        self.title("Login")
        self.geometry('600x400')
        self.configure(bg='#CCEEFF')  # Màu xanh lá pastel
        self.create_widgets()

    def create_widgets(self):
        image = Image.open("bongda.jpg")
        photo = ImageTk.PhotoImage(image)

        canvas = tk.Canvas(self, width=600, height=400)
        canvas.pack(fill="none", expand=True)
        canvas.create_image(0, 0, image=photo, anchor="nw")

        frame = tk.Frame(self, bg='#CCEEFF')
        canvas.create_window(300, 200, window=frame)

        login_label = tk.Label(frame, text="Đăng Nhập", fg='#3C7363', bg="#CCEEFF", font=('aria', 23))
        username_label = tk.Label(frame, text="Tài Khoản", fg='gray1', bg="#CCEEFF", font=('aria', 13))
        self.username_entry = tk.Entry(frame, fg='gray1', bg='snow', font=('aria', 13))
        password_label = tk.Label(frame, text="Mật Khẩu", fg='gray1', bg="#CCEEFF", font=('aria', 13))
        self.password_entry = tk.Entry(frame, show="*", bg='snow', fg='gray1', font=('aria', 13))
        login_button = tk.Button(frame, text="Đăng Nhập", fg='#3C7363', bg="#CCEEFF", 
                               font=('aria', 13), command=self.login)

        login_label.grid(row=0, column=0, columnspan=2, sticky='news', pady=35)
        username_label.grid(row=1, column=0)
        self.username_entry.grid(row=1, column=1, pady=5)
        password_label.grid(row=2, column=0)
        self.password_entry.grid(row=2, column=1, pady=5)
        login_button.grid(row=3, column=0, columnspan=2, pady=15)

    def login(self):
        username = "admin"
        password = "123"
        if self.username_entry.get() == username and self.password_entry.get() == password:
            messagebox.showinfo(title='Login Success', message="You successfully logged in.")
            self.destroy()
            # Hiển thị giao diện Team Management sau khi đăng nhập thành công
            show_team_management()
        else:
            messagebox.showerror(title="Error", message="Invalid login.")


class TeamManagementApp(tk.Tk):
    def __init__(self):
        super().__init__()
        self.title("Quản Lý Đội Bóng")
        self.geometry("400x300")
        self.configure(bg="#CCEEFF")  # Màu xanh lá pastel
        self.create_widgets()

    def create_widgets(self):
        # Tạo frame chứa các nút
        button_frame = tk.Frame(self, bg="#CCEEFF")
        button_frame.pack(pady=20)

        # Nút "Tạo đội bóng"
        create_button = tk.Button(button_frame, text="Tạo đội bóng", command=self.create_team,
                                   bg="#99FFCC", fg="white", font=("Arial", 12))
        create_button.pack(pady=5)

        # Nút "Sửa đội bóng"
        edit_button = tk.Button(button_frame, text="Sửa đội bóng", command=self.edit_team,
                                 bg="#99FFCC", fg="white", font=("Arial", 12))
        edit_button.pack(pady=5)

        # Nút "Xóa đội bóng"
        delete_button = tk.Button(button_frame, text="Xóa đội bóng", command=self.delete_team,
                                   bg="#99FFCC", fg="white", font=("Arial", 12))
        delete_button.pack(pady=5)

        # Frame chứa OptionMenu và nút "Vào đội bóng"
        join_frame = tk.Frame(self, bg="#CCEEFF")
        join_frame.pack()

        # OptionMenu hiển thị danh sách đội bóng
        self.selected_team = tk.StringVar(self)
        self.selected_team.set(teams[0] if teams else "")  # Chọn đội đầu tiên nếu có
        team_option = ttk.OptionMenu(join_frame, self.selected_team, *teams)
        team_option.config(width=20)
        team_option.grid(row=0, column=0, padx=5)

        # Nút "Vào đội bóng"
        join_button = tk.Button(join_frame, text="Vào đội bóng", command=self.join_team,
                                bg="#99FFCC", fg="white", font=("Arial", 12))
        join_button.grid(row=0, column=1, padx=5)

    # Các hàm xử lý sự kiện cho các nút
    def create_team(self):
        messagebox.showinfo("Thông báo", "Chức năng đang được phát triển.")

    def edit_team(self):
        messagebox.showinfo("Thông báo", "Chức năng đang được phát triển.")

    def delete_team(self):
        messagebox.showinfo("Thông báo", "Chức năng đang được phát triển.")

    def join_team(self):
        selected = self.selected_team.get()
        if selected:
            messagebox.showinfo("Thông báo", f"Bạn đã chọn đội: {selected}")

# Hàm để hiển thị giao diện Team Management
def show_team_management():
    team_app = TeamManagementApp()
    team_app.mainloop()

# Biến điều kiện để kiểm tra xem có cần hiển thị login hay không
show_login = True

if __name__ == "__main__":
    if show_login:
        login_app = LoginApp()
        login_app.mainloop()
    else:
        show_team_management()
