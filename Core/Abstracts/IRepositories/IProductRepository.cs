using Core.Concretes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstracts.IRepositories
{
    public interface IProductRepository : IGenericRepository<Product> { }
    public interface IProductCategoryRepository : IGenericRepository<ProductCategory> { }
    public interface IProductSubcategoryRepository : IGenericRepository<ProductSubcategory> { }
    public interface IProductPhotoRepository : IGenericRepository<ProductPhoto> { }
    public interface IProductProductPhotoRepository : IGenericRepository<ProductProductPhoto> { }
}
