using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheUKTories.Services.Data.EFCore.Models.People
{
    public class Person
    {
        [Required]
        public int PersonId { get; set; }
        [Required]
        public string? FullName { get; set; }
        public string? Nationality { get; set; }
        public string? PoliticalParty { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? CurrentTitle { get; set; }
        public string? ProfileImageBlobUri { get; set; }
        public bool? IsProfilePublic { get; set; }

        public virtual ICollection<Quote> Quotes { get; set; } = default!;
        public virtual ICollection<PersonGeneral> GeneralList { get; set; } = default!;
    }

    public class Quote : SourceItem, ISourceItem 
    { 
        public int QuoteId { get; set; }
        public virtual int PersonId { get; set; }
        public virtual Person? Person { get; set; }
    }

    public class PersonGeneral : SourceItem, ISourceItem 
    {
        public int PersonGeneralId { get; set; }
        public virtual int PersonId { get; set; }
        public virtual Person? Person { get; set; }
    }
}
