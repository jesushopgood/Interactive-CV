import { useState } from "react";

//the hook takes 2 parameters key and a generic initvalue
export default function useLS<T>(key: string, initialValue: T)
{
    const [storedValue, setStoredValue] = useState(initialValue);

    const getValue = () => {
        const value = window.localStorage.getItem(key);
        const parsedValue = value ? JSON.parse(value) : initialValue;
        setStoredValue(parsedValue);
        return parsedValue;
    }

    const setValue = (val: T | ((val:T) => T)) => {
        const valueToStore = val instanceof Function ? val(storedValue) : val;
        setStoredValue(valueToStore);
        window.localStorage.setItem(key, JSON.stringify(valueToStore));
    }

    return  { getValue, setValue }
}

