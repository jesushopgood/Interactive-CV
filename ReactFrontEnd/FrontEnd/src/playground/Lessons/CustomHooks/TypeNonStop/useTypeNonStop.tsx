import { useRef, useState } from "react";

export default function useTypeNonStop(warningDelay: number, finalWarningDelay: number){
    const [typed, setTyped] = useState("");
    const [warning, setWarning] = useState(false);
    const [finalWarning, setFinalWarning] = useState(false);

    const warningTimeoutRef = useRef<number | null>(null);
    const finalWarningTimeoutFocus = useRef<number | null>(null);

    const setTypedValue = (value: string) => {
        setTyped(value);
        setWarning(false);
        setFinalWarning(false);

        if (warningTimeoutRef.current) clearTimeout(warningTimeoutRef.current);
        if (finalWarningTimeoutFocus.current) clearTimeout(finalWarningTimeoutFocus.current);

        warningTimeoutRef.current = setTimeout(() => {
            setWarning(true);
        },warningDelay)

        finalWarningTimeoutFocus.current = setTimeout(() => {
            setFinalWarning(true);
        }, finalWarningDelay)
    }

    return { typed, warning, finalWarning, setTypedValue}
}