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
    /// ExternalIdentifier
    /// </summary>
    [DataContract]
        public partial class ExternalIdentifier :  IEquatable<ExternalIdentifier>, IValidatableObject
    {
        /// <summary>
        /// The name of the external system.
        /// </summary>
        /// <value>The name of the external system.</value>
        [JsonConverter(typeof(StringEnumConverter))]
                public enum ExternalSystemEnum
        {
            /// <summary>
            /// Enum Encompass for value: encompass
            /// </summary>
            [EnumMember(Value = "encompass")]
            Encompass = 1,
            /// <summary>
            /// Enum Otherlos for value: other_los
            /// </summary>
            [EnumMember(Value = "other_los")]
            Otherlos = 2,
            /// <summary>
            /// Enum Resware for value: resware
            /// </summary>
            [EnumMember(Value = "resware")]
            Resware = 3,
            /// <summary>
            /// Enum Softpro for value: softpro
            /// </summary>
            [EnumMember(Value = "softpro")]
            Softpro = 4,
            /// <summary>
            /// Enum Othertps for value: other_tps
            /// </summary>
            [EnumMember(Value = "other_tps")]
            Othertps = 5,
            /// <summary>
            /// Enum Byte for value: byte
            /// </summary>
            [EnumMember(Value = "byte")]
            Byte = 6        }
        /// <summary>
        /// The name of the external system.
        /// </summary>
        /// <value>The name of the external system.</value>
        [DataMember(Name="external_system", EmitDefaultValue=false)]
        public ExternalSystemEnum ExternalSystem { get; set; }
        /// <summary>
        /// The type of the external identifier.
        /// </summary>
        /// <value>The type of the external identifier.</value>
        [JsonConverter(typeof(StringEnumConverter))]
                public enum ExternalTypeEnum
        {
            /// <summary>
            /// Enum Loanid for value: loan_id
            /// </summary>
            [EnumMember(Value = "loan_id")]
            Loanid = 1,
            /// <summary>
            /// Enum Loanguid for value: loan_guid
            /// </summary>
            [EnumMember(Value = "loan_guid")]
            Loanguid = 2,
            /// <summary>
            /// Enum Filenumber for value: file_number
            /// </summary>
            [EnumMember(Value = "file_number")]
            Filenumber = 3,
            /// <summary>
            /// Enum Filedataid for value:
            /// </summary>
            [EnumMember(Value = "file_data_id")]
            Filedataid = 4        }
        /// <summary>
        /// The type of the external identifier.
        /// </summary>
        /// <value>The type of the external identifier.</value>
        [DataMember(Name="external_type", EmitDefaultValue=false)]
        public ExternalTypeEnum ExternalType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ExternalIdentifier" /> class.
        /// </summary>
        /// <param name="externalSystem">The name of the external system. (required).</param>
        /// <param name="externalType">The type of the external identifier. (required).</param>
        /// <param name="value">The value of the external identifier. (required).</param>
        public ExternalIdentifier(ExternalSystemEnum externalSystem = default(ExternalSystemEnum), ExternalTypeEnum externalType = default(ExternalTypeEnum), string value = default(string))
        {
            // to ensure "externalSystem" is required (not null)
            if (externalSystem == null)
            {
                throw new InvalidDataException("externalSystem is a required property for ExternalIdentifier and cannot be null");
            }
            else
            {
                this.ExternalSystem = externalSystem;
            }
            // to ensure "externalType" is required (not null)
            if (externalType == null)
            {
                throw new InvalidDataException("externalType is a required property for ExternalIdentifier and cannot be null");
            }
            else
            {
                this.ExternalType = externalType;
            }
            // to ensure "value" is required (not null)
            if (value == null)
            {
                throw new InvalidDataException("value is a required property for ExternalIdentifier and cannot be null");
            }
            else
            {
                this.Value = value;
            }
        }



        /// <summary>
        /// The value of the external identifier.
        /// </summary>
        /// <value>The value of the external identifier.</value>
        [DataMember(Name="value", EmitDefaultValue=false)]
        public string Value { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ExternalIdentifier {\n");
            sb.Append("  ExternalSystem: ").Append(ExternalSystem).Append("\n");
            sb.Append("  ExternalType: ").Append(ExternalType).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
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
            return this.Equals(input as ExternalIdentifier);
        }

        /// <summary>
        /// Returns true if ExternalIdentifier instances are equal
        /// </summary>
        /// <param name="input">Instance of ExternalIdentifier to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ExternalIdentifier input)
        {
            if (input == null)
                return false;

            return
                (
                    this.ExternalSystem == input.ExternalSystem ||
                    (this.ExternalSystem != null &&
                    this.ExternalSystem.Equals(input.ExternalSystem))
                ) &&
                (
                    this.ExternalType == input.ExternalType ||
                    (this.ExternalType != null &&
                    this.ExternalType.Equals(input.ExternalType))
                ) &&
                (
                    this.Value == input.Value ||
                    (this.Value != null &&
                    this.Value.Equals(input.Value))
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
                if (this.ExternalSystem != null)
                    hashCode = hashCode * 59 + this.ExternalSystem.GetHashCode();
                if (this.ExternalType != null)
                    hashCode = hashCode * 59 + this.ExternalType.GetHashCode();
                if (this.Value != null)
                    hashCode = hashCode * 59 + this.Value.GetHashCode();
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
