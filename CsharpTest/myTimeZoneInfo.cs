using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpTest
{
    class myTimeZoneInfo
    {
        public void runCreateCustomTimeZone()
        {
            string displayName = "(GMT+06:00) Antarctica/Mawson Time";
            string standardName = "Mawson Time";
            TimeSpan offset = new TimeSpan(06, 00, 00);
            TimeZoneInfo mawson = TimeZoneInfo.CreateCustomTimeZone(standardName, offset, displayName, standardName);
            Console.WriteLine("The current time is {0} {1}",
                              TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, mawson),
                              mawson.StandardName);
        }

        public void runFindSystemTimeZoneById()
        {
            DateTime thisTime = DateTime.Now;
            Console.WriteLine("Time in {0} zone: {1}", TimeZoneInfo.Local.IsDaylightSavingTime(thisTime) ?
                              TimeZoneInfo.Local.DaylightName : TimeZoneInfo.Local.StandardName, thisTime);
            Console.WriteLine("   UTC Time: {0}", TimeZoneInfo.ConvertTimeToUtc(thisTime, TimeZoneInfo.Local));
            // Get Tokyo Standard Time zone
            TimeZoneInfo tst = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");
            DateTime tstTime = TimeZoneInfo.ConvertTime(thisTime, TimeZoneInfo.Local, tst);
            Console.WriteLine("Time in {0} zone: {1}", tst.IsDaylightSavingTime(tstTime) ?
                              tst.DaylightName : tst.StandardName, tstTime);
            Console.WriteLine("   UTC Time: {0}", TimeZoneInfo.ConvertTimeToUtc(tstTime, tst));
        }

        public void runFromSerializedString()
        {
            TimeZoneInfo southPole = null;
            // Determine if South Pole time zone is defined in system
            try
            {
                southPole = TimeZoneInfo.FindSystemTimeZoneById("Antarctica/South Pole Standard Time");
            }
            // Time zone does not exist; create it, store it in a text file, and return it
            catch
            {
                const string filename = @".\TimeZoneInfo.txt";
                bool found = false;

                if (File.Exists(filename))
                {
                    StreamReader reader = new StreamReader(filename);
                    string timeZoneInfo;
                    while (reader.Peek() >= 0)
                    {
                        timeZoneInfo = reader.ReadLine();
                        if (timeZoneInfo.Contains("Antarctica/South Pole"))
                        {
                            southPole = TimeZoneInfo.FromSerializedString(timeZoneInfo);
                            reader.Close();
                            found = true;
                            break;
                        }
                    }
                }
                if (!found)
                {
                    // Define transition times to/from DST
                    TimeZoneInfo.TransitionTime startTransition = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1, 2, 0, 0), 10, 1, DayOfWeek.Sunday);
                    TimeZoneInfo.TransitionTime endTransition = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1, 2, 0, 0), 3, 3, DayOfWeek.Sunday);
                    // Define adjustment rule
                    TimeSpan delta = new TimeSpan(1, 0, 0);
                    TimeZoneInfo.AdjustmentRule adjustment = TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(new DateTime(1989, 10, 1), DateTime.MaxValue.Date, delta, startTransition, endTransition);
                    // Create array for adjustment rules
                    TimeZoneInfo.AdjustmentRule[] adjustments = { adjustment };
                    // Define other custom time zone arguments
                    string displayName = "(GMT+12:00) Antarctica/South Pole";
                    string standardName = "Antarctica/South Pole Standard Time";
                    string daylightName = "Antarctica/South Pole Daylight Time";
                    TimeSpan offset = new TimeSpan(12, 0, 0);
                    southPole = TimeZoneInfo.CreateCustomTimeZone(standardName, offset, displayName, standardName, daylightName, adjustments);
                    // Write time zone to the file
                    StreamWriter writer = new StreamWriter(filename, true);
                    writer.WriteLine(southPole.ToSerializedString());
                    writer.Close();
                }
            }
            Console.WriteLine(southPole);
        }

        public void runGetSystemTimeZones()
        {
            const string OUTPUTFILENAME = @"C:\Temp\TimeZoneInfo.txt";

            DateTimeFormatInfo dateFormats = CultureInfo.CurrentCulture.DateTimeFormat;
            ReadOnlyCollection<TimeZoneInfo> timeZones = TimeZoneInfo.GetSystemTimeZones();
            StreamWriter sw = new StreamWriter(OUTPUTFILENAME, false);

            foreach (TimeZoneInfo timeZone in timeZones)
            {
                bool hasDST = timeZone.SupportsDaylightSavingTime;
                TimeSpan offsetFromUtc = timeZone.BaseUtcOffset;
                TimeZoneInfo.AdjustmentRule[] adjustRules;
                string offsetString;

                sw.WriteLine("ID: {0}", timeZone.Id);
                sw.WriteLine("   Display Name: {0, 40}", timeZone.DisplayName);
                sw.WriteLine("   Standard Name: {0, 39}", timeZone.StandardName);
                sw.Write("   Daylight Name: {0, 39}", timeZone.DaylightName);
                sw.Write(hasDST ? "   ***Has " : "   ***Does Not Have ");
                sw.WriteLine("Daylight Saving Time***");
                offsetString = String.Format("{0} hours, {1} minutes", offsetFromUtc.Hours, offsetFromUtc.Minutes);
                sw.WriteLine("   Offset from UTC: {0, 40}", offsetString);
                adjustRules = timeZone.GetAdjustmentRules();
                sw.WriteLine("   Number of adjustment rules: {0, 26}", adjustRules.Length);
                if (adjustRules.Length > 0)
                {
                    sw.WriteLine("   Adjustment Rules:");
                    foreach (TimeZoneInfo.AdjustmentRule rule in adjustRules)
                    {
                        TimeZoneInfo.TransitionTime transTimeStart = rule.DaylightTransitionStart;
                        TimeZoneInfo.TransitionTime transTimeEnd = rule.DaylightTransitionEnd;

                        sw.WriteLine("      From {0} to {1}", rule.DateStart, rule.DateEnd);
                        sw.WriteLine("      Delta: {0}", rule.DaylightDelta);
                        if (!transTimeStart.IsFixedDateRule)
                        {
                            sw.WriteLine("      Begins at {0:t} on {1} of week {2} of {3}", transTimeStart.TimeOfDay,
                                                                                          transTimeStart.DayOfWeek,
                                                                                          transTimeStart.Week,
                                                                                          dateFormats.MonthNames[transTimeStart.Month - 1]);
                            sw.WriteLine("      Ends at {0:t} on {1} of week {2} of {3}", transTimeEnd.TimeOfDay,
                                                                                          transTimeEnd.DayOfWeek,
                                                                                          transTimeEnd.Week,
                                                                                          dateFormats.MonthNames[transTimeEnd.Month - 1]);
                        }
                        else
                        {
                            sw.WriteLine("      Begins at {0:t} on {1} {2}", transTimeStart.TimeOfDay,
                                                                           transTimeStart.Day,
                                                                           dateFormats.MonthNames[transTimeStart.Month - 1]);
                            sw.WriteLine("      Ends at {0:t} on {1} {2}", transTimeEnd.TimeOfDay,
                                                                         transTimeEnd.Day,
                                                                         dateFormats.MonthNames[transTimeEnd.Month - 1]);
                        }
                    }
                }
            }
            sw.Close();
        }
        public void runUtc() {
            TimeZoneInfo universalZone = TimeZoneInfo.Utc;
            Console.WriteLine("The universal time zone is {0}.", universalZone.DisplayName);
            Console.WriteLine("Its standard name is {0}.", universalZone.StandardName);
            Console.WriteLine("Its daylight savings name is {0}.", universalZone.DaylightName); 
        }
        public void runLocal1() {
            DateTime date1 = new DateTime(2006, 3, 21, 2, 0, 0);

            Console.WriteLine(date1.ToUniversalTime());
            Console.WriteLine(TimeZoneInfo.ConvertTimeToUtc(date1));
            Console.WriteLine(TimeZoneInfo.ConvertTimeToUtc(date1, TimeZoneInfo.Local));

            TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
            Console.WriteLine(TimeZoneInfo.ConvertTimeToUtc(date1, tz));    
        }
        public void runLocal2()
        {
            TimeZoneInfo localZone = TimeZoneInfo.Local;
            Console.WriteLine("Local Time Zone ID: {0}", localZone.Id);
            Console.WriteLine("   Display Name is: {0}.", localZone.DisplayName);
            Console.WriteLine("   Standard name is: {0}.", localZone.StandardName);
            Console.WriteLine("   Daylight saving name is: {0}.", localZone.DaylightName); 
        }

    }
}
