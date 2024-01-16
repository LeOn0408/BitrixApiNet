using BitrixApiNet.Item.Crm;

namespace BitrixApiNet.Factory.Crm
{
    public interface IBase<T> where T : CrmItem
    {
        int CreateItem(T item);
        bool DeleteItem(int id);
        CrmItem Get(int id);
        ICollection<CrmItem> GetItems(QueryParameters queryParameters);
        bool UpdateItem(CrmItem item);
    }
}