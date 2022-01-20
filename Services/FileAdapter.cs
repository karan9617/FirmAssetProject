using ASPProject4.Services.Interface;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace ASPProject4.Services
{
    public class FileAdapter : IFileAdapter
    {
        private readonly IEnumerable<IParseFiles> _parseFiles;
        // constructor
        public FileAdapter(IEnumerable<IParseFiles> parseFiles)
        {
            _parseFiles = parseFiles;
        }

        public IParseFiles GetService(IFormFile firmFile)
        {
            IParseFiles service = null;
            if (firmFile.ContentType == "text/csv")
            {
                service = _parseFiles.FirstOrDefault(h => h.ParserName.Equals("ParseCSVFile"));
            }
            else
            {
                service = _parseFiles.FirstOrDefault(h => h.ParserName.Equals("ParseXLXSFile"));
            }
            return service;
        }
    }
}