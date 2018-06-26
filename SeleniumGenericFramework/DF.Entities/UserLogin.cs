using Newtonsoft.Json;

namespace DF.Entities
{
    /// <summary>
    /// The user login entity.
    /// </summary>
    public class UserLogin
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        [JsonProperty(PropertyName = "userId")]
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
    }
}