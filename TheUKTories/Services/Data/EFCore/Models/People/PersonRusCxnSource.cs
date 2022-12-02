using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheUKTories.Services.Data.EFCore.Models.People
{
    public class PersonRusCxnSource : SourceItem, ISourceItem
    {
        public int PersonRusCxnSourceId { get; set; }
        public virtual int PersonRusCxnId { get; set; }
        public virtual PersonRusCxn PersonRusCxn { get; set; } = default!;
    }
}
