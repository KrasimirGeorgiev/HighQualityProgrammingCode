namespace SchoolSystem.DataModels
{
    public static class Constraints
    {
        public const int MinNameLength = 2;
        public const int MaxNameLength = 31;
        public const string NamePattern = "[A-Za-z]";

        public const int MinGrade = 1;
        public const int MaxGrade = 12;

        public const int MinMark = 2;
        public const int MaxMark = 6;
        public const int MaxMarksCount = 20;
    }
}