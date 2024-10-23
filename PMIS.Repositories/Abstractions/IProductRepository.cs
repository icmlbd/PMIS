﻿using CustomerOrderManagementApp.Repositories.Abstractions;
using PMIS.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMIS.Repositories.Abstractions
{
    public interface IProductRepository : IRepository<Product>
    {
    }
}