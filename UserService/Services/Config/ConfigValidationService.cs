using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;
using System.Text.RegularExpressions;
using UserService.Controllers.Config;

public class ConfigValidationService
{
    private readonly IStringLocalizer<ConfigController> _localizer;
    private readonly Regex _localeRegex = new Regex("^[A-Za-z0-9/-]+$");
    private readonly Regex _authKeyRegex = new Regex("^[A-Za-z0-9/-]+$");

    public ConfigValidationService(IStringLocalizer<ConfigController> localizer)
    {
        _localizer = localizer;
    }

    public void ValidateLocale(string locale)
    {
        bool isValidLocale = !string.IsNullOrWhiteSpace(locale) && _localeRegex.IsMatch(locale);
        if (!isValidLocale)
        {
            throw new ArgumentException(_localizer["locale.invalid"]);
        }
    }

    public void ValidateAuthKey(string authKey)
    {
        bool isValidKey = !string.IsNullOrWhiteSpace(authKey) && _authKeyRegex.IsMatch(authKey);
        if (!isValidKey)
        {
            throw new ArgumentException(_localizer["authkey.invalid"]);
        }
    }

    public string GetNormalizedLocale(string locale)
    {
        if (locale.StartsWith("en"))
        {
            return "en-rUS";
        }
        else if (locale.StartsWith("es"))
        {
            return "es-rMX";
        }
        else
        {
            return "es-rMX";
        }
    }
}
