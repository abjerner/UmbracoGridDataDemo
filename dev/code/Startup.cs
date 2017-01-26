using SkriftGridDemo.Grid.Converters;
using SkriftGridDemo.Grid.Indexers;
using Skybrud.Umbraco.GridData;
using Umbraco.Core;

namespace SkriftGridDemo {

    public class Startup : ApplicationEventHandler {

        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext) {
            
            // Add our custom grid converter
            GridContext.Current.Converters.Add(new SkriftGridConverter());

            // Initialize our custom Examine indexer
            SkriftGridExamineIndexer.Init();

        }

    }

}