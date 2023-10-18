using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace AuthenticationService.Models
{
    public class Organization
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? website { get; set; }
        public DateTime? createdate { get; set; }
        public DateTime? modifydate { get; set; }
        public int? isactive { get; set; }
        public string? authorizationkey { get; set; }
        public string? credourl { get; set; }
        public string credoauthkey { get; set; }
        public string? url { get; set; }
        public string? email { get; set; }
        public string? phone1 { get; set; }
        public string? phone2 { get; set; }
        public string? address1 { get; set; }
        public string? address2 { get; set; }
        public string? country { get; set; }
        public string? city { get; set; }
        public string? zipcode { get; set; }
        public string? image { get; set; }
        public string? primarycontact { get; set; }
        public string? accountexecutive { get; set; }
        public string? credouser { get; set; }
        public string? credopassword { get; set; }
        public string? credocollecturl { get; set; }
        public string? template { get; set; }
        public int? countryid { get; set; }
    }
}

