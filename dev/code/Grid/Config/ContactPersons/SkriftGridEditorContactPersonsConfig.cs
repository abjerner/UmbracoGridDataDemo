using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Umbraco.GridData;
using Skybrud.Umbraco.GridData.Interfaces;
using Skybrud.Umbraco.GridData.Json;

namespace SkriftGridDemo.Grid.Config.ContactPersons {
    
    public class SkriftGridEditorContactPersonsConfig : GridJsonObject, IGridEditorConfig {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent editor.
        /// </summary>
        public GridEditor Editor { get; private set; }

        public SkriftGridEditorContactPersonsConfigTitle Title { get; private set; }

        /// <summary>
        /// Gets the maximum allowed amount of items.
        /// </summary>
        public int Limit { get; private set; }

        #endregion

        #region Constructors

        private SkriftGridEditorContactPersonsConfig(GridEditor editor, JObject obj) : base(obj) {
            Editor = editor;
            Title = obj.GetObject("title", SkriftGridEditorContactPersonsConfigTitle.Parse) ?? SkriftGridEditorContactPersonsConfigTitle.Parse(new JObject());
            Limit = obj.GetInt32("limit");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="SkriftGridEditorContactPersonsConfig"/> from the specified
        /// <paramref name="obj"/>.
        /// </summary>
        /// <param name="editor">The parent editor.</param>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SkriftGridEditorContactPersonsConfigTitle"/>.</returns>
        public static SkriftGridEditorContactPersonsConfig Parse(GridEditor editor, JObject obj) {
            return obj == null ? null : new SkriftGridEditorContactPersonsConfig(editor, obj);
        }

        #endregion

    }

}