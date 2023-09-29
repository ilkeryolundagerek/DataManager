using Core.Abstracts.IRepositories;
using Core.Abstracts.IUnitOfWorks;
using Data.Contexts;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private AW22Context context;
        private IProductRepository? productRepo;
        private IProductCategoryRepository? categoryRepo;
        private IProductSubcategoryRepository? subcategoryRepo;
        private IProductPhotoRepository? productPhotoRepo;
        private IProductProductPhotoRepository? productProductPhotoRepo;
        private IShoppingCartRepository? shoppingCartRepo;
        private IShoppingCartItemRepository? shoppingCartItemRepo;

        public UnitOfWork(AW22Context context)
        {
            this.context = context;
        }

        public IProductRepository ProductRepo => productRepo ??= new ProductRepository(context);

        public IProductCategoryRepository CategoryRepo => categoryRepo ??= new ProductCategoryRepository(context);

        public IProductSubcategoryRepository SubcategoryRepo => subcategoryRepo ??= new ProductSubcategoryRepository(context);

        public IProductPhotoRepository PhotoRepo => productPhotoRepo ??= new ProductPhotoRepository(context);

        public IProductProductPhotoRepository ProductPhotoRepo => productProductPhotoRepo ??= new ProductProductPhotoRepository(context);

        public IShoppingCartRepository ShoppingCartRepo => shoppingCartRepo ??= new ShoppingCartRepository(context);

        public IShoppingCartItemRepository ShoppingCartItemRepo => shoppingCartItemRepo ??= new ShoppingCartItemRepository(context);

        public async Task CommitAsync()
        {
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                await DisposeAsync();
            }
        }

        public async ValueTask DisposeAsync()
        {
            await context.DisposeAsync();
        }
    }
}
