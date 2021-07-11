using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TuristickaAgencija.Model;
using Xamarin.Forms;

namespace TuristickaAgencija.MobileApp
{
    public class APIService
    {

        public static string Username { get; set; }
        public static string Password { get; set; }
        private readonly string _route = null;

#if DEBUG
        string apiUrl = "http://localhost:43791/api";
#endif
#if RELEASE
         string apiUrl = "https://mywebsite.com/api/";
#endif

        public APIService(string route)
        {
            _route = route;
        }

        public async Task<T> Get<T>(object search)
        {
            var url = $"{apiUrl}/{_route}";
            if (search != null)
            {
                url += "?";
                url += await search.ToQueryString();
            }

            var result = await url.GetJsonAsync<T>();

            return result;
            /*
            try
            {

                if (search != null)
                {
                    url += "?";
                    url += await search.ToQueryString();
                }

                var result = await url.GetJsonAsync<T>();

                return result;
            }

            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
                {

                    await Application.Current.MainPage.DisplayAlert("Error", "Niste autentificirani", "OK");
                }
                throw;
            }*/
        }

        public async Task<T> Login<T>(string username, string password)
        {
            var url = $"{apiUrl}/{_route}/Authenticiraj/{username},{password}";

            return await url.WithBasicAuth(username,password).GetJsonAsync<T>();

        }
        public async Task<T> GetById<T>(int id)
        {
            var url = $"{apiUrl}/{_route}/{id}";


            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        }

        public async Task<T> Insert<T>(object request)
        {
            var url = $"{apiUrl}/{_route}";

            try
            {
                return await url.PostJsonAsync(request).ReceiveJson<T>();
                //return await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }
                await Application.Current.MainPage.DisplayAlert("Greška", stringBuilder.ToString(), "OK");
                //MessageBox.Show(stringBuilder.ToString(), "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default(T);
            }
        }
        public async Task<T> Update<T>(int id, object request)
        {
            try
            {
                var url = $"{apiUrl}/{_route}/{id}";

                return await url.WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }
                await Application.Current.MainPage.DisplayAlert("Greška", stringBuilder.ToString(), "OK");
                //MessageBox.Show(stringBuilder.ToString(), "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default(T);
            }
        }
        public async Task<T> Delete<T>(int id)
        {
            try
            {
                var url = $"{apiUrl}/{_route}/{id}";

                return await url.DeleteAsync().ReceiveJson<T>();
            }
            catch (System.Exception ex)
            {
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Greška", ex.Message, "OK");
                return default;
            }
        }

        public async Task<T> GetRecommendedPutovanja<T>(int id)
        {
            var url = $"{apiUrl}/{_route}/GetRecommendedPutovanja/{id}";

            return await url.GetJsonAsync<T>();
        }


    }
}
