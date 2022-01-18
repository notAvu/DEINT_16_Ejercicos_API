using DEINT_16_Ejercios_API_Entidades;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DEINT_16_Ejercicios_API_DAL
{
    public class GestoraPersonasApi
    {
        string ApiBaseUrl { get; set; }
        public GestoraPersonasApi() 
        {
            ApiBaseUrl = "https://elnombrequetuquieras.azurewebsites.net/api/";
        }
        public async Task<List<clsPersona>> getListadoPersonasDAL()
        {
            List<clsPersona> personas;
            Uri apiUri = new Uri($"{ApiBaseUrl}personas");
            HttpClient httpClient= new HttpClient();
            HttpResponseMessage response;
            string jsonResponse;
            try {
                response = await httpClient.GetAsync(apiUri);
                if (response.IsSuccessStatusCode) 
                { 
                    jsonResponse = await httpClient.GetStringAsync(apiUri);
                    httpClient.Dispose();
                    personas=JsonConvert.DeserializeObject<List<clsPersona>>(jsonResponse);
                }
            }
            catch (Exception e) 
            {
                throw e;
            }
            return null;
        }
    }
}
