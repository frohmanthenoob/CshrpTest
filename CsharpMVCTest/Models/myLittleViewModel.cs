using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CsharpMVCTest.Models
{
    public class myLittleViewModel
    {
        public string Date { get; set; }
        public List<examSubjects> examSubject { get; set; }
        public string randomID { get; set; }
    }
    public class examSubjects
    {
        public string subject { get; set; }
    }
}