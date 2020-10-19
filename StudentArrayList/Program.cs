using System;
using System.Collections;
using System.Collections.Generic;

namespace AbstractyStudent
{
    class Program
    {
        static ArrayList list = new ArrayList();
        static void Main(string[] args)
        {
            for (; ; )
            {
                Console.WriteLine("введите 1 чтобы добавить студента\n" +
                    "введите 2 чтобы добавить аспиранта\n" +
                    "введите 3чтобы узнать информацию о студентах");
                switch (Console.ReadLine())
                {
                    case "1":
                        AddStudent();
                        break;
                    case "2":
                        AddAspirant();
                        break;
                    case "3":
                        InfoStudent();
                        break;
                    default:
                        break;
                }
            }
        }

        static void AddStudent()
        {
            Student stu = new Student();
            Console.WriteLine("введите имя студента");
            stu.Name = NameValid();
            Console.WriteLine("введите фамилию студента");
            stu.LastName = NameValid();
            Console.WriteLine("введите курс обучения");
            stu.Cours = CoursValid();
            Console.WriteLine("введите номер зачетной книжки");
            stu.Zacet = ZacetValid();
            list.Add(stu);
            
        }
        static void AddAspirant()
        {
            Aspirant asp = new Aspirant();
            Console.WriteLine("введите имя аспиранта");
            asp.Name = NameValid();
            Console.WriteLine("введите фамилию аспиранта");
            asp.LastName = NameValid();
            Console.WriteLine("ввендите курс обучения");
            asp.Cours = CoursValid();
            Console.WriteLine("введите номер зачетной книжки");
            asp.Zachet = ZacetValid();
            Console.WriteLine("введите тему диссертации");
            asp.Theme = Console.ReadLine();
            list.Add(asp);
            
        }
        static string NameValid()
        {
            char[] eng = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] big_eng = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            char[] rus = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ь', 'ы', 'ъ', 'э', 'ю', 'я' };
            char[] big_rus = { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Э', 'Ю', 'Я' };

            string name = Console.ReadLine();
            int j = 0;
            for (int i = 0; i < big_eng.Length; i++)
            {
                if (name[0] == big_eng[i])
                {
                    j++;
                    break;
                }
            }
            if (j == 0)
            {
                for (int i = 0; i < big_rus.Length; i++)
                {
                    if (name[0] == big_rus[i])
                    {
                        j++;
                        break;
                    }
                }
            }
            if (j == 0)
            {
                Console.WriteLine("введите коректные данные");
                NameValid();
            }
            else// j=1;
            {
                for (int k = 1; k < name.Length; k++)
                {
                    for (int i = 0; i < eng.Length; i++)
                    {
                        if (name[k] == eng[i])
                        {
                            j++;
                            break;
                        }
                    }
                }
                for (int k = 1; k < name.Length; k++)
                {
                    char second = name[k];
                    for (int i = 0; i < rus.Length; i++)
                    {
                        if (name[k] == rus[i])
                        {
                            j++;

                            break;
                        }
                    }
                }
            }
            if (j != name.Length)
            {
                j = 0;
                Console.WriteLine("введите коректные данные");
                return NameValid();
            }
            j = 0;
            return name;
        }
        static int NumValid()
        {
            if (int.TryParse(Console.ReadLine(), out int a))
                return a;
            else
            {
                Console.WriteLine("введите коректные данные");
                return NumValid();
            }
        }
        static int CoursValid()
        {
            int cours = NumValid();
            if (cours >= 1 & cours <= 10)
                return cours;
            else
            {
                Console.WriteLine("введите курс обучения коректно");
                return CoursValid();
            }
        }
        static int ZacetValid()
        {
            int zacet = NumValid();
            if (zacet >= 10000000 & zacet <= 99999999)
                return zacet;
            Console.WriteLine("номер зачетной книжки состоит из 8символов");
            return ZacetValid();
        }
        static void InfoStudent()
        {
            Console.WriteLine("введите номер студента для вывода информации");
            int i = InfoValid();
            try
            {
                Student stu = (Student)list[i];
                stu.PrintInfo();
            }
            catch
            {
                Aspirant asp = (Aspirant)list[i];
                asp.PrintInfo();
            }
        }
        static int InfoValid()
        {
            int i = NumValid();
            if (i >= 0 && i < list.Count)
                return i;
            else
            {
                Console.WriteLine("студентов с таким индексом не существует");
                return InfoValid();
            }
        }
        static void Sort()
        {
            list.Sort();
        }
    }
}
