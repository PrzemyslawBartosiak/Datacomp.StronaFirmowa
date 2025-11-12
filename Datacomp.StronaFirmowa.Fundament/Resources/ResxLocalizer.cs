using Microsoft.Extensions.Localization;
using Telerik.Blazor.Services;

namespace Datacomp.StronaFirmowa.Fundament.Resources
{
    public class ResxLocalizer : ITelerikStringLocalizer
    {
        private readonly IStringLocalizer<SharedResources> _localizer;

        public ResxLocalizer(IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer;
        }

        public string? this[string name] => _localizer[name];

        public string? GetString(string key) => _localizer[key];
    }
}