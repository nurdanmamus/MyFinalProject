﻿using Core.DataAccess;
using DataAccess.Abstract; 
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal  
    {
        List<Product> _products; 
        public InMemoryProductDal()
        {
            // oracle,sql server,postgres,mongoDb
            _products = new List<Product> {
                new Product{ProductId=1,CategoryId=1,ProductName="Bardak",
                UnitPrice=15,UnitsInStock=15},
                new Product{ProductId=2,CategoryId=1,ProductName="Kamera",
                UnitPrice=1500,UnitsInStock=3},
                new Product{ProductId=3,CategoryId=2,ProductName="Telefon",
                UnitPrice=15,UnitsInStock=2},
                new Product{ProductId=4,CategoryId=2,ProductName="Klavye",
                UnitPrice=150,UnitsInStock=65},
                new Product{ProductId=5,CategoryId=2,ProductName="Fare",
                UnitPrice=85,UnitsInStock=1},
            };
        }

        public void Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        /* void Add(Product product) 
         {
             _products.Add(product);
         }

         void Delete(Product product)
         {
             //LING - Language Integrated Query 
             // Lambda
             /* 
             Product productToDelete = null;         
                 foreach (var p in _products)
                 {
                     if (product.ProductId == p.ProductId )
                     {
                         productToDelete = p; 
                     }
                 } 

             Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

             _products.Remove(productToDelete);
         }

         List<Product> GetAll()
         {
             return _products; 
         }

         void Update(Product product) 
         {
             //Gönderdiğim ürün id'sine sahip olan listedeki ürünü bul
             Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
             productToUpdate.ProductName = product.ProductName;
             productToUpdate.CategoryId = product.CategoryId;
             productToUpdate.UnitPrice = product.UnitPrice;
             productToUpdate.UnitsInStock = product.UnitsInStock;
         } */

        public List<Product> GetAllByCategory(int categryId)
        {
            //yeni bir tablo oluşturup onu döndürür.
            return _products.Where(p => p.CategoryId == categryId).ToList();

        }

      

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
