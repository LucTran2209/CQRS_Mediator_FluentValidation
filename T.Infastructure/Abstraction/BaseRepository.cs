﻿using T.Domain.Abstractions.IRepositories;
using T.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T.Infastructure.Abstraction
{
    public abstract class BaseRepository
    {
        protected readonly ApplicationDbContext _dbContext;

        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
