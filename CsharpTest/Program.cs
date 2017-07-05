using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpTest
{
    class Program
    {
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

            string a = @"as""df";
            Console.WriteLine(a);

            Console.ReadLine();

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
}
