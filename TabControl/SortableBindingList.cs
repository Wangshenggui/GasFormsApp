using System;
using System.Collections.Generic;
using System.ComponentModel;

public class SortableBindingList<T> : BindingList<T>
{
    public SortableBindingList() : base() { }

    public SortableBindingList(IList<T> list) : base(list) { }  // ✅ 添加这一段

    // 其他已有代码保持不变
    private bool isSorted;
    private PropertyDescriptor sortProperty;
    private ListSortDirection sortDirection;

    protected override bool SupportsSortingCore => true;
    protected override bool IsSortedCore => isSorted;
    protected override PropertyDescriptor SortPropertyCore => sortProperty;
    protected override ListSortDirection SortDirectionCore => sortDirection;

    protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
    {
        var items = (List<T>)Items;
        var comparer = new PropertyComparer<T>(prop, direction);
        items.Sort(comparer);
        sortProperty = prop;
        sortDirection = direction;
        isSorted = true;
        OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
    }

    protected override void RemoveSortCore() => isSorted = false;
}


public class PropertyComparer<T> : IComparer<T>
{
    private PropertyDescriptor prop;
    private ListSortDirection direction;

    public PropertyComparer(PropertyDescriptor prop, ListSortDirection direction)
    {
        this.prop = prop;
        this.direction = direction;
    }

    public int Compare(T x, T y)
    {
        object valX = prop.GetValue(x);
        object valY = prop.GetValue(y);

        return direction == ListSortDirection.Ascending
            ? Comparer<object>.Default.Compare(valX, valY)
            : Comparer<object>.Default.Compare(valY, valX);
    }
}
