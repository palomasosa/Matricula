﻿
namespace claseModelado1.Client.Servicios
{
    public interface IHttpService
    {
        Task<HttpRespuesta<T>> Get<T>(string url);
        Task<HttpRespuesta<object>> Post<T>(string url, T enviar);
        Task<HttpRespuesta<object>> Put<T>(string url, T enviar);
    }
}