using ASPProject4.Models;
using ExcelDataReader;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace ASPProject4.Services
{
    // class for parsing the XLXFile
    public class ParseXLXSFile : ParseFiles
    {
        public ParseXLXSFile() : base("ParseXLXSFile") { }

        protected override IDictionary<string, List<string>> GetAssetNameAndInterestedFirmDict(IFormFile assetFile)
        {
            // data structure with assetName as the key and the list of firms as the interested firms.
            SortedDictionary<string, List<string>> assetNameInterestedFirms = new SortedDictionary<string, List<string>>();
            int rowIndex = 0;
            using (var stream = assetFile.OpenReadStream())
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        // skipping the first header row
                        if (rowIndex == 0)
                            rowIndex++;
                        else
                        {
                            string assestId = reader.GetValue(0).ToString();
                            string assetName = reader.GetValue(1).ToString();
                            string interestedFirmId = reader.GetValue(2).ToString();

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
            using (var stream = firmFile.OpenReadStream())
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        if (rowIndex == 0)
                        {
                            List<string> assetNames = new List<string>(assetNameInterestedFirms.Keys);
                            resultRecord.Add(new UserModel
                            {
                                FirmName = "",
                                Companytable = assetNames,
                            });
                            rowIndex++;
                        }
                        else
                        {
                            //Storing name as keys and id as value
                            firmNameId.Add(reader.GetValue(1).ToString(), reader.GetValue(0).ToString());
                        }
                    }
                }
            }
            return resultRecord;
        }
    }
}