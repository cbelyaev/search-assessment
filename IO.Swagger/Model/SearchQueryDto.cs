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
    /// Represents a search query options.
    /// </summary>
    [DataContract]
    public partial class SearchQueryDto :  IEquatable<SearchQueryDto>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchQueryDto" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected SearchQueryDto() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchQueryDto" /> class.
        /// </summary>
        /// <param name="query">Get or sets the query. (required).</param>
        /// <param name="markets">Gets or sets the sequence of markets to filter results..</param>
        /// <param name="maxResults">Gets or sets the max number of search results..</param>
        public SearchQueryDto(string query = default(string), List<string> markets = default(List<string>), int? maxResults = default(int?))
        {
            // to ensure "query" is required (not null)
            if (query == null)
            {
                throw new InvalidDataException("query is a required property for SearchQueryDto and cannot be null");
            }
            else
            {
                this.Query = query;
            }
            this.Markets = markets;
            this.MaxResults = maxResults;
        }
        
        /// <summary>
        /// Get or sets the query.
        /// </summary>
        /// <value>Get or sets the query.</value>
        [DataMember(Name="query", EmitDefaultValue=false)]
        public string Query { get; set; }

        /// <summary>
        /// Gets or sets the sequence of markets to filter results.
        /// </summary>
        /// <value>Gets or sets the sequence of markets to filter results.</value>
        [DataMember(Name="markets", EmitDefaultValue=false)]
        public List<string> Markets { get; set; }

        /// <summary>
        /// Gets or sets the max number of search results.
        /// </summary>
        /// <value>Gets or sets the max number of search results.</value>
        [DataMember(Name="maxResults", EmitDefaultValue=false)]
        public int? MaxResults { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SearchQueryDto {\n");
            sb.Append("  Query: ").Append(Query).Append("\n");
            sb.Append("  Markets: ").Append(Markets).Append("\n");
            sb.Append("  MaxResults: ").Append(MaxResults).Append("\n");
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
            return this.Equals(input as SearchQueryDto);
        }

        /// <summary>
        /// Returns true if SearchQueryDto instances are equal
        /// </summary>
        /// <param name="input">Instance of SearchQueryDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SearchQueryDto input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Query == input.Query ||
                    (this.Query != null &&
                    this.Query.Equals(input.Query))
                ) && 
                (
                    this.Markets == input.Markets ||
                    this.Markets != null &&
                    this.Markets.SequenceEqual(input.Markets)
                ) && 
                (
                    this.MaxResults == input.MaxResults ||
                    (this.MaxResults != null &&
                    this.MaxResults.Equals(input.MaxResults))
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
                if (this.Query != null)
                    hashCode = hashCode * 59 + this.Query.GetHashCode();
                if (this.Markets != null)
                    hashCode = hashCode * 59 + this.Markets.GetHashCode();
                if (this.MaxResults != null)
                    hashCode = hashCode * 59 + this.MaxResults.GetHashCode();
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