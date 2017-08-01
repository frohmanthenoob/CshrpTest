using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CsharpTest
{
    class Program
    {
        public static string toCommonEra(string date)
        {
            System.Globalization.CultureInfo tc = new System.Globalization.CultureInfo("zh-TW");
            tc.DateTimeFormat.Calendar = new System.Globalization.TaiwanCalendar();
            return DateTime.Parse(date, tc).Date.ToString("yyyy/MM/dd");
        }
        public static string addSlach(string date)
        {
            string a = date.Substring(0, 3);
            string b = date.Substring(3, 2);
            string c = date.Substring(5, date.Length-5);
            return a + "/" + b + "/" + c;
        }
        static void Main(string[] args)
        {
            //List<ggc> gg = new List<ggc> { new ggc() { xString = "gaa", xInt = 1 }, new ggc() { xString = "gbb", xInt = 2 } };
            //List<string> myList = gg.Select(x => x.xString + " asdf").ToList<string>();
            //string combindedString = string.Join(",", myList);
            //Console.WriteLine(combindedString);

            //List<demoStruct> abc = new List<demoStruct>();
            //demoStruct aa = new demoStruct() { structString = "gg", structInt = 123 };
            //abc.Add(aa);
            //var a = abc.FirstOrDefault<demoStruct>().structInt - 4;
            //var bbb = abc[0];
            //bbb.structInt = 4;
            //demoStruct bb = aa;
            //Console.WriteLine(bb.structInt.ToString());
            //aa.structInt = 500;
            //Console.WriteLine(bb.structInt.ToString());
            //Console.WriteLine(aa.structInt.ToString());

            //IEnumerable<string> aa = new List<string>() { "aa", "bb", "cc", "dd", "ee", "ff", "gg", "hh" }.AsEnumerable<string>();
            //foreach (var item in aa.Skip<string>(0))
            //{
            //    Console.WriteLine(item.ToString());
            //}

            //string aaa = "";
            //string bbb = null;
            //Console.WriteLine(string.IsNullOrEmpty(aaa));
            //Console.WriteLine(string.IsNullOrEmpty(bbb));

            //Int32 g = new Int32();
            //string a = @"as""df";
            //Console.WriteLine(a + g.ToString());

            //string aa=null;

            //ggc aa = new ggc();
            //Console.WriteLine(object.ReferenceEquals(aa.xString, null));
            //Console.WriteLine(object.Equals(aa.xString, null));
            //Console.WriteLine(aa.xString);

            //ggctest aa = new ggctest();
            //aa.start = "2017/07/25 9:20";
            //aa.end = "2017/07/25 10:00";
            //aa.xInt = 0;
            //aa.xString = "how to use";
            //IPeriod<string> bb = aa;
            //bb.end = "asdf";
            //Console.WriteLine(bb.end);
            //Console.WriteLine(aa.ToString());

            //Console.WriteLine(DateTime.Now.ToShortDateString());
            //Console.WriteLine(DateTime.Now.ToShortTimeString());
            //Console.WriteLine("2017-07-25");
            //Console.WriteLine(DateTime.Now.ToShortDateString().Replace("/","-"));
            //Console.WriteLine(DateTime.Now.ToShortDateString().Replace("/","-") == "2017-07-25");
            //Console.WriteLine(DateTime.Now.ToString("yyyy/MM/dd"));

            //HashSet<string> aa = new HashSet<string>() { "a", "b", "b" };

            //foreach (var item in aa)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine(toCommonEra("106/07/25"));
            //Console.WriteLine(toCommonEra(addSlach("1060725")));

            //List<foo> a = new List<foo>(){
            //    new foo(){id = 1, color = "red"},
            //    new foo(){id = 2, color = "blue"},
            //    new foo(){id = 2, color = "blue"},
            //    new foo(){id = 3, color = "green"},
            //    new foo(){id = 1, color = "blue"},
            //    new foo(){id = 2, color = "orange" },        
            //    new foo(){id = 1, color = "black"},
            //    new foo(){id = 2, color = "amber"},
            //    new foo(){id = 3, color = "red"},
            //    new foo(){id = 4, color = "red"},
            //    new foo(){id = 2, color = "silver"}            
            //};
            //var colours1 = a.GroupBy(x => x.id)
            //      .Select(x => new { id = x.Key, color = x.Select(y => y.color).Distinct().ToList() })
            //      .ToList();
            //foreach (var item1 in colours1)
            //{
            //    Console.WriteLine(item1.id);
            //    foreach (var item2 in item1.color)
            //    {
            //        Console.WriteLine("     " + item2.ToString());
            //    }
            //}
            //Console.WriteLine("----------");
            //var colours2 = a.GroupBy(x => x.id)
            //            .Select(x => new { id = x.Key, color = String.Join(",", x.Select(y => y.color).Distinct().ToArray()) })
            //            .ToList();
            //foreach (var item1 in colours2)
            //{
            //    Console.WriteLine(item1.id);
            //    Console.WriteLine("     " + item1.color);
            //}
            //Console.ReadLine();


            //var sourceItems = new[] {
            //    new LogEntry {ID=1   ,UserName="foo      ", TimeStamp= new DateTime(2010 ,1,01),Details="Account created ",}    ,
            //    new LogEntry {ID=2   ,UserName="zip      ", TimeStamp= new DateTime(2010 ,2,02),Details="Account created ",}    ,
            //    new LogEntry {ID=3   ,UserName="bar      ", TimeStamp= new DateTime(2010 ,2,02),Details="Account created ",}    ,
            //    new LogEntry {ID=4   ,UserName="sandwich ", TimeStamp= new DateTime(2010 ,3,03),Details="Account created ",}    ,
            //    new LogEntry {ID=5   ,UserName="bar      ", TimeStamp= new DateTime(2010 ,5,05),Details="Stole food      ",}    ,
            //    new LogEntry {ID=6   ,UserName="foo      ", TimeStamp= new DateTime(2010 ,5,05),Details="Can't find food ",}    ,
            //    new LogEntry {ID=7   ,UserName="sandwich ", TimeStamp= new DateTime(2010 ,8,08),Details="Donated food    ",}    ,
            //    new LogEntry {ID=8   ,UserName="sandwich ", TimeStamp= new DateTime(2010 ,9,09),Details="Ate more food   ",}    ,
            //    new LogEntry {ID=9   ,UserName="foo      ", TimeStamp= new DateTime(2010 ,9,09),Details="Ate food        ",}    ,
            //    new LogEntry {ID=10  ,UserName="bar      ", TimeStamp= new DateTime(2010,11,11),Details="Can't find food ",}    ,
            //};

            //var results = sourceItems
            //    .OrderByDescending(item => item.TimeStamp)
            //    .GroupBy(item => item.UserName)
            //    .Select(grp => grp.First())
            //    .OrderBy(item => item.ID)
            //    .ToArray();
            ////foreach (var items in results)
            ////{
            ////    foreach (var item in items)
            ////    {
            ////        Console.WriteLine("{0} {1} {2} {3}",
            ////            item.ID, item.UserName, item.TimeStamp, item.Details);
            ////    }
            ////}
            //foreach (var item in results)
            //{
            //    Console.WriteLine("{0} {1} {2} {3}",
            //        item.ID, item.UserName, item.TimeStamp, item.Details);
            //}

            //var pr = new List<Product>()
            //{
            //    new Product() {Title="Boots",Color="Red",    Price=1},
            //    new Product() {Title="Boots",Color="Green",  Price=1},
            //    new Product() {Title="Boots",Color="Black",  Price=2},

            //    new Product() {Title="Sword",Color="Gray", Price=2},
            //    new Product() {Title="Sword",Color="Green",Price=2}
            //};
            //List<Product> result = pr.GroupBy(g => new { g.Title, g.Price })
            //             .Select(g => g.First())
            //             .ToList();
            //foreach (var item in pr)
            //{
            //    Console.WriteLine("Title = {0}, Color = {1}, Price = {2}.", item.Title, item.Color, item.Price);
            //}
            //Console.WriteLine("----------");
            //var aa = pr.GroupBy(x => x.Title, x => x.Price).Distinct();
            //foreach (var item in aa)
            //{
            //    Console.WriteLine(item.Key);
            //    foreach (var items in item)
            //    {
            //        Console.WriteLine("    " + items);
            //    }
            //}

            //List<Pet> petsList =
            //    new List<Pet>{ new Pet { Name="Barley", Age=8.3 },
            //                   new Pet { Name="Boots", Age=4.9 },
            //                   new Pet { Name="Whiskers", Age=1.5 },
            //                   new Pet { Name="Daisy", Age=4.3 } };
            //IEnumerable<PetInfo> query = petsList.GroupBy<Pet, double, double, PetInfo>(
            //pet => Math.Floor(pet.Age), //keySelector
            //pet => pet.Age,             //elementSelector
            //(baseAge, ages) => new PetInfo()   //resultSelector
            //{
            //    Key = baseAge,
            //    Count = ages.Count(),
            //    Min = ages.Min(),
            //    Max = ages.Max()
            //});

            //foreach (var item in query)
            //{
            //    Console.WriteLine(
            //        "Key:baseAge = {0},\n Count:ages.Count() = {1},\n Min:ages.Min() = {2},\n Max:ages.Max() = {3}",
            //        item.Key, item.Count, item.Min, item.Max);
            //}

            //Category<string> a = new ggCategory() { subdivision="yy"};
            //a.division = "gg";
            //Console.WriteLine(a);
            //Console.WriteLine("--------------------------------------------------");
            //ICategory<string> b = new yyCategory() { subdivision = "gg" };
            //b.division = "yy";
            //ICategory<string> c = b;
            //Console.WriteLine(b.);
            //Console.WriteLine(c.division + " " + c.subdivision);

            IEnumerable<LogEntry> sourceItems = new List<LogEntry> {
                new LogEntry {ID=1   ,UserName="foo      ", TimeStamp= new DateTime(2010 ,1,01),Details="Account created "}    ,
                new LogEntry {ID=2   ,UserName="zip      ", TimeStamp= new DateTime(2010 ,2,02),Details="Account created "}    ,
                new LogEntry {ID=3   ,UserName="bar      ", TimeStamp= new DateTime(2010 ,2,02),Details="Account created "}    ,
                new LogEntry {ID=4   ,UserName="sandwich ", TimeStamp= new DateTime(2010 ,3,03),Details="Account created "}    ,
                new LogEntry {ID=5   ,UserName="bar      ", TimeStamp= new DateTime(2010 ,5,05),Details="Stole food      "}    ,
                new LogEntry {ID=6   ,UserName="foo      ", TimeStamp= new DateTime(2010 ,5,05),Details="Can't find food "}    ,
                new LogEntry {ID=7   ,UserName="sandwich ", TimeStamp= new DateTime(2010 ,8,08),Details="Donated food    "}    ,
                new LogEntry {ID=8   ,UserName="sandwich ", TimeStamp= new DateTime(2010 ,9,09),Details="Ate more food   "}    ,
                new LogEntry {ID=9   ,UserName="foo      ", TimeStamp= new DateTime(2010 ,9,09),Details="Ate food        "}    ,
                new LogEntry {ID=10  ,UserName="bar      ", TimeStamp= new DateTime(2010,11,11),Details="Can't find food "}    ,
                new LogEntry {ID=11  ,UserName="foo      ", TimeStamp= new DateTime(2010,11,12),Details="Account created "}    

            };


            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();//引用stopwatch物件
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時
            //var aa = sourceItems.GroupBy(m => m.UserName, y => y.Details);
            //IEnumerable<IGrouping<string,string>> aa = sourceItems.GroupBy(m => new { m.UserName, m.Details }).Select(g => g.First()).OrderByDescending(m => m.UserName).Select(m => new { UserName = m.UserName, Details = m.Details }).GroupBy(m=>m.UserName,m=>m.Details);

            IEnumerable<IGrouping<string, string>> aa = sourceItems.Select(m => new { UserName = m.UserName, Details = m.Details }).GroupBy(m => new { m.UserName, m.Details }).Select(g => g.First()).OrderByDescending(m => m.UserName).GroupBy(m => m.UserName, m => m.Details);
            
            sw.Stop();//碼錶停止
            //印出所花費的總豪秒數
            string result1 = sw.Elapsed.TotalMilliseconds.ToString();
            Console.WriteLine(result1);
            foreach (IGrouping<string, string> item in aa)
            {
                Console.WriteLine(item.Key);
                foreach (string items in item)
                {
                    Console.WriteLine(" "+items);
                }
            }


            Console.ReadKey();
        }
    };
    class ggc
    {
        public string xString { get; set; }
        public int xInt { get; set; }
    }
    struct demoStruct
    {
        public string structString { get; set; }
        public int structInt { get; set; }
    }
    class ggctest : ggc, IPeriod<string>
    {
        public string start { get; set; }
        public string end { get; set; }
        public override string ToString()
        {
            return "this is the " + this.xInt.ToString() + " data \nand has \"" + this.xString + "\" \nend record at " + this.end + " \nstart record at " + this.start;
        }
    }

    interface IPeriod<T>
    {
        T start { get; set; }
        T end { get; set; }
    }

    public class foo
    {
        public int id { get; set; }
        public string color { get; set; }
    }

    public class LogEntry
    {
        public int ID;
        public string UserName;
        public DateTime TimeStamp;
        public string Details;
    }
    public class Product
    {
        public string Title { get; set; }
        public string Color { get; set; }
        public int Price { get; set; }
    }
    public class Pet
    {
        public string Name { get; set; }
        public double Age { get; set; }
    }

    public class PetInfo
    {
        public double Key { get; set; }
        public double Count { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
    }

    public abstract class Category<T>
    {
        public T division { get; set; }
        public T subdivision { get; set; }
    }

    public class ggCategory : Category<string> 
    {
        public override string ToString()
        {
            return division+" "+subdivision;
        }
    }
    interface ICategory<T>
    {
        T division { get; set; }
        T subdivision { get; set; }
    }
    public class yyCategory : ICategory<string>
    {
        public string division { get; set; }

        public string subdivision { get; set; }

        public override string ToString()
        {
            return division + " " + subdivision;
        }
    }
}
