﻿using Microsoft.EntityFrameworkCore;

namespace Dwapi.Mnch.SharedKernel.Infrastructure.Data
{
    public abstract class BaseContext : DbContext
    {
        protected BaseContext(DbContextOptions options) : base(options)
        {
        }

        public virtual void EnsureSeeded()
        {

        }
    }
}
