#pragma checksum "C:\Users\hb\Desktop\Sources\HomepageSorce\2021-07-18\backend\ITCREW_Homepage\ITCREWS\ITCREWS\Views\Community\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "41a28a7c72476e366d2e66c9015faaf3a83c509d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Community_Detail), @"mvc.1.0.view", @"/Views/Community/Detail.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\hb\Desktop\Sources\HomepageSorce\2021-07-18\backend\ITCREW_Homepage\ITCREWS\ITCREWS\Views\_ViewImports.cshtml"
using ITCREWS;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\hb\Desktop\Sources\HomepageSorce\2021-07-18\backend\ITCREW_Homepage\ITCREWS\ITCREWS\Views\_ViewImports.cshtml"
using ITCREWS.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"41a28a7c72476e366d2e66c9015faaf3a83c509d", @"/Views/Community/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"366e29d5e577c4f298e27b08831c84c5ede6f32c", @"/Views/_ViewImports.cshtml")]
    public class Views_Community_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CrewModel.SubjectInfoModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\hb\Desktop\Sources\HomepageSorce\2021-07-18\backend\ITCREW_Homepage\ITCREWS\ITCREWS\Views\Community\Detail.cshtml"
  
    ViewData["Title"] = "Detail";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>이건 상세페이지임(예시)</h1>\r\n\r\n\r\n\r\n<h2>detail</h2>\r\n\r\n<div>\r\n    제목\r\n    <input name=\"Title\"");
            BeginWriteAttribute("value", " value=\"", 166, "\"", 186, 1);
#nullable restore
#line 14 "C:\Users\hb\Desktop\Sources\HomepageSorce\2021-07-18\backend\ITCREW_Homepage\ITCREWS\ITCREWS\Views\Community\Detail.cshtml"
WriteAttributeValue("", 174, Model.Title, 174, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" readonly />\r\n</div>\r\n<div>\r\n    작성자\r\n    <input name=\"UserId\"");
            BeginWriteAttribute("value", " value=\"", 249, "\"", 270, 1);
#nullable restore
#line 18 "C:\Users\hb\Desktop\Sources\HomepageSorce\2021-07-18\backend\ITCREW_Homepage\ITCREWS\ITCREWS\Views\Community\Detail.cshtml"
WriteAttributeValue("", 257, Model.UserId, 257, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" readonly />\r\n</div>\r\n<div>\r\n    내용\r\n    <textarea name=\"Desc\" cols=\"80\" rows=\"4\" readonly>");
#nullable restore
#line 22 "C:\Users\hb\Desktop\Sources\HomepageSorce\2021-07-18\backend\ITCREW_Homepage\ITCREWS\ITCREWS\Views\Community\Detail.cshtml"
                                                 Write(Model.Desc);

#line default
#line hidden
#nullable disable
            WriteLiteral("</textarea>\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CrewModel.SubjectInfoModel> Html { get; private set; }
    }
}
#pragma warning restore 1591