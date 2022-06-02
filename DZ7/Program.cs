using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ7
{
 
    internal class Program
    {
        static void Main(string[] args)
        {

            string path = @"test.txt";
            DB rep = new DB(path);

            //rep.NoteAdd();
            rep.Load();
            rep.PrintDbToConsole();
            //rep.NoteAdd();
            //rep.NoteDelete();
            //rep.Add(new Worker("111", "111", "111", 111, "111"));

            //Console.ReadKey();

            //rep.PrintDbToConsole();


            Console.ReadKey();






















            //DB rep = new DB(path);
            ////rep.NoteCreate();
            ////rep.PrintDbToConsole();
            ////rep.SearchId();
            ////rep.NoteDelete();
            ////rep.NoteChange();
            //rep.DischargeRange();

            //Console.ReadKey();


        }
    }
}
