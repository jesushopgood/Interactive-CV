import { useEffect } from "react";

export default function useBlinkingMessage(callback: (s:string) => void, message: string, delay: number){

    useEffect(() =>{
        let visible = true;
        
        const id = setInterval(() => {
            if (visible)
                callback(message);
            else    
                callback("");

            visible = !visible;
        },delay)

        return () => clearInterval(id);
    }, [callback, message, delay]);
}