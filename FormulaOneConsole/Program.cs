using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Permissions;
using System.Threading;
using FormulaOneDLL;

namespace FormulaOneConsole
{
    class Program {
        public static DBtools DBtoolsInst;

        #region menu(main)
        static void Main(string[] args)
        {
            int[] driverNs = {44,77,33,23,16,5,4,55,20,8,6,63,31,3,10,26,99,7,18,11,27,89,51 };

            Console.Title = "Formula 1";
            DBtoolsInst = new DBtools();
            dotAnimation("Starting", ConsoleColor.Green, true);
            char scelta = ' ';
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n*** FORMULA ONE - BATCH SCRIPTS ***\n");
                Console.WriteLine("1 - Create Countries");
                Console.WriteLine("2 - Create Teams");
                Console.WriteLine("3 - Create Drivers");
                Console.WriteLine("4 - Create Circuits");
                Console.WriteLine("5 - Create GP");
                Console.WriteLine("6 - Create Points");
                Console.WriteLine("7 - Create GPresults");
                Console.WriteLine("8 - Create relations");
                Console.WriteLine("9 - Drop relations");
                Console.WriteLine("q - Diver Stats");
                Console.WriteLine("------------------");
                Console.WriteLine("B - Backup");
                Console.WriteLine("T - Restore");
                Console.WriteLine("R - Reset");
                Console.WriteLine("------------------");
                Console.WriteLine("X - EXIT\n");
                scelta = Console.ReadKey(true).KeyChar;
                switch (scelta)
                {
                    case '1':
                        THanimation();
                        Thread.Sleep(1015);
                        callExecuteSqlScript("countries");
                        break;
                    case '2':
                        THanimation();
                        Thread.Sleep(1015);
                        callExecuteSqlScript("teams");
                        break;
                    case '3':
                        THanimation();
                        Thread.Sleep(1015);
                        callExecuteSqlScript("drivers");
                        break;
                    case '4':
                        THanimation();
                        Thread.Sleep(1015);
                        callExecuteSqlScript("circuits");
                        break;
                    case '5':
                        THanimation();
                        Thread.Sleep(1015);
                        callExecuteSqlScript("gps");
                        break;
                    case '6':
                        THanimation();
                        Thread.Sleep(1015);
                        callExecuteSqlScript("points");
                        break;
                    case '7':
                        THanimation();
                        Thread.Sleep(1015);
                        callExecuteSqlScript("gpResults");
                        break;
                    case '8':
                        THanimation();
                        Thread.Sleep(1015);
                        callExecuteSqlScript("relations");
                        break;
                    case '9':
                        THanimation();
                        Thread.Sleep(1015);
                        callExecuteSqlScript("dropRelations");
                        break;
                    case 'q':
                        THanimation();
                        Thread.Sleep(1015);
                        for (int i = 0; i < driverNs.Length; i++)
                        {
                            callExecuteSqlScript("statProc", driverNs[i]);
                        }
                        break;
                    case 'B':
                        THanimation();
                        Thread.Sleep(1015);
                        DBtoolsInst.DBBackup();
                        break;
                    case 'T':
                        THanimation();
                        Thread.Sleep(1015);
                        DBtoolsInst.DBRestore();
                        break;
                    case 'R':
                        THanimation();
                        Thread.Sleep(1015);
                        DBtoolsInst.DBBackup();
                        bool OK;

                        //tabelle
                        //OK=callExecuteSqlScript("dropRelations");
                        //if (OK) 
                            OK = callDropTable("Country");
                        if (OK) OK = callDropTable("Team");
                        if (OK) OK = callDropTable("Driver");
                        if (OK) OK = callDropTable("Circuit");
                        if (OK) OK = callDropTable("GP");
                        if (OK) OK = callDropTable("Point");
                        if (OK) OK = callDropTable("GPResult");
                        if (OK) OK = callDropTable("Stats");

                        //script file
                        if (OK) OK = callExecuteSqlScript("countries");
                        if (OK) OK = callExecuteSqlScript("teams");
                        if (OK) OK = callExecuteSqlScript("drivers");
                        if (OK) OK = callExecuteSqlScript("circuits");
                        if (OK) OK = callExecuteSqlScript("gps");
                        if (OK) OK = callExecuteSqlScript("points");
                        if (OK) OK = callExecuteSqlScript("gpResults");
                        if (OK)
                        {
                            for (int i = 0; i < driverNs.Length; i++)
                            {
                               OK = callExecuteSqlScript("statProc", driverNs[i]);
                            }

                        }
                        //if (OK) OK = callExecuteSqlScript("relations");
                        if (OK)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("RESET DB OK");
                        }
                        else
                        {
                            DBtoolsInst.DBRestore();
                        }

                        break;
                    case 'x':
                        dotAnimation("Closing", ConsoleColor.Green, false);
                        break;
                    default:
                        if (scelta != 'X' && scelta != 'x')
                            Console.WriteLine("\nUncorrect Choice - Try Again\n");
                        break;
                }
            } while (scelta != 'X' && scelta != 'x');
        }
        #endregion

        #region callExecutionfScripts
        public static bool callExecuteSqlScript(string scriptName)
        {
            try
            {
                DBtoolsInst.ExecuteSqlScript(scriptName + ".sql");
                if (Console.ForegroundColor != ConsoleColor.Red)
                    Console.WriteLine("\nCreate " + scriptName + " - SUCCESS\n");
                else
                    throw new Exception();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n"+ scriptName + " Not Created \nError Message: " + ex.Message);
                return false;
            }
        }
        public static bool callExecuteSqlScript(string scriptName,int num)
        {
            string DBPATH = @"C:\data\F1\";
            string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + DBPATH + "FormulaOne.mdf;Integrated Security=True;";
            try
            {
                using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
                {
                    con.Open();
                    string sql = scriptName;
                    SqlCommand cmd = new SqlCommand(sql, con);

                    SqlParameter res = new SqlParameter();
                    res.ParameterName = "@driverN";
                    res.Direction = ParameterDirection.Input;
                    res.DbType = DbType.Int32; //Tipo di dato nella S.P.
                    res.Value = num;
                    cmd.Parameters.Add(res);


                    cmd.CommandType = CommandType.StoredProcedure;

                    int ris = cmd.ExecuteNonQuery();
                }
                if (Console.ForegroundColor != ConsoleColor.Red)
                    Console.WriteLine("\nCreate " + scriptName +" Number:"+ num + " - SUCCESS\n");
                else
                    throw new Exception();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n" + scriptName + " Not Created \nError Message: " + ex.Message);
                return false;
            }
        }

        public static bool callDropTable(string tableName)
        {
            try
            {
                DBtoolsInst.DropTable(tableName);
                if (Console.ForegroundColor != ConsoleColor.Red)
                    Console.WriteLine("\nDROP " + tableName + " - SUCCESS\n");
                else
                    throw new Exception();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n" + tableName + " Not Dropped \nError Message: "+ex.Message);
                return false;
            }
        }
        #endregion

        #region dotAnimation
        private static void THanimation()
        {
            Thread anim = new Thread(ausTHanim);
            anim.Start();
        }

        private static void ausTHanim()
        {
            dotAnimation("Working", ConsoleColor.White, false);
        }

        public static void dotAnimation(string toWrite, ConsoleColor color,bool isTOclear)
        {
            Console.ForegroundColor = color;
            Console.Write(toWrite);
            for (int i = 0; i < 5; i++)
            {
                Console.Write(".");
                Thread.Sleep(200);
            }
            Console.Write("\n\n");
            if (isTOclear)
                Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
        }
        #endregion
    }
}
