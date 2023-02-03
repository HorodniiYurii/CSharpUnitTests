using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public class WeekEnd
    {
        // дата начала
        public DateTime StartDate { get; set; }
        //дата конца
        public DateTime EndDate { get; set; }
        //конструктор инициализация
        public WeekEnd(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
