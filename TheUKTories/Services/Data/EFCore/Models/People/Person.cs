using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public string Titles { get; set; }
        [Description("Profile Image Blob URL")]
        public string? ProfileImageBlobUri { get; set; }
        public bool IsProfilePublic { get; set; } = false;
        public virtual ICollection<PersonQuote> Quotes { get; set; } = default!;
        public virtual ICollection<PersonGeneral> GeneralList { get; set; } = default!;
        public virtual ICollection<PersonRusCxn> RussianConnections { get; set; } = default!;

        public string GetProfileImageName() => FullName.ToLower().Replace(' ', '_').Remove('\'');
        public string[] GetTitles() => (string.IsNullOrEmpty(Titles)) ? Array.Empty<string>() : Titles.Split(';');

    }
}
