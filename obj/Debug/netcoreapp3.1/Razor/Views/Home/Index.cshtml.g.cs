#pragma checksum "C:\Users\EJDH\Downloads\API-CASASHOW-5f28e12ebb137ba0b0cc2379d6586d9c74955275\API-CASASHOW-5f28e12ebb137ba0b0cc2379d6586d9c74955275\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ab5bc7a78d75b15b65a2e44aa0fe45c94cc5e1ae"
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
#line 1 "C:\Users\EJDH\Downloads\API-CASASHOW-5f28e12ebb137ba0b0cc2379d6586d9c74955275\API-CASASHOW-5f28e12ebb137ba0b0cc2379d6586d9c74955275\Views\_ViewImports.cshtml"
using CasaDeShow;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\EJDH\Downloads\API-CASASHOW-5f28e12ebb137ba0b0cc2379d6586d9c74955275\API-CASASHOW-5f28e12ebb137ba0b0cc2379d6586d9c74955275\Views\_ViewImports.cshtml"
using CasaDeShow.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ab5bc7a78d75b15b65a2e44aa0fe45c94cc5e1ae", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e14b4a6b6de72f110567a0b7dc451115319be6d0", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\EJDH\Downloads\API-CASASHOW-5f28e12ebb137ba0b0cc2379d6586d9c74955275\API-CASASHOW-5f28e12ebb137ba0b0cc2379d6586d9c74955275\Views\Home\Index.cshtml"
  
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Eventos passados</h1>
<br>
<hr/>
<div id=""carouselExampleIndicators"" class=""carousel slide"" data-ride=""carousel"">
  <ol class=""carousel-indicators"">
    <li data-target=""#carouselExampleIndicators"" data-slide-to=""0"" class=""active""></li>
    <li data-target=""#carouselExampleIndicators"" data-slide-to=""1""></li>
    <li data-target=""#carouselExampleIndicators"" data-slide-to=""2""></li>
  </ol>
  <div class=""carousel-inner"">
    <div class=""carousel-item active"">
      <img src=""/img/show4.jpg"" class=""d-block w-100"" alt=""..."">
    </div>
    <div class=""carousel-item"">
      <img src=""/img/show2.png"" class=""d-block w-100"" alt=""..."">
    </div>
    <div class=""carousel-item"">
      <img src=""/img/show3.png"" class=""d-block w-100"" alt=""..."">
    </div>
  </div>
  <a class=""carousel-control-prev"" href=""#carouselExampleIndicators"" role=""button"" data-slide=""prev"">
    <span class=""carousel-control-prev-icon"" aria-hidden=""true""></span>
    <span class=""sr-only"">Previous</span>
  </a>
  <a class=""carousel-control-next""");
            WriteLiteral(" href=\"#carouselExampleIndicators\" role=\"button\" data-slide=\"next\">\n    <span class=\"carousel-control-next-icon\" aria-hidden=\"true\"></span>\n    <span class=\"sr-only\">Next</span>\n  </a>\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
