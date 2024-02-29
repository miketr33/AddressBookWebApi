using System.Text.Json.Serialization;

namespace AddressBookWebApi.Models;

public class AddressBookItem
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }
    
    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }
    
    [JsonPropertyName("last_name")]
    public string? LastName { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
}