using System;
namespace ScsMarketplace.API.Config
{
	public class RepositoryGroupFactory
	{
        //public record ConfigRepositoryGroup(
    //ProductCategoryRepository ProductCategoryRepository,
    //AccountRepository AccountRepository,
    //OrgRepository OrgRepository,
    //CountryRepository CountryRepository,
    //ProductPurposeRepository ProductPurposeRepository,
    //PayPeriodRepository PayPeriodRepository,
    //ProductTermRepository ProductTermRepository,
    //ProductAmountRepository ProductAmountRepository,
    //SupportTypeRepository SupportTypeRepository,
    //IncomeTypeRepository IncomeTypeRepository,
    //EmploymentTypeRepository EmploymentTypeRepository);

        public RepositoryGroupFactory()
		{
		}

        //public class RepositoryGroupFactory
        //{
        //public ConfigRepositoryGroup ProvidesConfigRepositoryGroup(
        //    ProductCategoryRepository productCategoryRepository,
        //    AccountRepository accountRepository,
        //    OrgRepository orgRepository,
        //    CountryRepository countryRepository,
        //    ProductPurposeRepository productPurposeRepository,
        //    PayPeriodRepository payPeriodRepository,
        //    ProductTermRepository productTermRepository,
        //    ProductAmountRepository productAmountRepository,
        //    SupportTypeRepository supportTypeRepository,
        //    IncomeTypeRepository incomeTypeRepository,
        //    EmploymentTypeRepository employmentTypeRepository)
        //{
        //    return new ConfigRepositoryGroup(
        //        productCategoryRepository,
        //        accountRepository,
        //        orgRepository,
        //        countryRepository,
        //        productPurposeRepository,
        //        payPeriodRepository,
        //        productTermRepository,
        //        productAmountRepository,
        //        supportTypeRepository,
        //        incomeTypeRepository,
        //        employmentTypeRepository
        //    );
        //}
        //}
    }
}


//// Register services and create the service provider
//var serviceProvider = new ServiceCollection()
//    .AddSingleton<ProductCategoryRepository>()
//    .AddSingleton<AccountRepository>()
//    .AddSingleton<OrgRepository>()
//    .AddSingleton<CountryRepository>()
//    .AddSingleton<ProductPurposeRepository>()
//    .AddSingleton<PayPeriodRepository>()
//    .AddSingleton<ProductTermRepository>()
//    .AddSingleton<ProductAmountRepository>()
//    .AddSingleton<SupportTypeRepository>()
//    .AddSingleton<IncomeTypeRepository>()
//    .AddSingleton<EmploymentTypeRepository>()
//    .AddTransient<RepositoryGroupFactory>()
//    .AddTransient(provider =>
//    {
//        var factory = provider.GetRequiredService<RepositoryGroupFactory>();
//        return factory.ProvidesConfigRepositoryGroup(
//            provider.GetRequiredService<ProductCategoryRepository>(),
//            provider.GetRequiredService<AccountRepository>(),
//            provider.GetRequiredService<OrgRepository>(),
//            provider.GetRequiredService<CountryRepository>(),
//            provider.GetRequiredService<ProductPurposeRepository>(),
//            provider.GetRequiredService<PayPeriodRepository>(),
//            provider.GetRequiredService<ProductTermRepository>(),
//            provider.GetRequiredService<ProductAmountRepository>(),
//            provider.GetRequiredService<SupportTypeRepository>(),
//            provider.GetRequiredService<IncomeTypeRepository>(),
//            provider.GetRequiredService<EmploymentTypeRepository>());
//    })
//    .BuildServiceProvider();

//// You can now use the serviceProvider to resolve instances of ConfigRepositoryGroup.
//var configRepositoryGroup = serviceProvider.GetRequiredService<ConfigRepositoryGroup>();
