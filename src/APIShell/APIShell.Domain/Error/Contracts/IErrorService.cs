using RestSharp;

namespace APIShell.Domain.Error.Contracts
{
    public interface IErrorService
    {
        void Errors(string key, string message, string group);
        void ErrorsRest(string key, string message, string group, IRestResponse result = null);
    }
}
