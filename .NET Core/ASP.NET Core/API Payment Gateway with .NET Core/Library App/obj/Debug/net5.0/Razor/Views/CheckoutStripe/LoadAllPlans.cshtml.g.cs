#pragma checksum "D:\ASP.NET\.NET Core\ASP.NET Core\API Payment Gateway with .NET Core\Library App\Views\CheckoutStripe\LoadAllPlans.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8373991d812818f5fc08f25ed54ccb95b3b1a0de"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CheckoutStripe_LoadAllPlans), @"mvc.1.0.view", @"/Views/CheckoutStripe/LoadAllPlans.cshtml")]
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
#line 1 "D:\ASP.NET\.NET Core\ASP.NET Core\API Payment Gateway with .NET Core\Library App\Views\_ViewImports.cshtml"
using Library_App;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\ASP.NET\.NET Core\ASP.NET Core\API Payment Gateway with .NET Core\Library App\Views\_ViewImports.cshtml"
using Library_App.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8373991d812818f5fc08f25ed54ccb95b3b1a0de", @"/Views/CheckoutStripe/LoadAllPlans.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a878f38679ad303b7132a74d75eadff31ec75be0", @"/Views/_ViewImports.cshtml")]
    public class Views_CheckoutStripe_LoadAllPlans : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Stripe.Plan>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SubscribeToPlan", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "CheckoutStripe", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\ASP.NET\.NET Core\ASP.NET Core\API Payment Gateway with .NET Core\Library App\Views\CheckoutStripe\LoadAllPlans.cshtml"
  
    ViewData["Title"] = "LoadAllPlans";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 6 "D:\ASP.NET\.NET Core\ASP.NET Core\API Payment Gateway with .NET Core\Library App\Views\CheckoutStripe\LoadAllPlans.cshtml"
  
    ViewData["Title"] = "BraintreePlans";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container my-3\">\r\n    <div class=\"row\">\r\n");
#nullable restore
#line 12 "D:\ASP.NET\.NET Core\ASP.NET Core\API Payment Gateway with .NET Core\Library App\Views\CheckoutStripe\LoadAllPlans.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-md-6\">\r\n                <div class=\"card m-2\">\r\n");
            WriteLiteral("                    <div class=\"card-body\">\r\n                        <h5 class=\"card-title\"><b>");
#nullable restore
#line 18 "D:\ASP.NET\.NET Core\ASP.NET Core\API Payment Gateway with .NET Core\Library App\Views\CheckoutStripe\LoadAllPlans.cshtml"
                                             Write(item.Interval[0].ToString().ToUpper());

#line default
#line hidden
#nullable disable
            WriteLiteral("<span>");
#nullable restore
#line 18 "D:\ASP.NET\.NET Core\ASP.NET Core\API Payment Gateway with .NET Core\Library App\Views\CheckoutStripe\LoadAllPlans.cshtml"
                                                                                         Write(item.Interval.Substring(1,item.Interval.Length-1));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span><span>ly Plan</span></b></h5>\r\n                        <div class=\"card-text\">\r\n                            \r\n                            <p>Price : $");
#nullable restore
#line 21 "D:\ASP.NET\.NET Core\ASP.NET Core\API Payment Gateway with .NET Core\Library App\Views\CheckoutStripe\LoadAllPlans.cshtml"
                                   Write(String.Format("{0:0.000#}",Convert.ToDecimal(item.Amount)/100));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            <p>Trial Period : ");
#nullable restore
#line 22 "D:\ASP.NET\.NET Core\ASP.NET Core\API Payment Gateway with .NET Core\Library App\Views\CheckoutStripe\LoadAllPlans.cshtml"
                                         Write(item.Interval);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            \r\n                        </div>\r\n\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8373991d812818f5fc08f25ed54ccb95b3b1a0de6982", async() => {
                WriteLiteral("Subscribe to the Plan");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 26 "D:\ASP.NET\.NET Core\ASP.NET Core\API Payment Gateway with .NET Core\Library App\Views\CheckoutStripe\LoadAllPlans.cshtml"
                                                                                          WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 31 "D:\ASP.NET\.NET Core\ASP.NET Core\API Payment Gateway with .NET Core\Library App\Views\CheckoutStripe\LoadAllPlans.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Stripe.Plan>> Html { get; private set; }
    }
}
#pragma warning restore 1591