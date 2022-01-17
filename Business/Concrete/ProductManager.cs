﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService  
    {
        IProductDal _productDal;
        ICategoryService _categoryService;
        //bir entity manager kendisi hariç başka bir dal'ı enjekte edemez. 
        //
        public ProductManager(IProductDal productDal,ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService; 
        }
        //Claim
        //[SecuredOperation("product.add")
        [ValidationAspect(typeof(ProductValidator))] 
        public IResult Add(Product product)   
        {
            //business codes 
            //validation , eklenmesini istediğimiz nesnenin yapısıyla
            //ilgili ise. 

            //if (product.UnitPrice <=0)
            //{
            //    return new ErrorResult(Messages.UnitPriceInvalid);
            //}

            //if (product.ProductName.Length<2)
            //{ //magic string 
            //    return new ErrorResult(Messages.ProductNameInvalid); 
            //}
            //  ValidationTool.Validate(new ProductValidator(), product); 
            //log
            //cacherremove
            //performance
            //transaction
            //authorization  


            //business rules
            //bir kategoride en fazla 10 ürün olabilir.
            //aynı isimde ürün eklenemez
            //eğer mevcut kategori sayısı 15'i geçtiyse sisteme yeni ürün eklenemez 
            //microservice mimarileri için 
            IResult result = BusinessRules.Run(CheckIfProductNameExists(product.ProductName), 
                CheckIfProductCountOfCategoryCorrect(product.CategoryId),CheckIfCategoryLimitExceed());

            if (result != null) 
            {
                return result;
            }

            _productDal.Add(product);  

             return new SuccessResult(Messages.ProductAdded);

            //if (CheckIfProductCountOfCategoryCorrect(product.CategoryId).Success)
            //{
            //    if (CheckIfProductNameExists(product.ProductName).Success)
            //    {
            //        _productDal.Add(product);
            //        return new SuccessResult(Messages.ProductAdded);
            //    }               
            //}
            //return new ErrorResult(); 
        }

        public IDataResult<List<Product>> GetAll()   
        {
            //if (DateTime.Now.Hour==22) 
            //{
            //    return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            //}
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductsListed);  
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        { 
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));  
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>( _productDal.Get(p => p.ProductId == productId));  
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        { 
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        { 
            return new SuccessDataResult<List<ProductDetailDto>>( _productDal.GetProductDetails()); 
        }

        [ValidationAspect(typeof(ProductValidator))] 
        public IResult Update(Product product)
        {
            throw new NotImplementedException(); 
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)  
        {
            //select count(*) from products where categoryid=1 
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 10)
            { 
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductNameExists(string productName)
        {
            //select count(*) from products where categoryid=1 
            var result = _productDal.GetAll(p => p.ProductName == productName).Any(); 
            if (result) 
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);  
            }
            return new SuccessResult();
        }
        //eğer bu kuralı kategoriye yazmış olsaydık. bu tek başına bir servis
        //demek olurdu fakat bu method product servisinin kategoriyi nasıl
        //yorumladığıyla alakalıdır.
        private IResult CheckIfCategoryLimitExceed() 
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.CategoryLimitExceed);
            }
            return new SuccessResult();
        }
    }
}