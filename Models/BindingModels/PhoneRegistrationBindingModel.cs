using Newtonsoft.Json;

namespace HowAreYou.Models.BindingModels
{
    public class PhoneRegistrationBindingModel
    {
        [JsonProperty("number")]
        public string Number { get; set; }
    }
}