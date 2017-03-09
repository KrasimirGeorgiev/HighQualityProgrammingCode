namespace Telerik.Homeworks.HQC.DefensiveProgramming.Exceptions
{
    using System;

    public class SimpleMathExam : Exam
    {
        private const int MinProblemsSolved = 0;

        private const int MaxProblemsSolved = 10;

        private const int AverageProblemsSolved = 5;

        private const int BadGrade = 2;

        private const int AverageGrade = 4;

        private const int VeryGoodGrade = 5;

        private const int ExellentGrade = 6;

        private int problemsSolved;

        public SimpleMathExam(int problemsSolved)
        {
            this.ProblemsSolved = problemsSolved;
        }

        public int ProblemsSolved 
        {
            get
            {
                return this.problemsSolved;
            }

            private set
            {
                if (value <= SimpleMathExam.MinProblemsSolved)
                {
                    this.problemsSolved = SimpleMathExam.MinProblemsSolved;
                }
                else if (value >= SimpleMathExam.MaxProblemsSolved)
                {
                    this.problemsSolved = SimpleMathExam.MaxProblemsSolved;
                }
                else
                {
                    this.problemsSolved = value;
                }
            }
        }

        public override ExamResult Check()
        {
            int grade;
            string message;

            if (this.ProblemsSolved <= SimpleMathExam.MinProblemsSolved)
            {
                grade = SimpleMathExam.BadGrade;
                message = "Bad result: nothing done.";
            }
            else if (SimpleMathExam.MinProblemsSolved < this.ProblemsSolved && 
                this.ProblemsSolved <= SimpleMathExam.AverageProblemsSolved)
            {
                grade = SimpleMathExam.AverageGrade;
                message = "Average result: something done.";
            }
            else if (SimpleMathExam.MaxProblemsSolved > this.ProblemsSolved && this.ProblemsSolved > SimpleMathExam.AverageGrade)
            {
                grade = SimpleMathExam.VeryGoodGrade;
                message = "Very Good result: Almost all done.";
            }
            else
            {
                grade = SimpleMathExam.ExellentGrade;
                message = "Exellent results: All done.";
            }

            return new ExamResult(grade, SimpleMathExam.BadGrade, SimpleMathExam.ExellentGrade, message);
        }
    }
}