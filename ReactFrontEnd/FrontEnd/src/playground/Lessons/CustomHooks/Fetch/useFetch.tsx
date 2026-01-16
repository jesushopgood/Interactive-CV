import { useEffect, useState } from "react";

export default function useFetch<T = unknown>(url: string){
    //error, data, loading
    const [data, setData] = useState<T | null>(null);
    const [error, setError] = useState<Error | null>(null);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        (async () => {
            try{
                const response = await fetch(url);
                const data = await response.json();
                setData(data as T);
                setLoading(false);
            }
            catch(ex){
                setError(ex as Error);
                setLoading(false);
            }
        })();
    }, [url]);

    return  [data, error, loading];
}