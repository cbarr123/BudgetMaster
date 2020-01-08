#pragma checksum "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ef74d97fbd9ecf67ae4609820ed49cef4150e9bd"
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
#line 1 "C:\Users\cbarr\Workspace\BudgetMaster\Views\_ViewImports.cshtml"
using BudgetMaster;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\cbarr\Workspace\BudgetMaster\Views\_ViewImports.cshtml"
using BudgetMaster.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ef74d97fbd9ecf67ae4609820ed49cef4150e9bd", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"894374f8e677294a4f3992ede4204820071d68b5", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BudgetMaster.Models.ViewModels.HomeViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 6 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div class=\"text-left\">\r\n");
            WriteLiteral("        <img src=\"images/BMlogo.png\" />\r\n    </div>\r\n    <div class=\"text-left\">\r\n        Budget for ");
#nullable restore
#line 15 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
              Write(System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Model.Budget.CreatedMonth));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 15 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
                                                                                                                      Write(Html.DisplayFor(model => model.Budget.CreatedYear));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    </div>
<div class=""container-fluid"">
    <div class=""row"">
        <div class=""col"">
            <table class=""table-bordered"">
                <thead class=""thead-light"">
                    <tr>
                        <th>Budgeted Income</th>
                        <th>Amount</th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 28 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
                     foreach (var item in Model.Budget.ProjectedIncomes)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 31 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.IncomeCategory.Label));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 32 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
                           Write(Html.DisplayFor(modelitem => item.Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        </tr>\r\n");
#nullable restore
#line 34 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td><i>Total Budgeted Income</i></td>\r\n                        <td><i>");
#nullable restore
#line 37 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
                          Write(String.Format("{0:c}", Model.Budget.ProjectedIncomes.Sum(x => x.Amount)));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</i></td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class=""col"">
            <table class=""table-bordered"">
                <thead class=""thead-light"">
                    <tr>
                        <th>Actual Income</th>
                        <th>Amount</th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 51 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
                     foreach (var item in Model.Budget.ActualIncomes)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 54 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.IncomeCategory.Label));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 55 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
                           Write(Html.DisplayFor(modelitem => item.Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        </tr>\r\n");
#nullable restore
#line 57 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td><i>Total Actual Income</i></td>\r\n                        <td><i>");
#nullable restore
#line 60 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
                          Write(String.Format("{0:c}", Model.Budget.ActualIncomes.Sum(x => x.Amount)));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</i></td>
                    </tr>
                </tbody>
            </table>
        </div>

        <div class=""w-100""><p> </p></div>

        <div class=""col"">
            <table class=""table-bordered"">
                <thead class=""thead-light"">
                    <tr>
                        <th>Budgeted Expense</th>
                        <th>Amount</th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 77 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
                     foreach (var item in Model.Budget.ProjectedExpenses)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 80 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.ExpenseCategory.Label));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 81 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
                           Write(Html.DisplayFor(modelitem => item.Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        </tr>\r\n");
#nullable restore
#line 83 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td><i>Total Budgeted Expenses</i></td>\r\n                        <td><i>");
#nullable restore
#line 86 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
                          Write(String.Format("{0:c}", Model.Budget.ProjectedExpenses.Sum(x => x.Amount)));

#line default
#line hidden
#nullable disable
            WriteLiteral("</i></td>\r\n                    </tr>\r\n");
#nullable restore
#line 88 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
                       
                        decimal pi = Model.Budget.ProjectedIncomes.Sum(x => x.Amount);
                        decimal pe = Model.Budget.ProjectedExpenses.Sum(x => x.Amount);
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <th>Total</th>\r\n                        <th>");
#nullable restore
#line 94 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
                       Write(String.Format("{0:c}", pi - pe));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</th>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class=""col"">
            <table class=""table-bordered"">
                <thead class=""thead-light"">
                    <tr>
                        <th>Actual Expense</th>
                        <th>Amount</th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 108 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
                     foreach (var item in Model.Budget.ActualExpenses)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 111 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.ExpenseCategory.Label));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 112 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
                           Write(Html.DisplayFor(modelitem => item.Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        </tr>\r\n");
#nullable restore
#line 114 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td><i>Total Actual Expenses</i></td>\r\n                        <td><i>");
#nullable restore
#line 117 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
                          Write(String.Format("{0:c}", Model.Budget.ActualExpenses.Sum(x => x.Amount)));

#line default
#line hidden
#nullable disable
            WriteLiteral("</i></td>\r\n                    </tr>\r\n");
#nullable restore
#line 119 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
                      
                        decimal ai = Model.Budget.ActualIncomes.Sum(x => x.Amount);
                        decimal ae = Model.Budget.ActualExpenses.Sum(x => x.Amount);
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <th>Total </th>\r\n                        <th>");
#nullable restore
#line 125 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
                       Write(String.Format("{0:c}", ai - ae));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                    </tr>\r\n                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n    <div class=\"row\"><tr><td></td></tr></div>\r\n    <div class=\"row\">\r\n        <div>\r\n            \r\n        </div>\r\n\r\n    </div>\r\n\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BudgetMaster.Models.ViewModels.HomeViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
