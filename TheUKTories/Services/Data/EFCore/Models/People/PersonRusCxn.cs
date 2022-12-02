using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheUKTories.Services.Data.EFCore.Models.People
{
    public class PersonRusCxn
    {
        public int PersonRusCxnId { get; set; }
        public virtual int PersonId { get; set; }
        public string? Content { get; set; }
        public virtual Person? Person { get; set; }
        public virtual ICollection<PersonRusCxnSource> SourceItems { get; set; } = default!;
    }
}
