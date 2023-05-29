namespace Sales.Web.Repositories
{
    public interface IRepository
    {
        /// <summary>
        /// Get all Items
        /// </summary>
        /// <typeparam name="controllerName"></typeparam>
        /// <returns></returns>
        Task<HttpResponseWrapper<T>> GetItemsAsync<T>(string url);


        /// <summary>
        /// get Item by Id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="controllerName"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<HttpResponseWrapper<T>> GetItemByIdAsync<T>(string url, int id);


        /// <summary>
        /// Insert New Item
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="controllerName"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<HttpResponseWrapper<object>> PostAsync<T>(string url, T model);


        /// <summary>
        ///  Insert New Item
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="controllerName"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<HttpResponseWrapper<TResponse>> PostAsync<T, TResponse>(string url, T model);

        /// <summary>
        /// Delete a current item
        /// </summary>
        /// <param name="url"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<HttpResponseWrapper<object>> DeleteAsync(string url, int id);



        /// <summary>
        /// Save New Item
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="controllerName"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<HttpResponseWrapper<object>> PutAsync<T>(string url, T model);


        /// <summary>
        ///  Save New Item
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="controllerName"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<HttpResponseWrapper<TResponse>> PutAsync<T, TResponse>(string url, T model);

    }
}
