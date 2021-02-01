using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TheUKTories.DataStores.AzureCosmos;
using TheUKTories.DataStores.AzureCosmos.Models;

namespace TheUKTories.Pages
{
    public class IndexModel : PageModel
    {
        CosmosDbContext _context;

        public List<Austeritys> Austeritys
        {
            get { return _austeritys; }
            private set { }
        }

        private readonly ILogger<IndexModel> _logger;
        private List<Austeritys> _austeritys;

        public IndexModel(ILogger<IndexModel> logger, CosmosDbContext context) 
        {
            _logger = logger;
            _context = context;
        }

        public async Task OnGetAsync()
        {
            _austeritys = await _context.GetDocumentsAsync<Austeritys>(_context.AusterityContainer);
        }
    }
}
