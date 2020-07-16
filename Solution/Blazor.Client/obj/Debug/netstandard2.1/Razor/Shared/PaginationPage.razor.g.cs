#pragma checksum "E:\NetCore3.1Cursos\EntrevistaDemoBlazor\Solution\Blazor.Client\Shared\PaginationPage.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "79ff5c591621bc37b7657edd24a9b4d97ed77e5f"
// <auto-generated/>
#pragma warning disable 1591
namespace Blazor.Client.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "E:\NetCore3.1Cursos\EntrevistaDemoBlazor\Solution\Blazor.Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\NetCore3.1Cursos\EntrevistaDemoBlazor\Solution\Blazor.Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\NetCore3.1Cursos\EntrevistaDemoBlazor\Solution\Blazor.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\NetCore3.1Cursos\EntrevistaDemoBlazor\Solution\Blazor.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\NetCore3.1Cursos\EntrevistaDemoBlazor\Solution\Blazor.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\NetCore3.1Cursos\EntrevistaDemoBlazor\Solution\Blazor.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\NetCore3.1Cursos\EntrevistaDemoBlazor\Solution\Blazor.Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "E:\NetCore3.1Cursos\EntrevistaDemoBlazor\Solution\Blazor.Client\_Imports.razor"
using Blazor.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "E:\NetCore3.1Cursos\EntrevistaDemoBlazor\Solution\Blazor.Client\_Imports.razor"
using Blazor.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "E:\NetCore3.1Cursos\EntrevistaDemoBlazor\Solution\Blazor.Client\_Imports.razor"
using Blazor.Shared;

#line default
#line hidden
#nullable disable
    public partial class PaginationPage : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "nav");
            __builder.AddAttribute(1, "aria-label", "Page navigation example");
            __builder.AddMarkupContent(2, "\r\n    ");
            __builder.OpenElement(3, "ul");
            __builder.AddAttribute(4, "class", "pagination justify-content-center");
            __builder.AddMarkupContent(5, "\r\n");
#nullable restore
#line 3 "E:\NetCore3.1Cursos\EntrevistaDemoBlazor\Solution\Blazor.Client\Shared\PaginationPage.razor"
         foreach (var pag in pages)
        {

#line default
#line hidden
#nullable disable
            __builder.AddContent(6, "            ");
            __builder.OpenElement(7, "li");
            __builder.AddAttribute(8, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 5 "E:\NetCore3.1Cursos\EntrevistaDemoBlazor\Solution\Blazor.Client\Shared\PaginationPage.razor"
                            () => InternalSelectedPage(pag)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(9, "style", "cursor: pointer;");
            __builder.AddAttribute(10, "class", "page-item" + " " + (
#nullable restore
#line 7 "E:\NetCore3.1Cursos\EntrevistaDemoBlazor\Solution\Blazor.Client\Shared\PaginationPage.razor"
                                   pag.Enabled ? null : "disabled"

#line default
#line hidden
#nullable disable
            ) + " " + (
#nullable restore
#line 7 "E:\NetCore3.1Cursos\EntrevistaDemoBlazor\Solution\Blazor.Client\Shared\PaginationPage.razor"
                                                                      pag.Active ? "active" : null

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(11, "\r\n                ");
            __builder.OpenElement(12, "span");
            __builder.AddAttribute(13, "class", "page-link");
            __builder.AddAttribute(14, "href", "#");
            __builder.AddContent(15, 
#nullable restore
#line 8 "E:\NetCore3.1Cursos\EntrevistaDemoBlazor\Solution\Blazor.Client\Shared\PaginationPage.razor"
                                                  pag.Text

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(16, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(17, "\r\n");
#nullable restore
#line 10 "E:\NetCore3.1Cursos\EntrevistaDemoBlazor\Solution\Blazor.Client\Shared\PaginationPage.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.AddContent(18, "    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(19, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 14 "E:\NetCore3.1Cursos\EntrevistaDemoBlazor\Solution\Blazor.Client\Shared\PaginationPage.razor"
       
    [Parameter] public int ActualPage { get; set; } = 1;
    [Parameter] public int totalPages { get; set; }
    [Parameter] public int Radio { get; set; } = 3;
    [Parameter] public EventCallback<int> SelectedPage { get; set; }
    List<PagesModel> pages = new List<PagesModel>();

    protected override void OnParametersSet()
    {
        CargarPaginas();
    }

    private async Task InternalSelectedPage(PagesModel page)
    {
        if (page.Page == ActualPage)
        {
            return;
        }

        if (!page.Enabled)
        {
            return;
        }

        ActualPage = page.Page;

        CargarPaginas();

        await SelectedPage.InvokeAsync(page.Page);
    }

    private void CargarPaginas()
    {
        pages = new List<PagesModel>();
        var PreviousPageEnabled = ActualPage != 1;
        var previousPage = (ActualPage == 1) ? 1 : ActualPage - 1;
        pages.Add(new PagesModel(previousPage, PreviousPageEnabled, "Before"));

        for (int i = 1; i <= totalPages; i++)
        {
            if (i >= ActualPage - Radio && i <= ActualPage + Radio)
            {
                pages.Add(new PagesModel(i) { Active = ActualPage == i });
            }
        }

        var NextPageEnabled = ActualPage != totalPages;
        var NextPage = (ActualPage == totalPages) ? totalPages : ActualPage + 1;
        pages.Add(new PagesModel(NextPage, NextPageEnabled, "Next"));
    }

    class PagesModel
    {

        public PagesModel(int page)
            : this(page, true)
        { }

        public PagesModel(int page, bool enabled)
            : this(page, enabled, page.ToString())
        { }

        public PagesModel(int page, bool enabled, string text)
        {
            Page = page;
            Enabled = enabled;
            Text = text;
        }

        public string Text { get; set; }
        public int Page { get; set; }
        public bool Enabled { get; set; } = true;
        public bool Active { get; set; } = false;
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
