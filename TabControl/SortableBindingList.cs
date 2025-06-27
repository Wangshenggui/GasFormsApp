using System;
using System.Collections.Generic;
using System.ComponentModel;

/// <summary>
/// 支持排序的 BindingList 实现，适用于数据绑定（如 DataGridView）。
/// </summary>
public class SortableBindingList<T> : BindingList<T>
{
    // 构造函数：创建空列表
    public SortableBindingList() : base() { }

    // 构造函数：从已有列表创建
    public SortableBindingList(IList<T> list) : base(list) { }

    // 当前是否已排序
    private bool isSorted;

    // 当前排序所依据的属性
    private PropertyDescriptor sortProperty;

    // 当前排序方向（升序或降序）
    private ListSortDirection sortDirection;

    // 指示是否支持排序
    protected override bool SupportsSortingCore => true;

    // 当前是否已排序
    protected override bool IsSortedCore => isSorted;

    // 当前排序使用的属性
    protected override PropertyDescriptor SortPropertyCore => sortProperty;

    // 当前排序方向
    protected override ListSortDirection SortDirectionCore => sortDirection;

    /// <summary>
    /// 应用排序逻辑（当绑定控件请求排序时调用）。
    /// </summary>
    /// <param name="prop">要排序的属性</param>
    /// <param name="direction">排序方向</param>
    protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
    {
        // 将 Items 转换为 List<T>，以便调用 Sort()
        var items = (List<T>)Items;

        // 创建属性比较器
        var comparer = new PropertyComparer<T>(prop, direction);

        // 排序列表
        items.Sort(comparer);

        // 保存排序状态
        sortProperty = prop;
        sortDirection = direction;
        isSorted = true;

        // 通知绑定控件数据已重排
        OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
    }

    /// <summary>
    /// 移除排序（但此实现只是标记为未排序，不还原顺序）。
    /// </summary>
    protected override void RemoveSortCore() => isSorted = false;
}

/// <summary>
/// 用于按指定属性对对象进行比较的通用比较器。
/// </summary>
public class PropertyComparer<T> : IComparer<T>
{
    private PropertyDescriptor prop;              // 排序用的属性
    private ListSortDirection direction;          // 排序方向

    public PropertyComparer(PropertyDescriptor prop, ListSortDirection direction)
    {
        this.prop = prop;
        this.direction = direction;
    }

    /// <summary>
    /// 比较两个对象的指定属性值。
    /// </summary>
    public int Compare(T x, T y)
    {
        // 获取属性值
        object valX = prop.GetValue(x);
        object valY = prop.GetValue(y);

        // 使用默认比较器进行比较
        return direction == ListSortDirection.Ascending
            ? Comparer<object>.Default.Compare(valX, valY)
            : Comparer<object>.Default.Compare(valY, valX);
    }
}
