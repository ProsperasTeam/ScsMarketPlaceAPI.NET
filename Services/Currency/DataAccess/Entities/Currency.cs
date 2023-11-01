using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Currency.DataAccess.Entities
    
{
    [Table("currency")]
    public class Currency
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("symbol")]
        public string? Symbol { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("country")]
        public string? Country { get; set; }

        [Column("code")]
        public string? Code { get; set; }
    }
}
