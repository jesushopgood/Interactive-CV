import { useEffect } from "react";

export default function useWindowTicker(messages: string[], delay:number){

    useEffect(() => {
        let idx = 0;
        const id = setInterval(() => {
            document.title = messages[idx];
            idx = (idx + 1) % messages.length;
        },delay);

        return () => clearTimeout(id);
    },[messages, delay]);
}