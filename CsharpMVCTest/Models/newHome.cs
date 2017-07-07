using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CsharpMVCTest.Models
{
    public static class newHome
    {
        public static IHtmlString aa()
        {
            return new HtmlString(@"
<button type=""button"" class=""btn btn-primary btn-lg"" data-toggle=""modal"" data-target=""#gg"">gg</button>
<div class=""modal fade"" tabindex=""-1"" role=""dialog"" id=""gg"">
  <div class=""modal-dialog"" role=""document"">
    <div class=""modal-content"">
      <div class=""modal-header"">
        <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close""><span aria-hidden=""true"">&times;</span></button>
        <h4 class=""modal-title"">Modal title</h4>
      </div>
      <div class=""modal-body"">
        <p>One fine body&hellip;</p>
      </div>
      <div class=""modal-footer"">
        <button type=""button"" class=""btn btn-default"" data-dismiss=""modal"">Close</button>
        <button type=""button"" class=""btn btn-primary"">Save changes</button>
      </div>
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->");
        }
        public static IHtmlString bb()
        {
            return new HtmlString(@"
<button type=""button"" class=""btn btn-primary btn-lg"" data-toggle=""modal"" data-target=""#yy"">yy</button>
<div class=""modal fade"" tabindex=""-1"" role=""dialog"" id=""yy"">
  <div class=""modal-dialog"" role=""document"">
    <div class=""modal-content"">
      <div class=""modal-header"">
        <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close""><span aria-hidden=""true"">&times;</span></button>
        <h4 class=""modal-title"">Modal title</h4>
      </div>
      <div class=""modal-body"">
        <p>One fine body&hellip;</p>
      </div>
      <div class=""modal-footer"">
        <button type=""button"" class=""btn btn-default"" data-dismiss=""modal"">Close</button>
        <button type=""button"" class=""btn btn-primary"">Save changes</button>
      </div>
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->");
        }
    }


    public class newHomeViewModel
    {
        public IHtmlString FirstPart { get; set; }
        public IHtmlString SecondPart { get; set; }

    }
}