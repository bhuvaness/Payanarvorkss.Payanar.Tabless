using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Modelss;

namespace WinFormsApp1
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetNew(string url);
        Task<IEnumerable<T>> GetMultipleAsync(string url);
        Task<IEnumerable<T>> GetAsync(string url, string id);
        Task<T> Insert(string url, T model);
        Task<IEnumerable<T>> CreateMultiple(string url, IEnumerable<T> model);
        Task<bool> Update(string url, string id, T model);
        Task<bool> Delete(string url, string id);
        Task<bool> Delete(string url, T model);
        Task<bool> DeleteMultiple(string url, IEnumerable<T> model);
    }
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly IHttpClientFactory _httpClientFactory = null;

        public BaseRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<T> Insert(string url, T model)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, url);
                var content = JsonConvert.SerializeObject(model);
                request.Content = new StringContent(content, Encoding.UTF8, "application/json");

                var client = _httpClientFactory.CreateClient();
                HttpResponseMessage response = await client.SendAsync(request);
            }
            catch (Exception ex) { }
            return model;
        }

        public async Task<IEnumerable<T>> CreateMultiple(string url, IEnumerable<T> model)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);

            return model;
        }
        public async Task<bool> Delete(string url, T model)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, url);
            request.Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return true;

            return false;
        }
        public async Task<bool> Delete(string url, string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return false;

            var request = new HttpRequestMessage(HttpMethod.Delete, url + id);
            var client = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return true;

            return false;
        }
        public async Task<bool> DeleteMultiple(string url, IEnumerable<T> model)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, url);
            request.Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return true;

            return false;
        }

        public async Task<IEnumerable<T>> GetAsync(string url, string id)
        {
            HttpRequestMessage requestMessage = null;
            if (!string.IsNullOrWhiteSpace(id))
                requestMessage = new HttpRequestMessage(HttpMethod.Get, url + id);
            else
                requestMessage = new HttpRequestMessage(HttpMethod.Get, url);

            var client = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(requestMessage);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<T>>(content);
            }

            return null;
        }

        public async Task<T> GetNew(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var client = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content);
            }

            return null;
        }

        public async Task<IEnumerable<T>> GetMultipleAsync(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var client = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<T>>(content);
            }

            return null;
        }

        public async Task<bool> Update(string url, string id, T obj)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, url + id);

            if (obj == null)
                return false;

            request.Content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return true;

            return false;
        }
    }
    public interface IBaseRepositoryEx
    {
        Task<TRequest> Create<TRequest>(string url, TRequest model);
        Task<TResult> Read<TResult, TInput>(string url, TInput value) where TResult : class;
        Task<TRequest> Update<TRequest>(string url, string id, TRequest model);
        Task<TResult> Delete<TResult>(string url, string id, TResult model) where TResult : class;
    }
    public class BaseRepositoryEx : IBaseRepositoryEx
    {
        private readonly IHttpClientFactory _httpClientFactory = null;

        public BaseRepositoryEx(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<TRequest> Create<TRequest>(string url, TRequest model)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, url);
                var content = JsonConvert.SerializeObject(model);
                request.Content = new StringContent(content, Encoding.UTF8, "application/json");
                var client = _httpClientFactory.CreateClient();
                HttpResponseMessage response = await client.SendAsync(request);
            }
            catch (Exception ex) { }
            return model;
        }
        public async Task<TResult> Read<TResult, TInput>(string url, TInput value) where TResult : class
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var content = JsonConvert.SerializeObject(value);
            request.Content = new StringContent(content, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResult>(responseContent);
            }

            return null;
        }
        public async Task<TRequest> Update<TRequest>(string url, string id, TRequest model)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, url + id);

            request.Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return model;

            return model;
        }
        public async Task<TRequest> Delete<TRequest>(string url, string id, TRequest model) where TRequest : class
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, url);
            request.Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);

            return model;
        }
    }
    public interface IHierarchicalPayanarTypeColumnRepository : IBaseRepository<HierarchicalPayanarTypeColumn> { }
    public class HierarchicalPayanarTypeColumnRepository : BaseRepository<HierarchicalPayanarTypeColumn>, IHierarchicalPayanarTypeColumnRepository
    {
        public HierarchicalPayanarTypeColumnRepository(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }
    }
    public interface IHierarchicalPayanarTypeRepository : IBaseRepository<HierarchicalPayanarType> { }
    public class HierarchicalPayanarTypeRepository : BaseRepository<HierarchicalPayanarType>, IHierarchicalPayanarTypeRepository
    {
        public HierarchicalPayanarTypeRepository(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }
    }
    public interface IPayanarTableDesignRepository : IBaseRepository<PayanarTableDesign> { }
    public class PayanarTableDesignRepository : BaseRepository<PayanarTableDesign>, IPayanarTableDesignRepository
    {
        public PayanarTableDesignRepository(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }
    }
    public interface IPayanarTableDesignssRepository : IBaseRepository<IEnumerable<PayanarTableDesign>> { }
    public class PayanarTableDesignssRepository : BaseRepository<IEnumerable<PayanarTableDesign>>, IPayanarTableDesignssRepository
    {
        public PayanarTableDesignssRepository(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }
    }
}
