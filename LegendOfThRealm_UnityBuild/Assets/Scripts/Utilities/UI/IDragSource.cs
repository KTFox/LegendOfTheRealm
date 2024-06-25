namespace LegendOfTheRealm.Utilities.UI
{
    public interface IDragSource<T> where T : class
    {
        T Item { get; }
        int Quantity { get; }

        void RemoveItems(int quantity);
    }
}
