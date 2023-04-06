using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using Tangy_Common;
using Tangy_Models;
using TangyWeb_Client.Service.IService;

namespace TangyWeb_Client.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorageService;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public AuthenticationService(HttpClient httpClient, ILocalStorageService localStorageService, AuthenticationStateProvider authenticationStateProvider)
        {
            _httpClient = httpClient;
            _localStorageService = localStorageService;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<SignInResponseDTO> Login(SignInRequestDTO signInRequest)
        {
            var content = JsonConvert.SerializeObject(signInRequest);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/account/signin", bodyContent);
            var contentTemp = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<SignInResponseDTO>(contentTemp);

            if(response.IsSuccessStatusCode)
            {
                await _localStorageService.SetItemAsync(SD.Local_Token, result.Token);
                await _localStorageService.SetItemAsync(SD.Local_UserDetails, result.UserDTO);
                ((AuthStateProvider)_authenticationStateProvider).NotifyUserLoggedIn(result.Token);
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Token);
                return new SignInResponseDTO()
                {
                    IsAuthSuccessful = true
                };
            }
            else
            {
                return result;
            }
        }

        public async Task Logout()
        {
            await _localStorageService.RemoveItemAsync(SD.Local_Token);
            await _localStorageService.RemoveItemAsync(SD.Local_UserDetails);

            ((AuthStateProvider)_authenticationStateProvider).NotifyUserLoggedOut();

            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<SignUpResponseDTO> RegisterUser(SignUpRequestDTO signUpRequest)
        {
            var content = JsonConvert.SerializeObject(signUpRequest);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/account/signup", bodyContent);
            var contentTemp = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<SignUpResponseDTO>(contentTemp);

            if (response.IsSuccessStatusCode)
            {
                return new SignUpResponseDTO()
                {
                    IsRegisterationSuccessful = true
                };
            }
            else
            {
                return new SignUpResponseDTO()
                {
                    IsRegisterationSuccessful = false,
                    Errors = result.Errors
                };
            }
        }
    }
}
