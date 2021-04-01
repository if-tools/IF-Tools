using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using IFTools.Data.Types;
using Newtonsoft.Json;
using Group = IFTools.Data.Types.Group;

namespace IFTools.Data
{
    public class InfiniteFlightApi
    {
        private static HttpClient _http;
        private static string _apiKey;

        private const string BaseUrl = "https://api.infiniteflight.com/public/v2/";

        public static void Init()
        {
            _apiKey = Environment.GetEnvironmentVariable("IF_LIVE_KEY");
            _http = new HttpClient();
        }
        
        public readonly List<Group> Groups = new()
        {
            new Group("DF0F6341-5F6A-40EF-8B73-087A0EC255B5", "IFATC"),
            new Group("8C93A113-0C6C-491F-926D-1361E43A5833", "Moderators"),
            new Group("D07AFAD8-79DF-4363-B1C7-A5A1DDE6E3C8", "Staff")
        };

        public async Task<string> GetRawEndpoint(string endpoint, string parameters)
        {
            return await _http.GetStringAsync(
                ApiHelper.BuildUrl(BaseUrl, endpoint, parameters));
        }

        public async Task<List<SessionInfo>> GetSessionsAsync()
        {
            var json = await GetRawEndpoint("sessions", $"apikey={_apiKey}");
            var data = JsonConvert.DeserializeObject<ApiResponse<List<SessionInfo>>>(json);
            
            if(data == null) throw new Exception($"Invalid API Response. Data is null.");
            if(data.ErrorCode != ResponseCode.Ok)
            {
                throw new Exception($"Invalid API Response Code. Expected Ok, received {data.ErrorCode}");
            }

            return data.Result;
        }

        public async Task<List<FlightEntry>> GetFlightsAsync(Guid sessionId)
        {
            var json = await GetRawEndpoint($"/flights/{sessionId}", $"apikey={_apiKey}");
            var data = JsonConvert.DeserializeObject<ApiResponse<List<FlightEntry>>>(json);
            
            if(data == null) throw new Exception($"Invalid API Response. Data is null.");
            if(data.ErrorCode != ResponseCode.Ok)
            {
                throw new Exception($"Invalid API Response Code. Expected Ok, received {data.ErrorCode}");
            }

            return data.Result;
        }

        public async Task<List<AtcEntry>> GetAtcFacilitiesAsync(Guid sessionId)
        {
            var json = await GetRawEndpoint($"/atc/{sessionId}", $"apikey={_apiKey}");
            var data = JsonConvert.DeserializeObject<ApiResponse<List<AtcEntry>>>(json);
            
            if(data == null) throw new Exception($"Invalid API Response. Data is null.");
            if(data.ErrorCode != ResponseCode.Ok)
            {
                throw new Exception($"Invalid API Response Code. Expected Ok, received {data.ErrorCode}");
            }

            return data.Result;
        }

        public async Task<List<FlightPlanEntry>> GetFlightPlansAsync(Guid sessionId)
        {
            var json = await GetRawEndpoint($"/flightplans/{sessionId}", $"apikey={_apiKey}");
            var data = JsonConvert.DeserializeObject<ApiResponse<List<FlightPlanEntry>>>(json);
            
            if(data == null) throw new Exception($"Invalid API Response. Data is null.");
            if(data.ErrorCode != ResponseCode.Ok)
            {
                throw new Exception($"Invalid API Response Code. Expected Ok, received {data.ErrorCode}");
            }

            return data.Result;
        }
        
        public async Task<UserGradeInfo> GetUserGradeAsync(Guid userId)
        {
            var json = await GetRawEndpoint($"/user/grade/{userId}", $"apikey={_apiKey}");
            var data = JsonConvert.DeserializeObject<ApiResponse<UserGradeInfo>>(json);
            
            if(data == null) throw new Exception($"Invalid API Response. Data is null.");
            if(data.ErrorCode != ResponseCode.Ok)
            {
                throw new Exception($"Invalid API Response Code. Expected Ok, received {data.ErrorCode}");
            }

            return data.Result;
        }

        public async Task<List<UserStats>> GetUserStatsAsync(Guid[] userIds = null, string[] hashes = null, string[] ifcNames = null)
        {
            if (userIds == null && hashes == null && ifcNames == null)
            {
                throw new ArgumentNullException();
            }

            var contentObj = new UserStatsRequest();
            if (userIds != null) contentObj.UserIds = userIds;
            if (hashes != null) contentObj.Hashes = hashes;
            if (ifcNames != null) contentObj.IfcNames = ifcNames;

            var contentJson = JsonConvert.SerializeObject(contentObj);
            var content = new StringContent(contentJson, Encoding.UTF8, "application/json");

            var responseJson = await (await _http.PostAsync(BaseUrl + $"/user/stats?apikey={_apiKey}", content)).Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<ApiResponse<List<UserStats>>>(responseJson);

            if(responseData == null) throw new Exception($"Invalid API Response. Data is null.");
            if(responseData.ErrorCode != ResponseCode.Ok)
            {
                throw new Exception($"Invalid API Response Code. Expected Ok, received {responseData.ErrorCode}");
            }

            return responseData.Result;
        }
    }
}