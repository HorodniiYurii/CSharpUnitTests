using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public class WorkDayCalculator : IWorkDayCalculator
    {
        public DateTime Calculate(DateTime startDate, int dayCount, WeekEnd[] weekEnds)
        {
            //end date no holidays
            DateTime result = startDate.AddDays(dayCount);
            //count of weekends in one range
            TimeSpan CountWeekEnds;
            //total count of weekends 
            int TotalWeekEnds = 0;
            //if no weekends
            if (weekEnds == null)
            {
                result = startDate.AddDays(dayCount - 1);
            }
            //if weekends > 1
            else
            {

                for (int i = 0; i < weekEnds.Length; i++)
                {
                    // startDate coincides with weekEnds[i].EndDate of one of the weekends.
                    if (startDate == weekEnds[i].EndDate)
                    {
                        TotalWeekEnds += 1;
                        //i++;
                        continue;
                    }
                    if (result == weekEnds[i].StartDate)
                    {
                        // i++;
                        continue;
                    }
                    if ((weekEnds[i].StartDate <= startDate) && (startDate <= weekEnds[i].EndDate))
                    {
                        startDate = weekEnds[i].EndDate.AddDays(1);
                        result = startDate.AddDays(dayCount);
                        continue;
                    }
                    //if the weekend is between startDate and result
                    //if ((weekEnds[i].EndDate <= result) && (startDate >= weekEnds[i].StartDate))
                    if ((result >= weekEnds[i].EndDate) && (startDate <= weekEnds[i].StartDate) || (result.AddDays(-1) == weekEnds[i].StartDate))
                    {
                        //counting the number of weekEnds in range
                        CountWeekEnds = weekEnds[i].EndDate.Subtract(weekEnds[i].StartDate);
                        //total the number of weekEnds in range
                        TotalWeekEnds += (int)CountWeekEnds.TotalDays + 1;
                        //end date with holidays
                        result = startDate.AddDays(dayCount + TotalWeekEnds);
                    }
                }
                result = result.AddDays(-1);
            }
            return result;
        }

    }
}
