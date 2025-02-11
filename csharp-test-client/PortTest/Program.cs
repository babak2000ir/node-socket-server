// See https://aka.ms/new-console-template for more information

using System.Net.Sockets;

if (args.Length < 2)
{
    Console.WriteLine("Please specify a server and port number.");
    return;
}

Connect(args[0], args[1], "Call meee!");

static void Connect(String server, String port, String message)
{
    try
    {
        if (!int.TryParse(port, out int portNumber))
        {
            Console.WriteLine("Port number is not valid.");
            return;
        }

        // Prefer a using declaration to ensure the instance is Disposed later.
        using TcpClient client = new(server, portNumber);

        // Translate the passed message into ASCII and store it as a Byte array.
        Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

        // Get a client stream for reading and writing.
        NetworkStream stream = client.GetStream();

        // Send the message to the connected TcpServer.
        stream.Write(data, 0, data.Length);

        Console.WriteLine("Sent: {0}", message);

        // Receive the server response.

        // Buffer to store the response bytes.
        data = new Byte[256];

        // String to store the response ASCII representation.
        String responseData = String.Empty;

        // Read the first batch of the TcpServer response bytes.
        Int32 bytes = stream.Read(data, 0, data.Length);
        responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
        Console.WriteLine("Received: {0}", responseData);

        // Explicit close is not necessary since TcpClient.Dispose() will be
        // called automatically.
        // stream.Close();
        // client.Close();
    }
    catch (ArgumentNullException e)
    {
        Console.WriteLine("ArgumentNullException: {0}", e);
    }
    catch (SocketException e)
    {
        Console.WriteLine("SocketException: {0}", e);
    }

    Console.WriteLine("\n Press Enter to continue...");
    Console.Read();
}





