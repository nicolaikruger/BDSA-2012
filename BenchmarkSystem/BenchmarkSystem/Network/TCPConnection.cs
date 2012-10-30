using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.IO;


namespace BenchmarkSystem.Network
{
	public class TCPConnection
	{

		int port;
		Socket socket;

		string connectToIP;
		int connectToPort;

		/// <summary>
		/// Creates a connection on the specified port
		/// </summary>
		/// <param name="port">The port to listen to/create the socket on</param>
		public TCPConnection(int port)
		{
			this.port = port;
			socket = new Socket(
				AddressFamily.InterNetwork,
				SocketType.Stream,
				ProtocolType.Tcp);

			Console.WriteLine("Port: " + port);
		}

		/// <summary>
		/// Connects to a spicified IP. The port is by default 8080.
		/// </summary>
		/// <param name="ip">The IP to connect to</param>
		public void connect(string ip)
		{
			connectToIP = ip;
			connectToPort = 8080;
		}

		/// <summary>
		/// Connects to a spicified IP and port.
		/// </summary>
		/// <param name="ip">The IP to connect to</param>
		/// <param name="port">The port connect to</param>
		public void connect(string ip, int port)
		{
			connectToIP = ip;
			connectToPort = port;
		}

		/// <summary>
		/// Disconnect the corrent connection.
		/// </summary>
		private void disconnect()
		{
			if (socket.Connected)
				socket.Disconnect(false);
		}

		/// <summary>
		/// Sends a msg to the connected socket.
		/// </summary>
		/// <param name="msg">The message to be sent</param>
		public void send(string msg)
		{
			connect();

			NetworkStream networkStream = new NetworkStream(socket);
			StreamWriter streamWriter = new StreamWriter(networkStream);

			streamWriter.Write(msg);
			streamWriter.Flush();

			disconnect();
		}

		private void connect()
		{
			disconnect();
			IPAddress endIP = IPAddress.Parse(connectToIP);
			socket.Connect(endIP, connectToPort);
		}

		/// <summary>
		/// Sends a msg to the spcified IP on port 8080.
		/// </summary>
		/// <param name="msg">The message to be sent</param>
		/// <param name="ip">The IP to send the message to</param>
		public void send(string msg, string ip)
		{
			connect(ip);
			send(msg);
		}

		/// <summary>
		/// Sends a msg to the spcified IP and port.
		/// </summary>
		/// <param name="msg">The message to be sent</param>
		/// <param name="ip">The IP to send the message to</param>
		/// <param name="port">The port to send the messsage to</param>
		public void send(string msg, string ip, int port)
		{
			connect(ip, port);
			send(msg);
		}

		/// <summary>
		/// Listen for any incomming messages.
		/// </summary>
		/// <returns>The incomming message as a string</returns>
		public string recieve()
		{
			disconnect();

			IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, port);
			socket.Bind(ipEndPoint);
			socket.Listen(1);

			Socket incommingConnection = socket.Accept();

			NetworkStream networkStream = new NetworkStream(incommingConnection, true);
			StreamReader streamReader = new StreamReader(networkStream);

			string data = streamReader.ReadToEnd();

			return data;
		}
	}
}
