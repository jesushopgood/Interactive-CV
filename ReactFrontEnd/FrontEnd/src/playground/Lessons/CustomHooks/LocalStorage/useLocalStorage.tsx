//Proverbs 14:10: The heart knows its own bitterness, and no stranger shares its joy

import { useState } from "react";

export default function useLocalStorage<T>(key: string, initialValue: T) {
    //create a useState for storedValue than expects an empty function
    const [storedValue, setStoredValue] = useState<T>(() => {
        try{
            //get a var called item from the localstorage
            const item = window.localStorage.getItem(key);
            return item ? JSON.parse(item) : initialValue;
        }   
        catch(ex){
            console.error(ex);
            return initialValue;
        } 
    });

    //create a const function pointer that takes a T or a function that takes and returns T
    const setValue = (value: T | ((value:T) => T)) => {
        try{
            const valueToStore = value instanceof Function ? value(storedValue) : value;
            setStoredValue(valueToStore);
            window.localStorage.setItem(key, JSON.stringify(valueToStore));
        }
        catch(ex){
            console.error(ex);
        }
    }

    return [storedValue, setValue] as const;
}
