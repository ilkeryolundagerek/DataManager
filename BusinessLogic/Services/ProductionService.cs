using Core.Abstracts.IServices;
using Core.Abstracts.IUnitOfWorks;
using Core.Concretes.DTOs;
using Core.Concretes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ProductionService : IProductionService
    {
        private IUnitOfWork uow;

        public ProductionService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<IEnumerable<ProductListDTO>> GetProducts()
        {
            IEnumerable<Product> products_data = await uow.ProductRepo.GetManyAsync(x=>x.ListPrice>0 && (bool)x.FinishedGoodsFlag,new string[] { "ProductSubcategory.ProductCategory", "ProductProductPhotos.ProductPhoto" });

            return from p in products_data
                   select new ProductListDTO
                   {
                       ProductID = p.ProductId,
                       ProductNumber = p.ProductNumber,
                       Name = p.Name,
                       ProductSubcategoryID = p.ProductSubcategoryId,
                       ProductCategoryID = p.ProductSubcategory?.ProductCategoryId,
                       SubcategoryName = p.ProductSubcategory?.Name,
                       CategoryName = p.ProductSubcategory?.ProductCategory.Name,
                       ListPrice = p.ListPrice,
                       ThumbNailPhotos = p.ProductProductPhotos.Select(x => x.ProductPhoto.ThumbNailPhoto),
                       ThumbnailPhotoFileNames = p.ProductProductPhotos.Select(x => x.ProductPhoto.ThumbnailPhotoFileName),
                       LargePhotos = p.ProductProductPhotos.Select(x => x.ProductPhoto.LargePhoto),
                       LargePhotoFileNames = p.ProductProductPhotos.Select(x => x.ProductPhoto.LargePhotoFileName)
                   };
        }

    }
}
