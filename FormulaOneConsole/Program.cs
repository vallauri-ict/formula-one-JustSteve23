using System;
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
                        OK = callDropTable("Country");
                        if (OK) OK = callDropTable("Team");
                        if (OK) OK = callDropTable("Driver");
                        if (OK) OK = callDropTable("Circuit");
                        if (OK) OK = callDropTable("GP");

                        //script file
                        if (OK) OK = callExecuteSqlScript("countries");
                        if (OK) OK = callExecuteSqlScript("teams");
                        if (OK) OK = callExecuteSqlScript("drivers");
                        if (OK) OK = callExecuteSqlScript("circuits");
                        if (OK) OK = callExecuteSqlScript("gps");
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
                        if (scelta != 'X' && scelta != 'x') Console.WriteLine("\nUncorrect Choice - Try Again\n");
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
                Console.WriteLine("\n"+ scriptName + " Not Created \n");
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
                Console.WriteLine("\n" + tableName + " Not Dropped \n");
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
