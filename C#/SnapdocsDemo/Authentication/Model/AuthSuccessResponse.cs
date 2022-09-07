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
    /// AuthSuccessResponse
    /// </summary>
    [DataContract]
        public partial class AuthSuccessResponse :  IEquatable<AuthSuccessResponse>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthSuccessResponse" /> class.
        /// </summary>
        /// <param name="accessToken">The access token string as issued by the authorization server..</param>
        /// <param name="tokenType">The type of token this is, typically just the string “bearer”..</param>
        /// <param name="expiresIn">The duration of time the access token is granted for..</param>
        /// <param name="scope">The scope granted to the application..</param>
        /// <param name="createdAt">The Unix timestamp of when the token was issued by the authorization server..</param>
        public AuthSuccessResponse(string accessToken = default(string), string tokenType = default(string), int? expiresIn = default(int?), string scope = default(string), string createdAt = default(string))
        {
            this.AccessToken = accessToken;
            this.TokenType = tokenType;
            this.ExpiresIn = expiresIn;
            this.Scope = scope;
            this.CreatedAt = createdAt;
        }
        
        /// <summary>
        /// The access token string as issued by the authorization server.
        /// </summary>
        /// <value>The access token string as issued by the authorization server.</value>
        [DataMember(Name="access_token", EmitDefaultValue=false)]
        public string AccessToken { get; set; }

        /// <summary>
        /// The type of token this is, typically just the string “bearer”.
        /// </summary>
        /// <value>The type of token this is, typically just the string “bearer”.</value>
        [DataMember(Name="token_type", EmitDefaultValue=false)]
        public string TokenType { get; set; }

        /// <summary>
        /// The duration of time the access token is granted for.
        /// </summary>
        /// <value>The duration of time the access token is granted for.</value>
        [DataMember(Name="expires_in", EmitDefaultValue=false)]
        public int? ExpiresIn { get; set; }

        /// <summary>
        /// The scope granted to the application.
        /// </summary>
        /// <value>The scope granted to the application.</value>
        [DataMember(Name="scope", EmitDefaultValue=false)]
        public string Scope { get; set; }

        /// <summary>
        /// The Unix timestamp of when the token was issued by the authorization server.
        /// </summary>
        /// <value>The Unix timestamp of when the token was issued by the authorization server.</value>
        [DataMember(Name="created_at", EmitDefaultValue=false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AuthSuccessResponse {\n");
            sb.Append("  AccessToken: ").Append(AccessToken).Append("\n");
            sb.Append("  TokenType: ").Append(TokenType).Append("\n");
            sb.Append("  ExpiresIn: ").Append(ExpiresIn).Append("\n");
            sb.Append("  Scope: ").Append(Scope).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
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
            return this.Equals(input as AuthSuccessResponse);
        }

        /// <summary>
        /// Returns true if AuthSuccessResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of AuthSuccessResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AuthSuccessResponse input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.AccessToken == input.AccessToken ||
                    (this.AccessToken != null &&
                    this.AccessToken.Equals(input.AccessToken))
                ) && 
                (
                    this.TokenType == input.TokenType ||
                    (this.TokenType != null &&
                    this.TokenType.Equals(input.TokenType))
                ) && 
                (
                    this.ExpiresIn == input.ExpiresIn ||
                    (this.ExpiresIn != null &&
                    this.ExpiresIn.Equals(input.ExpiresIn))
                ) && 
                (
                    this.Scope == input.Scope ||
                    (this.Scope != null &&
                    this.Scope.Equals(input.Scope))
                ) && 
                (
                    this.CreatedAt == input.CreatedAt ||
                    (this.CreatedAt != null &&
                    this.CreatedAt.Equals(input.CreatedAt))
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
                if (this.AccessToken != null)
                    hashCode = hashCode * 59 + this.AccessToken.GetHashCode();
                if (this.TokenType != null)
                    hashCode = hashCode * 59 + this.TokenType.GetHashCode();
                if (this.ExpiresIn != null)
                    hashCode = hashCode * 59 + this.ExpiresIn.GetHashCode();
                if (this.Scope != null)
                    hashCode = hashCode * 59 + this.Scope.GetHashCode();
                if (this.CreatedAt != null)
                    hashCode = hashCode * 59 + this.CreatedAt.GetHashCode();
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
