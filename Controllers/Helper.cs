using System;
using System.Collections.Generic;
using System.Net.Http;  
using System.Net.Http.Headers;

namespace TanClient.Controllers
{

    public class TanAPI
    {
        private string _apiBaseURI = "http://open.tan.fr/";
        public HttpClient InitializeClient()
        {
            var client = new HttpClient();
            //Passing service base url    
            client.BaseAddress = new Uri(_apiBaseURI);

            client.DefaultRequestHeaders.Clear();
            //Define request data format    
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }
    }

    public class ArretDTO
    {
        public long Id { get; set; }
        public string CodeLieu { get; set; }
        public string Libelle { get; set; }
        public string Distance { get; set; }

        public List<LigneDTO> Ligne = new List<LigneDTO>();
    }

    public class LigneDTO
    {
        public long Id { get; set; }

        public string NumLigne { get; set; }
         
        public string TypeLigne { get; set; }

    }

    public class TempsAttenteDTO
    {

        public int Sens { get; set; }

        public string Terminus { get; set; }

        public Boolean InfoTrafic { get; set; }

        public String Temps { get; set; }

        public LigneDTO Ligne = new LigneDTO();

        public string CodeArret;
    }


}