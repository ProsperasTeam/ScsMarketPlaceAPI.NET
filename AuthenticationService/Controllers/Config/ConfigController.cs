using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace AuthenticationService.Controllers.Config
{
    [ApiController]
    [Route("Config")]
    public class ConfigController : Controller
    {
        //private readonly ConfigValidationService configValidationService;
        //private readonly ConfigService configService;

        //public ConfigController(ConfigValidationService configValidationService, ConfigService configService)
        //{
        //    this.configValidationService = configValidationService;
        //    this.configService = configService;
        //}

        //[HttpGet("{authKey}/{locale}")]
        //[Produces("application/json")]
        //[Route("Config")]
        //public ActionResult<GetConfigResponse> GetConfigForLocaleAndAuthKey(string authKey, string locale)
        //{
        //    configValidationService.ValidateAuthKey(authKey);
        //    configValidationService.ValidateLocale(locale);

        //    string normalizedLocale = configValidationService.GetNormalizedLocale(locale);

        //    //GetConfigResponse response = configService.GetConfig(authKey, normalizedLocale);
        //    //if (response == null)
        //    //{
        //    //    return NotFound("Configuration not found");
        //    //}

        //    return Ok();
        //}
    }
}

