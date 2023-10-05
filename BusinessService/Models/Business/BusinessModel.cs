using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessService.Models.Business
{
    public class BusinessModel
    {
        public int id { get; set; }
        public int? consumerid { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string phone { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string postalcode { get; set; }
        public string city { get; set; }
        public int? stateid { get; set; }
        public int? countryid { get; set; }
        public int? age { get; set; }
        public string taxid { get; set; }
        public DateTime created { get; set; }
        public DateTime? modified { get; set; }
        public DateTime? deleted { get; set; }

        // Define relationships if needed
        // public Consumer Consumer { get; set; }
        // public State State { get; set; }
        // public Country Country { get; set; }
    }
}