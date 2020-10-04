using Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Services.Response;
using Models.Abstract.Product;

namespace Service.Abstract
{
    public interface IProductService<T>:IService<T> where T:class,IProductModel
    {
    }
}
