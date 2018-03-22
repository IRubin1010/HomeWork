from math import sin
import socket

i = 5
print(i)
print "hii"
sock = socket.socket()
string = input()
# print(string)
sock.connect(('127.0.0.1',1729))
da = bytes('hello world'.encode())
sock.send(string.encode())
data = sock.recv(1024)
if i != 5:
    print('server:  ' + data.decode("utf-8"))
else:
    print('server with else:  ' + data.decode("utf-8"))
sock.close()
