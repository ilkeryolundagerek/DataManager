using Core.Concretes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core.Concretes.DTOs
{
    public class ProductListDTO
    {
        public int ProductID { get; set; }
        public string ProductNumber { get; set; }
        public string Name { get; set; }
        public decimal ListPrice { get; set; }
        public int? ProductSubcategoryID { get; set; }
        public string? SubcategoryName { get; set; }
        public int? ProductCategoryID { get; set; }
        public string? CategoryName { get; set; }
        public IEnumerable<byte[]?> ThumbNailPhotos { get; set; }
        public IEnumerable<string?> ThumbnailPhotoFileNames { get; set; }
        public IEnumerable<byte[]?> LargePhotos { get; set; }
        public IEnumerable<string?> LargePhotoFileNames { get; set; }
    }

    public class ProductDetailDTO
    {

    }
}
