using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Class_Student_hw_25_06_2024;
using static System.Formats.Asn1.AsnWriter;

namespace Class_Group_hw_27_06
{
    enum Speciallization { SoftwareDeveloper, Designer }

    internal class Group : ICloneable, IComparable<Group>
    {
        private List<Student> students = new List<Student>();
        private string name;
        private int courseNumber;
        private Speciallization groupSpeciallization;

        public Group() : this("", 0, Speciallization.SoftwareDeveloper, new List<Student>()) { }
        public Group(string name, int courseNumber, Speciallization groupSpeciality, List<Student> students)
        {
            SetStudentsList(students);
            SetName(name);
            SetCourseNumber(courseNumber);
            SetSpeciallization(groupSpeciallization);
        }
        public Group Copy()
        {
            List<Student> student = new List<Student>();
            for (int i = 0; i < this.students.Count; i++)
            {
                student.Add((Student)this.students[i].Clone());
            }
            return new Group(this.name, this.courseNumber, this.groupSpeciallization, student);
        }

        //Clone
        public object Clone()
        {
            return this.Copy();
        }

        //CompareTo
        public int CompareTo(Group group)
        {
            if (group == null) return 1;

            // Сначала сравниваем по количеству студентов
            int studentCountComparison = this.GetStudentList().Count.CompareTo(group.GetStudentList().Count);

            if (studentCountComparison != 0)
                return studentCountComparison;

            // Если количество студентов одинаково, сравниваем по имени группы
            return string.Compare(this.GetName(), group.GetName(), StringComparison.Ordinal);
        }

        //ToString
        public override string ToString()
        {
            var studentsInfo = students.Count > 0
                ? string.Join("\n", students)
                : "No students in the group.";

            return $"Group Name: {name}\n" +
                   $"Speciality: {groupSpeciallization}\n" +
                   $"Course: {courseNumber}\n" +
                   $"Number of Students: {students.Count}\n" +
                   $"Students:\n{studentsInfo}";
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return this.name;
        }
        public void SetCourseNumber(int courseNumber)
        {
            this.courseNumber = courseNumber;
        }

        public int GetCourseNumber()
        {
            return this.courseNumber;
        }

        public void SetSpeciallization(Speciallization speciallization)
        {
            this.groupSpeciallization = speciallization;
        }

        public Speciallization GetSpeciallization()
        {
            return this.groupSpeciallization;
        }

        public void SetStudentsList(List<Student> students)
        {
            this.students = students;
        }

        public List<Student> GetStudentList()
        {
            return this.students;
        }

        public void AddStudent(Student student)
        {
            this.students.Add(student);
        }

        public void DeleteStudent(in Student student)
        {
            this.students.Remove(student);
        }
        public void TransferStudent(in Student student, Group group)
        {
            this.DeleteStudent(student);
            group.students.Add(student);
        }

        public void ExpulsionFallingStudents()
        {
            foreach (var item in this.students)
            {
                double average = 0;
                for (int i = 0; i < item.GetExamRates().Count; i++)
                    average += item.GetExamRates()[i];
                average /= item.GetExamRates().Count;
                if (average < 6)
                {
                    this.DeleteStudent(item);
                }
            }
        }
        public void StudentsExpulsion()
        {
            for (int i = 0; i < this.students.Count; i++)
            {
                for (int j = 0; j < students[i].GetExamRates().Count; j++)
                {
                    if (students[i].GetExamRates()[j] < 6)
                    {
                        this.DeleteStudent(students[i]);
                        i--;
                        break;
                    }
                }
            }
        }

        //overload

        //public static bool operator ==(Group left, Group right)
        //{
        //    string averageGrade1 = left.GetName();
        //    string averageGrade2 = right.GetName();

        //    return averageGrade1 == averageGrade2;
        //}

        //public static bool operator !=(Group left, Group right)
        //{
        //    return !(left == right);
        //}
    }

    class GroupePrinter
    {
        static public void Print(in Group group)
        {
            Console.WriteLine(group.GetName());
            Console.WriteLine(group.GetCourseNumber());
            Console.WriteLine(group.GetSpeciallization());


            for (int i = 0; i < group.GetStudentList().Count; i++)
            {
                Student c = group.GetStudentList()[i];
                StudentPrinter.Print(c);
            }
            Console.WriteLine();
        }
    }
}
