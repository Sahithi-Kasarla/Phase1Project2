using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    public class Program
    {
        static string filePath = @"C:\Users\Dell\OneDrive\Documents\Mphasis Docs\Projects\Phase1Project2\Project2\Project2\TeacherData.txt";
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1. Add Teacher\n2. Update Teacher\n3. Display Records\n4. Exit");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddTeacher();
                        break;
                    case 2:
                        UpdateTeacher();
                        break;
                    case 3:
                        DisplayTeachers();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again. ");
                        break;
                }
            }
        }
        static void AddTeacher()
        {
            Console.WriteLine("Enter Teacher ID:");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Teacher Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Class Number:");
            int classnum = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Section:");
            string section = Console.ReadLine();
            Teacher teacher = new Teacher { ID = id, Name = name, ClassNum = classnum, Section = section };

            List<string> lines = File.ReadAllLines(filePath).ToList();

            lines.Add($"{teacher.ID}\t\t{teacher.Name}\t\t{teacher.ClassNum}\t\t{teacher.Section}");

            File.WriteAllLines(filePath, lines);

            Console.WriteLine("Teacher added Successfully!!");
        }
        static void UpdateTeacher()
        {
            Console.WriteLine("Enter Teacher ID to update:");
            int idToUpdate = int.Parse(Console.ReadLine());

            List<string> lines = File.ReadAllLines(filePath).ToList();
            bool found = false;

            for (int i = 0; i < lines.Count; i++)
            {
                string[] parts = lines[i].Split('\t');
                int id = int.Parse(parts[0]);

                if (id == idToUpdate)
                {
                    Console.WriteLine("Enter New Name:");
                    string newName = Console.ReadLine();

                    Console.WriteLine("Enter New Class:");
                    int newClass = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter New Section:");
                    string newSection = Console.ReadLine();
                    lines[i] = $"{idToUpdate}\t\t{newName}\t\t{newClass}\t\t{newSection}";
                    found = true;
                }
            }
            File.WriteAllLines(filePath, lines);
            if (!found)
            {
                Console.WriteLine("Teacher not found!");
            }
            else
            {
                Console.WriteLine("TeacherUpdated SuccessFully!!");
            }
        }
        static void DisplayTeachers()
        {
            Console.WriteLine("Teacher Records:");
            List<string> lines = File.ReadAllLines(filePath).ToList();
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
            Console.ReadKey();
        }
    }
}
