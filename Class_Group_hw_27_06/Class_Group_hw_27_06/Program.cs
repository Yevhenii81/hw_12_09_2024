using Class_Student_hw_25_06_2024;
using Class_Group_hw_27_06;

namespace Class_Group_hw_27_06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //создаём студентов
            Student student1 = new Student("Student", "Studenkov", "Studenkovich", DateTime.Now, new List<int> { 8, 7, 9 }, new List<int> { 9, 9, 9 }, new List<int> { 8, 7, 9 });
            Student student2 = new Student("Petya", "Petrovkin", "Vasilievich", DateTime.Now, new List<int> { 6, 5, 6 }, new List<int> { 5, 6, 6 }, new List<int> { 6, 5, 6 });
            Student student3 = new Student("Mikhail ", "Zubenko", "Petrovich", DateTime.Now, new List<int> { 9, 10, 9 }, new List<int> { 10, 9, 9 }, new List<int> { 9, 10, 9 });

            Student[] students = { student1, student2, student3 };

            //сортировка студентов по среднему баллу
            Array.Sort(students);

            Console.WriteLine("Students sorted by grade point average:");
            foreach (Student student in students)
            {
                Console.WriteLine(student);
            }

            //создаём группу
            Group group1 = new Group("P26", 1, Speciallization.SoftwareDeveloper, new List<Student>());
            //group1.AddStudent(student1);
            //group1.AddStudent(student2);

            Group group2 = new Group("P27", 2, Speciallization.Designer, new List<Student>());
            //group2.AddStudent(student3);

            //массив групп
            Group[] groups = { group1, group2 };

            //сортировка групп по количеству студентов
            Array.Sort(groups);

            //вывод отсортированных групп
            Console.WriteLine("\nGroups sorted by number of students:");
            foreach (var group in groups)
            {
                GroupePrinter.Print(group);
            }

            //Клонирование группы
            Group clonedGroup = (Group)group1.Clone();
            Console.WriteLine("\nCloned group:");
            GroupePrinter.Print(clonedGroup);

            Console.WriteLine("Student information:");
            StudentPrinter.Print(student1);
            StudentPrinter.Print(student2);
            StudentPrinter.Print(student3);

            ///////////////////

            //Student alex = new Student("Alex", "Asf", "Toren", new DateTime(1999, 5, 24));
            //alex.SetExamRates(12, 9, 10, 12);
            //alex.SetHomeworkRates(12, 12, 10, 8);
            //alex.SetClassWorkRates(11, 11, 10, 10);
            //Student viva = new Student("Viva", "Vbn", "Sire", new DateTime(2005, 8, 21));
            //viva.SetExamRates(8, 9, 10, 10);
            //viva.SetHomeworkRates(8, 9, 10, 10);
            //viva.SetClassWorkRates(8, 9, 10, 10);
            //Student lev = new Student("Lev", "FDf", "Tomato", new DateTime(1980, 7, 12));
            //lev.SetExamRates(7, 3, 8, 4);
            //lev.SetHomeworkRates(7, 5, 8, 9);
            //lev.SetClassWorkRates(7, 5, 8, 9);
            //Student max = new Student("Max", "Studentf", "Normal", DateTime.Now);
            //max.SetExamRates(10, 5, 9, 11);
            //max.SetHomeworkRates(10, 10, 9, 11);
            //max.SetClassWorkRates(10, 10, 9, 11);

            //Group p = new Group();
            //p.SetName("P26");
            //p.SetCourseNumber(2);
            //p.SetSpeciallization(Group.Speciallization.Programming);
            //p.AddStudent(alex);
            //p.AddStudent(max);

            //Group p2 = p.Copy();
            //GroupePrinter.Print(p2);


            ////p.DeleteStudent(alex);
            //p.TransferStudent(alex, p2);
            //GroupePrinter.Print(p);
            //p2.SetName("dgdgdg");
            //GroupePrinter.Print(p2);
            ////p.StudentsExpulsion();
        }
    }
}
