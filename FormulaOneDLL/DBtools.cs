using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Data;


namespace FormulaOneDLL
{
    public class DBtools
    {
        public DBtools() { }

        public const string QUERYPATH = @"C:\data\F1\queries\";
        public const string DBPATH = @"C:\data\F1\";
        public const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + DBPATH + "FormulaOne.mdf;Integrated Security=True";
        //private static string RESTORE_CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + DBPATH + @"FormulaOne.bak; Integrated Security=True";

        public void ExecuteSqlScript(string sqlScriptName)
        {
            var fileContent = File.ReadAllText(QUERYPATH + sqlScriptName);
            fileContent = fileContent.Replace("\r\n", "");
            fileContent = fileContent.Replace("\r", "");
            fileContent = fileContent.Replace("\n", "");
            fileContent = fileContent.Replace("\t", "");
            var sqlqueries = fileContent.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

            var con = new SqlConnection(CONNECTION_STRING);
            var cmd = new SqlCommand("query", con);
            con.Open(); int i = 0;
            foreach (var query in sqlqueries)
            {
                cmd.CommandText = query; i++;
                try
                {
                    cmd.ExecuteNonQuery();
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                catch (SqlException err)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Errore in esecuzione della query numero: " + i);
                    Console.WriteLine("\tErrore SQL: " + err.Number + " - " + err.Message);
                }
            }
            con.Close();
        }
        public void DropTable(string tableName)
        {
            var con = new SqlConnection(CONNECTION_STRING);
            var cmd = new SqlCommand("Drop Table " + tableName + ";", con);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                Console.ForegroundColor = ConsoleColor.Green;
            }
            catch (SqlException err)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tErrore SQL: " + err.Number + " - " + err.Message);
            }
            con.Close();
        }
        public void DBBackup()
        {
            try
            {
                using (SqlConnection dbConn = new SqlConnection())
                {
                    dbConn.ConnectionString = CONNECTION_STRING;
                    dbConn.Open();

                    using (SqlCommand multiuser_rollback_dbcomm = new SqlCommand())
                    {
                        multiuser_rollback_dbcomm.Connection = dbConn;
                        multiuser_rollback_dbcomm.CommandText = @"ALTER DATABASE [" + DBPATH + "FormulaOne.mdf] SET MULTI_USER WITH ROLLBACK IMMEDIATE";

                        multiuser_rollback_dbcomm.ExecuteNonQuery();
                    }
                    dbConn.Close();
                }

                SqlConnection.ClearAllPools();

                using (SqlConnection backupConn = new SqlConnection())
                {
                    backupConn.ConnectionString = CONNECTION_STRING;
                    backupConn.Open();

                    using (SqlCommand backupcomm = new SqlCommand())
                    {
                        File.Delete(DBPATH + "FormulaOne_Backup.bak");
                        backupcomm.Connection = backupConn;
                        backupcomm.CommandText = @"BACKUP DATABASE [" + DBPATH + "FormulaOne.mdf] TO DISK='" + DBPATH + @"FormulaOne_Backup.bak'";
                        backupcomm.ExecuteNonQuery();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Backup database Success");
                    }
                    backupConn.Close();
                }
            }

            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Backup database Failed");
                Console.WriteLine(ex.Message);
            }
        }

        public void DBRestore()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
                {
                    con.Open();
                    string sqlStmt2 = string.Format(@"ALTER DATABASE [" + DBPATH + "FormulaOne.mdf] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                    SqlCommand bu2 = new SqlCommand(sqlStmt2, con);
                    bu2.ExecuteNonQuery();

                    string sqlStmt3 = @"USE MASTER RESTORE DATABASE [" + DBPATH + "FormulaOne.mdf] FROM DISK='" + DBPATH + @"FormulaOne_Backup.bak' WITH REPLACE;";
                    SqlCommand bu3 = new SqlCommand(sqlStmt3, con);
                    bu3.ExecuteNonQuery();

                    string sqlStmt4 = string.Format(@"ALTER DATABASE [" + DBPATH + "FormulaOne.mdf] SET MULTI_USER");
                    SqlCommand bu4 = new SqlCommand(sqlStmt4, con);
                    bu4.ExecuteNonQuery();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Restore database Success");
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Restore database Failed");
                Console.WriteLine(ex.ToString());
            }
        }

        public List<string> GetTableList()
        {
            List<string> lst = new List<string>();
            var con = new SqlConnection(CONNECTION_STRING);
            con.Open();
            try
            {
                var command = new SqlCommand();
                command.Connection = con;
                command.CommandText = @"SELECT  Name from Sysobjects where xtype = 'u' ";
                command.ExecuteNonQuery();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(0) );
                    lst.Add($"{reader.GetString(0)}");
                }
            }

            catch (SqlException err)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + err.Message);
            }
            con.Close();
            return lst;
        }

        public List<string> GetHeaders(string Table)
        {
            List<string> lst = new List<string>();
            var con = new SqlConnection(CONNECTION_STRING);
            con.Open();
            try
            {
                var command = new SqlCommand();
                command.Connection = con;
                command.CommandText = @"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '"+Table+"' ORDER BY ORDINAL_POSITION";
                command.ExecuteNonQuery();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(0));
                    lst.Add($"{reader.GetString(0)}");
                }
            }

            catch (SqlException err)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + err.Message);
            }
            con.Close();
            return lst;
        }

        public DataTable GetData(string table,string orederBy,string orederByMode)
        {
            DataTable tableData = new DataTable();
            SqlConnection con = new SqlConnection(CONNECTION_STRING);
            string sql = $"SELECT * FROM  {table}  ORDER BY {orederBy} {orederByMode};";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(tableData);

            con.Close();

            da.Dispose();
            return tableData;
        }
    }
}