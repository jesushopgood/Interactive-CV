import { useState, useEffect, useRef } from "react";

interface FetchResult<T> {
  data: T | null;
  error: Error | null;
  loading: boolean;
}

interface CacheEntry<T> {
  data: T;
  timestamp: number;
}

export default function useAdvancedFetch<T = unknown>(
  url: string,
  options: RequestInit = {},
  cacheTime: number = 5000 // default 5 minutes
): FetchResult<T> {
  const cache = useRef<Map<string, CacheEntry<T>>>(new Map());
  const [data, setData] = useState<T | null>(null);
  const [error, setError] = useState<Error | null>(null);
  const [loading, setLoading] = useState<boolean>(false);

  useEffect(() => {
    if (!url) return;

    let isMounted = true;
    const controller = new AbortController();
    const signal = controller.signal;

    async function fetchData() {
      setLoading(true);

      // Check cache
      const cached = cache.current.get(url);
      if (cached && Date.now() - cached.timestamp < cacheTime) {
        console.log("getting cached data");
        setData(cached.data);
        setLoading(false);
        return;
      }

      try {
        const response = await fetch(url, { ...options, signal });
        if (!response.ok) throw new Error(`Error: ${response.status}`);
        const result: T = await response.json();

        if (isMounted) {
          setData(result);
          cache.current.set(url, { data: result, timestamp: Date.now() });
        }
      } catch (err) {
        if (isMounted && err instanceof Error && err.name !== "AbortError") {
          setError(err);
        }
      } finally {
        if (isMounted) setLoading(false);
      }
    }

    fetchData();

    return () => {
      isMounted = false;
      controller.abort();
    };
  }, [url, options, cacheTime]);

  return { data, error, loading };
}