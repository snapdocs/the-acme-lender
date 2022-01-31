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


namespace ClosingsAndDocs.Model
{
    /// <summary>
    /// ClosingUser
    /// </summary>
    [DataContract]
        public partial class ClosingUser :  IEquatable<ClosingUser>, IValidatableObject
    {
        /// <summary>
        /// Defines Roles
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
                public enum RolesEnum
        {
            /// <summary>
            /// Enum Closer for value: closer
            /// </summary>
            [EnumMember(Value = "closer")]
            Closer = 1,
            /// <summary>
            /// Enum Funder for value: funder
            /// </summary>
            [EnumMember(Value = "funder")]
            Funder = 2,
            /// <summary>
            /// Enum Loancoordinator for value: loan_coordinator
            /// </summary>
            [EnumMember(Value = "loan_coordinator")]
            Loancoordinator = 3        }
        /// <summary>
        /// Official role of the closing user handling this closing, such as Loan Officer, Closer, Funder, etc.
        /// </summary>
        /// <value>Official role of the closing user handling this closing, such as Loan Officer, Closer, Funder, etc.</value>
        [DataMember(Name="roles", EmitDefaultValue=false)]
        public List<RolesEnum> Roles { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ClosingUser" /> class.
        /// </summary>
        /// <param name="firstName">First name of the closing user handling this closing..</param>
        /// <param name="lastName">Last name of the closing user handling this closing..</param>
        /// <param name="phone">Phone number of the closing user handling this closing..</param>
        /// <param name="email">Email address of the closing user handling this closing. (required).</param>
        /// <param name="roles">Official role of the closing user handling this closing, such as Loan Officer, Closer, Funder, etc..</param>
        public ClosingUser(string firstName = default(string), string lastName = default(string), string phone = default(string), string email = default(string), List<RolesEnum> roles = default(List<RolesEnum>))
        {
            // to ensure "email" is required (not null)
            if (email == null)
            {
                throw new InvalidDataException("email is a required property for ClosingUser and cannot be null");
            }
            else
            {
                this.Email = email;
            }
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Phone = phone;
            this.Roles = roles;
        }
        
        /// <summary>
        /// First name of the closing user handling this closing.
        /// </summary>
        /// <value>First name of the closing user handling this closing.</value>
        [DataMember(Name="first_name", EmitDefaultValue=false)]
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of the closing user handling this closing.
        /// </summary>
        /// <value>Last name of the closing user handling this closing.</value>
        [DataMember(Name="last_name", EmitDefaultValue=false)]
        public string LastName { get; set; }

        /// <summary>
        /// Phone number of the closing user handling this closing.
        /// </summary>
        /// <value>Phone number of the closing user handling this closing.</value>
        [DataMember(Name="phone", EmitDefaultValue=false)]
        public string Phone { get; set; }

        /// <summary>
        /// Email address of the closing user handling this closing.
        /// </summary>
        /// <value>Email address of the closing user handling this closing.</value>
        [DataMember(Name="email", EmitDefaultValue=false)]
        public string Email { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ClosingUser {\n");
            sb.Append("  FirstName: ").Append(FirstName).Append("\n");
            sb.Append("  LastName: ").Append(LastName).Append("\n");
            sb.Append("  Phone: ").Append(Phone).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  Roles: ").Append(Roles).Append("\n");
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
            return this.Equals(input as ClosingUser);
        }

        /// <summary>
        /// Returns true if ClosingUser instances are equal
        /// </summary>
        /// <param name="input">Instance of ClosingUser to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ClosingUser input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.FirstName == input.FirstName ||
                    (this.FirstName != null &&
                    this.FirstName.Equals(input.FirstName))
                ) && 
                (
                    this.LastName == input.LastName ||
                    (this.LastName != null &&
                    this.LastName.Equals(input.LastName))
                ) && 
                (
                    this.Phone == input.Phone ||
                    (this.Phone != null &&
                    this.Phone.Equals(input.Phone))
                ) && 
                (
                    this.Email == input.Email ||
                    (this.Email != null &&
                    this.Email.Equals(input.Email))
                ) && 
                (
                    this.Roles == input.Roles ||
                    this.Roles != null &&
                    input.Roles != null &&
                    this.Roles.SequenceEqual(input.Roles)
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
                if (this.FirstName != null)
                    hashCode = hashCode * 59 + this.FirstName.GetHashCode();
                if (this.LastName != null)
                    hashCode = hashCode * 59 + this.LastName.GetHashCode();
                if (this.Phone != null)
                    hashCode = hashCode * 59 + this.Phone.GetHashCode();
                if (this.Email != null)
                    hashCode = hashCode * 59 + this.Email.GetHashCode();
                if (this.Roles != null)
                    hashCode = hashCode * 59 + this.Roles.GetHashCode();
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
