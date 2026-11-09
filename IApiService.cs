public interface IApiService
{
    Task<HttpResponseMessage> LoginAsync(string email, string password);
    Task<HttpResponseMessage> RegisterAsync(object registerDto);
    Task<T?> GetAsync<T>(string endpoint);
    Task<HttpResponseMessage> PostAsync<T>(string endpoint, T data);
    Task<HttpResponseMessage> PutAsync<T>(string endpoint, T data);
    Task<HttpResponseMessage> DeleteAsync(string endpoint);
    Task<HttpResponseMessage> PostMultipartAsync(string endpoint, MultipartFormDataContent content);
}
