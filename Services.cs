using Newtonsoft.Json;
using System.Text;

public class ApiService : IApiService
{
    private readonly HttpClient _httpClient;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ApiService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
    {
        _httpClient = httpClient;
        _httpContextAccessor = httpContextAccessor;
    }

    // Helper to attach JWT or Session token if your API uses it
    private void AddAuthHeader()
    {
        var token = _httpContextAccessor.HttpContext?.Session.GetString("JWToken");
        if (!string.IsNullOrEmpty(token))
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }
    }

    public async Task<HttpResponseMessage> LoginAsync(string email, string password)
    {
        var content = new StringContent(JsonConvert.SerializeObject(new { email, password }), Encoding.UTF8, "application/json");
        return await _httpClient.PostAsync("auth/login", content);
    }

    public async Task<HttpResponseMessage> RegisterAsync(object registerDto)
    {
        var content = new StringContent(JsonConvert.SerializeObject(registerDto), Encoding.UTF8, "application/json");
        return await _httpClient.PostAsync("auth/register", content);
    }

    public async Task<T?> GetAsync<T>(string endpoint)
    {
        AddAuthHeader();
        var response = await _httpClient.GetAsync(endpoint);
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);
        }
        return default;
    }

    public async Task<HttpResponseMessage> PostAsync<T>(string endpoint, T data)
    {
        AddAuthHeader();
        var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
        return await _httpClient.PostAsync(endpoint, content);
    }

    public async Task<HttpResponseMessage> PutAsync<T>(string endpoint, T data)
    {
        AddAuthHeader();
        var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
        return await _httpClient.PutAsync(endpoint, content);
    }

    public async Task<HttpResponseMessage> DeleteAsync(string endpoint)
    {
        AddAuthHeader();
        return await _httpClient.DeleteAsync(endpoint);
    }

    public async Task<HttpResponseMessage> PostMultipartAsync(string endpoint, MultipartFormDataContent content)
    {
        AddAuthHeader();
        return await _httpClient.PostAsync(endpoint, content);
    }
}
