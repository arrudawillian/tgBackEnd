﻿using Microsoft.EntityFrameworkCore;
using Sge.Data.Interfaces;
using Sge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sge.Data.Repositories
{
    public class PacoteRepository : RepositoryBase<Pacote>, IPacoteRepository
    {
        public PacoteRepository(SgeContext _context) : base(_context)
        { }
    }
}
