


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using Dapper;
using MyCat.Data.MyCatClient;

namespace ConsoleApp1
{



	class Program
	{
		static void Main(string[] args)
		{


			for (int i = 0; i <200 ; i++)

			{

				//   ThreadStart threadStart = new ThreadStart(dddd);

				Thread thread = new Thread(new System.Threading.ParameterizedThreadStart(dddd));

				thread.Start(i);
				Console.WriteLine(i);
			}


			Console.ReadKey();



		}
	
		static void dddd(object arg)
		{
		
			//try
			//{
				for (var i = 0; i < 1; i++)
				{


				using (var conn = new MyCatConnection("server=localhost;port=8066;database=TESTDB;uid=root;pwd=123456;CharSet=utf8;pooling=true;Allow User Variables=True"))
				{
				int a=   conn.Execute("INSERT INTO `test` (`name`) VALUES ( '" + System.DateTime.Now.ToString() + "')");
					Console.WriteLine(a);
					int b = conn.Execute("INSERT INTO `test` (`name`) VALUES ( '" + System.DateTime.Now.ToString() + "')");
					Console.WriteLine(b);

					//int c = conn.Execute("select count(0)  from   `test` ");
					//Console.WriteLine(c);


				}


				//using (var conn = new MyCatConnection("server=localhost;port=8066;database=TESTDB;uid=root;pwd=123456;CharSet=utf8;pooling=true;Allow User Variables=True"))
				//{



				//}




				//	MyCatConnection conn = new MyCatConnection("server=localhost;port=8066;database=TESTDB;uid=root;pwd=123456;CharSet=utf8;pooling=true;Allow User Variables=True");



				//	using (MyCatConnection conn = new MyCatConnection("server=localhost;port=8066;database=TESTDB;uid=root;pwd=123456;CharSet=utf8;pooling=true;Allow User Variables=True"))
				//	{
				//conn("INSERT INTO `test` (`name`) VALUES ( '" + System.DateTime.Now.ToString() + "')");


				//	conn.Open();

				//	var cmd = new MyCatCommand("INSERT INTO `test` (`name`) VALUES ( '" + System.DateTime.Now.ToString() + "')", conn);

				//	cmd.ExecuteNonQuery();
				//	conn.Close();
				//	}
				//if(conn==null)
				//	 conn = new MyCatConnection("server=localhost;port=8066;database=TESTDB;uid=root;pwd=123456;CharSet=utf8;pooling=true;Connection Timeout=10");



				//	conn.Query("select  name  from `test`");

				//Thread.Sleep(3000);
				dddd222();
				//Console.WriteLine(i);
			}
			//}
			//catch (Exception ex)
			//{
			//	//if(a==0)
			//	//{
			//	//	dddd( arg);
			//	//	return;
			//	//}
			//	//a++;
				
			//	Console.WriteLine(ex.ToString());
			//	Write(ex.ToString());
			//}






			//for (int i = 0; i < 1; i++)

			//{
			//	//
			//	var conn = new MyCatConnection("server=localhost;port=8066;database=TESTDB;uid=root;pwd=123456;CharSet=utf8;pooling=true;Connection Timeout=10");

			//		conn.Open();

			//	var cmd = new MyCatCommand("INSERT INTO `test` (`name`) VALUES ( '" + System.DateTime.Now.ToString() + "')", conn);

			//		cmd.ExecuteNonQuery();


			//		conn.Close();



			//	//using (var conn = new MySqlConnection("server=localhost;port=3306;database=acdb;uid=root;pwd=123456;CharSet=utf8;pooling=true"))
			//	//{
			//	//	//	conn.Execute("INSERT INTO `test` (`name`) VALUES ( '" + System.DateTime.Now.ToString() + "')");
			//	//	conn.Execute("INSERT INTO `test` (`taskid`,`taskid2`,`dtime`) VALUES ('" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fffffff") + "'," + 0 + ", '" + System.DateTime.Now.ToString() + "')");



			//}


			//}
		}


