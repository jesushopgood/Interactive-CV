import React from "react";
import { useMemo } from "react";

interface RandomNumberProps
{
    totalNumbers: number;
    minNumber: number;
    maxNumber: number;
}

 const useGenerateRandom = function useGenerateRandom({totalNumbers, minNumber, maxNumber}: RandomNumberProps){
    console.log('Re-Render');
    const generateNumbers = useMemo(() => {
        console.log("Rerun useMEmo");
        const numbers: number[] = [];

        for(let i = 1; i <= totalNumbers; i++){
            numbers.push((Math.random() * (maxNumber - minNumber) + minNumber));
        }

        return numbers;
    }, [totalNumbers, minNumber, maxNumber]);

    return generateNumbers;
};

export default useGenerateRandom;