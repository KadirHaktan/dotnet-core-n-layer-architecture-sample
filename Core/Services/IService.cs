using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Entity;
using Core.Model;
using Core.Services.Response;

namespace Core.Services
{
    public interface IService<T> where T:class,IModel
    {
        ServiceResponse<T> FindById(int id);

        Task<ServiceResponse<T>> FindByIdAsync(int id);

        ServiceResponse<T> List();

        Task<ServiceResponse<T>> ListAsync();


        ServiceResponse<int> Insert(T model);

        ServiceResponse<int> Update(T model);

        ServiceResponse<bool> Delete(T model);
    }
}
