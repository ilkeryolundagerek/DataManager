using Core.Abstracts.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstracts.IUnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IProductRepository ProductRepo { get; }
        IProductCategoryRepository CategoryRepo { get; }
        IProductSubcategoryRepository SubcategoryRepo { get; }
        IProductPhotoRepository PhotoRepo { get; }
        IProductProductPhotoRepository ProductPhotoRepo { get; }
        Task CommitAsync();
    }
}
