using System.Text.Json.Serialization;
namespace dotnet_rpg.Models{
    /* to display the string that belong to the number not the number itself*/
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgClass{
        Knight,
        Mage,
        Cleric
    }
}