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

namespace Subscriptions.Model
{
    /// <summary>
    /// GetSubscriptions
    /// </summary>
    [DataContract]
        public partial class GetSubscriptions :  IEquatable<GetSubscriptions>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetSubscriptions" /> class.
        /// </summary>
        /// <param name="data">An array of webhook subscription details..</param>
        /// <param name="meta">meta.</param>
        public GetSubscriptions(List<GetSubscriptionsData> data = default(List<GetSubscriptionsData>), GetSubscriptionsMeta meta = default(GetSubscriptionsMeta))
        {
            this.Data = data;
            this.Meta = meta;
        }
        
        /// <summary>
        /// An array of webhook subscription details.
        /// </summary>
        /// <value>An array of webhook subscription details.</value>
        [DataMember(Name="data", EmitDefaultValue=false)]
        public List<GetSubscriptionsData> Data { get; set; }

        /// <summary>
        /// Gets or Sets Meta
        /// </summary>
        [DataMember(Name="meta", EmitDefaultValue=false)]
        public GetSubscriptionsMeta Meta { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GetSubscriptions {\n");
            sb.Append("  Data: ").Append(Data).Append("\n");
            sb.Append("  Meta: ").Append(Meta).Append("\n");
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
            return this.Equals(input as GetSubscriptions);
        }

        /// <summary>
        /// Returns true if GetSubscriptions instances are equal
        /// </summary>
        /// <param name="input">Instance of GetSubscriptions to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GetSubscriptions input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Data == input.Data ||
                    this.Data != null &&
                    input.Data != null &&
                    this.Data.SequenceEqual(input.Data)
                ) && 
                (
                    this.Meta == input.Meta ||
                    (this.Meta != null &&
                    this.Meta.Equals(input.Meta))
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
                if (this.Data != null)
                    hashCode = hashCode * 59 + this.Data.GetHashCode();
                if (this.Meta != null)
                    hashCode = hashCode * 59 + this.Meta.GetHashCode();
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
