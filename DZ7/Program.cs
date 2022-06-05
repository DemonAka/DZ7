using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DZ7
{
 
    internal class Program
    {
        static void Main(string[] args)
        {

            string path = @"test.txt";
            string example = "0#02.05.2022 23:02:22#Акулич Дмитрий Игоревич#27#172#11.10.1994 0:00:00#Тверь";
            DB rep = new DB(path);
            
            if (File.Exists(path) == false)
            {
                File.AppendAllText(path, example);
            }
            else
            {
                rep.Load();
                rep.PrintDbToConsole();
            }
            Console.WriteLine(" ");
            //rep.LastIdFind();
            rep.NoteAdd();
            rep.PrintDbToConsole();
            Console.WriteLine(" ");
            rep.NoteDelete();
            rep.Load();
            rep.PrintDbToConsole();
            Console.WriteLine(" ");
            rep.NoteChange();
            rep.Load();
            rep.PrintDbToConsole();
            Console.WriteLine(" ");
            rep.DischargeRange();
            Console.WriteLine(" ");
            rep.Sort();
            rep.PrintDbToConsole();


            Console.ReadKey();


        }
    }
}
