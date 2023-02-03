﻿using System;
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
            DateTime result = startDate.AddDays(dayCount); ;
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
                    //if the weekend is in the range
                    if (result > weekEnds[i].StartDate)
                    {
                        //counting the number of weekEnds in range
                        CountWeekEnds = weekEnds[i].EndDate.Subtract(weekEnds[i].StartDate);
                        //total the number of weekEnds in range
                        TotalWeekEnds += (int)CountWeekEnds.TotalDays+1;
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
