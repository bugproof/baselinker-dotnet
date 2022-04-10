using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.ExternalStorages;

/// <summary>
/// The method allows you to retrieve a list of available external storages (shops, wholesalers) that can be referenced via API.
/// </summary>
public class GetExternalStoragesList : IRequest<GetExternalStoragesList.Response>
{
    public class Storage
    {
        /// <summary>
        /// Storage ID in format "[type:shop|warehouse]_[id:int]" (e.g. "shop_2445").
        /// </summary>
        [JsonPropertyName("storage_id")]
        public string StorageId { get; set; }

        /// <summary>
        /// Storage name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// An array of names of methods supported by the storage.
        /// </summary>
        [JsonPropertyName("methods")]
        public List<string> Methods { get; set; }
    }
        
    public class Response : ResponseBase
    {
        [JsonPropertyName("storages")]
        public List<Storage> Storages { get; set; }
    }
}