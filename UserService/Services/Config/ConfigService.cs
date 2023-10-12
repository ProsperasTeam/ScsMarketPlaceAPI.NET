using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.HttpResults;
using UserService.Controllers.Config;
using UserService.Models;
using UserService.Models.Config;
using static UserService.Config.RepositoryGroupFactory;

namespace UserService.Controllers.Config
{
    public class ConfigService
    {
        //private readonly ObjectMapper _objectMapper;
        //private readonly LocalizedMessageSource _messageSource;
        //private readonly ConfigRepositoryGroup _repositoryGroup;

        //public ConfigService(ObjectMapper objectMapper, LocalizedMessageSource messageSource, ConfigRepositoryGroup repositoryGroup)
        //{
        //    _objectMapper = objectMapper;
        //    _messageSource = messageSource;
        //    _repositoryGroup = repositoryGroup;
        //}




        //public GetConfigResponse GetConfig(string authKey, string locale)
        //{
        //    long countryId = _repositoryGroup.CountryRepository.FindByLocale(locale)?.Id ?? 1;
        //    var categories = _repositoryGroup.ProductCategoryRepository.GetByCountryId(countryId);

        //    var org = _repositoryGroup.OrgRepository.GetByAuthorizationKeyAndIsActive(authKey, 1).SingleOrDefault();
        //    if (org == null)
        //    {
        //        throw new NotFound();
        //    }

        //    var survey = GetSurvey(categories);

        //    var templateNode = _objectMapper.ReadTree(org.Template);

        //    return new GetConfigResponse(
        //        new ConfigOrg(org.Id, org.Name),
        //        templateNode.Get("features"),
        //        templateNode.Get("colors"),
        //        templateNode.Get("resources"),
        //        survey
        //    );
        //}


        //private List<SurveyCategory> GetSurvey(List<ProductCategory> categories)
        //    {
        //        var categoryIds = categories.Select(cat => cat.Id).ToList();
        //        var productPurposes = _repositoryGroup.ProductPurposeRepository.FindByCategoryIdIn(categoryIds).GroupBy(pp => pp.CategoryId).ToDictionary(g => g.Key, g => g.ToList());
        //        var payPeriods = _repositoryGroup.PayPeriodRepository.FindByCategoryIdIn(categoryIds).GroupBy(pp => pp.CategoryId).ToDictionary(g => g.Key, g => g.ToList());
        //        var productTerms = _repositoryGroup.ProductTermRepository.FindByCategoryIdIn(categoryIds).GroupBy(pt => pt.CategoryId).ToDictionary(g => g.Key, g => g.ToList());
        //        var productAmounts = _repositoryGroup.ProductAmountRepository.FindByCategoryIdIn(categoryIds).GroupBy(pa => pa.CategoryId).ToDictionary(g => g.Key, g => g.ToList());
        //        var supportTypes = _repositoryGroup.SupportTypeRepository.FindByCategoryIdIn(categoryIds).GroupBy(st => st.CategoryId).ToDictionary(g => g.Key, g => g.ToList());
        //        var incomeTypes = _repositoryGroup.IncomeTypeRepository.FindByCategoryIdIn(categoryIds).GroupBy(it => it.CategoryId).ToDictionary(g => g.Key, g => g.ToList());
        //        var employmentTypes = _repositoryGroup.EmploymentTypeRepository.FindByCategoryIdIn(categoryIds).GroupBy(et => et.CategoryId).ToDictionary(g => g.Key, g => g.ToList());

        //        return categories.Select(cat =>
        //        {
        //            var catPurpose = productPurposes.ContainsKey(cat.Id) ? productPurposes[cat.Id].OrderBy(pp => pp.Id).Select(pp => new SurveyPart(pp.Id, pp.Name, pp.Description, pp.CategoryId, null, pp.Icon, pp.CountryId)).ToList() : new List<SurveyPart>();
        //            var catPayPeriods = payPeriods.ContainsKey(cat.Id) ? payPeriods[cat.Id].OrderBy(pp => pp.Id).Select(pp => new SurveyPart(pp.Id, pp.Name, pp.Description, pp.CategoryId, pp.Value, pp.Icon, pp.CountryId)).ToList() : new List<SurveyPart>();
        //            var catProductTerms = productTerms.ContainsKey(cat.Id) ? productTerms[cat.Id].OrderBy(pt => pt.Id).Select(pt => new SurveyPart(pt.Id, pt.Name, pt.Description, pt.CategoryId, pt.Value, pt.Icon, pt.CountryId)).ToList() : new List<SurveyPart>();
        //            var catProductAmounts = productAmounts.ContainsKey(cat.Id) ? productAmounts[cat.Id].OrderBy(pa => pa.Id).Select(pa => new SurveyPart(pa.Id, pa.Name, pa.Description, pa.CategoryId, pa.Value, pa.Icon, pa.CountryId)).ToList() : new List<SurveyPart>();
        //            var catSupportTypes = supportTypes.ContainsKey(cat.Id) ? supportTypes[cat.Id].OrderBy(st => st.Id).Select(st => new SurveyPart(st.Id, st.Name, st.Description, st.CategoryId, null, st.Icon, st.CountryId)).ToList() : new List<SurveyPart>();
        //            var catIncomeTypes = incomeTypes.ContainsKey(cat.Id) ? incomeTypes[cat.Id].OrderBy(it => it.Id).Select(it => new SurveyPart(it.Id, it.Name, it.Description, it.CategoryId, it.Value, it.Icon, it.CountryId)).ToList() : new List<SurveyPart>();
        //            var catEmploymentTypes = employmentTypes.ContainsKey(cat.Id) ? employmentTypes[cat.Id].OrderBy(et => et.Id).Select(et => new SurveyPart(et.Id, et.Name, et.Description, et.CategoryId, null, et.Icon, et.CountryId)).ToList() : new List<SurveyPart>();

        //            return new SurveyCategory(
        //                cat.Id,
        //                cat.Name,
        //                cat.LowAmount,
        //                cat.HighAmount,
        //                cat.Created,
        //                cat.Modified,
        //                cat.Description,
        //                cat.Icon,
        //                cat.CountryId,
        //                cat.OrderBy,
        //                catPurpose,
        //                catPayPeriods,
        //                catProductTerms,
        //                catProductAmounts,
        //                catSupportTypes,
        //                catIncomeTypes,
        //                catEmploymentTypes
        //            );
        //        }).ToList();
        //    }
    }
}
