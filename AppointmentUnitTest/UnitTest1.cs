using c969.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace AppointmentUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckAppointmentOverlap()
        {
            DateTime apptStart = new DateTime(2022, 11, 11, 14, 45, 0);
            DateTime apptEnd = new DateTime(2022, 11, 11, 14, 57, 0);

            DateTime appt2Start = new DateTime(2022, 11, 11, 14, 50, 0);
            DateTime appt2End = new DateTime(2022, 11, 11, 14, 52, 0);

            if (appt2Start < apptStart && appt2End > apptStart)
            {
                Assert.Fail("Appointment 2's end time interferes with another appointment");
            }
            else if (appt2Start >= apptEnd && appt2End < apptEnd)
            {
                Assert.Fail("Appointment 2's end time interferes with another appointment and is earlier than the start time");
            }
            else if (appt2Start >= apptStart && appt2End <= apptEnd)
            {
                Assert.Fail("Appointment 2's time frame interferes with another appointment");
            }
            else if (appt2Start > apptStart && appt2Start < apptEnd) 
            {
                Assert.Fail("Appointment 2's start time interferes with another appointment");
            }
            else if (appt2Start <= apptStart && appt2End >= apptEnd)
            {
                Assert.Fail("Appointment 2 wraps another apointment");
            }

        }

        [TestMethod]
        public void CheckAppointmentAgainstBusinessHours()
        {
            DateTime apptStart = new DateTime(2022, 11, 11, 6, 45, 0);
            DateTime apptEnd = new DateTime(2022, 11, 11, 15, 30, 0);

            TimeSpan openTime = new TimeSpan(8, 0, 0);
            TimeSpan closeTime = new TimeSpan(17, 0, 0);

            TimeSpan start = new TimeSpan(apptStart.TimeOfDay.Hours, apptStart.TimeOfDay.Minutes, 0);
            TimeSpan end = new TimeSpan(apptEnd.TimeOfDay.Hours, apptEnd.TimeOfDay.Minutes, 0);

            if (TimeSpan.Compare(start, openTime) == -1 || TimeSpan.Compare(end, closeTime) > 0 || apptStart.Day != apptEnd.Day) {
                Assert.Fail("Start & End Times Must Be between 8:00 AM & 5:00 PM & Be On The Same Date In Local Time!");
            }
        }
    }
}
