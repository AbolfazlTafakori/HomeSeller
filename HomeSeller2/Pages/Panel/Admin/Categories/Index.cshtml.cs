﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TafakoriHomeSeller.Data;
using TafakoriHomeSeller.Models;

namespace TafakoriHomeSeller.Pages.Panel.Admin.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<CategoryModel> CategoryModel { get;set; }

        public async Task OnGetAsync()
        {
            CategoryModel = await _context.Category.ToListAsync();
        }
    }
}
