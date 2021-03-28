using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using FormulaOneDLL.Models;

namespace FormulaOneDLL
{
    public class DBtools
    {
        public DBtools() { }

        public const string QUERYPATH = @"C:\data\F1\queries\";
        public const string DBPATH = @"C:\data\F1\";
        public const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + DBPATH + "FormulaOne.mdf;Integrated Security=True;";
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

        public List<string> GetHeaders(string Table)
        {
            List<string> lst = new List<string>();
            var con = new SqlConnection(CONNECTION_STRING);
            con.Open();
            try
            {
                var command = new SqlCommand();
                command.Connection = con;
                command.CommandText = @"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + Table + "' ORDER BY ORDINAL_POSITION";
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

        public DataTable GetData(string table, string orederBy, string orederByMode)
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

        public List<Country> GetData(string table)
        {
            List<Country> lst = new List<Country>();
            var con = new SqlConnection(CONNECTION_STRING);
            con.Open();
            try
            {
                var command = new SqlCommand();
                command.Connection = con;
                command.CommandText = $"SELECT * FROM  {table};";
                command.ExecuteNonQuery();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    lst.Add(new Country(reader.GetString(0), reader.GetString(1)));
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
        public List<Country> GetDataWParam(string table, string paramName, string param)
        {
            List<Country> lst = new List<Country>();
            var con = new SqlConnection(CONNECTION_STRING);
            con.Open();
            try
            {
                var command = new SqlCommand();
                command.Connection = con;
                command.CommandText = $"SELECT * FROM  {table} WHERE {paramName}='{param}';";
                command.ExecuteNonQuery();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    lst.Add(new Country(reader.GetString(0), reader.GetString(1)));
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

        public List<DriverList> GetDataDriverList()
        {
            List<DriverList> lst = new List<DriverList>();
            List<string> ausLst = new List<string>();
            var con = new SqlConnection(CONNECTION_STRING);
            con.Open();
            try
            {
                var command = new SqlCommand();
                command.Connection = con;
                command.CommandText = $"SELECT * FROM  Driver;";
                command.ExecuteNonQuery();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ausLst.Add(reader.GetInt32(0).ToString());
                    ausLst.Add(reader.GetString(1));
                    ausLst.Add(reader.GetString(2));
                    ausLst.Add(reader.GetString(3));
                    ausLst.Add("https://www.countryflags.io/" + reader.GetString(4) + "/flat/64.png");
                    ausLst.Add(reader.GetString(7));
                }
                reader.Close();

                int postGenElN = 0;
                int len = ausLst.Count();
                for (int i = 0; i < len; i += 6)
                {
                    var cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = $"SELECT teamFullName,HEXcolour,RGBcolour FROM Team WHERE Team.teamCode='{ausLst[i + 3]}';";
                    cmd.ExecuteNonQuery();

                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ausLst.Add(reader.GetString(0));
                        ausLst.Add(reader.GetString(1));
                        ausLst.Add(reader.GetString(2));
                        postGenElN += 3;
                    }
                    reader.Close();
                }

                int y = 1;
                for (int i = 0; i < ausLst.Count(); i += 6)
                {
                    lst.Add(new DriverList(int.Parse(ausLst[i]), ausLst[i + 1], ausLst[i + 2], ausLst[((ausLst.Count() - 1) - postGenElN) + y + 1], ausLst[((ausLst.Count() - 1) - postGenElN) + y + 2], ausLst[i + 4], ausLst[((ausLst.Count() - 1) - postGenElN) + y], ausLst[i + 5]));
                    y += 3;
                }
            }

            catch (Exception err)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + err.Message);
            }
            con.Close();
            return lst;
        }

        public List<TeamList> GetDataTeamList()
        {
            List<TeamList> lst = new List<TeamList>();
            List<Driver> lstD = new List<Driver>();
            List<Team> lstT = new List<Team>();
            var con = new SqlConnection(CONNECTION_STRING);
            con.Open();
            try
            {
                var command = new SqlCommand();
                command.Connection = con;
                command.CommandText = $"SELECT * FROM  Team;";
                command.ExecuteNonQuery();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    lstT.Add(new Team(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),reader.GetInt32(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetString(9), reader.GetString(10)));
                }
                reader.Close();

                for (int i = 0; i < lstT.Count(); i++)
                {
                    var cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = $"SELECT * FROM Driver WHERE teamCode='{lstT[i].teamCode}' ORDER BY teamCode;";
                    cmd.ExecuteNonQuery();

                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        lstD.Add(new Driver(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetString(7),reader.GetInt32(8)));
                    }
                    reader.Close();
                }

                for (int i = 0; i < lstT.Count(); i ++)
                {
                    string driver1="";
                    string driver2="";
                    string img1="";
                    string img2="";
                    for (int j = 0; j < lstD.Count(); j++)
                    {
                        if (lstT[i].teamCode == lstD[j].teamCode)
                            if (lstD[j].driverNumber!=51 && lstD[j].driverNumber != 27 && lstD[j].driverNumber != 89) {
                                if (driver1 == "")
                                {
                                    driver1 = lstD[j].driverName + "-" + lstD[j].driverSurname + "-" + lstD[j].driverNumber;
                                    img1 = lstD[j].img;
                                }
                                else
                                {
                                    driver2 = lstD[j].driverName + "-" + lstD[j].driverSurname + "-" + lstD[j].driverNumber;
                                    img2 = lstD[j].img;
                                }
                            }
                    }
                    lst.Add(new TeamList(lstT[i].teamFullName, lstT[i].logo, lstT[i].img, lstT[i].HEXcolour, lstT[i].RGBcolour,driver1,driver2,img1,img2));
                }
            }

            catch (Exception err)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + err.Message);
            }
            con.Close();
            return lst;
        }

        public List<GPlist> GetDataCircuitList()
        {
            List<Circuit> lst = new List<Circuit>();
            List<GP> lst2 = new List<GP>();
            List<GPlist> gpLst = new List<GPlist>();

            var con = new SqlConnection(CONNECTION_STRING);
            con.Open();
            try
            {
                var command = new SqlCommand();
                command.Connection = con;
                command.CommandText = $"SELECT * FROM  Circuit ORDER BY circuitID;";
                command.ExecuteNonQuery();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    lst.Add(new Circuit(
                        reader.GetString(0),
                        reader.GetString(1),
                        $"https://www.countryflags.io/{reader.GetString(2).ToLower()}/flat/64.png",
                        reader.GetInt32(3),
                        reader.GetInt32(4),
                        reader.GetString(5),
                        reader.GetString(6),
                        reader.GetString(7),
                        reader.GetString(8)));
                }
                reader.Close();

                command.CommandText = $"SELECT * FROM  GP ORDER BY circuitID;";
                command.ExecuteNonQuery();

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    lst2.Add(new GP(
                        reader.GetString(0),
                        reader.GetString(1),
                        reader.GetInt32(2),
                        reader.GetString(3)));
                }
                reader.Close();

                for (int i = 0; i < lst2.Count(); i++)
                {
                    for (int j = 0; j < lst.Count(); j++)
                    {
                        if(lst2[i].circuitId==lst[j].id)
                        {
                            gpLst.Add(new GPlist(lst2[i].gpId,lst[j].id,lst[j].circuitName,lst[j].flag,lst[j].turnNumber,lst[j].circuitLen,lst[j].firstGpYear,$"{lst[j].fastestLapTime}-{lst[j].fastestLapPilot}-{lst[j].fastestLapYear}",lst[j].thumbIMG,lst[j].fullIMG,lst2[i].gpName,lst2[i].lapNumber));
                            break;
                        }
                    }
                }
            }
            catch (Exception err)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + err.Message);
            }
            con.Close();
            gpLst.Sort((p, q) => int.Parse(p.gpId.Split('p')[1]).CompareTo(int.Parse(q.gpId.Split('p')[1])));
            return gpLst;
        }
        public List<Circuit> GetDataCircuitList(string param,string val)
        {
            List<Circuit> lst = new List<Circuit>();

            var con = new SqlConnection(CONNECTION_STRING);
            con.Open();
            try
            {
                var command = new SqlCommand();
                command.Connection = con;
                command.CommandText = $"SELECT * FROM  Circuit WHERE {param}='{val}';";
                command.ExecuteNonQuery();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    lst.Add(new Circuit(
                        reader.GetString(0),
                        reader.GetString(1),
                        $"https://www.countryflags.io/{reader.GetString(2).ToLower()}/flat/64.png",
                        reader.GetInt32(3),
                        reader.GetInt32(4),
                        reader.GetString(5),
                        reader.GetString(6),
                        reader.GetString(7),
                        reader.GetString(8)));
                }
                reader.Close();


            }
            catch (Exception err)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + err.Message);
            }
            con.Close();
            return lst;
        }

        public List<RaceWinnerList> GetRaceWinnerList()
        {
            List<RaceWinnerList> raceWlst = new List<RaceWinnerList>();
            List<RaceResults> listRR = new List<RaceResults>();
            List<GP> GPlist = new List<GP>();

            var con = new SqlConnection(CONNECTION_STRING);
            con.Open();
            try
            {
                var command = new SqlCommand();
                command.Connection = con;
                command.CommandText = $"SELECT * FROM  GPResult WHERE place='1';";
                command.ExecuteNonQuery();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listRR.Add(new RaceResults(reader.GetInt32(0),reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5)));
                }
                reader.Close();
                listRR.Sort((p, q) => int.Parse(p.gpID.Split('p')[1]).CompareTo(int.Parse(q.gpID.Split('p')[1])));

                command.CommandText = $"SELECT * FROM  GP;";
                command.ExecuteNonQuery();

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    GPlist.Add(new GP(reader.GetString(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3)));
                }
                reader.Close();
                GPlist.Sort((p, q) => int.Parse(p.gpId.Split('p')[1]).CompareTo(int.Parse(q.gpId.Split('p')[1])));

                for (int i = 0; i < listRR.Count(); i++)
                {
                    string teamName="";
                    string pilot="";

                    command.CommandText = $"SELECT driverName,driverSurname FROM  Driver WHERE driverNumber={listRR[i].driverNumber};";
                    command.ExecuteNonQuery();

                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        pilot = reader.GetString(0)+"-"+ reader.GetString(1);
                    }
                    reader.Close();


                    command.CommandText = $"SELECT teamFullName FROM Team WHERE teamCode='{listRR[i].teamCode}';";
                    command.ExecuteNonQuery();

                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        teamName = reader.GetString(0);
                    }
                    reader.Close();


                    raceWlst.Add(new RaceWinnerList(GPlist[i].gpId,GPlist[i].gpName,GPlist[i].lapNumber,pilot.Split('-')[0], pilot.Split('-')[1],teamName));
                }
            }
            catch (Exception err)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + err.Message);
            }
            con.Close();

            return raceWlst;
        }

        public List<RaceResults> GetRaceResult()
        {
            List<RaceResults> lst = new List<RaceResults>();
            var con = new SqlConnection(CONNECTION_STRING);
            con.Open();
            try
            {
                var command = new SqlCommand();
                command.Connection = con;
                command.CommandText = $"SELECT * FROM  GPResult;";
                command.ExecuteNonQuery();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    lst.Add(new RaceResults(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5)));
                }
                lst.Sort((p, q) => int.Parse(p.gpID.Split('p')[1]).CompareTo(int.Parse(q.gpID.Split('p')[1])));

            }
            catch (Exception err)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + err.Message);
            }
            con.Close();
            return lst;
        }

        public List<RaceResults> GetRaceResult(string id)
        {
            List<RaceResults> lst = new List<RaceResults>();
            var con = new SqlConnection(CONNECTION_STRING);
            con.Open();
            try
            {
                var command = new SqlCommand();
                command.Connection = con;
                command.CommandText = $"SELECT * FROM  GPResult WHERE gpID='{id}';";
                command.ExecuteNonQuery();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    lst.Add(new RaceResults(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5)));
                }

            }
            catch (Exception err)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + err.Message);
            }
            con.Close();
            return lst;
        }

        public List<PilotRanking> GetPilotRanking()
        {
            List<PilotRanking> lst = new List<PilotRanking>();
            List<RaceResults> listRR = new List<RaceResults>();

            var con = new SqlConnection(CONNECTION_STRING);
            con.Open();
            try
            {
                var command = new SqlCommand();
                command.Connection = con;
                command.CommandText = $"SELECT * FROM GPResult;";
                command.ExecuteNonQuery();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listRR.Add(new RaceResults(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5)));
                }
                listRR.Sort((p, q) => p.driverNumber.CompareTo(q.driverNumber));

                for (int i = 0; i < listRR.Count(); i++)
                {

                }

            }
            catch (Exception err)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + err.Message);
            }
            con.Close();

            return lst;
        }

        public List <driverStats> getDriverStats()
        {
            List<driverStats> driverSlist = new List<driverStats>();

            var con = new SqlConnection(CONNECTION_STRING);
            con.Open();
            try
            {
                var command = new SqlCommand();
                command.Connection = con;
                command.CommandText = $"SELECT s.driverNumber,p.driverName,p.driverSurname,s.totalPoints,s.poleNumber,s.raceWinNumber,s.raceSecondNumber,s.raceThirdNumber,s.podiumNumber,s.fastestLapNumber FROM Stats s,Driver p WHERE s.driverNumber=p.driverNumber ORDER BY totalPoints DESC;";
                command.ExecuteNonQuery();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    driverSlist.Add(new driverStats(reader.GetInt32(0),reader.GetString(1),reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetInt32(7), reader.GetInt32(8), reader.GetInt32(9)));
                }
            }
            catch (Exception err)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + err.Message);
            }

            return driverSlist;
        }

        public List<driverStats> getDriverStats(int driverNumber)
        {
            List<driverStats> driverSlist = new List<driverStats>();

            var con = new SqlConnection(CONNECTION_STRING);
            con.Open();
            try
            {
                var command = new SqlCommand();
                command.Connection = con;
                command.CommandText = $"SELECT s.driverNumber,p.driverName,p.driverSurname,s.totalPoints,s.poleNumber,s.raceWinNumber,s.raceSecondNumber,s.raceThirdNumber,s.podiumNumber,s.fastestLapNumber FROM Stats s,Driver p WHERE s.driverNumber={driverNumber} AND s.driverNumber=p.driverNumber;";
                command.ExecuteNonQuery();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    driverSlist.Add(new driverStats(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetInt32(7), reader.GetInt32(8), reader.GetInt32(9)));
                }
            }
            catch (Exception err)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + err.Message);
            }

            return driverSlist;
        }

    }
}