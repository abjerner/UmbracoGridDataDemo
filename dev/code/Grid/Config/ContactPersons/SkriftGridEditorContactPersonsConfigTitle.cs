using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Umbraco.GridData.Json;

namespace SkriftGridDemo.Grid.Config.ContactPersons {
    
    public class SkriftGridEditorContactPersonsConfigTitle : GridJsonObject {

        #region Properties
        
        public bool Show { get; private set; }

        public string Placeholder { get; set; }

        public string Default { get; private set; }

        #endregion

        #region Constructors

        private SkriftGridEditorContactPersonsConfigTitle(JObject obj) : base(obj) {
            Show = obj.GetBoolean("show");
            Placeholder = obj.GetString("placeholder");
            Default = obj.GetString("default");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="SkriftGridEditorContactPersonsConfigTitle"/> from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SkriftGridEditorContactPersonsConfigTitle"/>.</returns>
        public static SkriftGridEditorContactPersonsConfigTitle Parse(JObject obj) {
            return new SkriftGridEditorContactPersonsConfigTitle(obj ?? new JObject());
        }

        #endregion
    
    }

}