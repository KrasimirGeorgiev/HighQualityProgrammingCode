namespace InheritanceAndPolymorphism.Courses
{
    using System;
    using System.Text.RegularExpressions;

    public static class CourseValidations
    {
        public static void ValidateCourseName(string name)
        {
            var invalidCharacters = @"[^\w\s]";
            ValidateString(name, invalidCharacters);
        }

        public static void ValidateHumanName(string name)
        {
            var invalidCharacters = @"[^A-Za-z\s]";
            ValidateString(name, invalidCharacters);
        }

        public static void ValidateLabName(string name)
        {
            var invalidCharacters = @"[^\w\d]";
            ValidateString(name, invalidCharacters);
        }

        private static void ValidateString(string str, string invalidCharacters)
        {
            if (Regex.IsMatch(str, invalidCharacters))
            {
                throw new NotSupportedException("Invalid Characters Used");
            }
        }
    }
}