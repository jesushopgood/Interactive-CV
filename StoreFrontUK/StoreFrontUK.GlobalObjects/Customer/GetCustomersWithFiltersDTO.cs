public record SortingState
{
    public string Id { get; set; } = string.Empty;
    public bool Desc { get; set; }
}

public record PaginationState
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
}

public record ColumnFilterState
{
    public string Id { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
}

public record GetCustomersWithFiltersDTO
{
    public List<ColumnFilterState> ColumnFilterState { get; set; } = [];

    public PaginationState PaginationState { get; set; } = new();

    public List<SortingState> SortingState { get; set; } = [];
}
