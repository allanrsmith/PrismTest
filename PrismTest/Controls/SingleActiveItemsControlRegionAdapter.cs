using Prism.Regions;

namespace PrismTest.Controls
{
    public class SingleActiveItemsControlRegionAdapter : ItemsControlRegionAdapter
    {
        public SingleActiveItemsControlRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        { }

        protected override IRegion CreateRegion()
        {
            return new SingleActiveRegion();
        }
    }
}
