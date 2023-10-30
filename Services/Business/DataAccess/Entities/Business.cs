using System.ComponentModel.DataAnnotations.Schema;

namespace Business.DataAccess.Entities
{
    [Table("business")]
    public class Business
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("consumerid")]
        public int? ConsumerId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string? description { get; set; }

        [Column("phone")]
        public string? Phone { get; set; }

        [Column("postalcode")]
        public string? PostalCode { get; set; }

        [Column("stateid")]
        public int? StateId { get; set; }

        [Column("countryid")]
        public int? CountryId { get; set; }

        [Column("created")]
        public DateTime? Created { get; set; }

        [Column("modified")]
        public DateTime? Modified { get; set; }

        [Column("deleted")]
        public DateTime? Deleted { get; set; }

        [Column("age")]
        public int? Age { get; set; }

        [Column("taxid")]
        public string? Taxid { get; set; }

        [Column("city")]
        public string? City { get; set; }
    }
}
