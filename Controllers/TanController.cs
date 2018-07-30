using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

namespace TanClient.Controllers
{
    public class TanController : Controller
    {
        TanAPI _api = new TanAPI();

        public string UrlAPiArret = "ewp/arrets.json";
        public string UrlAPiDetails = "ewp/tempsattente.json";

        public async Task<ActionResult> Index()
        {
            List<ArretDTO> dto = new List<ArretDTO>();

            HttpClient client = _api.InitializeClient();

            HttpResponseMessage res = await client.GetAsync(UrlAPiArret);

            //Checking the response is successful or not which is sent using HttpClient    
            if (res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api     
                var result = res.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api and storing into the Employee list    
                dto = JsonConvert.DeserializeObject<List<ArretDTO>>(result);

            }

            //returning the employee list to view    
            return View(dto);
        }

        // GET: Tan/Detail/1
        public async Task<ActionResult> Details(int id)
        {
            if (id == null)
            {
                return RedirectToAction("index");
            }
            List<TempsAttenteDTO> dto = new List<TempsAttenteDTO>();

            HttpClient client = _api.InitializeClient();

            HttpResponseMessage res = await client.GetAsync($"{UrlAPiDetails}/{id}");
            


            //Checking the response is successful or not which is sent using HttpClient    
            if (res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api     
                var result = res.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api and storing into the Employee list    
                dto = JsonConvert.DeserializeObject<List<TempsAttenteDTO>>(result);

            }
            //returning the employee list to view    
            return View(dto);
        }



    }
}
