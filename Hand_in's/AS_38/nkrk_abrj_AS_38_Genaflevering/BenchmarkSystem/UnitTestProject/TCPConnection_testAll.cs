using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BenchmarkSystem.Network;
using System.Threading;

namespace UnitTestProject
{
	[TestClass]
	public class TCPConnection_testAll
	{
		[TestMethod]
		public void sendRecieve()
		{
			TCPConnection conn1 = new TCPConnection(8080);
			TCPConnection conn2 = new TCPConnection(8081);
			string v = "";
			Thread t = new Thread(() =>
			{
				v = conn2.recieve();
			});
			t.Start();

			Thread.Sleep(1000);

			conn1.connect("127.0.1.1", 8081);
			conn1.send("test");

			t.Join();

			Assert.AreEqual("test", v);
		}
	}
}
