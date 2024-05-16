namespace RequestTrackerAPI.Models
{
    public class ErrorModel
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }

        public ErrorModel()
        {
            
        }
        public ErrorModel(int errorcode,string errormessage) {
            ErrorCode = errorcode;
            ErrorMessage = errormessage;
        }
    }
}
