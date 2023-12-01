using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace ID.Host.Infrastracture.Components.Base
{
    public class IDLayoutComponent : LayoutComponentBase
    {
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
                    _ => "Не определено",
                };
            }
        }
        protected MudTheme Theme => new MudTheme()
        {
            Palette = new Palette()
            {
                Primary = new MudBlazor.Utilities.MudColor("#6b7ef2"),
                Error = new MudBlazor.Utilities.MudColor("#b43d41")
            }
        };
    }
}
