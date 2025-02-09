//env import & config
import dotenv from 'dotenv';
dotenv.config({ path: '../.env' });

import net from 'net';

const port = process.env.serverport || 8080;
const host = process.env.serverhost || 'localhost';

var server = net.createServer(function (socket) {
  socket.write('Echo Server\r\n');
  socket.pipe(socket);
});

server.on('listening', () => {
  console.log(`Server is listening on ${host}:${port}`);
});

server.on('connection', (socket) => {
  console.log(`New connection from ${socket.remoteAddress}:${socket.remotePort}`);
});

server.on('timeout', () => {
  console.log(`Server timeout`);
});

server.on('data', (data) => {
  console.log(`Server data: ${data}`);
});

server.on('close', () => {
  console.log(`All connections to the Server are closed successfully.`);
});

Init()
  .then(() => {
    console.log('Init Completed.');
    server.listen(port, host);
  })
  .catch((error) => {
    console.log(`Initialization error: ${error}`);
  });

  server.on('error', (err) => {
    if (e.code === 'EADDRINUSE') {
      console.error('Address in use, retrying...');
      setTimeout(() => {
        server.close();
        server.listen(port, host);
      }, 1000);
    }
  });

async function Init() {
  console.log('Init Started.');
}
