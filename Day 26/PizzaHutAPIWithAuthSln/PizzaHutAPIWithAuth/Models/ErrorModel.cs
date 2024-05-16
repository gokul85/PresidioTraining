namespace PizzaHutAPIWithAuth.Models
{
    public class ErrorModel
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }

        public ErrorModel()
        {
            
        }
        public ErrorModel(int errcode,string errmsg)
        {
            ErrorCode = errcode;
            ErrorMessage = errmsg;
        }
    }
}
