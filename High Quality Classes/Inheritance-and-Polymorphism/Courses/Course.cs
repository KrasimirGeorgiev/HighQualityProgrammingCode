namespace InheritanceAndPolymorphism.Courses
{
    using System.Collections.Generic;
    using System.Text;

    public abstract class Course
    {
        private readonly IList<string> students = new List<string>();

        private string name;

        private string teacher;

        protected Course(string courseName)
        {
            this.Name = courseName;
            this.Teacher = null;
        }

        protected Course(string courseName, string teacher)
            : this(courseName)
        {
            this.Teacher = teacher;
        }

        protected Course(string courseName, string teacher, IList<string> students)
            : this(courseName, teacher)
        {
            this.AddStudents(students);
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                CourseValidations.ValidateCourseName(value);
                this.name = value;
            }
        }

        public string Teacher
        {
            get
            {
                return this.teacher;
            }

            set
            {
                if (value != null)
                {
                    CourseValidations.ValidateHumanName(value);
                }

                this.teacher = value;
            }
        }

        public IList<string> Students
        {
            get { return new List<string>(this.students); }
        }

        public void AddStudents(params string[] list)
        {
            foreach (var studentName in list)
            {
                this.AddStudent(studentName);
            }
        }

        public void AddStudents(IList<string> studentsList)
        {
            foreach (var studentName in studentsList)
            {
                this.AddStudent(studentName);
            }
        }

        public void RemoveAllStudents()
        {
            this.Students.Clear();
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.Append("LocalCourse { Name = ");
            result.Append(this.Name);

            if (this.Teacher != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.Teacher);
            }

            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());

            result.Append(" }");

            return result.ToString();
        }

        private void AddStudent(string name)
        {
            CourseValidations.ValidateHumanName(name);
            this.students.Add(name);
        }

        private string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }

            return "{ " + string.Join(", ", this.Students) + " }";
        }
    }
}