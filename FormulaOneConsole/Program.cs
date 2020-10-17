using System;
using System.Security.Permissions;
using System.Threading;
using FormulaOneDLL;

namespace FormulaOneConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            dotAnimation("Starting", ConsoleColor.Green,true);
            char scelta = ' ';
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n*** FORMULA ONE - BATCH SCRIPTS ***\n");
                Console.WriteLine("1 - Create Countries");
                Console.WriteLine("2 - Create Teams");
                Console.WriteLine("3 - Create Drivers");
                Console.WriteLine("4 - Create Circuits");
                Console.WriteLine("------------------");
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
                    case 'R':
                        THanimation();
                        Thread.Sleep(1015);
                        bool OK;

                        //tabelle
                        OK = callDropTable("Country");
                        if (OK) OK = callDropTable("Team");
                        if (OK) OK = callDropTable("Driver");
                        if (OK) OK = callDropTable("Circuit");

                        //script file
                        if (OK) OK = callExecuteSqlScript("countries");
                        if (OK) OK = callExecuteSqlScript("teams");
                        if (OK) OK = callExecuteSqlScript("drivers");
                        if (OK) OK = callExecuteSqlScript("circuits");
                        if (OK) 
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("RESET DB OK");
                        }

                        break;
                    case 'x':
                        dotAnimation("Closing",ConsoleColor.Green,false);
                        break;
                    default:
                        if (scelta != 'X' && scelta != 'x') Console.WriteLine("\nUncorrect Choice - Try Again\n");
                        break;
                }
            } while (scelta != 'X' && scelta != 'x');
        }

        private static void THanimation()
        {
            Thread anim = new Thread(ausTHanim);
            anim.Start();
        }

        private static void ausTHanim()
        {
            dotAnimation("Working",ConsoleColor.White,false);
        }

        public static bool callExecuteSqlScript(string scriptName)
        {
            try
            {
                DBtools.ExecuteSqlScript(scriptName + ".sql");
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
                DBtools.DropTable(tableName);
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
    }
}
