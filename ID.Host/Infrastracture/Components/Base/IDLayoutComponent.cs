using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace ID.Host.Infrastracture.Components.Base
{
    public class IDLayoutComponent : LayoutComponentBase
    {
        [Inject] protected NavigationManager? Location { get; set; }

        protected bool CurrentThemeMode {  get; set; }

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
                    "/forbidden" => "403 - доступ запрещён",
                    "/unauthorized" => "401 - unauthorized",
                    "/roles" => "Роли",
                    "/users" => "Пользователи",
                    _ => "Страница не найдена",
                };
            }
        }

        [Obsolete("mud blazor palette is obsolete")]
        protected static MudTheme Theme => new()
        {
            Palette = new Palette()
            {
                Primary = new MudBlazor.Utilities.MudColor("#5941a7"),
                Error = new MudBlazor.Utilities.MudColor("#b43d41"),
            }
        };

        protected void ChangeThemeMode(bool newThemeMode)
        {
            CurrentThemeMode = newThemeMode;
        }
    }
}
