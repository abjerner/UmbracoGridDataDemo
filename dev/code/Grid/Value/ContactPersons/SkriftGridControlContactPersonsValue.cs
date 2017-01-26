using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Umbraco.GridData;
using Skybrud.Umbraco.GridData.Values;

namespace SkriftGridDemo.Grid.Value.ContactPersons {

    public class SkriftGridControlContactPersonsValue : GridControlValueBase {

        #region Properties

        /// <summary>
        /// Gets the title of the control value.
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// Gets whether the control value has a title.
        /// </summary>
        public bool HasTitle {
            get { return !String.IsNullOrWhiteSpace(Title); }
        }

        /// <summary>
        /// Gets an array of the items.
        /// </summary>
        public SkriftContactPersonItem[] Items { get; private set; }

        /// <summary>
        /// Gets whether the control value has any items.
        /// </summary>
        public bool HasItems {
            get { return Items.Length > 0; }
        }

        /// <summary>
        /// Gets wether the control value is valid (AKA whether the value has any items).
        /// </summary>
        public override bool IsValid {
            get { return HasItems; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="control"/> and <paramref name="obj"/>.
        /// </summary>
        /// <param name="control">An instance of <see cref="GridControl"/> representing the control.</param>
        /// <param name="obj">An instance of <see cref="JObject"/> representing the value of the control.</param>
        protected SkriftGridControlContactPersonsValue(GridControl control, JObject obj) : base(control, obj) {
            Title = obj.GetString("title");
            Items = obj.GetArrayItems("items", SkriftContactPersonItem.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="SkriftGridControlContactPersonsValue"/>.
        /// </summary>
        /// <param name="control">The parent control.</param>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SkriftGridControlContactPersonsValue"/>.</returns>
        public static SkriftGridControlContactPersonsValue Parse(GridControl control, JObject obj) {
            return obj == null ? null : new SkriftGridControlContactPersonsValue(control, obj);
        }

        #endregion

    }

}