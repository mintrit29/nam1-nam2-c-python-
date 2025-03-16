import socket

# Tạo socket client
s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
host = socket.gethostname()
port = 12345

# Kết nối đến server
s.connect((host, port))

# Gửi họ tên đến server
name = "Nguyen Van A"
s.send(name.encode())

# Nhận phản hồi từ server
data = s.recv(1024).decode()
print(data)

# Đóng kết nối
s.close()
