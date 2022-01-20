#pragma checksum "/Users/karanvishwakarma/Desktop/webproj/FirmAssetProject/Views/Home/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eb501b6535d56bb7e20e4fec63d7197d7987c172"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "/Users/karanvishwakarma/Desktop/webproj/FirmAssetProject/Views/_ViewImports.cshtml"
using ASPProject4;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "/Users/karanvishwakarma/Desktop/webproj/FirmAssetProject/Views/Home/Index.cshtml"
using ASPProject4.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eb501b6535d56bb7e20e4fec63d7197d7987c172", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"314e9eabfd80f89ba025fea56ede4e140120a784", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<UserModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 4 "/Users/karanvishwakarma/Desktop/webproj/FirmAssetProject/Views/Home/Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<div class=\"text-center\">\n    <h1 class=\"display-4\">Firms and Assests Association</h1>\n</div>\n<!-- HTML Form for uploading the files -->\n");
#nullable restore
#line 12 "/Users/karanvishwakarma/Desktop/webproj/FirmAssetProject/Views/Home/Index.cshtml"
 using (Html.BeginForm("Index",
                    "Home",
                    FormMethod.Post,
                    new { @enctype = "multipart/form-data" }))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <label class=\"form-label\" for=\"file\">Upload Firm File</label>\n    <input type=\"file\" class=\"form-control\" name=\"firmFile\" id=\"firmFile\" />\n");
            WriteLiteral("    <br>\n    <label class=\"form-label\" for=\"file\">Upload Assest Class File</label>\n    <input type=\"file\" class=\"form-control\" name=\"assetFile\" id=\"assetFile\" />\n    <br>\n    <br>\n");
            WriteLiteral("    <input type=\"submit\" class=\"btn btn-primary\" value=\"Get results\" />\n");
            WriteLiteral("    <br>\n    <br>\n");
#nullable restore
#line 30 "/Users/karanvishwakarma/Desktop/webproj/FirmAssetProject/Views/Home/Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<!-- Condition for checking if the number of records returned from the HomeController is not zero-->\n");
#nullable restore
#line 32 "/Users/karanvishwakarma/Desktop/webproj/FirmAssetProject/Views/Home/Index.cshtml"
 if (Model.Count() > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <table class=\"table caption-top table-bordered table-striped table-hover\">\n    <!-- iterating through the result and printing the output-->\n");
#nullable restore
#line 36 "/Users/karanvishwakarma/Desktop/webproj/FirmAssetProject/Views/Home/Index.cshtml"
         foreach (UserModel user in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\n            <td>");
#nullable restore
#line 39 "/Users/karanvishwakarma/Desktop/webproj/FirmAssetProject/Views/Home/Index.cshtml"
           Write(user.FirmName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <!-- Getting the asset name of the parrticular company -->\n");
#nullable restore
#line 41 "/Users/karanvishwakarma/Desktop/webproj/FirmAssetProject/Views/Home/Index.cshtml"
             foreach (string assetName in @user.Companytable)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td>");
#nullable restore
#line 43 "/Users/karanvishwakarma/Desktop/webproj/FirmAssetProject/Views/Home/Index.cshtml"
               Write(assetName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n");
#nullable restore
#line 44 "/Users/karanvishwakarma/Desktop/webproj/FirmAssetProject/Views/Home/Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tr>\n");
#nullable restore
#line 46 "/Users/karanvishwakarma/Desktop/webproj/FirmAssetProject/Views/Home/Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\n");
#nullable restore
#line 48 "/Users/karanvishwakarma/Desktop/webproj/FirmAssetProject/Views/Home/Index.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<UserModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
