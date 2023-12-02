using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;

namespace ID.Host.Infrastracture.Components.Base
{
    public class IDLayoutComponent : LayoutComponentBase
    {
        [CascadingParameter] Task<AuthenticationState>? State { get; set; }
        [Inject] protected NavigationManager? Location { get; set; }

        protected string AppTitle
        {
            get
            {
                return $"/{Location!.Uri.Split('/')?.LastOrDefault()}" switch
                {
                    "/" => "Главная",
                    "/clients" => "Список приложений",
                    "/resources" => "Ресурсы приложений",
                    "/scopes" => "Области доступа приложений",
                    "/login" => "Вход",
                    _ => "Не определено",
                };
            }
        }
        protected MudTheme Theme => new MudTheme()
        {
            Palette = new Palette()
            {
                Primary = new MudBlazor.Utilities.MudColor("#5941a7"),
                Error = new MudBlazor.Utilities.MudColor("#b43d41")
            }
        };

        //protected override async Task OnParametersSetAsync()
        //{
        //    if(State != null)
        //    {
        //        var user = await State;
        //        if (user.User.Identity == null || !user.User.Identity.IsAuthenticated)
        //            Location!.NavigateTo("/login");
        //    }

        //    await base.OnParametersSetAsync();
        //}
    }
}
