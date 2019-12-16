#pragma checksum "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c88267efe595f73e8608f6f2e9233ce460ea289e"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c88267efe595f73e8608f6f2e9233ce460ea289e", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"894374f8e677294a4f3992ede4204820071d68b5", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BudgetMaster.Models.Budget>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""text-center"">
    <h1 class=""display-5"">BudgetMaster</h1>
</div>
<div class=""container-fluid"">
    <div class=""row"">
        <div class=""col"">
                Budgeted Income
            <table class=""table-bordered"">
                <thead class=""thead-light"">
                    <tr>
                        <th>ProjectedIncomeId</th>
                        <th>IncomeCategoryLabel</th>
                        <th>CategoryId</th>
                        <th>Amount</th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 26 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
                     foreach (var item in Model.ProjectedIncomes)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 29 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.ProjectedIncomeId));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 30 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.IncomeCategoriesList[0].Label));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 31 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.IncomeCategoryId));

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
            WriteLiteral(@"                        <tr>
                            <td></td>
                            <td>Total Budgeted Income</td>
                            <td></td>
                            <td>Do Sum Here</td>
                    
                        </tr>
                </tbody>

            </table>
        </div>
        <div class=""col"">
            Actual Income
            <table class=""table-bordered"">
                <thead class=""thead-light"">
                    <tr>
                        <th>ActualIncomeId</th>
                        <th>IncomeCategoryLabel</th>
                        <th>CategoryId</th>
                        <th>Amount</th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 58 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
                     foreach (var item in Model.ActualIncomes)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 61 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.ActualIncomeId));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 62 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.IncomeCategoriesList[0].Label));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 63 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.IncomeCategoryId));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 64 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
                           Write(Html.DisplayFor(modelitem => item.Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        </tr>\r\n");
#nullable restore
#line 66 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        <tr>
                            <td></td>
                            <td>Total Actual Income</td>
                            <td></td>
                            <td>Do Sum Here</td>
                        </tr>
                </tbody>

            </table>
        </div>
    </div>
    <div class=""row"">
        <div class=""col"">
            Budgeted Expense
            <table class=""table-bordered"">
                <thead class=""thead-light"">
                    <tr>
                        <th>ProjectedExpenseId</th>
                        <th>ExpenseCategoryLabel</th>
                        <th>CategoryId</th>
                        <th>Amount</th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 92 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
                     foreach (var item in Model.ProjectedExpenses)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 95 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.ProjectedExpenseId));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 96 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.ExpenseCategoriesList[0].Label));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 97 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.ExpenseCategoryId));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 98 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
                           Write(Html.DisplayFor(modelitem => item.Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        </tr>\r\n");
#nullable restore
#line 100 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        <tr>
                            <td></td>
                            <td>Total Budgeted Expenses</td>
                            <td></td>
                            <td>Do Sum Here</td>
                        </tr>
                </tbody>

            </table>
        </div>
        <div class=""col"">
            Actual Expense
            <table class=""table-bordered"">
                <thead class=""thead-light"">
                    <tr>
                        <th>ActualExpenseId</th>
                        <th>ExpenseCategoryLabel</th>
                        <th>CategoryId</th>
                        <th>Amount</th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 124 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
                     foreach (var item in Model.ActualExpenses)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 127 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.ActualExpenseId));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 128 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.ExpenseCategoriesList[0].Label));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 129 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.ExpenseCategoryId));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 130 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
                           Write(Html.DisplayFor(modelitem => item.Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        </tr>\r\n");
#nullable restore
#line 132 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        <tr>
                            <td></td>
                            <td>Total Actual Expenses</td>
                            <td></td>
                            <td>Do Sum Here</td>
                        </tr>

                </tbody>
            </table>
        </div>
        <div>
            temp debugging info<br />
            ");
#nullable restore
#line 146 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
       Write(Html.DisplayFor(model => model.BudgetId));

#line default
#line hidden
#nullable disable
            WriteLiteral(" BudgetId<br />\r\n            ");
#nullable restore
#line 147 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
       Write(Html.DisplayFor(model => model.CreatedMonth));

#line default
#line hidden
#nullable disable
            WriteLiteral(" CreatedMonth<br />\r\n            ");
#nullable restore
#line 148 "C:\Users\cbarr\Workspace\BudgetMaster\Views\Home\Index.cshtml"
       Write(Html.DisplayFor(model => model.CreatedYear));

#line default
#line hidden
#nullable disable
            WriteLiteral(" CreatedYear<br />\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BudgetMaster.Models.Budget> Html { get; private set; }
    }
}
#pragma warning restore 1591
