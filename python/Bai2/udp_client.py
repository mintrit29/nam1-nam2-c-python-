import socket

host = socket.gethostname(socket.gethostname())
port = 12345
name = input("Enter your name: ")
byteToSendName = str.encode(name)
password = input("Enter your password: ")
byteToSendPassword = str.encode(password)
bufferSize = 1024
serverAddrPort = (host, port)

s = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
s.connect((host, port))

s.sendto(byteToSendName, (serverAddrPort))
s.sendall(byteToSendPassword, (serverAddrPort))
msg = s.recvfrom(bufferSize)
msg = "Message from server ()".format(msg).encode()
print(msg)