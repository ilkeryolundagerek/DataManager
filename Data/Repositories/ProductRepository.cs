using Core.Abstracts.IRepositories;
using Core.Concretes.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context)
        {
        }
    }

    public class ProductCategoryRepository : GenericRepository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(DbContext context) : base(context)
        {
        }
    }

    public class ProductSubcategoryRepository : GenericRepository<ProductSubcategory>, IProductSubcategoryRepository
    {
        public ProductSubcategoryRepository(DbContext context) : base(context)
        {
        }
    }

    public class ProductPhotoRepository : GenericRepository<ProductPhoto>, IProductPhotoRepository
    {
        public ProductPhotoRepository(DbContext context) : base(context)
        {
        }
    }

    public class ProductProductPhotoRepository : GenericRepository<ProductProductPhoto>, IProductProductPhotoRepository
    {
        public ProductProductPhotoRepository(DbContext context) : base(context)
        {
        }
    }
}
