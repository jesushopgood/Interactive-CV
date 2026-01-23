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
    return (
        <input 
            id={id}
            className={`form-control ${isReadOnly ? "" : "editable"}`} 
            value={value}
            readOnly={isReadOnly}
            onChange={(e) => onEdit({...formData, [fieldName]: e.target.value})}
        />
    )
}