using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ7
{
    struct DB
    {

        private Employee[] employers;
        private string path;
        int index;
        string[] titles;
        

        public DB(string Path)
        {
            this.path = Path;
            this.index = 0;
            this.titles = new string[6];
            this.employers = new Employee[2];
        }

        private void Resize(bool Flag)
        {
            if (Flag)
            {
                Array.Resize(ref this.employers, this.employers.Length * 2);
            }
        }

        public void Add(Employee ConcreteWorker)
        {
            this.Resize(index >= this.employers.Length);
            this.employers[index] = ConcreteWorker;
            this.index++;
        }
        public void Load()
        {
            using (StreamReader sr = new StreamReader(this.path, true))
            {
                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split('#');
                    Add(new Employee(Convert.ToInt32(args[0]), Convert.ToDateTime(args[1]), args[2], Convert.ToInt32(args[3]), Convert.ToInt32(args[4]), Convert.ToDateTime(args[5]), args[6]));
                }
                }  
        }
        public void PrintDbToConsole()
        {
            //Console.WriteLine($"{this.titles[0],2} {this.titles[1],10} {this.titles[4],15} {this.titles[2],15} {this.titles[3],10}");

            for (int i = 0; i < index; i++)
            {
                Console.WriteLine(employers[i].Print());
            }

        }

        public void NoteAdd()
        {
            using (StreamWriter sw = new StreamWriter(path, true, Encoding.Unicode))
            {
                char key = 'д';
                int id = index;
                Employee emp = new Employee();
                do
                {
                    string note = string.Empty;
                    id++;
                    note += $"{id}#";

                    note += $"{DateTime.Now}#";

                    Console.Write("\nВведите фамилию имя отчество автора записи: ");
                    emp.Name = Console.ReadLine();
                    note += $"{emp.Name}#";

                    Console.Write("\nВведите возраст сотрудника: ");
                    emp.Age = Convert.ToInt32(Console.ReadLine());
                    note += $"{emp.Age}#";

                    Console.Write("\nВведите рост сотрудника: ");
                    emp.Heigh = Convert.ToInt32(Console.ReadLine());
                    note += $"{emp.Heigh}#";

                    Console.WriteLine($"\nЗапишите дату рождения Сотррудника в формате ГГГГ.ММ.ДД.: ");
                    emp.Birthday = Convert.ToDateTime(Console.ReadLine());
                    note += $"{emp.Birthday}#";

                    Console.Write("\nВведите место рождения сотрудника: ");
                    emp.PlaceBith = Console.ReadLine();
                    note += $"{emp.PlaceBith}#";

                    sw.WriteLine(note);
                    Add(new Employee(id, DateTime.Now, emp.Name, emp.Age, emp.Heigh, emp.Birthday, emp.PlaceBith));
                    Console.Write("\nПродожить н/д"); key = Console.ReadKey(true).KeyChar;
                    
                    sw.Flush();
                } while (char.ToLower(key) == 'д');
            }
        }

        public void NoteDelete()
        {
            using (StreamReader sr = new StreamReader(path, Encoding.Unicode))
            {
                using (StreamWriter sw = new StreamWriter("temporary.txt", false, Encoding.Unicode))
                {
                    Console.WriteLine($"Введите id которое хотите удалить");
                    int id = Convert.ToInt32(Console.ReadLine());
                    while (!sr.EndOfStream)
                    {
                        string[] data = sr.ReadLine().Split('#');
                        int idcheck = Convert.ToInt32(data[0]);
                        if (idcheck != id)
                        {
                            sw.WriteLine($"{data[0]}#{data[1]}#{data[2]}#{data[3]}#{data[4]}#{data[5]}#{data[6]}");
                        }
                    }
                }
            }
            File.Delete(path);
            File.Move("temporary.txt", path);
        }

        public void NoteChange()
        {
            using (StreamReader sr = new StreamReader(path, Encoding.Unicode))
            {
                using (StreamWriter sw = new StreamWriter("temporary.txt", false, Encoding.Unicode))
                {
                    Employee emp = new Employee();
                    int idCheck;
                    Console.WriteLine($"Введите id которое хотите изменить");
                    int id = Convert.ToInt32(Console.ReadLine());
                    while (!sr.EndOfStream)
                    {
                        string[] data = sr.ReadLine().Split('#');
                        idCheck = Convert.ToInt32(data[0]);

                        if (idCheck == id)
                        {

                            data[1] = Convert.ToString(emp.DataRegistration);

                            Console.Write("\nВведите фамилию имя отчество автора записи: ");
                            emp.Name = Console.ReadLine();
                            data[2] = emp.Name;

                            Console.Write("\nВведите возраст сотрудника: ");
                            emp.Age = Convert.ToInt32(Console.ReadLine());
                            data[3] = Convert.ToString(emp.Age);

                            Console.Write("\nВведите рост сотрудника: ");
                            emp.Heigh = Convert.ToInt32(Console.ReadLine());
                            data[4] = Convert.ToString(emp.Heigh);

                            Console.WriteLine($"\nЗапишите дату рождения Сотррудника в формате ГГГГ.ММ.ДД.: ");
                            emp.Birthday = Convert.ToDateTime(Console.ReadLine());
                            data[5] = Convert.ToString(emp.Birthday);

                            Console.Write("\nВведите место рождения сотрудника: ");
                            emp.PlaceBith = Console.ReadLine();
                            data[6] = emp.PlaceBith;
                        }
                        sw.WriteLine($"{data[0]}#{data[1]}#{data[2]}#{data[3]}#{data[4]}#{data[5]}#{data[6]}");
                    }
                }
            }
            File.Delete(path);
            File.Move("temporary.txt", path);
        }


        public void DischargeRange()
        {
            using (StreamReader sr = new StreamReader(path, Encoding.Unicode))
            {
                var date1 = new DateTime();
                var date2 = new DateTime();
                var tempdate = new DateTime();
                Console.WriteLine($"Введите первый границу для выгрузки по дате");
                date1 = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine($"Введите вторую границу для выгрузки по дате");
                date2 = Convert.ToDateTime(Console.ReadLine());

                if (date1 > date2)
                {
                    tempdate = date2;
                    date2 = date1;
                    date1 = tempdate;

                }
                Console.WriteLine($"{"ID ",2} {"Время создания записи ",10} {"Фамилия Имя Отчество ",27} {"Возраст ",10} {"Рост ",5} {"Дата рождения ",17} {"Место рождения ",17}\n");
                while (!sr.EndOfStream)
                {
                    string[] data = sr.ReadLine().Split('#');
                    tempdate = Convert.ToDateTime(data[1]);
                    if (tempdate >= date1 && tempdate <= date2)
                    {
                        Console.WriteLine($"{data[0],2} {data[1],22} {data[2],30} {data[3],5} {data[4],6} {data[5],20} {data[6],12}");
                    }
                }
            }
        }


        //}
        //public void SearchId ()
        //{
        //    using (StreamReader sr = new StreamReader(path, Encoding.Unicode))
        //    {
        //       int idCheck;
        //       Console.WriteLine($"Введите id пользователя");
        //       int id = Convert.ToInt32(Console.ReadLine());
        //        while (!sr.EndOfStream)
        //        {
        //            string[] data = sr.ReadLine().Split('#');
        //            idCheck = Convert.ToInt32(data[0]);
        //                if (idCheck == id)
        //                {
        //                Console.WriteLine($"{"ID ",2} {"Время создания записи ",10} {"Фамилия Имя Отчество ",27} {"Возраст ",10} {"Рост ",5} {"Дата рождения ",17} {"Место рождения ",17}\n"); 
        //                Console.WriteLine($"{data[0],2} {data[1],22} {data[2],30} {data[3],5} {data[4],6} {data[5],20} {data[6],12}");
        //                break;
        //                }
        //        }
        //    }
        //}




    }
}
