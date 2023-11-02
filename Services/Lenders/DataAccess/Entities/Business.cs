using System.ComponentModel.DataAnnotations.Schema;

namespace Lenders.DataAccess.Entities
{
    [Table("lender")]
    public class Lender
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("email")]
        public string? Email { get; set; }

        [Column("phone")]
        public string? Phone { get; set; }

        [Column("password")]
        public string? Password { get; set; }

        [Column("createdate")]
        public DateTime CreateDate { get; set; }

        [Column("modifydate")]
        public DateTime? ModifyDate { get; set; }

        [Column("companyicon")]
        public string CompanyIcon { get; set; }

        [Column("s3bucket")]
        public string? S3Bucket { get; set; }

        [Column("countryid")]
        public int? CountryId { get; set; }

        [Column("stateid")]
        public int? StateId { get; set; }

        [Column("lenderuuid")]
        public string? LenderUuid { get; set; }

        [Column("lowscorethreshold")]
        public int? LowScoreThreshold { get; set; }

        [Column("campaigncostlimit")]
        public int? CampaignCostLimit { get; set; }

        [Column("dailycostlimit")]
        public int? DailyCostLimit { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("website")]
        public string? Website { get; set; }

        [Column("kycflag")]
        public bool? KycFlag { get; set; }

        [Column("fraudthreshold")]
        public int? FraudThreshold { get; set; }

        [Column("leadcost")]
        public decimal? LeadCost { get; set; }

        [Column("defaultthreshold")]
        public decimal? DefaultThreshold { get; set; }
    }
}
