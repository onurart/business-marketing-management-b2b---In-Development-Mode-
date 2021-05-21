#pragma checksum "C:\Users\saran\Desktop\Web Projerim\TredeWeb\TredeWeb\Views\Towns\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6ee5940c7a082724a8e12164eb5eb944e85a6033"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(TredeWeb.Models.Towns.Views_Towns_Index), @"mvc.1.0.view", @"/Views/Towns/Index.cshtml")]
namespace TredeWeb.Models.Towns
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6ee5940c7a082724a8e12164eb5eb944e85a6033", @"/Views/Towns/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d5c1a0e1929df983dbe05db96aab116c6c1a2c8", @"/Views/_ViewImports.cshtml")]
    public class Views_Towns_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\saran\Desktop\Web Projerim\TredeWeb\TredeWeb\Views\Towns\Index.cshtml"
  
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
#line 15 "C:\Users\saran\Desktop\Web Projerim\TredeWeb\TredeWeb\Views\Towns\Index.cshtml"
Write(Html.DevExtreme().DataGrid<TredeWeb.DataLayer.Towns>()
    .DataSource(ds => ds.Mvc()
        .Controller("ApiTowns")
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
                        .Title("İlçeler Formu").ShowTitle(true).ShowCloseButton(true).CloseOnOutsideClick(true)
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
                            groupItems.AddSimpleFor(m => m.City);
                            groupItems.AddSimpleFor(m => m.TownName);
                            groupItems.AddSimpleFor(m => m.Owner);
                            groupItems.AddSimpleFor(m => m.IsActive);
                            groupItems.AddSimpleFor(m => m.CreatedDate);

                        }));
                cnfg.ShowValidationSummary(true);
                })
                .UseIcons(true)
                .ConfirmDelete(true)
                .AllowAdding(true)
                .AllowUpdating(true)
                .AllowDeleting(true)
            ).Columns(columns => {


                columns.AddFor(m => m.City).Caption("Şehir");

                columns.AddFor(m => m.TownName).Caption("İlçe Adi");

                columns.AddFor(m => m.Owner).Caption("Sahip");

                columns.AddFor(m => m.IsActive).Caption("Aktif Mi");

                columns.AddFor(m => m.CreatedDate).Caption("Oluşturma Tahiri");
            }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
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
