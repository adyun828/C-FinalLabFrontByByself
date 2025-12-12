using Frontend.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Frontend.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private string? _token;

   public string BaseUrl { get; set; } = "http://localhost:5000/api";

  public ApiService()
        {
      _httpClient = new HttpClient();
            _httpClient.Timeout = TimeSpan.FromSeconds(30);
   }

  public void SetToken(string token)
        {
     _token = token;
   }

        public async Task<RegisterResponse> RegisterAsync(string username, string password)
        {
            try
            {
                var request = new RegisterRequest
                {
                    Username = username,
                    Password = password
                };

                var json = JsonConvert.SerializeObject(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"{BaseUrl}/Auth/register", content);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var registerResponse = JsonConvert.DeserializeObject<RegisterResponse>(responseContent);
                    return registerResponse ?? new RegisterResponse { Success = false, Message = "ÏìÓ¦½âÎöÊ§°Ü" };
                }
                else
                {
                    return new RegisterResponse { Success = false, Message = $"×¢²áÊ§°Ü: {response.StatusCode}" };
                }
            }
            catch (Exception ex)
            {
                return new RegisterResponse { Success = false, Message = $"ÍøÂç´íÎó: {ex.Message}" };
            }
        }

        public async Task<LoginResponse> LoginAsync(string username, string password)
        {
            try
            {
                var request = new LoginRequest
                {
                    Username = username,
                    Password = password
                };

                var json = JsonConvert.SerializeObject(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"{BaseUrl}/Auth/login", content);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(responseContent);
                    if (loginResponse != null && loginResponse.Success && loginResponse.Token != null)
                    {
                        SetToken(loginResponse.Token);
                    }
                    return loginResponse ?? new LoginResponse { Success = false, Message = "ÏìÓ¦½âÎöÊ§°Ü" };
  }
      else
  {
          return new LoginResponse { Success = false, Message = $"µÇÂ¼Ê§°Ü: {response.StatusCode}" };
        }
  }
     catch (Exception ex)
       {
      return new LoginResponse { Success = false, Message = $"ÍøÂç´íÎó: {ex.Message}" };
      }
}

        public async Task<List<ImageInfo>> GetImagesAsync(int count = 3)
  {
      try
 {
    if (string.IsNullOrEmpty(_token))
       {
       throw new Exception("Î´µÇÂ¼");
       }

      _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

    var response = await _httpClient.GetAsync($"{BaseUrl}/Images?count={count}");
          var responseContent = await response.Content.ReadAsStringAsync();

      if (response.IsSuccessStatusCode)
         {
     var images = JsonConvert.DeserializeObject<List<ImageInfo>>(responseContent);
     return images ?? new List<ImageInfo>();
      }
       else
     {
     throw new Exception($"»ñÈ¡Í¼ÏñÊ§°Ü: {response.StatusCode}");
       }
      }
       catch (Exception ex)
{
      throw new Exception($"»ñÈ¡Í¼Ïñ´íÎó: {ex.Message}");
    }
  }

        public async Task<bool> SaveSelectionAsync(int imageId, string selectedOption)
{
     try
      {
  if (string.IsNullOrEmpty(_token))
     {
   throw new Exception("Î´µÇÂ¼");
      }

      _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

   var request = new SelectionRequest
    {
    ImageId = imageId,
   SelectedOption = selectedOption
       };

  var json = JsonConvert.SerializeObject(request);
         var content = new StringContent(json, Encoding.UTF8, "application/json");

    var response = await _httpClient.PostAsync($"{BaseUrl}/Selections", content);
    
       return response.IsSuccessStatusCode;
    }
    catch (Exception ex)
       {
        throw new Exception($"±£´æÑ¡Ôñ´íÎó: {ex.Message}");
 }
        }
    }
}
