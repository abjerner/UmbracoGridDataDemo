using Newtonsoft.Json.Linq;
using SkriftGridDemo.Grid.Config.ContactPersons;
using SkriftGridDemo.Grid.Value.ContactPersons;
using Skybrud.Umbraco.GridData;
using Skybrud.Umbraco.GridData.Interfaces;
using Skybrud.Umbraco.GridData.Rendering;

namespace SkriftGridDemo.Grid.Converters {

    public class SkriftGridConverter : IGridConverter {

        /// <summary>
        /// Converts the specified <paramref name="token"/> into an instance of <see cref="IGridControlValue"/>.
        /// </summary>
        /// <param name="control">The parent control.</param>
        /// <param name="token">The instance of <see cref="JToken"/> representing the control value.</param>
        /// <param name="value">The converted value.</param>
        public virtual bool ConvertControlValue(GridControl control, JToken token, out IGridControlValue value) {

            // Just set the value to NULL initially (output parameters must be defined)
            value = null;

            // Check the alias of the grid editor
            switch (control.Editor.Alias) {

                // Handle any further parsing of the value of our grid control
                case "SkriftContactPersons":
                    value = SkriftGridControlContactPersonsValue.Parse(control, token as JObject);
                    break;

            }

            // Return whether our converter supported the editor
            return value != null;

        }

        /// <summary>
        /// Converts the specified <paramref name="token"/> into an instance of <see cref="IGridEditorConfig"/>.
        /// </summary>
        /// <param name="editor"></param>
        /// <param name="token">The instance of <see cref="JToken"/> representing the editor config.</param>
        /// <param name="config">The converted config.</param>
        public virtual bool ConvertEditorConfig(GridEditor editor, JToken token, out IGridEditorConfig config) {

            // Just set the value to NULL initially (output parameters must be defined)
            config = null;

            // Check the alias of the grid editor
            switch (editor.Alias) {

                // Handle any further parsing of the value of our grid editor configugration
                case "SkriftContactPersons":
                    config = SkriftGridEditorContactPersonsConfig.Parse(editor, token as JObject);
                    break;

            }

            // Return whether our converter supported the editor
            return config != null;

        }

        /// <summary>
        /// Gets an instance <see cref="GridControlWrapper"/> for the specified <paramref name="control"/>.
        /// </summary>
        /// <param name="control">The control to be wrapped.</param>
        /// <param name="wrapper">The wrapper.</param>
        public virtual bool GetControlWrapper(GridControl control, out GridControlWrapper wrapper) {

            // Just set the value to NULL initially (output parameters must be defined)
            wrapper = null;

            // Check the alias of the grid editor
            switch (control.Editor.Alias) {

                // Initialize a control wrapper with the correct generic types
                case "SkriftContactPersons":
                    wrapper = control.GetControlWrapper<SkriftGridControlContactPersonsValue, SkriftGridEditorContactPersonsConfig>();
                    break;

            }

            // Return whether our converter supported the editor
            return wrapper != null;

        }

    }

}