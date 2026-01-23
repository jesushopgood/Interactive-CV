/* eslint-disable react-hooks/exhaustive-deps */
import type { Column } from "@tanstack/react-table";
import { useEffect, useRef, useState } from "react";
import { useDebounce } from "../CustomHooks/DebounceClient";
import useLocalStorage from "../../playground/Lessons/CustomHooks/LocalStorage/useLocalStorage";


interface DebouncedColumnFilterProps<IEntity>
{
    column: Column<IEntity>;
}

/*
1. User hits a key
2. onChange causes setValue 
3. Re-Render
4. filterValue read and new debounceValue gotten
5. useEffect see [debouncedValue] changed and sets the filter with the debounced value
*/
export function DebouncedColumnFilter<Entity>({ column } : DebouncedColumnFilterProps<Entity>) {

    const rawValue = column.getFilterValue();
    const filterValue = typeof rawValue === "string" ? rawValue : "";
    const [value, setValue] = useState(filterValue);
    const debouncedValue = useDebounce(value, 600);
    const inputRef = useRef<HTMLInputElement | null>(null);
    const [focusedInputId, setFocusedInputId] = useLocalStorage<string>("focusId", "null");

    useEffect(() => {
        column.setFilterValue(debouncedValue);
    }, [debouncedValue]);

    useEffect(() => {
        if (inputRef.current?.id === focusedInputId) inputRef.current?.focus();
    },[filterValue])

    const updateFocus = (id: string) => {
        setFocusedInputId(id);
    }

    return (
        <input
            id={column.id}
            ref={inputRef}
            onFocus={() => updateFocus(column.id)}
            className="w-75 me-2"
            value={value}
            onChange={e => setValue(e.target.value)}
            placeholder="Filter..."
        />
    );
}