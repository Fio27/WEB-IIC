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

        #region GetAll
        public List<ShipperViewModel> GetAll()
        {
            ServiceRepository repository = new ServiceRepository();

            List<ShipperViewModel> lista = new List<ShipperViewModel>();
            HttpResponseMessage responseMessage = repository.GetResponse("api/shipper/");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<ShipperViewModel>>(content);
            }

            return lista;
        }
        #endregion 

        #region GetByID
        public ShipperViewModel GetByID(int id) 
        {
        ShipperViewModel shipper = new ShipperViewModel();

            HttpResponseMessage responseMessage = repository.GetResponse("api/shipper/" + id);
            string content = responseMessage.Content.ReadAsStringAsync().Result;
            shipper = JsonConvert.DeserializeObject<ShipperViewModel>(content);
            return shipper;
        }
        #endregion

        #region Update
        public ShipperViewModel Edit(ShipperViewModel shipper)
        {
            HttpResponseMessage responseMessage = repository.PutResponse("api/shipper/", shipper);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            ShipperViewModel shipperAPI = JsonConvert.DeserializeObject<ShipperViewModel>(content);
            return shipperAPI;
        }
        #endregion

        #region Add
        public ShipperViewModel Add(ShipperViewModel shipper)
        {
            HttpResponseMessage responseMessage = repository.PostResponse("api/shipper/", shipper);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            ShipperViewModel shipperAPI = JsonConvert.DeserializeObject<ShipperViewModel>(content);
            return shipperAPI;
        }
        #endregion

        #region Delete
        public ShipperViewModel Delete(int id)
        {
            ShipperViewModel shipper = new ShipperViewModel();
            HttpResponseMessage responseMessage = repository.DeleteResponse("api/shipper/" + id);
            // string content = responseMessage.Content.ReadAsStringAsync().Result;
            // category = JsonConvert.DeserializeObject<CategoryViewModel>(content);
            return shipper;
        }

        #endregion
    }

}