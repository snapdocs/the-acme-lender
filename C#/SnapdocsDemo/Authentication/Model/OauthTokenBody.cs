using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace Authentication.Model
{
    /// <summary>
    /// OauthTokenBody
    /// </summary>
    [DataContract]
        public partial class OauthTokenBody :  IEquatable<OauthTokenBody>, IValidatableObject
    {
        /// <summary>
        /// Indicates the type of grant being presented in exchange for an access token.
        /// </summary>
        /// <value>Indicates the type of grant being presented in exchange for an access token.</value>
        [JsonConverter(typeof(StringEnumConverter))]
                public enum GrantTypeEnum
        {
            /// <summary>
            /// Enum Clientcredentials for value: client_credentials
            /// </summary>
            [EnumMember(Value = "client_credentials")]
            Clientcredentials = 1        }
        /// <summary>
        /// Indicates the type of grant being presented in exchange for an access token.
        /// </summary>
        /// <value>Indicates the type of grant being presented in exchange for an access token.</value>
        [DataMember(Name="grant_type", EmitDefaultValue=false)]
        public GrantTypeEnum GrantType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="OauthTokenBody" /> class.
        /// </summary>
        /// <param name="clientId">The unique Client ID provided by Snapdocs. (required).</param>
        /// <param name="clientSecret">The unique Client Secret provided by Snapdocs. (required).</param>
        /// <param name="grantType">Indicates the type of grant being presented in exchange for an access token. (required).</param>
        /// <param name="scope">The scope of the access request expressed as a list of space-delimited, case-sensitive strings. (required).</param>
        public OauthTokenBody(string clientId = default(string), string clientSecret = default(string), GrantTypeEnum grantType = default(GrantTypeEnum), string scope = default(string))
        {
            // to ensure "clientId" is required (not null)
            if (clientId == null)
            {
                throw new InvalidDataException("clientId is a required property for OauthTokenBody and cannot be null");
            }
            else
            {
                this.ClientId = clientId;
            }
            // to ensure "clientSecret" is required (not null)
            if (clientSecret == null)
            {
                throw new InvalidDataException("clientSecret is a required property for OauthTokenBody and cannot be null");
            }
            else
            {
                this.ClientSecret = clientSecret;
            }
            // to ensure "grantType" is required (not null)
            if (grantType == null)
            {
                throw new InvalidDataException("grantType is a required property for OauthTokenBody and cannot be null");
            }
            else
            {
                this.GrantType = grantType;
            }
            // to ensure "scope" is required (not null)
            if (scope == null)
            {
                throw new InvalidDataException("scope is a required property for OauthTokenBody and cannot be null");
            }
            else
            {
                this.Scope = scope;
            }
        }
        
        /// <summary>
        /// The unique Client ID provided by Snapdocs.
        /// </summary>
        /// <value>The unique Client ID provided by Snapdocs.</value>
        [DataMember(Name="client_id", EmitDefaultValue=false)]
        public string ClientId { get; set; }

        /// <summary>
        /// The unique Client Secret provided by Snapdocs.
        /// </summary>
        /// <value>The unique Client Secret provided by Snapdocs.</value>
        [DataMember(Name="client_secret", EmitDefaultValue=false)]
        public string ClientSecret { get; set; }


        /// <summary>
        /// The scope of the access request expressed as a list of space-delimited, case-sensitive strings.
        /// </summary>
        /// <value>The scope of the access request expressed as a list of space-delimited, case-sensitive strings.</value>
        [DataMember(Name="scope", EmitDefaultValue=false)]
        public string Scope { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OauthTokenBody {\n");
            sb.Append("  ClientId: ").Append(ClientId).Append("\n");
            sb.Append("  ClientSecret: ").Append(ClientSecret).Append("\n");
            sb.Append("  GrantType: ").Append(GrantType).Append("\n");
            sb.Append("  Scope: ").Append(Scope).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as OauthTokenBody);
        }

        /// <summary>
        /// Returns true if OauthTokenBody instances are equal
        /// </summary>
        /// <param name="input">Instance of OauthTokenBody to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OauthTokenBody input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.ClientId == input.ClientId ||
                    (this.ClientId != null &&
                    this.ClientId.Equals(input.ClientId))
                ) && 
                (
                    this.ClientSecret == input.ClientSecret ||
                    (this.ClientSecret != null &&
                    this.ClientSecret.Equals(input.ClientSecret))
                ) && 
                (
                    this.GrantType == input.GrantType ||
                    (this.GrantType != null &&
                    this.GrantType.Equals(input.GrantType))
                ) && 
                (
                    this.Scope == input.Scope ||
                    (this.Scope != null &&
                    this.Scope.Equals(input.Scope))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.ClientId != null)
                    hashCode = hashCode * 59 + this.ClientId.GetHashCode();
                if (this.ClientSecret != null)
                    hashCode = hashCode * 59 + this.ClientSecret.GetHashCode();
                if (this.GrantType != null)
                    hashCode = hashCode * 59 + this.GrantType.GetHashCode();
                if (this.Scope != null)
                    hashCode = hashCode * 59 + this.Scope.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
