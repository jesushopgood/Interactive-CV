/* eslint-disable react-hooks/set-state-in-effect */
import { useEffect, useState } from "react";

const products = ["Chicken Wings", "Chicken Nuggets", "Cheese Strips", "Cheese Toast", "Pork Scratchings"];


function useDebounce(value: string, delay: number){
    const [debouncedValue, setDebouncedValue] = useState(value);

    useEffect(() => {        
        const handler = setTimeout(() => setDebouncedValue(value), delay);
        return () => clearTimeout(handler);
    }, [value, delay])

    return debouncedValue;
}

export default function DebounceClient(){
    const [query, setQuery] = useState("");
    const deboucedValue = useDebounce(query, 1000);
    const [searchResults, setSearchResults] = useState<Array<string>>([]);

    useEffect(() => {
        if(deboucedValue){
            const foundProducts = products.filter(x => x.toLowerCase().indexOf(deboucedValue.toLowerCase()) === 0);
            setSearchResults(foundProducts);
        }
    }, [deboucedValue]);

    return (
        <form>
            <div className="mb-3">
                <label className="form-label" htmlFor="search-box">Search</label>
                <input id="search-box" className="form-control" value={query} onChange={e => setQuery(e.target.value)} />
            </div>
            <div>
                { searchResults && 
                    <ul className="list-unstyled">
                    { 
                        searchResults.map((val, idx) => <li key={idx}>{val}</li>)
                    }
                    </ul>
                }
            </div>
        </form>
    )
}
