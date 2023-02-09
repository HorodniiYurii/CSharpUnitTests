using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    [TestClass]
    public class WorkDayCalculatorTests
    {

        [TestMethod]
        public void TestNoWeekEnd()
        {
         
            DateTime startDate = new DateTime(2021, 12, 1);
         
            int count = 10;

            DateTime result = new WorkDayCalculator().Calculate(startDate, count, null);

            Assert.AreEqual(startDate.AddDays(count-1), result);
        }

        [TestMethod]
        public void TestNormalPath()
        {
            DateTime startDate = new DateTime(2021, 4, 21);
            
            int count = 5;
            
            WeekEnd[] weekends = new WeekEnd[1]
            {
                new WeekEnd(new DateTime(2021, 4, 23), new DateTime(2021, 4, 25))
            };
            
            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekends);

            Assert.IsTrue(result.Equals(new DateTime(2021, 4, 28)));
        }

        [TestMethod]
        public void TestWeekendAfterEnd()
        {
            DateTime startDate = new DateTime(2021, 4, 21);
            int count = 5;
            WeekEnd[] weekends = new WeekEnd[2]
            {
                
                new WeekEnd(new DateTime(2021, 4, 23), new DateTime(2021, 4, 25)),
                new WeekEnd(new DateTime(2021, 4, 29), new DateTime(2021, 4, 29))
            };
            
            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekends);

            Assert.IsTrue(result.Equals(new DateTime(2021, 4, 28)));
        }

        [TestMethod]
        public void TestMoreThenOneWeekend()
        {
            DateTime startDate = new DateTime(2021, 4, 1);
            int count = 20;
            WeekEnd[] weekends = new WeekEnd[2]
            {
                new WeekEnd(new DateTime(2021, 4, 5), new DateTime(2021, 4, 9)),
                new WeekEnd(new DateTime(2021, 4, 10), new DateTime(2021, 4, 13))
                
            };

            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekends);

            Assert.IsTrue(result.Equals(new DateTime(2021, 4, 29)));
        }

        //TEST 5 StartDate coincide the last day of one of the weekends.
        [TestMethod]
        public void TestDateStartCoincideLastDay()
        {
            DateTime startDate = new DateTime(2021, 4, 5);
            int count = 10;
            WeekEnd[] weekends = new WeekEnd[2]
            {
                new WeekEnd(new DateTime(2021, 4, 3), new DateTime(2021, 4, 5)),
                new WeekEnd(new DateTime(2021, 4, 10), new DateTime(2021, 4, 13))

            };

            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekends);

            Assert.IsTrue(result.Equals(new DateTime(2021, 4, 19)));
        }

        //TEST 7 StartDate coincide with one of the weekends and it consists of 1 day.
        [TestMethod]
        public void TestDateStartCoincideLastOneDay()
        {
            DateTime startDate = new DateTime(2021, 4, 5);
            int count = 10;
            WeekEnd[] weekends = new WeekEnd[2]
            {
                new WeekEnd(new DateTime(2021, 4, 5), new DateTime(2021, 4, 5)),
                new WeekEnd(new DateTime(2021, 4, 10), new DateTime(2021, 4, 13))

            };

            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekends);

            Assert.IsTrue(result.Equals(new DateTime(2021, 4, 19)));
        }


        //Test 6 StartDate falls between weekends and falls on 1 of the weekends.
        [TestMethod]
        public void TestDateStartBetweenWeekends()
        {
            DateTime startDate = new DateTime(2021, 4, 23);
            int count = 6;
            WeekEnd[] weekends = new WeekEnd[3]
            {
                new WeekEnd(new DateTime(2021, 4, 20), new DateTime(2021, 4, 21)),
                new WeekEnd(new DateTime(2021, 4, 28), new DateTime(2021, 4, 28)),
                new WeekEnd(new DateTime(2021, 4, 29), new DateTime(2021, 4, 29))

            };

            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekends);

            Assert.IsTrue(result.Equals(new DateTime(2021, 4, 30)));
        }
    }
}
