// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace SetTradeBot.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\dusit\source\repos\SetTradeBot\SetTradeBot\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\dusit\source\repos\SetTradeBot\SetTradeBot\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\dusit\source\repos\SetTradeBot\SetTradeBot\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\dusit\source\repos\SetTradeBot\SetTradeBot\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\dusit\source\repos\SetTradeBot\SetTradeBot\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\dusit\source\repos\SetTradeBot\SetTradeBot\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\dusit\source\repos\SetTradeBot\SetTradeBot\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\dusit\source\repos\SetTradeBot\SetTradeBot\_Imports.razor"
using SetTradeBot;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\dusit\source\repos\SetTradeBot\SetTradeBot\_Imports.razor"
using SetTradeBot.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\dusit\source\repos\SetTradeBot\SetTradeBot\_Imports.razor"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\dusit\source\repos\SetTradeBot\SetTradeBot\_Imports.razor"
using SetTradeBot.Model;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\dusit\source\repos\SetTradeBot\SetTradeBot\_Imports.razor"
using MatBlazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\dusit\source\repos\SetTradeBot\SetTradeBot\_Imports.razor"
using System.Text;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\dusit\source\repos\SetTradeBot\SetTradeBot\_Imports.razor"
using System.Text.RegularExpressions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\dusit\source\repos\SetTradeBot\SetTradeBot\_Imports.razor"
using LineDC.Liff;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\dusit\source\repos\SetTradeBot\SetTradeBot\_Imports.razor"
using LineDC.Liff.Data;

#line default
#line hidden
#nullable disable
    public partial class NavMenu : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 33 "C:\Users\dusit\source\repos\SetTradeBot\SetTradeBot\Shared\NavMenu.razor"
       
    private bool collapseNavMenu = true;

    private string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

    private void ToggleNavMenu()
    {
        collapseNavMenu = !collapseNavMenu;
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
