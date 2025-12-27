using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AgOpenGPS.Core.AgShare
{
    /// <summary>
    /// HTTP client for communicating with the AgShare API using API key authentication.
    /// Supports field upload, download, status checks, and querying both public and own fields.
    /// </summary>
    public class AgShareClient
    {
        private readonly HttpClient _client;

        // Constructs client with base URL and API key
        public AgShareClient(string serverUrl, string apiKey)
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.Timeout = TimeSpan.FromSeconds(5);

            SetApiKey(apiKey);
            SetServerUrl(serverUrl);
        }

        // Updates the API key
        public void SetApiKey(string key)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("ApiKey", key);
        }

        // Updates the server URL
        public void SetServerUrl(string url)
        {
            _client.BaseAddress = new Uri(url);
        }

        // Checks if the API key and connection are valid
        public static async Task<(bool ok, string message)> CheckApiAsync(string baseUrl, string apiKey)
        {
            try
            {
                using (var tempClient = new HttpClient())
                {
                    tempClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    tempClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("ApiKey", apiKey);
                    tempClient.BaseAddress = new Uri(baseUrl);

                    var response = await tempClient.GetAsync("/api/fields");
                    string responseBody = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                        return (true, "Connection OK");
                    else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                        return (false, "Invalid API key");
                    else
                        return (false, $"Status {response.StatusCode}: {responseBody}");
                }
            }
            catch (Exception ex)
            {
                return (false, $"Error: {ex.Message}");
            }
        }

        // Uploads a field by ID with JSON payload
        public async Task<(bool ok, string message)> UploadFieldAsync(Guid fieldId, object fieldPayload)
        {
            try
            {
                var json = JsonConvert.SerializeObject(fieldPayload, Formatting.Indented);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _client.PutAsync($"/api/fields/{fieldId}", content);

                if (response.IsSuccessStatusCode)
                    return (true, "Upload successful");
                else
                    return (false, $"Upload failed: {response.StatusCode}");
            }
            catch (Exception ex)
            {
                return (false, $"Exception: {ex.Message}");
            }
        }

        // Retrieves a list of fields owned by the current user
        public async Task<List<AgShareGetOwnFieldDto>> GetOwnFieldsAsync()
        {
            var response = await _client.GetAsync("/api/fields");
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<AgShareGetOwnFieldDto>>(json);
        }

        // Downloads a specific field as raw JSON string
        public async Task<string> DownloadFieldAsync(Guid fieldId)
        {
            var response = await _client.GetAsync($"/api/fields/{fieldId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        // Queries public fields within a given radius around a lat/lon
        // !!! This is not implemented yet !!!
        public async Task<string> GetPublicFieldsAsync(double lat, double lon, double radius = 50)
        {
            var response = await _client.GetAsync($"/api/fields/public?lat={lat}&lon={lon}&radius={radius}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
