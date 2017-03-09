namespace InheritanceAndPolymorphism.Courses
{
    using System.Collections.Generic;
    using System.Text;

    public class OffsiteCourse : Course
    {
        private string town;

        public OffsiteCourse(string courseName)
            : base(courseName)
        {
            this.Town = null;
        }

        public OffsiteCourse(string courseName, string teacherName)
            : base(courseName, teacherName)
        {
            this.Town = null;
        }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students)
            : base(courseName, teacherName, students)
        {
            this.Town = null;
        }

        public string Town
        {
            get
            {
                return this.town;
            }

            set
            {
                if (value != null)
                {
                    CourseValidations.ValidateHumanName(value);
                }

                this.town = value;
            }
        }

        public override string ToString()
        {
            if (this.Town != null)
            {
                var result = new StringBuilder();

                result.Append(base.ToString());
                result.Remove(result.Length - 1, 1);

                result.Append("; Town = ");
                result.Append(this.Town);

                result.Append(" }");

                return result.ToString();
            }

            return base.ToString();
        }
    }
}