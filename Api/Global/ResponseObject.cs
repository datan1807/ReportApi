namespace Api.Global
{
    public class ResponseObject
    {
        public string status { get; set; } = "success";
        public string message { get; set; } = string.Empty;
        public Object? data { get; set; }
    }
}
