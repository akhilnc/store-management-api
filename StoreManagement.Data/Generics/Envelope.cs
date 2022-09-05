namespace StoreManagement.Data.Generics
{
    public class Envelope
    {
        public Envelope(bool success, string message = null)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public class Envelope<TData> : Envelope
    {
        public Envelope(bool success, TData data, string message = null) : base(success, message)
        {
            Data = data;
        }

        public TData Data { get; set; }
    }
}