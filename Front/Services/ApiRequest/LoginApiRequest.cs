using Front.Dto;
using Front.ModelView;
using Microsoft.AspNetCore.Identity;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace Front.Services.ApiRequest;

public class LoginApiRequest
{
    public async Task<string> Login(LoginViewModel vm)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7121/api/login");
        string jsonString = JsonSerializer.Serialize(new
        {
            email = vm.Email,
            password = vm.Password
        }   );

        var content = new StringContent(jsonString, null, "application/json");
        request.Content = content;
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadAsStringAsync();
        TokenDto tokenDto = JsonSerializer.Deserialize<TokenDto>(responseData);
        
        return tokenDto.token;
    }

}
