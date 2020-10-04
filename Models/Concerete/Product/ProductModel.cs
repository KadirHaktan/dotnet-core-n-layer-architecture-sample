using Core.Model;
using System;
using Models.Abstract.Product;

namespace Models.Concerete.Product
{
    public class ProductModel:IProductModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Stock { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public bool IsDeleted { get; set; }

        public string InnerBarcode { get; set; }
    }
}
