using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Web.Repositories
{
    /// <summary>
    /// Http Response Manager
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HttpResponseWrapper<T>
    {

        /// <summary>
        /// Contructos
        /// </summary>
        /// <param name="response">reponse object</param>
        /// <param name="error">error </param>
        /// <param name="httpResponseMessage">httreponse message</param>
        public HttpResponseWrapper(T? response, bool error, HttpResponseMessage httpResponseMessage)
        {
            Response=response;
            Error=error;
            HttpResponseMessage=httpResponseMessage;
        }


        #region Properties

        /// <summary>
        /// Reponse Object
        /// </summary>
        public T? Response { get; set; }

        /// <summary>
        /// Check if exist error
        /// </summary>
        public bool Error { get; set; }


        /// <summary>
        /// Http reponse message object
        /// </summary>
        public HttpResponseMessage HttpResponseMessage { get; set; }

        #endregion

        #region publib Functions
        public async Task<string?> GetErrorMessageAsync()
        {
            if (!Error) return null;

            return HttpResponseMessage.StatusCode switch
            {
                HttpStatusCode.NotFound => "Recurso no encontrado",
                HttpStatusCode.BadRequest => await HttpResponseMessage.Content.ReadAsStringAsync(),
                HttpStatusCode.Unauthorized => "Usuario no Valido",
                HttpStatusCode.Forbidden => "Usuario no tiene permiso para esta operación",
                _ => "Ha ocurrido un error inesperado",
            };
        }
        #endregion




    }
}
