﻿using System.Globalization;

namespace Medallion.Models
{
    public class Patron
    {
        public string PatronId { get; set; }
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string ZipCode { get; set; }
        public string CellPhone { get; set; }
        public string Email {  get; set; }
    }
}
