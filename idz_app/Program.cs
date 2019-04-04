using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idz_app
{
    class Program
    {
        static public bool if_admin(string pass)
        {
            string Password_for_admin = "123qwe";
            if (pass == Password_for_admin)
                return true;
            else
                return false;
        }

        static public void show_main()
        {
            Console.WriteLine("Main Page!!!");
            Console.WriteLine("111: Login as Admin");
            Console.WriteLine("1 or any key: Show Main page");
            Console.WriteLine("2: Show all weather for now");
            Console.WriteLine("3: Show weather for day you want");
            Console.WriteLine("4: Input weather from file");
            Console.WriteLine("5: Input weather from console");
            Console.WriteLine("6: Show info for week");
            Console.WriteLine("7: Remove the day you want");
            Console.WriteLine("8: Remove all days");
            Console.WriteLine("9: Get Manual from file");
            Console.WriteLine("10: Write all weather in file");
            Console.WriteLine("0: Exit");
            Console.WriteLine("");
        }

        static void Main(string[] args)
        {
            bool admin = false;
            bool done = false;
            string ProgramKey;
            var raspisanie = new Raspisanie();

            show_main();

            while (!done)
            {
            MM:
                Console.WriteLine("To return on main page input any key");
                Console.Write("Input number of function: ");
                ProgramKey = Console.ReadLine();

                if (ProgramKey.Equals("111"))
                {
                    Console.Clear();
                    Console.Write("Password for Admin: ");
                    string strdatkey = Console.ReadLine();
                    if (if_admin(strdatkey))
                    {
                        admin = true;
                        Console.WriteLine("Hello from Admin");
                    }
                    else
                    {
                        Console.WriteLine("Wrong password!!!\nTry once again");
                    }
                  
                }
                if (ProgramKey.Any())
                {
                    Console.Clear();
                    show_main();              
                }
                if (ProgramKey.Equals("2"))
                {
                    raspisanie.ShowWeather();
                    goto MM;
                }
                if (ProgramKey.Equals("3"))
                {
                    Console.Write("Input number of day you want: ");
                    string strdatkey = Console.ReadLine();
                    int datkey = Convert.ToInt32(strdatkey);
                    raspisanie.ShowWeather(datkey);
                    goto MM;
                }
                if (ProgramKey.Equals("4"))
                {
                    if (admin)
                    {
                        raspisanie.Get_text_from_file("idz_in.txt");
                        goto MM;
                    }
                    else
                    {
                        Console.Write("You are not admin ");
                    }
                }
                if (ProgramKey.Equals("5"))
                {
                    raspisanie.InputOneDay();
                    goto MM;
                }
                if (ProgramKey.Equals("6"))
                {
                    raspisanie.StatusForWeek();
                    goto MM;
                }
                if (ProgramKey.Equals("7"))
                {
                    if (admin)
                    {
                        Console.Write("Input number of day you want delete: ");
                        string strdatkey = Console.ReadLine();
                        int datkey = Convert.ToInt32(strdatkey);
                        raspisanie.DelOneDay(datkey);
                        goto MM;
                    }
                    else
                    {
                        Console.Write("You are not admin ");
                    }
                }
                if (ProgramKey.Equals("8"))
                {
                    if (admin)
                    {
                        raspisanie.DelAll();
                        goto MM;
                    }
                    else
                    {
                        Console.Write("You are not admin ");
                    }
                }
                if (ProgramKey.Equals("9"))
                {
                    raspisanie.Get_ruk_polz("idz_home.txt");
                    goto MM;
                }
                if (ProgramKey.Equals("10"))
                {
                    if (admin)
                    {
                        Console.Write("Saving to file...");
                        raspisanie.Set_text_in_file("idz_out.txt");
                        Console.Write("Done!\n");
                        goto MM;
                    }
                    else
                    {
                        Console.Write("You are not admin ");
                    }
                }
                else if (ProgramKey.Equals("0"))
                {
                    break;
                }
            }
        }
    }
}
