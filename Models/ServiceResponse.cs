
namespace portfolio.models
{
    public class ServiceResponse<T>
    {
        public T data {get;set;}
        public bool success {get;set;}
        public string message {get;set;} = string.Empty;

    }
}