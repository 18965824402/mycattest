using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using config;
using Emode_Temporary_data;
using loghelper;
using MySql.Data.MySqlClient;

namespace MySqlHelper
{

    public   class MySqlhelper
    {
        public   MySqlhelper()
        {
            ConnString = TemporaryData.mysqlconn[0];

        }

        LogClass log = new LogClass();
        /// <summary>
        /// 数据库连接
        /// </summary>
        private static MySqlConnection Conndel;

        public static DataSet ds = null;

        public static string ConnString = "";

        public static string Iorder = "";
        /// <summary>
        /// 读取配置文件
        /// </summary>
        Config config=new Config();
        /// <summary>
        /// 打开数据库连接
        /// </summary>
        /// <returns></returns>
        public   void Open()
        {
            try
            {

                ConnString = config.GetXmlValue("mysqlconn", "Information");
              
                Conndel = new MySqlConnection(string.Format("{0}", ConnString));
                if (Conndel.State != ConnectionState.Open)
                {
                    Conndel.Open();
                }
                log.WriteLogFile("数据库连接成功");
             }
            catch (System.Exception e)
            {
                log.WriteLogFile(string.Format("数据库连接失败,检查网络连接!\r\n{0}", e.Message));
             }
        }

        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        /// <returns></returns>
        public   void Openclose()
        {
            //从配置文件中获取连接字符串
            //配置文件需要放在项目目录下的bin\Release中
            try
            {
                if (Conndel.State == ConnectionState.Open)
                {
                    Conndel.Close();
                }
                log.WriteLogFile(string.Format("数据库关闭成功"));

             }
            catch (System.Exception e)
            {
                log.WriteLogFile(string.Format("数据库连接失败,检查网络连接!\r\n{0}", e.Message));

             }
        }

        /// <summary>
        /// 执行sql语句，返回dataset
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public   DataSet ReturnRecordSet(string sql)
        {
            DataSet dss = new DataSet();
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter(sql, ConnString);
                da.Fill(dss);
                Openclose();
                log.WriteLogFile(string.Format("sql语句执行完毕{0}",sql));
            }
            catch (Exception e)
            {
                log.WriteLogFile(string.Format("sql语句执行失败,检查问题!\r\n{0}\r\n{1}",sql, e.Message));
                throw;
            }
            return dss;
        }

        /// <summary>
        /// 执行sql语句，返回影响行数
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public   int ExecuteRecordSet(string sql)
        {
            try
            {

         
            Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = Conndel;
            cmd.CommandTimeout = 1000;
            cmd.CommandText = sql;
            int result = cmd.ExecuteNonQuery();
                 
            Openclose();
            log.WriteLogFile(string.Format("sql语句执行完毕{0}", sql));

            return result;
            }
            catch (Exception e)
            {
                log.WriteLogFile(string.Format("sql语句执行失败,检查问题!\r\n{0}\r\n{1}", sql, e.Message));
                throw;
            }
      
        }

        /// <summary>
        /// 执行sql语句 返回datatable
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable ExecuteReturnDatatable(string sql)
        {

            DataSet dss = new DataSet();
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter(sql, ConnString);
                da.Fill(dss);
                da.Dispose();
                //_dsTable = new DataTable();
                //using (MySqlDataAdapter myAdapter = new MySqlDataAdapter(sql, ConnString))
                //{

                //    //_dataAdapter = new MySqlDataAdapter(sql,ConnString);
                //    myAdapter.Fill(_dsTable); 
                //}

            }
            catch (Exception e)
            {
                log.WriteLogFile(string.Format("sql语句执行失败,检查问题!\r\n{0}\r\n{1}", sql, e.Message));
                throw;
            }
            return dss.Tables[0];
        }
        /// <summary>
        /// 登录用户专用，用到了其他数据库
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable loginExecuteReturnDatatable(string sql, string connstr)
        {

            DataSet dss = new DataSet();
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connstr);
                da.Fill(dss);
                da.Dispose();
                //_dsTable = new DataTable();
                //using (MySqlDataAdapter myAdapter = new MySqlDataAdapter(sql, ConnString))
                //{

                //    //_dataAdapter = new MySqlDataAdapter(sql,ConnString);
                //    myAdapter.Fill(_dsTable); 
                //}

            }
            catch (Exception e)
            {
                log.WriteLogFile(string.Format("sql语句执行失败,检查问题!\r\n{0}\r\n{1}", sql, e.Message));
                throw;
            }
            return dss.Tables[0];
        }
        /// <summary>  
        /// 执行多条SQL语句，实现数据库事务。  
        /// </summary>mysql数据库  
        /// <param name="sqlStringList">多条SQL语句</param>  
        public void BeginTransactions(ArrayList sqlStringList)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnString))
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                MySqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                cmd.CommandTimeout = 100;
                try
                {
                    int n = 0;
                    foreach (var strsql in sqlStringList)
                    {
                        if (strsql.ToString().Length > 10)
                        { 
                            cmd.CommandText = strsql.ToString();
                            cmd.ExecuteNonQuery(); 
                        } 
                        n++;
                    }
                    tx.Commit();//原来一次性提交  
                }
                catch (Exception e)
                {
                    foreach (var strsql in sqlStringList)
                    {
                        log.WriteLogFile(string.Format("sql语句执行失败,检查问题!\r\n{0}", strsql));
                    }
                    log.WriteLogFile(string.Format("sql语句执行失败,检查问题!\r\n{0}", e.Message));
                    tx.Rollback();
                    throw new Exception(e.Message);

                }
                //conn.Close();
            }
            //conn.Close();
        }
    }
}
