#pragma checksum "C:\Users\saran\Desktop\Web Projerim\TredeWeb\TredeWeb\Views\FnBankFiche\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ccfbe04e5d060846c7b8e3b748d2e2f36a4a9b1f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(TredeWeb.Models.FnBankFiche.Views_FnBankFiche_Index), @"mvc.1.0.view", @"/Views/FnBankFiche/Index.cshtml")]
namespace TredeWeb.Models.FnBankFiche
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ccfbe04e5d060846c7b8e3b748d2e2f36a4a9b1f", @"/Views/FnBankFiche/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d5c1a0e1929df983dbe05db96aab116c6c1a2c8", @"/Views/_ViewImports.cshtml")]
    public class Views_FnBankFiche_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\saran\Desktop\Web Projerim\TredeWeb\TredeWeb\Views\FnBankFiche\Index.cshtml"
  
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
#line 16 "C:\Users\saran\Desktop\Web Projerim\TredeWeb\TredeWeb\Views\FnBankFiche\Index.cshtml"
Write(Html.DevExtreme().DataGrid<TredeWeb.DataLayer.FnBankFiches>
    ()
    .DataSource(ds => ds.Mvc()
    .Controller("ApiFnBankFiche")
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
                        .Title("Banka Fişleri Formu").ShowTitle(true).ShowCloseButton(true).CloseOnOutsideClick(true)
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
                            groupItems.AddSimpleFor(m => m.ApproveDate);
                            groupItems.AddSimpleFor(m => m.FinanceRef);
                            groupItems.AddSimpleFor(m => m.IsAccounting);
                            groupItems.AddSimpleFor(m => m.IsApproved);
                            groupItems.AddSimpleFor(m => m.Number);

                        }));
                    cnfg.Items(itm => itm
                        .AddGroup()
                        .ColCount(2)
                        .ColSpan(2)
                        .Caption("İkinci grup")
                        .Items(groupItems =>
                        {
                            groupItems.AddSimpleFor(m => m.Owner);
                            groupItems.AddSimpleFor(m => m.FicheDate);
                            groupItems.AddSimpleFor(m => m.CreatedDate);
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


        columns.AddFor(m => m.ApproveDate).Caption("Onay Tarihi");

        columns.AddFor(m => m.FinanceRef).Caption("Finans Ref").Lookup(lookup => lookup
        .DataSource(ds => ds.WebApi().Controller("ApiFnBankFiche").LoadAction("FnFichesLookup").Key("Value"))
        .ValueExpr("Value")
        .DisplayExpr("Text")
        );

        columns.AddFor(m => m.IsAccounting).Caption("Muhasebe");

        columns.AddFor(m => m.IsApproved).Caption("Onaylandı");

        columns.AddFor(m => m.Number).Caption("Numara");

        columns.AddFor(m => m.Owner).Caption("Sahip").Lookup(lookup => lookup
        .DataSource(ds => ds.WebApi().Controller("ApiFnBankFiche").LoadAction("UsersLookup").Key("Value"))
        .ValueExpr("Value")
        .DisplayExpr("Text")
        );

        columns.AddFor(m => m.FicheDate).Caption("Fiş Tarihi");

        columns.AddFor(m => m.IsActive).Caption("Aktif Mi");

        columns.AddFor(m => m.CreatedDate).Caption("Oluşturma Tahiri");
    }));

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
