using System.Collections.Generic;
using Umbraco.Core;
using Umbraco.Core.PropertyEditors;

namespace Umbraco.Web.PropertyEditors
{
    /// <summary>
    /// Media picker property editors that stores UDI
    /// </summary>
    [PropertyEditor(Constants.PropertyEditors.MediaPicker2Alias, "Media Picker", PropertyEditorValueTypes.Text, "mediapicker", IsParameterEditor = true, Group = "media", Icon = "icon-picture")]
    public class MediaPicker2PropertyEditor : PropertyEditor
    {
        public MediaPicker2PropertyEditor()
        {
            InternalPreValues = new Dictionary<string, object>
            {
                {"idType", "udi"}
            };
        }

        internal IDictionary<string, object> InternalPreValues;
        
        public override IDictionary<string, object> DefaultPreValues
        {
            get { return InternalPreValues; }
            set { InternalPreValues = value; }
        }

        protected override PreValueEditor CreatePreValueEditor()
        {
            return new MediaPickerPreValueEditor();
        }

        internal class MediaPickerPreValueEditor : PreValueEditor
        {
            public MediaPickerPreValueEditor()
            {
                Fields.Add(new PreValueField()
                {
                    Key = "minNumber",
                    View = "number",
                    Name = "Min. items",
                    Description = "Mininum number of items allowed."                    
                });
                Fields.Add(new PreValueField()
                {
                    Key = "maxNumber",
                    View = "number",
                    Name = "Max. items",
                    Description = "Maximum number of items allowed."
                });
                Fields.Add(new PreValueField()
                {
                    Key = "onlyImages",
                    View = "boolean",
                    Name = "Pick only images",
                    Description = "Only let the editor choose images from media."
                });
                Fields.Add(new PreValueField()
                {
                    Key = "disableFolderSelect",
                    View = "boolean",
                    Name = "Disable folder select",
                    Description = "Do not allow folders to be picked."
                });
                Fields.Add(new PreValueField()
                {
                    Key = "startNodeId",
                    View = "mediapicker",
                    Name = "Start node",
                    Config = new Dictionary<string, object>
                    {
                        {"idType", "udi"}
                    }
                });                
            }
        }
    }
}
