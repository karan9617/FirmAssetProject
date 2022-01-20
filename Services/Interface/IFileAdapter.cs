using Microsoft.AspNetCore.Http;

namespace ASPProject4.Services.Interface
{
    public interface IFileAdapter
    {
        IParseFiles GetService(IFormFile firmFile);
    }
}