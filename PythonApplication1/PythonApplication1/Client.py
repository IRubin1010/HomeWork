import socket

i = 5
print(i)
sock = socket.socket()
name = input('enter word or line')
# print(string)
sock.connect(('127.0.0.1',8820))
#da = bytes('hello world'.encode())
sock.send(name.encode())
data = sock.recv(1024)
if i != 5:
    print('server:  ' + data.decode("utf-8"))
else:
    print('server with else:  ' + data.decode("utf-8"))
name = input()
sock.close()
