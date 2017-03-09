// Task 2. Refactor the following if statements
namespace Homework.Telerik.HighQualityCode
{
   public class VisitCellIfStatements
    {
        private static void CellChecks()
        {
            if (shouldVisitCell &&  
                MAX_X >= x && x >= MIN_X && 
                MAX_Y >= y && y >= MIN_Y)
            {
                VisitCell();
            }
        }
    }
}
