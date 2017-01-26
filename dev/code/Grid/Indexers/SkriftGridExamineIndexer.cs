using System;
using Examine;
using Examine.Providers;
using Skybrud.Umbraco.GridData;
using Umbraco.Core.Logging;

namespace SkriftGridDemo.Grid.Indexers {

    public class SkriftGridExamineIndexer {

        private SkriftGridExamineIndexer() {

            BaseIndexProvider externalIndexer = ExamineManager.Instance.IndexProviderCollection["ExternalIndexer"];

            externalIndexer.GatheringNodeData += OnExamineGatheringNodeData;

        }

        public static SkriftGridExamineIndexer Init() {
            return new SkriftGridExamineIndexer();
        }

        private void OnExamineGatheringNodeData(object sender, IndexingNodeDataEventArgs e) {

            try {

                string nodeTypeAlias = e.Fields["nodeTypeAlias"];

                if (nodeTypeAlias == "Home" || nodeTypeAlias == "LandingPage" || nodeTypeAlias == "TextPage" || nodeTypeAlias == "BlogPost") {

                    string value;

                    // Just return now if the "content" field wasn't found
                    if (!e.Fields.TryGetValue("content", out value)) return;

                    // Parse the raw JSON into an instance of "GridDataModel"
                    GridDataModel grid = GridDataModel.Deserialize(e.Fields["content"]);
                    
                    // Get the searchable text (based on each control in the grid model)
                    e.Fields["content"] = grid.GetSearchableText();

                }

            } catch (Exception ex) {

                // Remember to change the message added to the log. My colleagues typically doesn't,
                // so I occasionally see "MAYDAY! MAYDAY! MAYDAY!" in our logs :(
                LogHelper.Error<SkriftGridExamineIndexer>("MAYDAY! MAYDAY! MAYDAY!", ex);

            }

        }

    }

}