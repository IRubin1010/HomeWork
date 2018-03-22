import socket

sock = socket.socket()
sock.bind(('0.0.0.0',8820))
sock.listen(1)

(client_socket, client_address) = sock.accept() 
print(client_address)

data = client_socket.recv(1024)
client_socket.send(data)

client_socket.close()
sock.close()


