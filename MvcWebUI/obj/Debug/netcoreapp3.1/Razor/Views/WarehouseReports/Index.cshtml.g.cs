#pragma checksum "C:\Users\ismail\source\repos\StockTracking\MvcWebUI\Views\WarehouseReports\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "982bd383974030be890b5a6ceafbc11000c811d1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_WarehouseReports_Index), @"mvc.1.0.view", @"/Views/WarehouseReports/Index.cshtml")]
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
#line 1 "C:\Users\ismail\source\repos\StockTracking\MvcWebUI\Views\_ViewImports.cshtml"
using MvcWebUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ismail\source\repos\StockTracking\MvcWebUI\Views\_ViewImports.cshtml"
using MvcWebUI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"982bd383974030be890b5a6ceafbc11000c811d1", @"/Views/WarehouseReports/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e90fbe64bce36a3ccac09ea850cf7cd992ce84ef", @"/Views/_ViewImports.cshtml")]
    public class Views_WarehouseReports_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WarehouseReportsListViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\ismail\source\repos\StockTracking\MvcWebUI\Views\WarehouseReports\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<h1>Depo Giriş/Çıkış Raporları</h1>
<br />
<a class=""btn btn-success"" href=""/Warehouse/Index"">Depo Giriş/Çıkış Ekle</a>
<br />
<br />

<table class=""table"" id=""tblWarehouse"">
    <thead>
        <tr>
            <th>Fiş Numarası</th>
            <th>Depo Kodu</th>
            <th>Stok Kodu</th>
            <th>Giriş/Çıkış Miktarı</th>
            <th>Operasyon Tipi</th>
            <th>Kayıt Tarihi</th>
            <th>Kayıt Yapan Kullanıcı</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 25 "C:\Users\ismail\source\repos\StockTracking\MvcWebUI\Views\WarehouseReports\Index.cshtml"
         foreach (var warehouseOperation in Model.WarehouseOperations)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 28 "C:\Users\ismail\source\repos\StockTracking\MvcWebUI\Views\WarehouseReports\Index.cshtml"
               Write(warehouseOperation.VoucherNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 29 "C:\Users\ismail\source\repos\StockTracking\MvcWebUI\Views\WarehouseReports\Index.cshtml"
               Write(warehouseOperation.WarehouseCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 30 "C:\Users\ismail\source\repos\StockTracking\MvcWebUI\Views\WarehouseReports\Index.cshtml"
               Write(warehouseOperation.StockCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 31 "C:\Users\ismail\source\repos\StockTracking\MvcWebUI\Views\WarehouseReports\Index.cshtml"
               Write(warehouseOperation.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 32 "C:\Users\ismail\source\repos\StockTracking\MvcWebUI\Views\WarehouseReports\Index.cshtml"
                 if (warehouseOperation.OperationType == true)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>Giriş</td>\r\n");
#nullable restore
#line 35 "C:\Users\ismail\source\repos\StockTracking\MvcWebUI\Views\WarehouseReports\Index.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>Çıkıç</td>\r\n");
#nullable restore
#line 39 "C:\Users\ismail\source\repos\StockTracking\MvcWebUI\Views\WarehouseReports\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td>");
#nullable restore
#line 40 "C:\Users\ismail\source\repos\StockTracking\MvcWebUI\Views\WarehouseReports\Index.cshtml"
               Write(warehouseOperation.CreateDate.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 41 "C:\Users\ismail\source\repos\StockTracking\MvcWebUI\Views\WarehouseReports\Index.cshtml"
               Write(warehouseOperation.UserId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 43 "C:\Users\ismail\source\repos\StockTracking\MvcWebUI\Views\WarehouseReports\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </tbody>\r\n</table>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WarehouseReportsListViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
