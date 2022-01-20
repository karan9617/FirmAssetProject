using ASPProject4.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace ASPProject4.Services.Interface
{
    public interface IParseFiles
    {
        string ParserName { get; }
        List<UserModel> ParseFile(IFormFile firmFile, IFormFile assetFile);
    }
}