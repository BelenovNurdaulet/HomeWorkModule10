using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HomeWorkModule10
{
    class Program
    {
        static void Main(string[] args)
        {
            Person[] people = new Person[10];

            for (int i = 0; i < people.Length; i++)
            {
                if (i % 3 == 0)
                {
                    people[i] = Teacher.RandomTeacher();
                }
                else if (i % 3 == 1)
                {
                    people[i] = StudentWithoutAdvisor.RandomStudent();
                }
                else
                {
                    people[i] = StudentWithAdvisor.RandomStudentWithAdvisor(people);
                }
            }

            foreach (Person person in people)
            {
                Console.WriteLine(person.ToString());
            }

            int personCount = 0;
            int studentCount = 0;
            int teacherCount = 0;

            foreach (Person person in people)
            {
                if (person is StudentWithoutAdvisor)
                {
                    studentCount++;
                    if (person is StudentWithAdvisor)
                    {
                        StudentWithAdvisor student = (StudentWithAdvisor)person;
                        student.Course++; // Переводим студентов на следующий курс
                    }
                }
                else if (person is Teacher)
                {
                    teacherCount++;
                }
                else
                {
                    personCount++;
                }
            }

            Console.WriteLine($"Person count: {personCount}");
            Console.WriteLine($"Student count: {studentCount}");
            Console.WriteLine($"Teacher count: {teacherCount}");
        }
    }
}