		static void dddd222()
		{

			using (var conn = new MyCatConnection("server=localhost;port=8066;database=TESTDB;uid=root;pwd=123456;CharSet=utf8;pooling=true;Allow User Variables=True"))
			{
				int a = conn.Execute("INSERT INTO `test` (`name`) VALUES ( '" + System.DateTime.Now.ToString() + "')");
				Console.WriteLine(a);
				//int b = conn.Execute("INSERT INTO `test` (`name`) VALUES ( '" + System.DateTime.Now.ToString() + "')");
				//Console.WriteLine(b);

				//int c = conn.Execute("select count(0)  from   `test` ");
				//Console.WriteLine(c);


			}
			////int a = 0;
			//////try
			//////{
			////for (var i = 0; i < 1; i++)
			////{

			////	using (MyCatConnection conn = new MyCatConnection("server=localhost;port=8066;database=TESTDB;uid=root;pwd=123456;CharSet=utf8;pooling=true;Allow User Variables=True"))
			////	{
			////		//conn("INSERT INTO `test` (`name`) VALUES ( '" + System.DateTime.Now.ToString() + "')");


			////		conn.Open();

			////		var cmd = new MyCatCommand("INSERT INTO `test` (`name`) VALUES ( '" + System.DateTime.Now.ToString() + "')", conn);

			////		cmd.ExecuteNonQuery();

			////	}

			////	//using (var conn = new MyCatConnection("server=localhost;port=8066;database=TESTDB;uid=root;pwd=123456;CharSet=utf8;pooling=true;Connection Timeout=10"))
			////	//{
			////	//	conn.Open();

			////	//	var command = new MyCatCommand("INSERT INTO `test` (`name`) VALUES ( '" + System.DateTime.Now.ToString() + "')", conn);
			////	//	//command.ExecuteReader("select  *  from `test`");
			////	//	conn.Query("select  name  from `test`");

			////	//	command.ExecuteNonQuery();

			////	//}
			////	//if (conn == null)
			////	//	conn = new MyCatConnection("server=localhost;port=8066;database=TESTDB;uid=root;pwd=123456;CharSet=utf8;pooling=true;Connection Timeout=10");

			////	//	var conn = new MyCatConnection("server=localhost;port=8066;database=TESTDB;uid=root;pwd=123456;CharSet=utf8;pooling=true;Connection Timeout=10");
			////	//	conn.Execute("INSERT INTO `test` (`name`) VALUES ( '" + System.DateTime.Now.ToString() + "')");


			////	//	conn.Query("select  name  from `test`");

			////}
			//////}
			//////catch (Exception ex)
			//////{

			//////	//if (a == 0)
			//////	//{
			//////	//	dddd222();
			//////	//	return;
			//////	//}
			//////	//a++;

			//////	Console.WriteLine(ex.ToString());

			//////	Write(ex.ToString());
			//////}






			//////for (int i = 0; i < 1; i++)

			//////{
			//////	//
			//////	var conn = new MyCatConnection("server=localhost;port=8066;database=TESTDB;uid=root;pwd=123456;CharSet=utf8;pooling=true;Connection Timeout=10");

			//////		conn.Open();

			//////	var cmd = new MyCatCommand("INSERT INTO `test` (`name`) VALUES ( '" + System.DateTime.Now.ToString() + "')", conn);

			//////		cmd.ExecuteNonQuery();


			//////		conn.Close();



			//////	//using (var conn = new MySqlConnection("server=localhost;port=3306;database=acdb;uid=root;pwd=123456;CharSet=utf8;pooling=true"))
			//////	//{
			//////	//	//	conn.Execute("INSERT INTO `test` (`name`) VALUES ( '" + System.DateTime.Now.ToString() + "')");
			//////	//	conn.Execute("INSERT INTO `test` (`taskid`,`taskid2`,`dtime`) VALUES ('" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fffffff") + "'," + 0 + ", '" + System.DateTime.Now.ToString() + "')");



			//////}


			//////}
		}

		static void Write(string a)
		{
			CreateErrorLog(a);

			//FileStream fs = new FileStream(@"C:\Users\admin\Desktop\MyCATConnector-master\ConsoleApp1\ak.txt", FileMode.Create);
			////获得字节数组
			//byte[] data = System.Text.Encoding.Default.GetBytes(a);
			////开始写入
			//fs.Write(data, 0, data.Length);
			////清空缓冲区、关闭流
			//fs.Flush();
			//fs.Close();


			//StreamWriter sw = File.AppendText(@"C:\Users\admin\Desktop\MyCATConnector-master\ConsoleApp1\ak.txt");
			//sw.Encoding= Encoding.UTF8;
			//sw.WriteLine(a+ "\n");



			//sw.WriteLine(DateTime.Now.ToString()+ "\n");

			//sw.Flush();

			//sw.Close();


		}


		private static string m_fileName = @"C:\Users\admin\Desktop\MyCATConnector-master\ConsoleApp1\" + DateTime.Now.ToString("yyyyMMdd") + ".log";
		public static String FileName
		{
			get { return (m_fileName); }
			set { if (value != null || value != "") { m_fileName = value; } }
		}

		public static void CreateErrorLog(string message)
		{
			if (File.Exists(m_fileName))
			{
				///如果日志文件已经存在，则直接写入日志文件
				StreamWriter sr = File.AppendText(FileName);
				sr.WriteLine("\n");
				sr.WriteLine(DateTime.Now.ToString() + message);
				sr.Close();
			}
			else
			{
				///创建日志文件
				StreamWriter sr = File.CreateText(FileName);
				sr.WriteLine("\n");
				sr.WriteLine(DateTime.Now.ToString() + message);
				sr.Close();
			}
		}



	}
}
