using System;
using System.Text;

namespace ExperimentProject 
{
    public class MainProgram
    {
        static void Main(string[] args)
        {

            TeacherDataFile teachersDatabase = new TeacherDataFile("D:/Desktop/sample.txt");
            bool proceed = true;

            do
            {
                Console.WriteLine("Welcome to Rainbow School Database");
                Console.WriteLine();
                Console.WriteLine("1. Add Teachers Details \n2. Update Teachers Records \n3. Get Teachers Record \n4. Exit");
                Console.WriteLine();
                Console.Write("Choose from the option: ");

                int choice = int.Parse(Console.ReadLine());

                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter Teachers Details");
                        Console.Write("Enter Teacher ID : ");
                        int teacherId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Teachers Name : ");
                        string teacherName = Console.ReadLine();
                        Console.Write("Enter Teachers Section : ");
                        string teacherSection = Console.ReadLine();

                        TeacherDataFormat newTeacher = new TeacherDataFormat(teacherId, teacherName, teacherSection);
                        teachersDatabase.AddTeacherData(newTeacher);

                        Console.WriteLine();
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("Teachers Record Successfully added");
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine();
                        break;
                    case 2:
                        Console.Write("Enter Teachers ID to be updated : ");
                        int techid = int.Parse(Console.ReadLine());
                        Console.Write("Enter updated Name : ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Updated Section : ");
                        string section = Console.ReadLine();
                        teachersDatabase.UpdateTeacherDataById(techid, name, section);
                        Console.WriteLine("-------------------------------------");
                        Console.WriteLine("Teachers Details Successfully Updated");
                        Console.WriteLine("-------------------------------------");
                        break;
                    case 3:
                        Console.Write("Enter Teachers ID : ");
                        int id = int.Parse(Console.ReadLine());
                        TeacherDataFormat teacherDetails = teachersDatabase.GetTeacherDataById(id);
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine($"Teachers ID : {teacherDetails.Id}\nTeachers Name : {teacherDetails.Name} \nTeachers Section : {teacherDetails.ClassSection}");
                        Console.WriteLine("-----------------------------------");
                        break;
                    case 4:
                        proceed = false;
                        break;
                }   
            } while (proceed);

        }
    }
}