using Sales.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Web.Repositories
{
    public interface IRepository
    {
        /// <summary>
        /// Get all Items
        /// </summary>
        /// <typeparam name="controllerName"></typeparam>
        /// <returns></returns>
        Task<HttpResponseWrapper<T>> GetItemsAsync<T>(string controllerName) ;


        /// <summary>
        /// get Item by Id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="controllerName"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<HttpResponseWrapper<T>> GetItemByIdAsync<T>(string controllerName, int id);


        /// <summary>
        /// Save New Item
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="controllerName"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<HttpResponseWrapper<object>> PostAsync<T>(string controllerName, T model) ;


        /// <summary>
        ///  Save New Item
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="controllerName"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<HttpResponseWrapper<TResponse>> PostAsync<T, TResponse>(string controllerName, T model);
    }
}
