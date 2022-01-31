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
    /// Borrower
    /// </summary>
    [DataContract]
        public partial class Borrower :  IEquatable<Borrower>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Borrower" /> class.
        /// </summary>
        /// <param name="firstName">The Borrower&#x27;s first name. This must match the first name printed on the closing documents. (required).</param>
        /// <param name="middleName">The Borrower&#x27;s middle name. This must match the middle name printed on the closing documents..</param>
        /// <param name="lastName">The Borrower&#x27;s last name. This must match the last name printed on the closing documents. (required).</param>
        /// <param name="suffix">The suffix of the Borrower&#x27;s name..</param>
        /// <param name="email">The Borrower&#x27;s email address..</param>
        /// <param name="phone">The Borrower&#x27;s phone number..</param>
        /// <param name="address">The Borrower&#x27;s current address..</param>
        /// <param name="city">The city the Borrower&#x27;s currently residing in..</param>
        /// <param name="state">The state the Borrower&#x27;s currently residing in..</param>
        /// <param name="zip">The zip code the Borrower&#x27;s currently residing in..</param>
        /// <param name="ssnLast4">The last 4 digits of the Borrower&#x27;s social security number..</param>
        public Borrower(string firstName = default(string), string middleName = default(string), string lastName = default(string), string suffix = default(string), string email = default(string), string phone = default(string), string address = default(string), string city = default(string), string state = default(string), string zip = default(string), string ssnLast4 = default(string))
        {
            // to ensure "firstName" is required (not null)
            if (firstName == null)
            {
                throw new InvalidDataException("firstName is a required property for Borrower and cannot be null");
            }
            else
            {
                this.FirstName = firstName;
            }
            // to ensure "lastName" is required (not null)
            if (lastName == null)
            {
                throw new InvalidDataException("lastName is a required property for Borrower and cannot be null");
            }
            else
            {
                this.LastName = lastName;
            }
            this.MiddleName = middleName;
            this.Suffix = suffix;
            this.Email = email;
            this.Phone = phone;
            this.Address = address;
            this.City = city;
            this.State = state;
            this.Zip = zip;
            this.SsnLast4 = ssnLast4;
        }
        
        /// <summary>
        /// The Borrower&#x27;s first name. This must match the first name printed on the closing documents.
        /// </summary>
        /// <value>The Borrower&#x27;s first name. This must match the first name printed on the closing documents.</value>
        [DataMember(Name="first_name", EmitDefaultValue=false)]
        public string FirstName { get; set; }

        /// <summary>
        /// The Borrower&#x27;s middle name. This must match the middle name printed on the closing documents.
        /// </summary>
        /// <value>The Borrower&#x27;s middle name. This must match the middle name printed on the closing documents.</value>
        [DataMember(Name="middle_name", EmitDefaultValue=false)]
        public string MiddleName { get; set; }

        /// <summary>
        /// The Borrower&#x27;s last name. This must match the last name printed on the closing documents.
        /// </summary>
        /// <value>The Borrower&#x27;s last name. This must match the last name printed on the closing documents.</value>
        [DataMember(Name="last_name", EmitDefaultValue=false)]
        public string LastName { get; set; }

        /// <summary>
        /// The suffix of the Borrower&#x27;s name.
        /// </summary>
        /// <value>The suffix of the Borrower&#x27;s name.</value>
        [DataMember(Name="suffix", EmitDefaultValue=false)]
        public string Suffix { get; set; }

        /// <summary>
        /// The Borrower&#x27;s email address.
        /// </summary>
        /// <value>The Borrower&#x27;s email address.</value>
        [DataMember(Name="email", EmitDefaultValue=false)]
        public string Email { get; set; }

        /// <summary>
        /// The Borrower&#x27;s phone number.
        /// </summary>
        /// <value>The Borrower&#x27;s phone number.</value>
        [DataMember(Name="phone", EmitDefaultValue=false)]
        public string Phone { get; set; }

        /// <summary>
        /// The Borrower&#x27;s current address.
        /// </summary>
        /// <value>The Borrower&#x27;s current address.</value>
        [DataMember(Name="address", EmitDefaultValue=false)]
        public string Address { get; set; }

        /// <summary>
        /// The city the Borrower&#x27;s currently residing in.
        /// </summary>
        /// <value>The city the Borrower&#x27;s currently residing in.</value>
        [DataMember(Name="city", EmitDefaultValue=false)]
        public string City { get; set; }

        /// <summary>
        /// The state the Borrower&#x27;s currently residing in.
        /// </summary>
        /// <value>The state the Borrower&#x27;s currently residing in.</value>
        [DataMember(Name="state", EmitDefaultValue=false)]
        public string State { get; set; }

        /// <summary>
        /// The zip code the Borrower&#x27;s currently residing in.
        /// </summary>
        /// <value>The zip code the Borrower&#x27;s currently residing in.</value>
        [DataMember(Name="zip", EmitDefaultValue=false)]
        public string Zip { get; set; }

        /// <summary>
        /// The last 4 digits of the Borrower&#x27;s social security number.
        /// </summary>
        /// <value>The last 4 digits of the Borrower&#x27;s social security number.</value>
        [DataMember(Name="ssn_last_4", EmitDefaultValue=false)]
        public string SsnLast4 { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Borrower {\n");
            sb.Append("  FirstName: ").Append(FirstName).Append("\n");
            sb.Append("  MiddleName: ").Append(MiddleName).Append("\n");
            sb.Append("  LastName: ").Append(LastName).Append("\n");
            sb.Append("  Suffix: ").Append(Suffix).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  Phone: ").Append(Phone).Append("\n");
            sb.Append("  Address: ").Append(Address).Append("\n");
            sb.Append("  City: ").Append(City).Append("\n");
            sb.Append("  State: ").Append(State).Append("\n");
            sb.Append("  Zip: ").Append(Zip).Append("\n");
            sb.Append("  SsnLast4: ").Append(SsnLast4).Append("\n");
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
            return this.Equals(input as Borrower);
        }

        /// <summary>
        /// Returns true if Borrower instances are equal
        /// </summary>
        /// <param name="input">Instance of Borrower to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Borrower input)
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
                    this.MiddleName == input.MiddleName ||
                    (this.MiddleName != null &&
                    this.MiddleName.Equals(input.MiddleName))
                ) && 
                (
                    this.LastName == input.LastName ||
                    (this.LastName != null &&
                    this.LastName.Equals(input.LastName))
                ) && 
                (
                    this.Suffix == input.Suffix ||
                    (this.Suffix != null &&
                    this.Suffix.Equals(input.Suffix))
                ) && 
                (
                    this.Email == input.Email ||
                    (this.Email != null &&
                    this.Email.Equals(input.Email))
                ) && 
                (
                    this.Phone == input.Phone ||
                    (this.Phone != null &&
                    this.Phone.Equals(input.Phone))
                ) && 
                (
                    this.Address == input.Address ||
                    (this.Address != null &&
                    this.Address.Equals(input.Address))
                ) && 
                (
                    this.City == input.City ||
                    (this.City != null &&
                    this.City.Equals(input.City))
                ) && 
                (
                    this.State == input.State ||
                    (this.State != null &&
                    this.State.Equals(input.State))
                ) && 
                (
                    this.Zip == input.Zip ||
                    (this.Zip != null &&
                    this.Zip.Equals(input.Zip))
                ) && 
                (
                    this.SsnLast4 == input.SsnLast4 ||
                    (this.SsnLast4 != null &&
                    this.SsnLast4.Equals(input.SsnLast4))
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
                if (this.MiddleName != null)
                    hashCode = hashCode * 59 + this.MiddleName.GetHashCode();
                if (this.LastName != null)
                    hashCode = hashCode * 59 + this.LastName.GetHashCode();
                if (this.Suffix != null)
                    hashCode = hashCode * 59 + this.Suffix.GetHashCode();
                if (this.Email != null)
                    hashCode = hashCode * 59 + this.Email.GetHashCode();
                if (this.Phone != null)
                    hashCode = hashCode * 59 + this.Phone.GetHashCode();
                if (this.Address != null)
                    hashCode = hashCode * 59 + this.Address.GetHashCode();
                if (this.City != null)
                    hashCode = hashCode * 59 + this.City.GetHashCode();
                if (this.State != null)
                    hashCode = hashCode * 59 + this.State.GetHashCode();
                if (this.Zip != null)
                    hashCode = hashCode * 59 + this.Zip.GetHashCode();
                if (this.SsnLast4 != null)
                    hashCode = hashCode * 59 + this.SsnLast4.GetHashCode();
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
