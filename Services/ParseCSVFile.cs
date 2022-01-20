using ASPProject4.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;

namespace ASPProject4.Services
{
    // class for parsing the CSVFile
    public class ParseCSVFile : ParseFiles
    {
        public ParseCSVFile() : base("ParseCSVFile") { }

        protected override IDictionary<string, List<string>> GetAssetNameAndInterestedFirmDict(IFormFile assetFile)
        {
            // data structure with assetName as the key and the list of firms as the interested firms.
            SortedDictionary<string, List<string>> assetNameInterestedFirms = new SortedDictionary<string, List<string>>();
            using (var sreader = new StreamReader(assetFile.OpenReadStream()))
            {
                string[] headers = sreader.ReadLine().Split(',');
                while (!sreader.EndOfStream)
                {
                    string[] rowContent = sreader.ReadLine().Split(',');

                    string assestId = rowContent.GetValue(0).ToString();
                    string assetName = rowContent.GetValue(1).ToString();
                    string interestedFirmId = rowContent.GetValue(2).ToString();

                    if (assetNameInterestedFirms.ContainsKey(assetName))
                    {
                        assetNameInterestedFirms[assetName].Add(interestedFirmId);
                    }
                    else
                    {
                        assetNameInterestedFirms[assetName] = new List<string>() { interestedFirmId };
                    }
                }
            }
            return assetNameInterestedFirms;
        }
        // method for reading the XLXS file
        protected override List<UserModel> ParseResults(IFormFile firmFile, IDictionary<string, List<string>> assetNameInterestedFirms, out SortedDictionary<string, string> firmNameId)
        {
            int rowIndex = 0;
            List<UserModel> resultRecord = new List<UserModel>();
            firmNameId = new SortedDictionary<string, string>();
// getting the stream from the file
            using (var sreader = new StreamReader(firmFile.OpenReadStream()))
            {
                while (!sreader.EndOfStream)
                {
                    // getting the headers from the file
                    if (rowIndex == 0)
                    {
                        List<string> assetNames = new List<string>(assetNameInterestedFirms.Keys);
                        resultRecord.Add(new UserModel
                        {
                            FirmName = "",
                            Companytable = assetNames,

                        });
                        rowIndex++;
                        string[] headers = sreader.ReadLine().Split(',');
                    }
                    else
                    {
                        //Storing name as keys and id as value
                        string[] rowContent = sreader.ReadLine().Split(',');
                        firmNameId.Add(rowContent.GetValue(1).ToString(), rowContent.GetValue(0).ToString());
                    }
                }
            }
            return resultRecord;
        }
    }
}