using ASPProject4.Models;
using ASPProject4.Services.Interface;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace ASPProject4.Services
{
    public abstract class ParseFiles : IParseFiles
    {
        // storing the file name
        public string ParserName { get; protected set; }

        public ParseFiles(string parserName)
        {
            ParserName = parserName;
        }

        // method definition of parseFile
        public List<UserModel> ParseFile(IFormFile firmFile, IFormFile assetFile)
        {
            // data structure for getting the assetNames as key and the list of firms interested in that asset
            IDictionary<string, List<string>> assetNameInterestedFirms = GetAssetNameAndInterestedFirmDict(assetFile);

            // reading the file for the firm names and their ID.
            List<UserModel> resultRows = ParseResults(firmFile, assetNameInterestedFirms, out SortedDictionary<string, string> firmNameId);
            // getting the required rressult and storing in resultRows 
            resultRows.AddRange(AddRemainingRows(firmNameId, assetNameInterestedFirms));
            return resultRows;
        }

        protected abstract IDictionary<string, List<string>> GetAssetNameAndInterestedFirmDict(IFormFile assetFile);
        protected abstract List<UserModel> ParseResults(IFormFile firmFile, IDictionary<string, List<string>> assetNameInterestedFirms, out SortedDictionary<string, string> firmNameId);


// method for detecting the assets the particular firm is having
        protected List<UserModel> AddRemainingRows(SortedDictionary<string, string> firmNameId, IDictionary<string, List<string>> assetNameInterestedFirms)
        {
            // storing the firm name and the interested list of assets in this list
            List<UserModel> resultRecord = new List<UserModel>();
            foreach (KeyValuePair<string, string> firmInfo in firmNameId)
            {
                List<string> assestClassNamesForFirm = new List<string>();
                foreach (KeyValuePair<string, List<string>> entry in assetNameInterestedFirms)
                {
                    // checking if the firm name exists in the assets firms list
                    if (entry.Value.Contains(firmInfo.Value))
                    {
                        assestClassNamesForFirm.Add("X");
                    }
                    else
                    {
                        assestClassNamesForFirm.Add("");
                    }
                }
                // adding the record in the resultRecord
                resultRecord.Add(new UserModel
                {
                    FirmName = firmInfo.Key,
                    Companytable = assestClassNamesForFirm,
                });
            }
            return resultRecord;
        }
    }
}