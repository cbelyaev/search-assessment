/* 
 * Searcher API
 *
 * Web API for Searcher Assessment project.
 *
 * OpenAPI spec version: v1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

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
using SwaggerDateConverter = IO.Swagger.Client.SwaggerDateConverter;

namespace IO.Swagger.Model
{
    /// <summary>
    /// FoundItem
    /// </summary>
    [DataContract]
    public partial class FoundItem :  IEquatable<FoundItem>, IValidatableObject
    {
        /// <summary>
        /// Defines ItemType
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ItemTypeEnum
        {
            
            /// <summary>
            /// Enum Unknown for value: Unknown
            /// </summary>
            [EnumMember(Value = "Unknown")]
            Unknown = 1,
            
            /// <summary>
            /// Enum Building for value: Building
            /// </summary>
            [EnumMember(Value = "Building")]
            Building = 2,
            
            /// <summary>
            /// Enum Company for value: Company
            /// </summary>
            [EnumMember(Value = "Company")]
            Company = 3
        }

        /// <summary>
        /// Gets or Sets ItemType
        /// </summary>
        [DataMember(Name="itemType", EmitDefaultValue=false)]
        public ItemTypeEnum? ItemType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="FoundItem" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="itemType">itemType.</param>
        /// <param name="name">name.</param>
        /// <param name="formerName">formerName.</param>
        /// <param name="market">market.</param>
        /// <param name="state">state.</param>
        /// <param name="address">address.</param>
        /// <param name="city">city.</param>
        public FoundItem(int? id = default(int?), ItemTypeEnum? itemType = default(ItemTypeEnum?), string name = default(string), string formerName = default(string), string market = default(string), string state = default(string), string address = default(string), string city = default(string))
        {
            this.Id = id;
            this.ItemType = itemType;
            this.Name = name;
            this.FormerName = formerName;
            this.Market = market;
            this.State = state;
            this.Address = address;
            this.City = city;
        }
        
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public int? Id { get; set; }


        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets FormerName
        /// </summary>
        [DataMember(Name="formerName", EmitDefaultValue=false)]
        public string FormerName { get; set; }

        /// <summary>
        /// Gets or Sets Market
        /// </summary>
        [DataMember(Name="market", EmitDefaultValue=false)]
        public string Market { get; set; }

        /// <summary>
        /// Gets or Sets State
        /// </summary>
        [DataMember(Name="state", EmitDefaultValue=false)]
        public string State { get; set; }

        /// <summary>
        /// Gets or Sets Address
        /// </summary>
        [DataMember(Name="address", EmitDefaultValue=false)]
        public string Address { get; set; }

        /// <summary>
        /// Gets or Sets City
        /// </summary>
        [DataMember(Name="city", EmitDefaultValue=false)]
        public string City { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FoundItem {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  ItemType: ").Append(ItemType).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  FormerName: ").Append(FormerName).Append("\n");
            sb.Append("  Market: ").Append(Market).Append("\n");
            sb.Append("  State: ").Append(State).Append("\n");
            sb.Append("  Address: ").Append(Address).Append("\n");
            sb.Append("  City: ").Append(City).Append("\n");
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
            return this.Equals(input as FoundItem);
        }

        /// <summary>
        /// Returns true if FoundItem instances are equal
        /// </summary>
        /// <param name="input">Instance of FoundItem to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FoundItem input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.ItemType == input.ItemType ||
                    (this.ItemType != null &&
                    this.ItemType.Equals(input.ItemType))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.FormerName == input.FormerName ||
                    (this.FormerName != null &&
                    this.FormerName.Equals(input.FormerName))
                ) && 
                (
                    this.Market == input.Market ||
                    (this.Market != null &&
                    this.Market.Equals(input.Market))
                ) && 
                (
                    this.State == input.State ||
                    (this.State != null &&
                    this.State.Equals(input.State))
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
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.ItemType != null)
                    hashCode = hashCode * 59 + this.ItemType.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.FormerName != null)
                    hashCode = hashCode * 59 + this.FormerName.GetHashCode();
                if (this.Market != null)
                    hashCode = hashCode * 59 + this.Market.GetHashCode();
                if (this.State != null)
                    hashCode = hashCode * 59 + this.State.GetHashCode();
                if (this.Address != null)
                    hashCode = hashCode * 59 + this.Address.GetHashCode();
                if (this.City != null)
                    hashCode = hashCode * 59 + this.City.GetHashCode();
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
