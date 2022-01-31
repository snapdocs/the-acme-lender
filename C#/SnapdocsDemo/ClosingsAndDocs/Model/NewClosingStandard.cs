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
    /// A closing with signing_method of wet_only, hybrid, or hybrid_with_enote
    /// </summary>
    [DataContract]
        public partial class NewClosingStandard :  IEquatable<NewClosingStandard>, IValidatableObject
    {
        /// <summary>
        /// The type of Closing (Wet, Hybrid, Full, Hybrid/Full with eNote/) for the loan.
        /// </summary>
        /// <value>The type of Closing (Wet, Hybrid, Full, Hybrid/Full with eNote/) for the loan.</value>
        [JsonConverter(typeof(StringEnumConverter))]
                public enum SigningMethodEnum
        {
            /// <summary>
            /// Enum Hybrid for value: hybrid
            /// </summary>
            [EnumMember(Value = "hybrid")]
            Hybrid = 1,
            /// <summary>
            /// Enum Hybridwithenote for value: hybrid_with_enote
            /// </summary>
            [EnumMember(Value = "hybrid_with_enote")]
            Hybridwithenote = 2,

            [EnumMember(Value = "wet_only")]
            WetOnly = 3
        }
        /// <summary>
        /// The type of Closing (Wet, Hybrid, Full, Hybrid/Full with eNote/) for the loan.
        /// </summary>
        /// <value>The type of Closing (Wet, Hybrid, Full, Hybrid/Full with eNote/) for the loan.</value>
        [DataMember(Name="signing_method", EmitDefaultValue=false)]
        public SigningMethodEnum SigningMethod { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="NewClosingStandard" /> class.
        /// </summary>
        /// <param name="fileNumber">The file number on the loan. (required).</param>
        /// <param name="referenceId">Unique Loan Guid (required).</param>
        /// <param name="source">Name of the source which will be calling the API. (required).</param>
        /// <param name="signingMethod">The type of Closing (Wet, Hybrid, Full, Hybrid/Full with eNote/) for the loan. (required).</param>
        /// <param name="appointmentEarliestAt">The earliest date the Wet Signing appointment can happen in &#x27;YYYY-MM-DD&#x27; or &#x27;YYYY-MM-DDT00:00:00&#x27; format. In case your organization would like to set eSign constraint on the closing, this date is used to determine when will the Borrower be allowed to eSign some of the closing documents..</param>
        /// <param name="appointmentLatestAt">The latest date the Wet Signing appointment can happen in &#x27;YYYY-MM-DD&#x27; or &#x27;YYYY-MM-DDT00:00:00&#x27; format..</param>
        /// <param name="appointmentDate">The exact date of the closing in &#x60;YYYY-MM-DD&#x60; format..</param>
        /// <param name="appointmentTime">The exact time for the closing. The time zone used to display the signing time will be calculated based on the data sent to Snapdocs in the following fields:   &#x60;appointment_location_address&#x60;   &#x60;appointment_location_city&#x60;   &#x60;appointment_location_state&#x60;   &#x60;appointment_location_zip&#x60;.</param>
        /// <param name="appointmentLocationAddress">The street address where the signing will be held at..</param>
        /// <param name="appointmentLocationCity">The city where the signing will be held at..</param>
        /// <param name="appointmentLocationState">Two-letter state abbreviations where the signing will be held at..</param>
        /// <param name="appointmentLocationZip">The zip code of the address where the signing will be held at..</param>
        /// <param name="fundingTeamEmail">Email address of the Funding Team who needs to be notified about the closing..</param>
        /// <param name="propertyStreetAddress">The address of the property being purchased..</param>
        /// <param name="propertyCity">The city the property is located in..</param>
        /// <param name="propertyState">The state the property is located in..</param>
        /// <param name="propertyZip">The zip code of the property being purchased..</param>
        /// <param name="settlementOfficeEmail">Email address of the settlement office handling this closing. (required).</param>
        /// <param name="settlementOfficeName">The name of the settlement office handling this closing. (required).</param>
        /// <param name="settlementOfficeAddress">The address of the settlement office..</param>
        /// <param name="settlementOfficeCity">The city the settlement office is located in..</param>
        /// <param name="settlementOfficeState">The state the settlement office is located in..</param>
        /// <param name="settlementOfficeZip">The zip code of the settlement office..</param>
        /// <param name="additionalFileContactEmails">Any additional lender emails that need to be notified about the closing..</param>
        /// <param name="borrowers">The Borrower&#x27;s detailed info. At least one borrower is required. (required).</param>
        /// <param name="closingUsers">The closing user&#x27;s info. (required).</param>
        /// <param name="settlementAgents">The settlement agent&#x27;s info. At least one valid settlement agent email is required. (required).</param>
        /// <param name="externalIdentifiers">External identifiers of the closing..</param>
        public NewClosingStandard(string fileNumber = default(string), string referenceId = default(string), string source = default(string), SigningMethodEnum signingMethod = default(SigningMethodEnum), DateTime? appointmentEarliestAt = default(DateTime?), DateTime? appointmentLatestAt = default(DateTime?), DateTime? appointmentDate = default(DateTime?), string appointmentTime = default(string), string appointmentLocationAddress = default(string), string appointmentLocationCity = default(string), string appointmentLocationState = default(string), string appointmentLocationZip = default(string), string fundingTeamEmail = default(string), string propertyStreetAddress = default(string), string propertyCity = default(string), string propertyState = default(string), string propertyZip = default(string), string settlementOfficeEmail = default(string), string settlementOfficeName = default(string), string settlementOfficeAddress = default(string), string settlementOfficeCity = default(string), string settlementOfficeState = default(string), string settlementOfficeZip = default(string), List<string> additionalFileContactEmails = default(List<string>), List<Borrower> borrowers = default(List<Borrower>), List<ClosingUser> closingUsers = default(List<ClosingUser>), List<SettlementAgent> settlementAgents = default(List<SettlementAgent>), List<ExternalIdentifier> externalIdentifiers = default(List<ExternalIdentifier>))
        {
            // to ensure "fileNumber" is required (not null)
            if (fileNumber == null)
            {
                throw new InvalidDataException("fileNumber is a required property for NewClosingStandard and cannot be null");
            }
            else
            {
                this.FileNumber = fileNumber;
            }
            // to ensure "referenceId" is required (not null)
            if (referenceId == null)
            {
                throw new InvalidDataException("referenceId is a required property for NewClosingStandard and cannot be null");
            }
            else
            {
                this.ReferenceId = referenceId;
            }
            // to ensure "source" is required (not null)
            if (source == null)
            {
                throw new InvalidDataException("source is a required property for NewClosingStandard and cannot be null");
            }
            else
            {
                this.Source = source;
            }
            // to ensure "signingMethod" is required (not null)
            if (signingMethod == null)
            {
                throw new InvalidDataException("signingMethod is a required property for NewClosingStandard and cannot be null");
            }
            else
            {
                this.SigningMethod = signingMethod;
            }
            // to ensure "settlementOfficeEmail" is required (not null)
            if (settlementOfficeEmail == null)
            {
                throw new InvalidDataException("settlementOfficeEmail is a required property for NewClosingStandard and cannot be null");
            }
            else
            {
                this.SettlementOfficeEmail = settlementOfficeEmail;
            }
            // to ensure "settlementOfficeName" is required (not null)
            if (settlementOfficeName == null)
            {
                throw new InvalidDataException("settlementOfficeName is a required property for NewClosingStandard and cannot be null");
            }
            else
            {
                this.SettlementOfficeName = settlementOfficeName;
            }
            // to ensure "borrowers" is required (not null)
            if (borrowers == null)
            {
                throw new InvalidDataException("borrowers is a required property for NewClosingStandard and cannot be null");
            }
            else
            {
                this.Borrowers = borrowers;
            }
            // to ensure "closingUsers" is required (not null)
            if (closingUsers == null)
            {
                throw new InvalidDataException("closingUsers is a required property for NewClosingStandard and cannot be null");
            }
            else
            {
                this.ClosingUsers = closingUsers;
            }
            // to ensure "settlementAgents" is required (not null)
            if (settlementAgents == null)
            {
                throw new InvalidDataException("settlementAgents is a required property for NewClosingStandard and cannot be null");
            }
            else
            {
                this.SettlementAgents = settlementAgents;
            }
            this.AppointmentEarliestAt = appointmentEarliestAt;
            this.AppointmentLatestAt = appointmentLatestAt;
            this.AppointmentDate = appointmentDate;
            this.AppointmentTime = appointmentTime;
            this.AppointmentLocationAddress = appointmentLocationAddress;
            this.AppointmentLocationCity = appointmentLocationCity;
            this.AppointmentLocationState = appointmentLocationState;
            this.AppointmentLocationZip = appointmentLocationZip;
            this.FundingTeamEmail = fundingTeamEmail;
            this.PropertyStreetAddress = propertyStreetAddress;
            this.PropertyCity = propertyCity;
            this.PropertyState = propertyState;
            this.PropertyZip = propertyZip;
            this.SettlementOfficeAddress = settlementOfficeAddress;
            this.SettlementOfficeCity = settlementOfficeCity;
            this.SettlementOfficeState = settlementOfficeState;
            this.SettlementOfficeZip = settlementOfficeZip;
            this.AdditionalFileContactEmails = additionalFileContactEmails;
            this.ExternalIdentifiers = externalIdentifiers;
        }
        
        /// <summary>
        /// The file number on the loan.
        /// </summary>
        /// <value>The file number on the loan.</value>
        [DataMember(Name="file_number", EmitDefaultValue=false)]
        public string FileNumber { get; set; }

        /// <summary>
        /// Unique Loan Guid
        /// </summary>
        /// <value>Unique Loan Guid</value>
        [DataMember(Name="reference_id", EmitDefaultValue=false)]
        public string ReferenceId { get; set; }

        /// <summary>
        /// Name of the source which will be calling the API.
        /// </summary>
        /// <value>Name of the source which will be calling the API.</value>
        [DataMember(Name="source", EmitDefaultValue=false)]
        public string Source { get; set; }


        /// <summary>
        /// The earliest date the Wet Signing appointment can happen in &#x27;YYYY-MM-DD&#x27; or &#x27;YYYY-MM-DDT00:00:00&#x27; format. In case your organization would like to set eSign constraint on the closing, this date is used to determine when will the Borrower be allowed to eSign some of the closing documents.
        /// </summary>
        /// <value>The earliest date the Wet Signing appointment can happen in &#x27;YYYY-MM-DD&#x27; or &#x27;YYYY-MM-DDT00:00:00&#x27; format. In case your organization would like to set eSign constraint on the closing, this date is used to determine when will the Borrower be allowed to eSign some of the closing documents.</value>
        [DataMember(Name="appointment_earliest_at", EmitDefaultValue=false)]
        [JsonConverter(typeof(DateConverter))]
        public DateTime? AppointmentEarliestAt { get; set; }

        /// <summary>
        /// The latest date the Wet Signing appointment can happen in &#x27;YYYY-MM-DD&#x27; or &#x27;YYYY-MM-DDT00:00:00&#x27; format.
        /// </summary>
        /// <value>The latest date the Wet Signing appointment can happen in &#x27;YYYY-MM-DD&#x27; or &#x27;YYYY-MM-DDT00:00:00&#x27; format.</value>
        [DataMember(Name="appointment_latest_at", EmitDefaultValue=false)]
        [JsonConverter(typeof(DateConverter))]
        public DateTime? AppointmentLatestAt { get; set; }

        /// <summary>
        /// The exact date of the closing in &#x60;YYYY-MM-DD&#x60; format.
        /// </summary>
        /// <value>The exact date of the closing in &#x60;YYYY-MM-DD&#x60; format.</value>
        [DataMember(Name="appointment_date", EmitDefaultValue=false)]
        [JsonConverter(typeof(DateConverter))]
        public DateTime? AppointmentDate { get; set; }

        /// <summary>
        /// The exact time for the closing. The time zone used to display the signing time will be calculated based on the data sent to Snapdocs in the following fields:   &#x60;appointment_location_address&#x60;   &#x60;appointment_location_city&#x60;   &#x60;appointment_location_state&#x60;   &#x60;appointment_location_zip&#x60;
        /// </summary>
        /// <value>The exact time for the closing. The time zone used to display the signing time will be calculated based on the data sent to Snapdocs in the following fields:   &#x60;appointment_location_address&#x60;   &#x60;appointment_location_city&#x60;   &#x60;appointment_location_state&#x60;   &#x60;appointment_location_zip&#x60;</value>
        [DataMember(Name="appointment_time", EmitDefaultValue=false)]
        public string AppointmentTime { get; set; }

        /// <summary>
        /// The street address where the signing will be held at.
        /// </summary>
        /// <value>The street address where the signing will be held at.</value>
        [DataMember(Name="appointment_location_address", EmitDefaultValue=false)]
        public string AppointmentLocationAddress { get; set; }

        /// <summary>
        /// The city where the signing will be held at.
        /// </summary>
        /// <value>The city where the signing will be held at.</value>
        [DataMember(Name="appointment_location_city", EmitDefaultValue=false)]
        public string AppointmentLocationCity { get; set; }

        /// <summary>
        /// Two-letter state abbreviations where the signing will be held at.
        /// </summary>
        /// <value>Two-letter state abbreviations where the signing will be held at.</value>
        [DataMember(Name="appointment_location_state", EmitDefaultValue=false)]
        public string AppointmentLocationState { get; set; }

        /// <summary>
        /// The zip code of the address where the signing will be held at.
        /// </summary>
        /// <value>The zip code of the address where the signing will be held at.</value>
        [DataMember(Name="appointment_location_zip", EmitDefaultValue=false)]
        public string AppointmentLocationZip { get; set; }

        /// <summary>
        /// Email address of the Funding Team who needs to be notified about the closing.
        /// </summary>
        /// <value>Email address of the Funding Team who needs to be notified about the closing.</value>
        [DataMember(Name="funding_team_email", EmitDefaultValue=false)]
        public string FundingTeamEmail { get; set; }

        /// <summary>
        /// The address of the property being purchased.
        /// </summary>
        /// <value>The address of the property being purchased.</value>
        [DataMember(Name="property_street_address", EmitDefaultValue=false)]
        public string PropertyStreetAddress { get; set; }

        /// <summary>
        /// The city the property is located in.
        /// </summary>
        /// <value>The city the property is located in.</value>
        [DataMember(Name="property_city", EmitDefaultValue=false)]
        public string PropertyCity { get; set; }

        /// <summary>
        /// The state the property is located in.
        /// </summary>
        /// <value>The state the property is located in.</value>
        [DataMember(Name="property_state", EmitDefaultValue=false)]
        public string PropertyState { get; set; }

        /// <summary>
        /// The zip code of the property being purchased.
        /// </summary>
        /// <value>The zip code of the property being purchased.</value>
        [DataMember(Name="property_zip", EmitDefaultValue=false)]
        public string PropertyZip { get; set; }

        /// <summary>
        /// Email address of the settlement office handling this closing.
        /// </summary>
        /// <value>Email address of the settlement office handling this closing.</value>
        [DataMember(Name="settlement_office_email", EmitDefaultValue=false)]
        public string SettlementOfficeEmail { get; set; }

        /// <summary>
        /// The name of the settlement office handling this closing.
        /// </summary>
        /// <value>The name of the settlement office handling this closing.</value>
        [DataMember(Name="settlement_office_name", EmitDefaultValue=false)]
        public string SettlementOfficeName { get; set; }

        /// <summary>
        /// The address of the settlement office.
        /// </summary>
        /// <value>The address of the settlement office.</value>
        [DataMember(Name="settlement_office_address", EmitDefaultValue=false)]
        public string SettlementOfficeAddress { get; set; }

        /// <summary>
        /// The city the settlement office is located in.
        /// </summary>
        /// <value>The city the settlement office is located in.</value>
        [DataMember(Name="settlement_office_city", EmitDefaultValue=false)]
        public string SettlementOfficeCity { get; set; }

        /// <summary>
        /// The state the settlement office is located in.
        /// </summary>
        /// <value>The state the settlement office is located in.</value>
        [DataMember(Name="settlement_office_state", EmitDefaultValue=false)]
        public string SettlementOfficeState { get; set; }

        /// <summary>
        /// The zip code of the settlement office.
        /// </summary>
        /// <value>The zip code of the settlement office.</value>
        [DataMember(Name="settlement_office_zip", EmitDefaultValue=false)]
        public string SettlementOfficeZip { get; set; }

        /// <summary>
        /// Any additional lender emails that need to be notified about the closing.
        /// </summary>
        /// <value>Any additional lender emails that need to be notified about the closing.</value>
        [DataMember(Name="additional_file_contact_emails", EmitDefaultValue=false)]
        public List<string> AdditionalFileContactEmails { get; set; }

        /// <summary>
        /// The Borrower&#x27;s detailed info. At least one borrower is required.
        /// </summary>
        /// <value>The Borrower&#x27;s detailed info. At least one borrower is required.</value>
        [DataMember(Name="borrowers", EmitDefaultValue=false)]
        public List<Borrower> Borrowers { get; set; }

        /// <summary>
        /// The closing user&#x27;s info.
        /// </summary>
        /// <value>The closing user&#x27;s info.</value>
        [DataMember(Name="closing_users", EmitDefaultValue=false)]
        public List<ClosingUser> ClosingUsers { get; set; }

        /// <summary>
        /// The settlement agent&#x27;s info. At least one valid settlement agent email is required.
        /// </summary>
        /// <value>The settlement agent&#x27;s info. At least one valid settlement agent email is required.</value>
        [DataMember(Name="settlement_agents", EmitDefaultValue=false)]
        public List<SettlementAgent> SettlementAgents { get; set; }

        /// <summary>
        /// External identifiers of the closing.
        /// </summary>
        /// <value>External identifiers of the closing.</value>
        [DataMember(Name="external_identifiers", EmitDefaultValue=false)]
        public List<ExternalIdentifier> ExternalIdentifiers { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class NewClosingStandard {\n");
            sb.Append("  FileNumber: ").Append(FileNumber).Append("\n");
            sb.Append("  ReferenceId: ").Append(ReferenceId).Append("\n");
            sb.Append("  Source: ").Append(Source).Append("\n");
            sb.Append("  SigningMethod: ").Append(SigningMethod).Append("\n");
            sb.Append("  AppointmentEarliestAt: ").Append(AppointmentEarliestAt).Append("\n");
            sb.Append("  AppointmentLatestAt: ").Append(AppointmentLatestAt).Append("\n");
            sb.Append("  AppointmentDate: ").Append(AppointmentDate).Append("\n");
            sb.Append("  AppointmentTime: ").Append(AppointmentTime).Append("\n");
            sb.Append("  AppointmentLocationAddress: ").Append(AppointmentLocationAddress).Append("\n");
            sb.Append("  AppointmentLocationCity: ").Append(AppointmentLocationCity).Append("\n");
            sb.Append("  AppointmentLocationState: ").Append(AppointmentLocationState).Append("\n");
            sb.Append("  AppointmentLocationZip: ").Append(AppointmentLocationZip).Append("\n");
            sb.Append("  FundingTeamEmail: ").Append(FundingTeamEmail).Append("\n");
            sb.Append("  PropertyStreetAddress: ").Append(PropertyStreetAddress).Append("\n");
            sb.Append("  PropertyCity: ").Append(PropertyCity).Append("\n");
            sb.Append("  PropertyState: ").Append(PropertyState).Append("\n");
            sb.Append("  PropertyZip: ").Append(PropertyZip).Append("\n");
            sb.Append("  SettlementOfficeEmail: ").Append(SettlementOfficeEmail).Append("\n");
            sb.Append("  SettlementOfficeName: ").Append(SettlementOfficeName).Append("\n");
            sb.Append("  SettlementOfficeAddress: ").Append(SettlementOfficeAddress).Append("\n");
            sb.Append("  SettlementOfficeCity: ").Append(SettlementOfficeCity).Append("\n");
            sb.Append("  SettlementOfficeState: ").Append(SettlementOfficeState).Append("\n");
            sb.Append("  SettlementOfficeZip: ").Append(SettlementOfficeZip).Append("\n");
            sb.Append("  AdditionalFileContactEmails: ").Append(AdditionalFileContactEmails).Append("\n");
            sb.Append("  Borrowers: ").Append(Borrowers).Append("\n");
            sb.Append("  ClosingUsers: ").Append(ClosingUsers).Append("\n");
            sb.Append("  SettlementAgents: ").Append(SettlementAgents).Append("\n");
            sb.Append("  ExternalIdentifiers: ").Append(ExternalIdentifiers).Append("\n");
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
            return this.Equals(input as NewClosingStandard);
        }

        /// <summary>
        /// Returns true if NewClosingStandard instances are equal
        /// </summary>
        /// <param name="input">Instance of NewClosingStandard to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(NewClosingStandard input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.FileNumber == input.FileNumber ||
                    (this.FileNumber != null &&
                    this.FileNumber.Equals(input.FileNumber))
                ) && 
                (
                    this.ReferenceId == input.ReferenceId ||
                    (this.ReferenceId != null &&
                    this.ReferenceId.Equals(input.ReferenceId))
                ) && 
                (
                    this.Source == input.Source ||
                    (this.Source != null &&
                    this.Source.Equals(input.Source))
                ) && 
                (
                    this.SigningMethod == input.SigningMethod ||
                    (this.SigningMethod != null &&
                    this.SigningMethod.Equals(input.SigningMethod))
                ) && 
                (
                    this.AppointmentEarliestAt == input.AppointmentEarliestAt ||
                    (this.AppointmentEarliestAt != null &&
                    this.AppointmentEarliestAt.Equals(input.AppointmentEarliestAt))
                ) && 
                (
                    this.AppointmentLatestAt == input.AppointmentLatestAt ||
                    (this.AppointmentLatestAt != null &&
                    this.AppointmentLatestAt.Equals(input.AppointmentLatestAt))
                ) && 
                (
                    this.AppointmentDate == input.AppointmentDate ||
                    (this.AppointmentDate != null &&
                    this.AppointmentDate.Equals(input.AppointmentDate))
                ) && 
                (
                    this.AppointmentTime == input.AppointmentTime ||
                    (this.AppointmentTime != null &&
                    this.AppointmentTime.Equals(input.AppointmentTime))
                ) && 
                (
                    this.AppointmentLocationAddress == input.AppointmentLocationAddress ||
                    (this.AppointmentLocationAddress != null &&
                    this.AppointmentLocationAddress.Equals(input.AppointmentLocationAddress))
                ) && 
                (
                    this.AppointmentLocationCity == input.AppointmentLocationCity ||
                    (this.AppointmentLocationCity != null &&
                    this.AppointmentLocationCity.Equals(input.AppointmentLocationCity))
                ) && 
                (
                    this.AppointmentLocationState == input.AppointmentLocationState ||
                    (this.AppointmentLocationState != null &&
                    this.AppointmentLocationState.Equals(input.AppointmentLocationState))
                ) && 
                (
                    this.AppointmentLocationZip == input.AppointmentLocationZip ||
                    (this.AppointmentLocationZip != null &&
                    this.AppointmentLocationZip.Equals(input.AppointmentLocationZip))
                ) && 
                (
                    this.FundingTeamEmail == input.FundingTeamEmail ||
                    (this.FundingTeamEmail != null &&
                    this.FundingTeamEmail.Equals(input.FundingTeamEmail))
                ) && 
                (
                    this.PropertyStreetAddress == input.PropertyStreetAddress ||
                    (this.PropertyStreetAddress != null &&
                    this.PropertyStreetAddress.Equals(input.PropertyStreetAddress))
                ) && 
                (
                    this.PropertyCity == input.PropertyCity ||
                    (this.PropertyCity != null &&
                    this.PropertyCity.Equals(input.PropertyCity))
                ) && 
                (
                    this.PropertyState == input.PropertyState ||
                    (this.PropertyState != null &&
                    this.PropertyState.Equals(input.PropertyState))
                ) && 
                (
                    this.PropertyZip == input.PropertyZip ||
                    (this.PropertyZip != null &&
                    this.PropertyZip.Equals(input.PropertyZip))
                ) && 
                (
                    this.SettlementOfficeEmail == input.SettlementOfficeEmail ||
                    (this.SettlementOfficeEmail != null &&
                    this.SettlementOfficeEmail.Equals(input.SettlementOfficeEmail))
                ) && 
                (
                    this.SettlementOfficeName == input.SettlementOfficeName ||
                    (this.SettlementOfficeName != null &&
                    this.SettlementOfficeName.Equals(input.SettlementOfficeName))
                ) && 
                (
                    this.SettlementOfficeAddress == input.SettlementOfficeAddress ||
                    (this.SettlementOfficeAddress != null &&
                    this.SettlementOfficeAddress.Equals(input.SettlementOfficeAddress))
                ) && 
                (
                    this.SettlementOfficeCity == input.SettlementOfficeCity ||
                    (this.SettlementOfficeCity != null &&
                    this.SettlementOfficeCity.Equals(input.SettlementOfficeCity))
                ) && 
                (
                    this.SettlementOfficeState == input.SettlementOfficeState ||
                    (this.SettlementOfficeState != null &&
                    this.SettlementOfficeState.Equals(input.SettlementOfficeState))
                ) && 
                (
                    this.SettlementOfficeZip == input.SettlementOfficeZip ||
                    (this.SettlementOfficeZip != null &&
                    this.SettlementOfficeZip.Equals(input.SettlementOfficeZip))
                ) && 
                (
                    this.AdditionalFileContactEmails == input.AdditionalFileContactEmails ||
                    this.AdditionalFileContactEmails != null &&
                    input.AdditionalFileContactEmails != null &&
                    this.AdditionalFileContactEmails.SequenceEqual(input.AdditionalFileContactEmails)
                ) && 
                (
                    this.Borrowers == input.Borrowers ||
                    this.Borrowers != null &&
                    input.Borrowers != null &&
                    this.Borrowers.SequenceEqual(input.Borrowers)
                ) && 
                (
                    this.ClosingUsers == input.ClosingUsers ||
                    this.ClosingUsers != null &&
                    input.ClosingUsers != null &&
                    this.ClosingUsers.SequenceEqual(input.ClosingUsers)
                ) && 
                (
                    this.SettlementAgents == input.SettlementAgents ||
                    this.SettlementAgents != null &&
                    input.SettlementAgents != null &&
                    this.SettlementAgents.SequenceEqual(input.SettlementAgents)
                ) && 
                (
                    this.ExternalIdentifiers == input.ExternalIdentifiers ||
                    this.ExternalIdentifiers != null &&
                    input.ExternalIdentifiers != null &&
                    this.ExternalIdentifiers.SequenceEqual(input.ExternalIdentifiers)
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
                if (this.FileNumber != null)
                    hashCode = hashCode * 59 + this.FileNumber.GetHashCode();
                if (this.ReferenceId != null)
                    hashCode = hashCode * 59 + this.ReferenceId.GetHashCode();
                if (this.Source != null)
                    hashCode = hashCode * 59 + this.Source.GetHashCode();
                if (this.SigningMethod != null)
                    hashCode = hashCode * 59 + this.SigningMethod.GetHashCode();
                if (this.AppointmentEarliestAt != null)
                    hashCode = hashCode * 59 + this.AppointmentEarliestAt.GetHashCode();
                if (this.AppointmentLatestAt != null)
                    hashCode = hashCode * 59 + this.AppointmentLatestAt.GetHashCode();
                if (this.AppointmentDate != null)
                    hashCode = hashCode * 59 + this.AppointmentDate.GetHashCode();
                if (this.AppointmentTime != null)
                    hashCode = hashCode * 59 + this.AppointmentTime.GetHashCode();
                if (this.AppointmentLocationAddress != null)
                    hashCode = hashCode * 59 + this.AppointmentLocationAddress.GetHashCode();
                if (this.AppointmentLocationCity != null)
                    hashCode = hashCode * 59 + this.AppointmentLocationCity.GetHashCode();
                if (this.AppointmentLocationState != null)
                    hashCode = hashCode * 59 + this.AppointmentLocationState.GetHashCode();
                if (this.AppointmentLocationZip != null)
                    hashCode = hashCode * 59 + this.AppointmentLocationZip.GetHashCode();
                if (this.FundingTeamEmail != null)
                    hashCode = hashCode * 59 + this.FundingTeamEmail.GetHashCode();
                if (this.PropertyStreetAddress != null)
                    hashCode = hashCode * 59 + this.PropertyStreetAddress.GetHashCode();
                if (this.PropertyCity != null)
                    hashCode = hashCode * 59 + this.PropertyCity.GetHashCode();
                if (this.PropertyState != null)
                    hashCode = hashCode * 59 + this.PropertyState.GetHashCode();
                if (this.PropertyZip != null)
                    hashCode = hashCode * 59 + this.PropertyZip.GetHashCode();
                if (this.SettlementOfficeEmail != null)
                    hashCode = hashCode * 59 + this.SettlementOfficeEmail.GetHashCode();
                if (this.SettlementOfficeName != null)
                    hashCode = hashCode * 59 + this.SettlementOfficeName.GetHashCode();
                if (this.SettlementOfficeAddress != null)
                    hashCode = hashCode * 59 + this.SettlementOfficeAddress.GetHashCode();
                if (this.SettlementOfficeCity != null)
                    hashCode = hashCode * 59 + this.SettlementOfficeCity.GetHashCode();
                if (this.SettlementOfficeState != null)
                    hashCode = hashCode * 59 + this.SettlementOfficeState.GetHashCode();
                if (this.SettlementOfficeZip != null)
                    hashCode = hashCode * 59 + this.SettlementOfficeZip.GetHashCode();
                if (this.AdditionalFileContactEmails != null)
                    hashCode = hashCode * 59 + this.AdditionalFileContactEmails.GetHashCode();
                if (this.Borrowers != null)
                    hashCode = hashCode * 59 + this.Borrowers.GetHashCode();
                if (this.ClosingUsers != null)
                    hashCode = hashCode * 59 + this.ClosingUsers.GetHashCode();
                if (this.SettlementAgents != null)
                    hashCode = hashCode * 59 + this.SettlementAgents.GetHashCode();
                if (this.ExternalIdentifiers != null)
                    hashCode = hashCode * 59 + this.ExternalIdentifiers.GetHashCode();
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
