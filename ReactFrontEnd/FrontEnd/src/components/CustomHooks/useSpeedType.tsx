/* eslint-disable react-hooks/exhaustive-deps */
/* eslint-disable react-hooks/set-state-in-effect */
import { useEffect, useRef, useState } from "react";
import { StringHelper } from "./Libraries/StringHelper";

export interface UseSpeedTypeProps
{
    isStart: boolean;
    masterMessage: string;
    message: string;
    initialInterval: number;
    minCharsPerInterval: number;
}

export interface UseSpeedTypeResult
{
    message: string;
    success: boolean;
    resultMessage: string;
    goodWord?: string;
    goodWordPosition?: number;
}

export default function useSpeedType({ masterMessage, message, initialInterval, minCharsPerInterval }: UseSpeedTypeProps) {
    const [speedResult, setSpeedResult] = useState<UseSpeedTypeResult>({ message: "", resultMessage: "Let's Go!!", success: true });
    const lastMessageRef = useRef("");
    const lastIntervalMessageRef = useRef("");
    const messageRef = useRef(message);
    const activeIntervalId = useRef<number>(0);
    const stringHelper = useRef<StringHelper>(new StringHelper());

    function handleInvalidDeleteKeyPress() {
        deleteInterval(activeIntervalId.current);
        setSpeedResult({ message: "FAILED!!", resultMessage: "GAME OVER: No deletes allowed!!", success: false });
    }

    function handleBadKeypress(currentMessageLength: number) {
        deleteInterval(activeIntervalId.current);
        const endOfWord = currentMessageLength - 1;
        const goodWord = stringHelper.current.getWordAtPosition(masterMessage, endOfWord);
        const badWord = stringHelper.current.getWordAtPosition(messageRef.current, endOfWord);
        
        setSpeedResult({
            message: "FAILED!!",
            resultMessage: `GAME OVER: You typed a wrong key in the word "${goodWord}" you typed '${badWord}' !!`,
            success: false,
            goodWord,
            goodWordPosition: endOfWord
        });
    }

    const deleteInterval = (intervalId: number) => {
        if (intervalId){
            clearInterval(intervalId);
        }
    }

    useEffect(() => {
        lastMessageRef.current = "";
        lastIntervalMessageRef.current = "";
    }, [masterMessage])

    useEffect(() => {

        messageRef.current = message;
        
        if (messageRef.current.length > 0)
        {
            const currentMessageLength = messageRef.current.length; 

            if (currentMessageLength < lastMessageRef.current.length){
                handleInvalidDeleteKeyPress();    
            }
            else if (messageRef.current !== masterMessage.slice(0, currentMessageLength)){
                handleBadKeypress(currentMessageLength);
            }
            else{
                setSpeedResult({message: message, resultMessage: "", success: true})
            }
        }
        else{
            setSpeedResult({message: message, resultMessage: "", success: true})
        }

        lastMessageRef.current = message;
    }, [message, masterMessage]);

    
    useEffect(() => {       
        activeIntervalId.current = setInterval(() => {            
            const newCharactersCount = messageRef.current.length - lastIntervalMessageRef.current.length;
            lastIntervalMessageRef.current = messageRef.current;
            lastMessageRef.current = messageRef.current;
            
            if (newCharactersCount < minCharsPerInterval) {
                
                setSpeedResult({ 
                    message: "FAILED!!", 
                    resultMessage: `GAME OVER: BOOOOOM!! Only ${newCharactersCount} chars typed!!!!!!`,
                    success: false
                 });
            } else {
                setSpeedResult({ 
                    message: messageRef.current, 
                    resultMessage: `Keep going ${newCharactersCount} chars typed`,
                    success: true
                });
            }
        }, initialInterval);

        return () => deleteInterval(activeIntervalId.current);

    }, [masterMessage, initialInterval, minCharsPerInterval]);

    return speedResult;
}