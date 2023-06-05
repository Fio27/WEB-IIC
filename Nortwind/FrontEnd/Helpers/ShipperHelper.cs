using FrontEnd.Models;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;

namespace FrontEnd.Helpers
{
    public class ShipperHelper
    {
        ServiceRepository repository;

        public ShipperHelper()

            {
                repository = new ServiceRepository();
            }

        public List<ShipperViewModel> GetAll()
        {
            ServiceRepository repository = new ServiceRepository();

            List<ShipperViewModel> lista = new List<ShipperViewModel>();
                HttpResponseMessage responseMessage = repository.GetResponse("api/shipper/");
                if(responseMessage != null)
                {
                    var content = responseMessage.Content.ReadAsStringAsync().Result;
                    lista = JsonConvert.DeserializeObject<List<ShipperViewModel>>(content);
                }

                return lista;
        }
    }
}
