import { useState } from "react";

function useLocalStorage(key: string, defaultValue: string){
    
    const [storedValue, setStoredValue] = useState(() => {
        try{
            const item = window.localStorage.getItem(key);
            return item ? JSON.parse(item) : defaultValue;
        }
        catch(err){
            console.log(err);
            return defaultValue;
        }
    })

    const setValue = (value: string) => {
        try{
            const json = JSON.stringify(value);
            setStoredValue(value);
            window.localStorage.setItem(key, json);
        }
        catch(err){
            console.error(err)
        }
    }

    return [storedValue, setValue];
}

export default function LocalStorageClient(){

    const [theme, setTheme] = useLocalStorage("theme", "Winter");
    
    return (
        <div className="container-fluid">
            <h2 className="fs-4 mb-2">Current Theme: {theme}</h2>
            
            <div className="d-flex justify-content-start mt-2">
                <button className="btn btn-primary me-2" onClick={() => setTheme("Spring")}>Spring</button>
                <button className="btn btn-primary me-2" onClick={() => setTheme("Summer")}>Summer</button>
                <button className="btn btn-primary me-2" onClick={() => setTheme("Autumn")}>Autumn</button>
                <button className="btn btn-primary me-2" onClick={() => setTheme("Winter")}>Winter</button>
            </div>
        </div>
    )
}

