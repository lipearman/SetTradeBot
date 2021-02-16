// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace SetTradeBot.Pages
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
    [Microsoft.AspNetCore.Components.RouteAttribute("/set50")]
    public partial class SET50 : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 121 "C:\Users\dusit\source\repos\SetTradeBot\SetTradeBot\Pages\SET50.razor"
       
    Ohlc[] ohlc;
    Ohlc ItemSelected = new Ohlc();
    bool addFavoriteLoading = false;
    bool dialogIsOpen = false;
    string animal = null;
    string dialogAnimal = null;
    string lastdate = null;
    private string _title = "";
    private string _message = "";
    private bool _actionOnClick = false;

    protected Profile Profile { get; set; }
    protected LiffContext Context { get; set; }
    protected string TokenId { get; set; }
    protected string OS { get; set; }
    protected string Language { get; set; }
    protected string Version { get; set; }
    protected string IDToken { get; set; }
    protected string LineVersion { get; set; }
    protected Friendship Friendship { get; set; }

    void OpenDialog(Ohlc ohlc)
    {
        ItemSelected = new Ohlc();

        ItemSelected = ohlc;

        _title = ItemSelected.Symbol;
        _message = "Added To Favorite";

        dialogAnimal = null;
        dialogIsOpen = true;
    }

    void OpenLinkTradingView(string symbol)
    {
        var url = $"https://th.tradingview.com/chart/?symbol=SET%3A{symbol}";

        NavManager.NavigateTo(url, forceLoad: true);
    }
    void OpenLinkSetTrade(string symbol)
    {
        var url = $"https://www.settrade.com/C04_01_stock_quote_p1.jsp?txtSymbol={symbol}";

        NavManager.NavigateTo(url, forceLoad: true);
    }

    async Task OkClick()
    {

        addFavoriteLoading = true;

        await SetTradeBot.Services.GoogleAPI.AddFavorite(Context.UserId, ItemSelected.Symbol);

        Show(MatToastType.Success);

        animal = dialogAnimal;
        dialogIsOpen = false;

        addFavoriteLoading = false;
    }
    private static HttpClient _httpClient = new HttpClient();

    protected override async Task OnInitializedAsync()
    {
 
        //try
        //{
        if (!Liff.Initialized)
        {
            await Liff.Init(JSRuntime);
            if (!await Liff.IsLoggedIn())
            {
                await Liff.Login();
                return;
            }
            Liff.Initialized = true;
        }
        Profile = await Liff.GetProfile();
        if (await Liff.IsInClient())
        {
            Context = await Liff.GetContext();
        }
        //var idtoken = await Liff.GetDecodedIDToken();
        //TokenId = idtoken.Sub;
        //OS = await Liff.GetOS();
        //Language = await Liff.GetLanguage();
        //Version = await Liff.GetVersion();
        //LineVersion = await Liff.GetLineVersion();
        ////Friendship = await Liff.GetFriendship();
        //IDToken = await Liff.GetIDToken();
        ////StateHasChanged();

        ohlc = await SetTradeBot.Services.GoogleAPI.GetSET50();
        lastdate = $"({ohlc[0].Date.ToString("dd/MM/yyyy HH:mm")})";

        //}
        //catch (Exception e)
        //{
        //    //Profile = null;
        //    //await JSRuntime.InvokeAsync<object>("alert", e.ToString());
        //}


    }


    void SortData(MatSortChangedEvent sort)
    {
        if (!(sort == null || sort.Direction == MatSortDirection.None || string.IsNullOrEmpty(sort.SortId)))
        {
            //Comparison<Ohlc> comparison = null;
            switch (sort.SortId)
            {
                case "Symbol":
                    //comparison = (s1, s2) => string.Compare(s1.Symbol, s2.Symbol, StringComparison.InvariantCultureIgnoreCase);
                    if (sort.Direction == MatSortDirection.Desc)
                    {
                        ohlc = ohlc.OrderByDescending(x => x.Symbol).ToArray();
                    }
                    else
                    {
                        ohlc = ohlc.OrderBy(x => x.Symbol).ToArray();
                    }
                    break;
                case "Close":
                    //comparison = (s1, s2) => string.Compare(s1.ActionZone, s2.ActionZone, StringComparison.InvariantCultureIgnoreCase);
                    if (sort.Direction == MatSortDirection.Desc)
                    {
                        ohlc = ohlc.OrderByDescending(x => x.Close).ToArray();
                    }
                    else
                    {
                        ohlc = ohlc.OrderBy(x => x.Close).ToArray();
                    }
                    break;
                case "Volume":
                    //comparison = (s1, s2) => string.Compare(s1.ActionZone, s2.ActionZone, StringComparison.InvariantCultureIgnoreCase);
                    if (sort.Direction == MatSortDirection.Desc)
                    {
                        ohlc = ohlc.OrderByDescending(x => x.Volume).ToArray();
                    }
                    else
                    {
                        ohlc = ohlc.OrderBy(x => x.Volume).ToArray();
                    }
                    break;
                case "Value":
                    //comparison = (s1, s2) => string.Compare(s1.ActionZone, s2.ActionZone, StringComparison.InvariantCultureIgnoreCase);
                    if (sort.Direction == MatSortDirection.Desc)
                    {
                        ohlc = ohlc.OrderByDescending(x => x.Value).ToArray();
                    }
                    else
                    {
                        ohlc = ohlc.OrderBy(x => x.Value).ToArray();
                    }
                    break;
                case "RSI_Signal":
                    //comparison = (s1, s2) => string.Compare(s1.ActionZone, s2.ActionZone, StringComparison.InvariantCultureIgnoreCase);
                    if (sort.Direction == MatSortDirection.Desc)
                    {
                        ohlc = ohlc.OrderByDescending(x => x.RSI_Signal).ToArray();
                    }
                    else
                    {
                        ohlc = ohlc.OrderBy(x => x.RSI_Signal).ToArray();
                    }
                    break;
            }

        }
    }



    public void Show(MatToastType type, string icon = "")
    {
        Toaster.Configuration.Position = MatToastPosition.BottomCenter;

        Toaster.Add(_message, type, _title, icon, config =>
        {
            if (_actionOnClick)
            {
                config.Onclick = toast =>
                {
                    return Task.CompletedTask;
                };
            }
        });
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JSRuntime { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ILiffClient Liff { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IMatToaster Toaster { get; set; }
    }
}
#pragma warning restore 1591
