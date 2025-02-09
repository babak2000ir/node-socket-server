import net from 'net';

const port = 3001;
const host = 'localhost';

const client = new net.Socket();
client.connect(port, host, function () {
  console.log('Connected');
  client.write('Hello, server! Love, Client.');
});

client.on('data', function (data) {
  console.log('Received: ' + data);
  if (data.toString().includes('~¬DROP¬~')) {
    client.destroy(); // kill client after server says DROP
  }
});

client.on('close', function () {
  console.log('Connection closed');
});

