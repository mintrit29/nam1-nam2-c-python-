import tkinter as tk
from tkinter import ttk

class Player:
    def __init__(self, name, age, position, nationality):
        self.name = name
        self.age = age
        self.position = position
        self.nationality = nationality

class MainApp(tk.Tk):
    def __init__(self):
        super().__init__()
        self.title("Quản lý đội bóng")

        # Dữ liệu mẫu
        self.players = [
            Player("Ronaldo", 38, "Tiền đạo", "Bồ Đào Nha"),
            Player("Messi", 36, "Tiền vệ", "Argentina"),
            Player("Neymar", 31, "Tiền đạo", "Brazil")
        ]

        # Khung danh sách cầu thủ
        self.player_list_frame = tk.Frame(self)
        self.player_list_frame.pack(side=tk.LEFT, padx=10, pady=10)

        self.player_listbox = tk.Listbox(self.player_list_frame)
        for player in self.players:
            self.player_listbox.insert(tk.END, player.name)
        self.player_listbox.bind("<<ListboxSelect>>", self.on_player_select)
        self.player_listbox.pack(fill=tk.BOTH, expand=True)

        # Khung thông tin chi tiết
        self.player_info_frame = tk.Frame(self)
        self.player_info_frame.pack(side=tk.LEFT, padx=10, pady=10)

        self.name_label = tk.Label(self.player_info_frame, text="Tên:")
        self.name_label.pack()
        self.age_label = tk.Label(self.player_info_frame, text="Tuổi:")
        self.age_label.pack()
        self.position_label = tk.Label(self.player_info_frame, text="Vị trí:")
        self.position_label.pack()
        self.nationality_label = tk.Label(self.player_info_frame, text="Quốc tịch:")
        self.nationality_label.pack()

        # Hiển thị thông tin chi tiết khi chọn cầu thủ
    def on_player_select(self, event):
        selection = self.player_listbox.curselection()
        if selection:
            index = selection[0]
            player = self.players[index]
            self.name_label.config(text=f"Tên: {player.name}")
            self.age_label.config(text=f"Tuổi: {player.age}")
            self.position_label.config(text=f"Vị trí: {player.position}")
            self.nationality_label.config(text=f"Quốc tịch: {player.nationality}")

if __name__ == "__main__":
    app = MainApp()
    app.mainloop()