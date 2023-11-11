using FirstMVCPractise.Models;
using FirstMVCPractise.Static_Details;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FirstMVCPractise.Respository
{
    public class UserRespository
    {
        private HttpClient client;

        public UserRespository()
        {
            client = new HttpClient();
        }
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var url = SD.baseUrl + "api/User/getusers";
           
            HttpResponseMessage response = client.GetAsync(url).Result;

            if(response.StatusCode==HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<User>>(jsonString);
            }

            else
            {
                return null;
            }
        }

        public async Task<User> GetById(int id)
        {
            var url = SD.baseUrl + "api/User/getuserbyid/"+id;

            HttpResponseMessage response = client.GetAsync(url).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<User>(jsonString);
            }

            else
            {
                return null;
            }
        }

        public bool Create(User user)
        {
            string data = JsonConvert.SerializeObject(user);
            var url = SD.baseUrl + "api/User/addUser";
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(url,content).Result;

            if (response.StatusCode == HttpStatusCode.Created)
            {
                return true;
            }
            else
                return false;
        }

        public bool Update(User user, int id)
        {
            string data = JsonConvert.SerializeObject(user);
            var url = SD.baseUrl + "/api/User/update/" +id;
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PutAsync(url, content).Result;

            if(response.StatusCode==HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            var url = SD.baseUrl + "/api/User/delete/" + id;
            HttpResponseMessage response = client.DeleteAsync(url).Result;

            if(response.StatusCode==HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}