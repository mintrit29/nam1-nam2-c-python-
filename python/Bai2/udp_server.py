import socket

localIP = socket.gethostbyname()
localPort = 12345
buffer = 1024
s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
s.bind((localIP, localPort))
print('UDP SERVER CONNECTED')

di = {'vu:123456', 'an:123456', 'quan:123456'}
while True:
    name, addr = s.recvfrom(buffer)
    password, addr = s.recvfrom(buffer)
    
    name = name.decode()
    password = password.decode()
    msg = ''
    if name not in di:
        msg = 'username not found'
        flags = 0
    for i in di:
        if i == name:
            if di[i] == password:
                msg = 'password found'
                flags = 1
            else:
                msg = 'password not found'
    byteToSend = str.encode(msg)
    s.sendall(byteToSend, addr)
    