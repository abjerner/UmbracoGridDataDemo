using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Umbraco.GridData.Json;

namespace SkriftGridDemo.Grid.Value.ContactPersons {

    /// <summary>
    /// Class representing a contact person.
    /// </summary>
    public class SkriftContactPersonItem : GridJsonObject {

        #region Properties

        /// <summary>
        /// Gets the name of the contact person.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets whether a name has been specified for the contact person.
        /// </summary>
        public bool HasName {
            get { return !String.IsNullOrWhiteSpace(Name); }
        }

        /// <summary>
        /// Gets the job title of the contact person.
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// Gets whether a job title has been specified for the contact person.
        /// </summary>
        public bool HasTitle {
            get { return !String.IsNullOrWhiteSpace(Title); }
        }

        /// <summary>
        /// Gets the email address of the contact person.
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// Gets whether an email address has been specified for the contact person.
        /// </summary>
        public bool HasEmail {
            get { return !String.IsNullOrWhiteSpace(Email); }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the item.</param>
        protected SkriftContactPersonItem(JObject obj) : base(obj) {
            Name = obj.GetString("name");
            Title = obj.GetString("title");
            Email = obj.GetString("email");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="SkriftContactPersonItem"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SkriftContactPersonItem"/>.</returns>
        public static SkriftContactPersonItem Parse(JObject obj) {
            return obj == null ? null : new SkriftContactPersonItem( obj);
        }

        #endregion

    }

}