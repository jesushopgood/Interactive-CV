using StoreFrontUK.Services.Common.Repository;

namespace StoreFrontUK.GlobalObjects.Common;

public record TableQueryOptions<T> where T : class
{
    public List<T> EntityList { get; set; } = new();

    public int TotalRowCount { get; set; }
}