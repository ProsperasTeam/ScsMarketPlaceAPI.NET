using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthenticationService.Models
{

    public class ProductCategoryModel
	{
        public long? Id { get; set; }
        public string? Name { get; set; }
        public long? LowAmount { get; set; }
        public long? HighAmount { get; set; }
        public DateTimeOffset? Created { get; set; }
        public DateTimeOffset? Modified { get; set; }
        public string? Description { get; set; }
        public string? Icon { get; set; }
        public long? CountryId { get; set; }
        public int? OrderBy { get; set; }
    }
}

