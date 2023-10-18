//using VetApp.Entities;

//namespace VetApp.Models
//{
//    public class SupplierModel
//    {
//        public SupplierModel() { }

//        public int CreateSupplier(SupplierObj supplierObj)
//        {
//            using (var supplier = new HttpSupplier())
//            {
//                JsonContent body = JsonContent.Create(supplierObj);
//                string url = "https://localhost:7032/api/Supplier/CreateSupplier";
//                HttpResponseMessage response = supplier.PostAsync(url, body).GetAwaiter().GetResult();

//                if (response.IsSuccessStatusCode)
//                    return response.Content.ReadFromJsonAsync<int>().Result;

//                return 0;
//            }
//        }

//        public List<SupplierObj> GetSuppliers()
//        {
//            using (var supplier = new HttpSupplier())
//            {
//                string url = "https://localhost:7032/api/Supplier/GetSuppliers";

//                HttpResponseMessage response = supplier.GetAsync(url).GetAwaiter().GetResult();

//                if (response.IsSuccessStatusCode)
//                    return response.Content.ReadFromJsonAsync<List<SupplierObj>>().Result;

//                return new List<SupplierObj>();
//            }
//        }


//        public int UpdateSupplier(SupplierObj supplierObj)
//        {
//            using (var supplier = new HttpSupplier())
//            {
//                JsonContent body = JsonContent.Create(supplierObj);
//                string url = "https://localhost:7032/api/Supplier/UpdateSupplier";
//                HttpResponseMessage response = supplier.PutAsync(url, body).GetAwaiter().GetResult();

//                if (response.IsSuccessStatusCode)
//                    return response.Content.ReadFromJsonAsync<int>().Result;

//                return 0;
//            }
//        }

//        public int DeleteSupplier(int idSupplier)
//        {
//            using (var supplier = new HttpSupplier())
//            {
//                string url = "https://localhost:7032/api/Supplier/DeleteSupplier?idSupplier=" + idSupplier;
//                HttpResponseMessage response = supplier.DeleteAsync(url).GetAwaiter().GetResult();

//                if (response.IsSuccessStatusCode)
//                    return response.Content.ReadFromJsonAsync<int>().Result;

//                return 0;
//            }
//        }
//    }
//}