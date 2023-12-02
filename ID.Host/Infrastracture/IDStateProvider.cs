using ID.UI.Core.State.Abstractions;
using Microsoft.AspNetCore.Components.Authorization;

namespace ID.Host.Infrastracture
{
    public class IDStateProvider : AuthenticationStateProvider
    {
        protected readonly IStateService _stateService;

        public IDStateProvider(IStateService stateService)
        {
            _stateService = stateService ?? throw new ArgumentNullException(nameof(stateService));
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var currentUser = await _stateService.CurrentStateAsync();

            return new AuthenticationState(currentUser);
        }
    }
}
