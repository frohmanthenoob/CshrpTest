using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CsharpMVCTest.Models
{
    public static class UiHelper 
    {
        public static IHtmlString mkDOM(object a, DOMProperty prop)
        {
            string dom = "<" + prop.tagName + " class=\"" + prop.className + "\" style=\"" + prop.styleName + "\">" + a.ToString() + "</" + prop.tagName + ">";
            string domBeginTag, domEndTag;
            if (String.IsNullOrEmpty(prop.tagName))
            {
                return new HtmlString("");
            }
            else
            {
                domBeginTag = "<" + prop.tagName;
                domEndTag = "</" + prop.tagName + ">";
                if (!String.IsNullOrEmpty(prop.styleName))
                {
                    domBeginTag += " style=\"" + prop.styleName + "\"";
                }
                if (!String.IsNullOrEmpty(prop.tagName))
                {
                    domBeginTag += " class=\"" + prop.className + "\"";
                }
                domBeginTag += ">";
                dom = domBeginTag + a.ToString() + domEndTag;
            }
            return new HtmlString(dom);
        }
    }
    public static class UiHelper<T> where T : struct
    {
        public static IHtmlString mkDOM(T a, DOMProperty prop) 
        {
            string dom = "<" + prop.tagName + " class=\"" + prop.className + "\" style=\"" + prop.styleName + "\">" + a.ToString() + "</" + prop.tagName + ">";
            string domBeginTag,domEndTag;
            if (String.IsNullOrEmpty(prop.tagName))
            {
                return new HtmlString("");
            }
            else
            {
                domBeginTag = "<" + prop.tagName;
                domEndTag = "</" + prop.tagName + ">";
                if (!String.IsNullOrEmpty(prop.styleName))
                {
                    domBeginTag += " style=\"" + prop.styleName + "\"";
                }
                if (!String.IsNullOrEmpty(prop.tagName))
                {
                    domBeginTag += " class=\"" + prop.className + "\"";
                }
                domBeginTag += ">";
                dom = domBeginTag+a.ToString()+domEndTag;
            }
            return new HtmlString(dom);
        }
    }
    public class DOMProperty 
    {
        public string tagName { get; set; }
        public string className { get; set; }
        public string styleName { get; set; }
    }
}