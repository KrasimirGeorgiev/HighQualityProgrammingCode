namespace InheritanceAndPolymorphism.Courses
{
    using System.Collections.Generic;
    using System.Text;

    public class LocalCourse : Course
    {
        private string lab;

        public LocalCourse(string courseName)
            : base(courseName)
        {
        }

        public LocalCourse(string courseName, string teacher)
            : base(courseName, teacher)
        {
        }

        public LocalCourse(string courseName, string teacher, string lab)
            : base(courseName, teacher)
        {
            this.Lab = lab;
        }

        public LocalCourse(string courseName, string teacher, IList<string> students, string lab)
            : base(courseName, teacher, students)
        {
            this.Lab = lab;
        }

        public string Lab
        {
            get
            {
                return this.lab;
            }

            set
            {
                if (value != null)
                {
                    CourseValidations.ValidateLabName(value);
                }

                this.lab = value;
            }
        }

        public override string ToString()
        {
            if (this.Lab != null)
            {
                var result = new StringBuilder();

                result.Append(base.ToString());
                result.Remove(result.Length - 1, 1);

                result.Append("; Lab = ");
                result.Append(this.Lab);
                result.Append("}");
                return result.ToString();
            }

            return base.ToString();
        }
    }
}