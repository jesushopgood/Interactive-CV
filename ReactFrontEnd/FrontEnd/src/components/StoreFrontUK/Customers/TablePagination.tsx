import type { Table } from "@tanstack/react-table";

interface TablePaginationProps<T>
{
    table: Table<T>;
    onRefresh: () => void;
}

export default function TablePagination<T>({table, onRefresh} : TablePaginationProps<T>){
    return(
        <div className="d-flex justify-content-between align-items-center mb-3">
            <div>
                Page <strong>{table.getState().pagination.pageIndex + 1}</strong> of {table.getPageCount()}
            </div>
            <div className="btn-group">
                <button className="btn btn-sm btn-outline-primary" onClick={() => table.previousPage()} 
                                        disabled={!table.getCanPreviousPage()}>
                    Previous
                </button>
                <button className="btn btn-sm btn-outline-primary" onClick={() => table.nextPage()} 
                                        disabled={!table.getCanNextPage()}>
                    Next
                </button>
            </div>
        </div>
    )       
}