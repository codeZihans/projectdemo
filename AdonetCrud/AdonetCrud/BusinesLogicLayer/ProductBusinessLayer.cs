using AdonetCrud.DataAccessLayer;
using AdonetCrud.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdonetCrud.BusinesLogicLayer
{
    public class ProductBusinessLayer
    {
        public bool Create(Product product)
        {
            ProductAdoDataAcessLayer  nextLayer = new ProductAdoDataAcessLayer();
            bool result = nextLayer.Create(product);
            return result;
        }
        
        public bool Update(Product product)
        {
            ProductAdoDataAcessLayer nextLayer = new ProductAdoDataAcessLayer();
            bool result = nextLayer.Update(product);
            return result;
        }
        public Product GetProductById(int id)
        {
          ProductAdoDataAcessLayer nextLayer = new ProductAdoDataAcessLayer();
          Product result = nextLayer.GetProductById(id);
          return result;
        }
            
        public bool DeleteById(int id) 
        {
            ProductAdoDataAcessLayer nextLayer = new ProductAdoDataAcessLayer();
            bool result = nextLayer.DeleteById(id);
            return result;
        }

        public List<Product> GetProducts()
        {
            ProductAdoDataAcessLayer nextLayer = new ProductAdoDataAcessLayer();
            List<Product> products = nextLayer.GetProducts();
            return products;
        }  

        

       
    }
}
