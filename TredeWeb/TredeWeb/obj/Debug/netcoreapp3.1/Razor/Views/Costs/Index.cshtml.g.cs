#pragma checksum "C:\Users\saran\Desktop\Web Projerim\TredeWeb\TredeWeb\Views\Costs\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6bab97e6082bc8f5dd09238d0dbacd283d14cc45"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(TredeWeb.Models.Costs.Views_Costs_Index), @"mvc.1.0.view", @"/Views/Costs/Index.cshtml")]
namespace TredeWeb.Models.Costs
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
#line 1 "C:\Users\saran\Desktop\Web Projerim\TredeWeb\TredeWeb\Views\_ViewImports.cshtml"
using TredeWeb;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\saran\Desktop\Web Projerim\TredeWeb\TredeWeb\Views\_ViewImports.cshtml"
using DevExtreme.AspNet.Mvc;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6bab97e6082bc8f5dd09238d0dbacd283d14cc45", @"/Views/Costs/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d5c1a0e1929df983dbe05db96aab116c6c1a2c8", @"/Views/_ViewImports.cshtml")]
    public class Views_Costs_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\saran\Desktop\Web Projerim\TredeWeb\TredeWeb\Views\Costs\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<script>
    function onShowing(e) {
        var btns = e.component.content().parent().find("".dx-button.dx-button-has-text"");
        for (var i = 0; i < btns.length; i++) {
            var btn = btns[i];
            $(btn).dxButton(""option"", ""text"", i == 0 ? ""Kaydet"" : ""Vazgeç"");
        }
    }
</script>

");
#nullable restore
#line 16 "C:\Users\saran\Desktop\Web Projerim\TredeWeb\TredeWeb\Views\Costs\Index.cshtml"
Write(Html.DevExtreme().DataGrid<TredeWeb.DataLayer.Costs>
    ()
    .DataSource(ds => ds.Mvc()
    .Controller("ApiCosts")
    .LoadAction("Get")
    .InsertAction("Post")
    .UpdateAction("Put")
    .DeleteAction("Delete")
    .Key("Id")
    )
      .ShowBorders(true)
            .ShowColumnLines(true)
            .HighlightChanges(true)
            .Paging(pagination => pagination
                .Enabled(true)
                .PageSize(5)
            )
            .RemoteOperations(true)
            .Editing(e => e
                .Mode(GridEditMode.Popup)
                    .Popup(pop => pop
                        .DragEnabled(false)
                        .OnShowing("onShowing")
                        .Position(PositionAlignment.Center)
                        .Width(700)
                        .Height(800)
                        .Title("Maliyetler Formu").ShowTitle(true).ShowCloseButton(true).CloseOnOutsideClick(true)
                        )
                .Form(cnfg =>
                {
                    cnfg.Items(itm => itm
                        .AddGroup()
                        .ColCount(2)
                        .ColSpan(2)
                        .Caption("İlk grup")
                        .Items(groupItems =>
                        {
                            groupItems.AddSimpleFor(m => m.Type);
                            groupItems.AddSimpleFor(m => m.Description);
                            groupItems.AddSimpleFor(m => m.Number);
                            groupItems.AddSimpleFor(m => m.OwnerRef);
                            groupItems.AddSimpleFor(m => m.CostTotal);
                            groupItems.AddSimpleFor(m => m.CostDate);
                            groupItems.AddSimpleFor(m => m.BankRef);

                        }));
                    cnfg.Items(itm => itm
                        .AddGroup()
                        .ColCount(2)
                        .ColSpan(2)
                        .Caption("İkinci grup")
                        .Items(groupItems =>
                        {
                            groupItems.AddSimpleFor(m => m.CsRef);
                            groupItems.AddSimpleFor(m => m.CashRef);
                            groupItems.AddSimpleFor(m => m.IsApproved);
                            groupItems.AddSimpleFor(m => m.ApproveDate);
                            groupItems.AddSimpleFor(m => m.IsActive);
                            groupItems.AddSimpleFor(m => m.CreatedDate);
                            groupItems.AddSimpleFor(m => m.CreditCardRef);
                        }));
                    cnfg.ShowValidationSummary(true);
                })
                .UseIcons(true)
                .ConfirmDelete(true)
                .AllowAdding(true)
                .AllowUpdating(true)
                .AllowDeleting(true)
            )
    .Columns(columns => {

        columns.AddFor(m => m.Type).Caption("Tipi");

        columns.AddFor(m => m.Description).Caption("Açıkalama");

        columns.AddFor(m => m.Number).Caption("Numara");

        columns.AddFor(m => m.OwnerRef).Caption("Sahip").Lookup(lookup => lookup
        .DataSource(ds => ds.WebApi().Controller("ApiCosts").LoadAction("UsersLookup").Key("Value"))
        .ValueExpr("Value")
        .DisplayExpr("Text")
        );

        columns.AddFor(m => m.CostTotal).Caption("Maliyet Toplam");

        columns.AddFor(m => m.CostDate).Caption("Maliyet Tarihi");

        columns.AddFor(m => m.BankRef).Caption("Banka Referansı").Lookup(lookup => lookup
        .DataSource(ds => ds.WebApi().Controller("ApiCosts").LoadAction("FnBankLinesLookup").Key("Value"))
        .ValueExpr("Value")
        .DisplayExpr("Text")
        );

        columns.AddFor(m => m.CsRef).Lookup(lookup => lookup
        .DataSource(ds => ds.WebApi().Controller("ApiCosts").LoadAction("FnCsLinesLookup").Key("Value"))
        .ValueExpr("Value")
        .DisplayExpr("Text")
        );

        columns.AddFor(m => m.CashRef).Caption("Nakit");

        columns.AddFor(m => m.AccountRef).Caption("Hesap").Lookup(lookup => lookup
        .DataSource(ds => ds.WebApi().Controller("ApiCosts").LoadAction("AccountsLookup").Key("Value"))
        .ValueExpr("Value")
        .DisplayExpr("Text")
        );

        columns.AddFor(m => m.IsApproved).Caption("Onaylandı");

        columns.AddFor(m => m.ApproveDate).Caption("Onay Tarihi");

        columns.AddFor(m => m.IsActive).Caption("Aktiv mi");

        columns.AddFor(m => m.CreatedDate).Caption("Oluşturma Tahiri");

        columns.AddFor(m => m.CreditCardRef).Caption("Kredi Kartı").Lookup(lookup => lookup
        .DataSource(ds => ds.WebApi().Controller("ApiCosts").LoadAction("FnCreditCardLinesLookup").Key("Value"))
        .ValueExpr("Value")
        .DisplayExpr("Text")
        );
    }) );

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
