using Newtonsoft.Json;

namespace StoreManagement.Data.Generics.General
{
    public class ExceptionDetails
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}