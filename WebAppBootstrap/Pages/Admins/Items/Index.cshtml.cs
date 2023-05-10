﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppBootstrap.Domain.Items;
using WebAppBootstrap.Infrastructure;

namespace WebAppBootstrap.Pages.Admins.Items
{
    public class IndexModel : PageModel
    {
        private readonly WebAppBootstrap.Infrastructure.ApplicationDbContext _context;

        public IndexModel(WebAppBootstrap.Infrastructure.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Item> Item { get;set; }

        public async Task OnGetAsync()
        {
            Item = await _context.Item
                .Include(i => i.Brand).ToListAsync();
        }
    }
}