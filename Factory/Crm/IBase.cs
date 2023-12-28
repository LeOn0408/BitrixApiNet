using BitrixApiNet.Item;

namespace BitrixApiNet.Factory.Crm
{
    public interface IBase<T> where T : EntityItem
    {
        int CreateItem(T item);
        bool DeleteItem(int id);
        EntityItem Get(int id);
        ICollection<EntityItem> GetItems(QueryParameters queryParameters);
        bool UpdateItem(EntityItem item);
    }
}