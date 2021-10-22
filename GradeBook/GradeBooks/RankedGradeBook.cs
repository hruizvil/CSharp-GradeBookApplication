using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name)
            :base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5) 
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            
            var top20 = averageGrade * 0.8;
            var top40 = averageGrade * 0.6;
            var top60 = averageGrade * 0.4;
            var top80 = averageGrade * 0.2;

            if (averageGrade >= top20) return 'A';
            else if (averageGrade < top20 || averageGrade >= top40)
                return 'B';
            else if (averageGrade < top40 || averageGrade > top60)
                return 'C';
            else if (averageGrade < top60 || averageGrade > top80)
                return 'D';

            //return base.GetLetterGrade(averageGrade);
            return 'F';
        }
    }
}
