using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkModule10
{
    public class Teacher : Person
    {
        public List<StudentWithAdvisor> Students { get; set; }

        public Teacher(string name, int age) : base(name, age)
        {
            Students = new List<StudentWithAdvisor>();
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Students: {Students.Count}";
        }

        public static Teacher RandomTeacher()
        {
            string[] names = { "Абылай Муратович", "Евгений Александрович", "Василий Вальеривич", "Рамзат Рахмятжанович", "Асем Тултанова" };
            Random random = new Random();
            string randomName = names[random.Next(names.Length)];
            int randomAge = random.Next(30, 60);
            return new Teacher(randomName, randomAge);
        }
    }
}
