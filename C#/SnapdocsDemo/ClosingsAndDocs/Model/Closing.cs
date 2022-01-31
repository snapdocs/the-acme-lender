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
    /// Closing
    /// </summary>
    [DataContract]
        public partial class Closing :  IEquatable<Closing>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Closing" /> class.
        /// </summary>
        /// <param name="closingUuid">The unique identifier for this closing..</param>
        /// <param name="snapdocsUrl">The closing’s URL created by Snapdocs..</param>
        /// <param name="errors">Errors encountered while creating the closing. Note that for errors that are not critical, Snapdocs allows the closing to be created, and will follow up with the Lender to fix the issues..</param>
        public Closing(string closingUuid = default(string), string snapdocsUrl = default(string), List<ClosingError> errors = default(List<ClosingError>))
        {
            this.ClosingUuid = closingUuid;
            this.SnapdocsUrl = snapdocsUrl;
            this.Errors = errors;
        }
        
        /// <summary>
        /// The unique identifier for this closing.
        /// </summary>
        /// <value>The unique identifier for this closing.</value>
        [DataMember(Name="closing_uuid", EmitDefaultValue=false)]
        public string ClosingUuid { get; set; }

        /// <summary>
        /// The closing’s URL created by Snapdocs.
        /// </summary>
        /// <value>The closing’s URL created by Snapdocs.</value>
        [DataMember(Name="snapdocs_url", EmitDefaultValue=false)]
        public string SnapdocsUrl { get; set; }

        /// <summary>
        /// Errors encountered while creating the closing. Note that for errors that are not critical, Snapdocs allows the closing to be created, and will follow up with the Lender to fix the issues.
        /// </summary>
        /// <value>Errors encountered while creating the closing. Note that for errors that are not critical, Snapdocs allows the closing to be created, and will follow up with the Lender to fix the issues.</value>
        [DataMember(Name="errors", EmitDefaultValue=false)]
        public List<ClosingError> Errors { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Closing {\n");
            sb.Append("  ClosingUuid: ").Append(ClosingUuid).Append("\n");
            sb.Append("  SnapdocsUrl: ").Append(SnapdocsUrl).Append("\n");
            sb.Append("  Errors: ").Append(Errors).Append("\n");
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
            return this.Equals(input as Closing);
        }

        /// <summary>
        /// Returns true if Closing instances are equal
        /// </summary>
        /// <param name="input">Instance of Closing to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Closing input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.ClosingUuid == input.ClosingUuid ||
                    (this.ClosingUuid != null &&
                    this.ClosingUuid.Equals(input.ClosingUuid))
                ) && 
                (
                    this.SnapdocsUrl == input.SnapdocsUrl ||
                    (this.SnapdocsUrl != null &&
                    this.SnapdocsUrl.Equals(input.SnapdocsUrl))
                ) && 
                (
                    this.Errors == input.Errors ||
                    this.Errors != null &&
                    input.Errors != null &&
                    this.Errors.SequenceEqual(input.Errors)
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
                if (this.ClosingUuid != null)
                    hashCode = hashCode * 59 + this.ClosingUuid.GetHashCode();
                if (this.SnapdocsUrl != null)
                    hashCode = hashCode * 59 + this.SnapdocsUrl.GetHashCode();
                if (this.Errors != null)
                    hashCode = hashCode * 59 + this.Errors.GetHashCode();
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
