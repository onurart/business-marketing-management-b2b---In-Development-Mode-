#pragma checksum "C:\Users\saran\Desktop\Web Projerim\TredeWeb\TredeWeb\Views\BankAccounts\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "89a9f63da3c15564130c7245bfa87182a799796b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(TredeWeb.Models.BankAccounts.Views_BankAccounts_Index), @"mvc.1.0.view", @"/Views/BankAccounts/Index.cshtml")]
namespace TredeWeb.Models.BankAccounts
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"89a9f63da3c15564130c7245bfa87182a799796b", @"/Views/BankAccounts/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d5c1a0e1929df983dbe05db96aab116c6c1a2c8", @"/Views/_ViewImports.cshtml")]
    public class Views_BankAccounts_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\saran\Desktop\Web Projerim\TredeWeb\TredeWeb\Views\BankAccounts\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script>
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
#line 17 "C:\Users\saran\Desktop\Web Projerim\TredeWeb\TredeWeb\Views\BankAccounts\Index.cshtml"
Write(Html.DevExtreme().DataGrid<TredeWeb.DataLayer.BankAccounts>()
    .DataSource(ds => ds.Mvc()
        .Controller("ApiBankAccounts1")
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
                        .Title("Banka Formu").ShowTitle(true).ShowCloseButton(true).CloseOnOutsideClick(true)
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
                            groupItems.AddSimpleFor(m => m.BankBranch);
                            groupItems.AddSimpleFor(m => m.Code);
                            groupItems.AddSimpleFor(m => m.Description);

                        }));
                    cnfg.Items(itm => itm
                        .AddGroup()
                        .ColCount(2)
                        .ColSpan(2)
                        .Caption("İkinci grup")
                        .Items(groupItems =>
                        {
                            groupItems.AddSimpleFor(m => m.Name);
                            groupItems.AddSimpleFor(m => m.OwnerRef);
                            groupItems.AddSimpleFor(m => m.IbanNo);
                            groupItems.AddSimpleFor(m => m.IsActive);
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
        columns.AddFor(m => m.BankBranch).Caption("Banka şubesi").Lookup(lookup => lookup
            .DataSource(ds => ds.WebApi().Controller("ApiBankAccounts1").LoadAction("BankBranchesLookup").Key("Value"))
            .ValueExpr("Value")
            .DisplayExpr("Text")
        );

        columns.AddFor(m => m.Code).Caption("Kodu");

        columns.AddFor(m => m.Description).Caption("Açıklama");

        columns.AddFor(m => m.Name).Caption("Ad");

        columns.AddFor(m => m.OwnerRef).Caption("Sahip Ref").Lookup(lookup => lookup
            .DataSource(ds => ds.WebApi().Controller("ApiBankAccounts1").LoadAction("UsersLookup").Key("Value"))
            .ValueExpr("Value")
            .DisplayExpr("Text")
        );

        columns.AddFor(m => m.IbanNo).Caption("IBN No");

        columns.AddFor(m => m.IsActive).Caption("Aktiv mi");
    })

    );

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n)");
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
