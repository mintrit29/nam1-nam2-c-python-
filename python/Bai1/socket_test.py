import socket
import datetime

# Tạo socket server
s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
host = socket.gethostname()
port = 12345
print('Server is running...')

# Bind server với địa chỉ và port
s.bind((host, port))

# Server lắng nghe tối đa 5 client cùng lúc
s.listen(5)

while True:
    conn, addr = s.accept()  # Chấp nhận kết nối từ client
    print(f'Connection from {addr}')

    # Nhận họ tên từ client
    name = conn.recv(1024).decode()
    print(f"Client name: {name}")

    # Tạo phản hồi
    current_time = datetime.datetime.now().strftime('%Y-%m-%d %H:%M:%S')
    response = f"{name} connected to server at {current_time}"
    
    # Gửi phản hồi về cho client
    conn.send(response.encode())

    # Đóng kết nối
    conn.close()
