import { useRef } from "react";
import { StringHelper } from "../../CustomHooks/Libraries/StringHelper";
import type { ICustomer } from "../../../api/entities/ICustomer";

interface ReadOnlyInputProps<T>
{
    id?: string;
    value: string;
    isReadOnly: boolean;
    formData: T
    onEdit: (newData: T) => void;
    fieldName: string;
}

export default function ToggledReadOnlyInput<T>({id, value, isReadOnly, onEdit, formData, fieldName} : ReadOnlyInputProps<T>){

    const stringHelper = new StringHelper();

    return (
        <input 
            id={id}
            className={`form-control ${isReadOnly ? "" : "editable"}`} 
            value={value}
            readOnly={isReadOnly}
            onChange={(e) => onEdit(stringHelper.setByPath<T>(formData, fieldName, e.target.value))}
        />
    )
}