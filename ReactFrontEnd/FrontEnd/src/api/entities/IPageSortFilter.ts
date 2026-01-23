import type { ColumnFiltersState, PaginationState, SortingState } from "@tanstack/react-table";

export interface IPageSortFilter
{
    paginationState: PaginationState;
    sortingState: SortingState;
    columnFilterState: ColumnFiltersState
}