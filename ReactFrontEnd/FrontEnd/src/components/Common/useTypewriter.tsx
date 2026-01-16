import { useState, useEffect } from "react";
import { layoutEvents } from "../../event-bus/layoutEvents";

interface TypeWriterProps
{
    text: string;
    speed: number;
}

export default function useTypewriter({text, speed = 40}: TypeWriterProps) {
    const [displayed, setDisplayed] = useState("");

    useEffect(() => {
        setDisplayed("");
        let i = 0;

        const interval = setInterval(() => {
            if (i >= text.length) {
                clearInterval(interval);
                return;
            }
            setDisplayed(prev => {
                if (i === text.length -1) {
                    clearInterval(interval);
                    setTimeout(() => layoutEvents.emit("typewriter:done"), 0);
                    return prev;
                }

                const next = prev + text[i];
                i++;
                return next;
            });
            
        }, speed);
        
        return () => clearInterval(interval);
    }, [text, speed]);

    return displayed;
}