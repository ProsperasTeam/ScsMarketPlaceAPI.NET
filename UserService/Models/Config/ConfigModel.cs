using System;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace UserService.Models.Config

{
    public class ConfigOrgModel
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }

    public class SurveyPart
        {
        public SurveyPart(object id, object name, object description, object categoryId, object value, object icon, object countryId)
        {
        }

        [JsonPropertyName("id")]
            public long? Id { get; set; }

            [JsonPropertyName("name")]
            public string? Name { get; set; }

            [JsonPropertyName("description")]
            public string? Description { get; set; }

            [JsonPropertyName("categoryId")]
            public long? CategoryId { get; set; }

            [JsonPropertyName("value")]
            public long? Value { get; set; }

            [JsonPropertyName("icon")]
            public string? Icon { get; set; }

            [JsonPropertyName("countryId")]
            public long? CountryId { get; set; }
        }

        public class SurveyCategory
        {
        public SurveyCategory(long? id, string? name, long? lowAmount, long? highAmount, DateTimeOffset? created, DateTimeOffset? modified, string? description, string? icon, long? countryId, int? orderBy, object catPurpose, object catPayPeriods, object catProductTerms, object catProductAmounts, object catSupportTypes, object catIncomeTypes, object catEmploymentTypes)
        {
            Id = id;
            Name = name;
            LowAmount = lowAmount;
            HighAmount = highAmount;
            Created = created;
            Modified = modified;
            Description = description;
            Icon = icon;
            CountryId = countryId;
            OrderBy = orderBy;
        }

        [JsonPropertyName("id")]
            public long? Id { get; set; }

            [JsonPropertyName("name")]
            public string? Name { get; set; }

            [JsonPropertyName("lowamount")]
            public long? LowAmount { get; set; }

            [JsonPropertyName("highamount")]
            public long? HighAmount { get; set; }

            [JsonPropertyName("created")]
            public DateTimeOffset? Created { get; set; }

            [JsonPropertyName("modified")]
            public DateTimeOffset? Modified { get; set; }

            [JsonPropertyName("description")]
            public string? Description { get; set; }

            [JsonPropertyName("icon")]
            public string? Icon { get; set; }

            [JsonPropertyName("countryid")]
            public long? CountryId { get; set; } 

            [JsonPropertyName("orderby")]
            public int? OrderBy { get; set; }

            [JsonPropertyName("productpurposes")]
            public List<SurveyPart>? ProductPurpose { get; set; }

            [JsonPropertyName("payperiods")]
            public List<SurveyPart>? PayPeriod { get; set; }

            [JsonPropertyName("productterms")]
            public List<SurveyPart>? ProductTerm { get; set; }

            [JsonPropertyName("productamounts")]
            public List<SurveyPart>? ProductAmount { get; set; }

            [JsonPropertyName("supporttypes")]
            public List<SurveyPart>? SupportType { get; set; }

            [JsonPropertyName("incometypes")]
            public List<SurveyPart>? IncomeType { get; set; }

            [JsonPropertyName("employmenttypes")]
            public List<SurveyPart>? EmploymentType { get; set; }
        }

        public class GetConfigResponse
        {
            public ConfigOrgModel? Org { get; set; }
            public JsonNode? Features { get; set; }
            public JsonNode? Colors { get; set; }
            public JsonNode? Resources { get; set; }
            public List<SurveyCategory>? Survey { get; set; }
        }
    }

