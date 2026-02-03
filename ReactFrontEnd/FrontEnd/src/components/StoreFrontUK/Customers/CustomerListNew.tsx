/* eslint-disable react-hooks/exhaustive-deps */
import { useQuery } from "@tanstack/react-query";
import { postCustomerFilter } from "../../../api/customers";
import type { ICustomer } from "../../../api/entities/ICustomer";
import {
    createColumnHelper,
    useReactTable,
    getCoreRowModel,
    getSortedRowModel,
    getPaginationRowModel,
    type SortingState,
    type PaginationState,
    type ColumnFiltersState,
} from "@tanstack/react-table";
import { useMemo, useState } from "react";
import CustomerAddresses from "./CustomerAdddresses";
import TablePagination from "./TablePagination";
import EntityListTable from "../../Common/EntityListTable";
import type EntityListProps from "../Common/EntityHandlers";

export default function CustomerListNew({ onSelectEntity, onCreateEntity }: EntityListProps<string>) {

    //Store objects for Sorting, Pagination, Filtering
    const [tableSortingState, setTableSortingState] = useState<SortingState>([]);
    const [tablePaginationState, setTablePaginationState] = useState<PaginationState>({ pageIndex: 0, pageSize: 10 });
    const [columnFilters, setColumnFilters] = useState<ColumnFiltersState>([]);    

    const queryKeyFilters = useMemo(() => ({
        sortingState: tableSortingState,
        paginationState: tablePaginationState,
        columnFilterState: columnFilters
    }), [tableSortingState, tablePaginationState, columnFilters]);

    const { data, isLoading, error } = useQuery({
        //Acts as a caching key for data.  The query will use the cache if the key is the same or 
        //the staleTime expires...
        queryKey: ["customers", queryKeyFilters],
        queryFn: () =>
            postCustomerFilter(queryKeyFilters),
        staleTime: 1000 * 60 * 1
    });

    const columns = useMemo(() => {
        const columnHelper = createColumnHelper<ICustomer>();

        return [
            columnHelper.accessor("customerName.title", {
                header: "Title"
            }),
            columnHelper.accessor("customerName.firstName", {
                header: "First Name",
            }),
            columnHelper.accessor("customerName.surname", {
                header: "Surname",
            }),
            columnHelper.accessor("customerEmailAddress", {
                header: "Email Address",
                cell: info => {
                    const parts = info.getValue().split("@");
                    return parts[0].concat("@", "\n", parts[1]);
                }
            }),
            columnHelper.accessor(
                row => Array.isArray(row.addresses) ? row.addresses : [],
                {
                    id: "addresses",
                    header: "Addresses",
                    cell: info => <CustomerAddresses data={info.getValue()} />,
                    enableSorting: false,
                    enableColumnFilter: false
                }
            )
        ];
    }, []);
    
    const getPageCount = () => {
        const totalRecords = data?.totalRowCount ?? 0;
        return Math.ceil(totalRecords / tablePaginationState.pageSize);    
    }
    
    const table = useReactTable({
        data: data ? data.entityList : [],
        columns,
        getCoreRowModel: getCoreRowModel(),
        getSortedRowModel: getSortedRowModel(),
        getPaginationRowModel: getPaginationRowModel(),
        pageCount: getPageCount(),
        
        state: {
            sorting: tableSortingState,
            pagination: tablePaginationState,
            columnFilters,
        },

        onSortingChange: setTableSortingState,
        onPaginationChange: setTablePaginationState,
        onColumnFiltersChange: setColumnFilters,

        manualSorting: true,
        manualPagination: true,
        manualFiltering: true,
    });

    if (isLoading) return <p>Loading...</p>;
    if (error) return <p>Something went wrong {error.message}</p>;

    return (
        <>
            <TablePagination onCreate={onCreateEntity} table={table} />
            <EntityListTable table={table} onSelectEntity={onSelectEntity}/>    
            <TablePagination onCreate={onCreateEntity} table={table}  />
        </>
    );
}