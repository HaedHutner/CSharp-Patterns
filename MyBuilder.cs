namespace std_3_st2 {

    public class MainApp {
        public static void Main () {
            Student[] students = {
                new StudentBuilder ()
                .Name ("Мирослав Василев")
                .Age (21)
                .EGN (9912319999)
                .EyeColor ("Кафяви")
                .FacultyNumber (1601681060)
                .Specialty ("СТД")
                .Build (),
                new StudentBuilder ()
                .Name ("Калеко Алеко")
                .Age (46)
                .EGN (5305037893)
                .EyeColor ("Черни")
                .FacultyNumber (1601182060)
                .Specialty ("???")
                .Build ()
            };

            foreach (Student student in students) {
                System.Console.WriteLine ("------------");
                System.Console.WriteLine ("Име: {0}", student.Name);
                System.Console.WriteLine ("Възраст: {0}", student.Age);
                System.Console.WriteLine ("ЕГН: {0}", student.EGN);
                System.Console.WriteLine ("Цвят на очите: {0}", student.EyeColor);
                System.Console.WriteLine ("Факултетен номер: {0}", student.FacultyNumber);
                System.Console.WriteLine ("Специалност: {0}", student.Specialty);
            }
        }
    }
    public interface Person {
        string Name { get; set; }

        string EyeColor { get; set; }

        long EGN { get; set; }

        int Age { get; set; }
    }

    public class Student : Person {
        public string Name { get; set; }

        public string EyeColor { get; set; }

        public long EGN { get; set; }

        public int Age { get; set; }

        public long FacultyNumber { get; set; }

        public string Specialty { get; set; }
    }

    public class StudentBuilder {
        private string name;
        private long egn;
        private int age;
        private string eyeColor;
        private string specialty;
        private long facultyNumber;

        public StudentBuilder () { }

        public StudentBuilder Name (string name) {
            this.name = name;
            return this;
        }

        public StudentBuilder EGN (long egn) {
            this.egn = egn;
            return this;
        }

        public StudentBuilder Age (int age) {
            this.age = age;
            return this;
        }

        public StudentBuilder EyeColor (string eyeColor) {
            this.eyeColor = eyeColor;
            return this;
        }

        public StudentBuilder FacultyNumber (long facultyNumber) {
            this.facultyNumber = facultyNumber;
            return this;
        }

        public StudentBuilder Specialty (string specialty) {
            this.specialty = specialty;
            return this;
        }

        public Student Build () {
            Student student = new Student ();
            student.Name = name;
            student.Age = age;
            student.EyeColor = eyeColor;
            student.EGN = egn;
            student.FacultyNumber = facultyNumber;
            student.Specialty = specialty;

            return student;
        }
    }
}

/*
Output:

------------
Име: Мирослав Василев
Възраст: 21
ЕГН: 9912319999
Цвят на очите: Кафяви
Факултетен номер: 1601681060
Специалност: СТД
------------
Име: Калеко Алеко
Възраст: 46
ЕГН: 5305037893
Цвят на очите: Черни
Факултетен номер: 1601182060
Специалност: ???
 */