using System;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (base.Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked grading requires at least 5 students.");
            }

            int cutoff = (int)Math.Ceiling(Students.Count * 0.2);
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if(grades[cutoff-1] <= averageGrade)
            {
                return 'A';
            } else if (grades[(cutoff * 2) - 1] <= averageGrade)
            {
                return 'B';
            } else if (grades[(cutoff * 3) - 1] <= averageGrade)
            {
                return 'C';
            } else if (grades[(cutoff * 4) - 1] <= averageGrade)
            {
                return 'D';
            } else
            {
                return 'F';
            }
        }

        public override void CalculateStatistics()
        {
            if (base.Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            } else
            {
                base.CalculateStatistics();
            }
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (base.Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            } else
            {
                base.CalculateStudentStatistics(name);
            }
        }
    }
}
