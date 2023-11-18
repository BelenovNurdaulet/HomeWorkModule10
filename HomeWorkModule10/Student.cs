
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkModule10
{
    public class StudentWithoutAdvisor : Person
    {
        public int Course { get; set; }

        public StudentWithoutAdvisor(string name, int age, int course) : base(name, age)
        {
            Course = course;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Course: {Course}";
        }

        public static StudentWithoutAdvisor RandomStudent()
        {
            string[] names = { "Нурдаулет Беленов", "Аскар Айболат", "Даниал Сагатов", "Бекзат Юсубаев", "Данияр Куантаев" };
            Random random = new Random();
            string randomName = names[random.Next(names.Length)];
            int randomAge = random.Next(18, 30);
            int randomCourse = random.Next(1, 5);
            return new StudentWithoutAdvisor(randomName, randomAge, randomCourse);
        }
    }
    public class StudentWithAdvisor : StudentWithoutAdvisor
    {
        public Teacher Advisor { get; set; }

        public StudentWithAdvisor(string name, int age, int course, Teacher advisor) : base(name, age, course)
        {
            Advisor = advisor;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Advisor: {Advisor.Name}";
        }

        public static StudentWithAdvisor RandomStudentWithAdvisor(Person[] people)
        {
            string[] names = { "Даниал Сагатов", "Раис Шотаев", "Нурммухамед Макатаев", "Арман Беридбаев", "Медет Рыспаев" };
            Random random = new Random();
            string randomName = names[random.Next(names.Length)];
            int randomAge = random.Next(18, 30);
            int randomCourse = random.Next(1, 5);

            Teacher randomAdvisor = null;
            foreach (Person person in people)
            {
                if (person is Teacher)
                {
                    randomAdvisor = (Teacher)person;
                    break;
                }
            }

            return new StudentWithAdvisor(randomName, randomAge, randomCourse, randomAdvisor);
        }
    }
}
