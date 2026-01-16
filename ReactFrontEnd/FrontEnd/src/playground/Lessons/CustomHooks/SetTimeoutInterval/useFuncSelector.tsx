import { useEffect, useRef } from "react";

type stringFunc = (s:string) => void;

export default function useFuncSelector(
    func1: stringFunc,
    func2: stringFunc,
    delay: number)
{    
    const fn1 = useRef<stringFunc>(null);
    const fn2 = useRef<stringFunc>(null);
    
    useEffect(() => {
        fn1.current = func1;
        fn2.current = func2;
    });
    
    useEffect(() => {
        const id = setInterval(() => {
            const seconds = new Date().getSeconds();
            if (fn1.current && fn2.current)
            {
                if (seconds % 2 === 0 && fn1.current){
                    fn1.current(`Function 1 Callled ${seconds}`);
                    fn2.current("");
                } 
                else{
                    fn2.current(`Function 2 called ${seconds}`);
                    fn1.current("");
                }
            }
        },delay);

        return () => clearInterval(id);
    }, [func1, func2, delay]);
}