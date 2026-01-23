/* eslint-disable react-hooks/refs */
import { flexRender, type Table } from "@tanstack/react-table";
import type { ICustomer } from "../../api/entities/ICustomer";
import { DebouncedColumnFilter } from "./DebouncedColumnFilter";
import type EntityHandlers from "../StoreFrontUK/Common/EntityHandlers";

interface EntityTableListProps extends EntityHandlers<string>
{
    table: Table<ICustomer>;    
}

export default function EntityListTable({table, onSelectEntity} : EntityTableListProps){
    return(
        <table className="table table-hover table-striped table-fixed">
        <thead>
            {table.getHeaderGroups().map(headerGroup => (
                <tr key={headerGroup.id}>
                    {headerGroup.headers.map(header => (
                        <th key={header.id}>
                            <div onClick={header.column.getToggleSortingHandler()} style={{ cursor: "pointer" }}>
                                {/* flexRender will safely render if value, function or a react node */}
                                {!header.isPlaceholder && flexRender(header.column.columnDef.header, header.getContext())}
                                {header.column.getIsSorted() === "asc" && " ▲"}
                                {header.column.getIsSorted() === "desc" && " ▼"}
                            </div>
                            <div className="my-2 me-1">
                                {header.column.getCanFilter() && ( 
                                    <DebouncedColumnFilter<ICustomer>
                                        key={header.column.id} 
                                        column={header.column}                                     />
                                )}
                            </div>
                        </th>
                    ))}
                </tr>
            ))}
        </thead>
        <tbody>
            {table.getRowModel().rows.map(row => (
                <tr key={row.id} className="clickable" onClick={() => onSelectEntity?.(row.original.customerId)}>
                    {row.getVisibleCells().map(cell => (
                        <td key={cell.id}>
                            {flexRender(cell.column.columnDef.cell, cell.getContext())}
                        </td>
                    ))}
                </tr>
            ))}
        </tbody>
    </table>
    )
}