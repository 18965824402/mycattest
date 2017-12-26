using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Threading;
using System.Data.Common;

namespace ConsoleApp3
{
	class Program
	{
		static void Main(string[] args)
		{
			//dddd(1);
			for (int i = 0; i < 10000; i++)

			{

				//   ThreadStart threadStart = new ThreadStart(dddd);

				Thread thread = new Thread(new System.Threading.ParameterizedThreadStart(dddd));

				thread.Start(i);
				//Console.WriteLine(i);
			}


			Console.ReadKey();
		}

		static void dddd(object arg)
		{


	


			try
			{
				for (var i = 0; i < 2; i++)
				{

					using (MySqlConnection conn = new MySqlConnection("server=localhost;port=8066;database=TESTDB;uid=root;pwd=123456;CharSet=utf8;pooling=true;Allow User Variables=True"))
					{
					

						conn.Open();
						MySqlTransaction transaction = conn.BeginTransaction();
						var cmd = new MySqlCommand("INSERT INTO `test` (`name`) VALUES ( '" + System.DateTime.Now.ToString() + "')", conn);
					    cmd.Transaction = transaction;
					    var t= 	cmd.ExecuteNonQuery();
						Console.WriteLine(t);
						transaction.Commit();

					}
				


				
				
				}


			
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				//Write(ex.ToString());
			}






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


	}
}
