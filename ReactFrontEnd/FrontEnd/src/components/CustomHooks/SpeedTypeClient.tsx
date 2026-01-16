/* eslint-disable react-hooks/exhaustive-deps */
/* eslint-disable react-hooks/set-state-in-effect */

import { useEffect, useRef, useState } from "react";
import { StringHelper, type Segments } from "./Libraries/StringHelper";

const masterMessage1 = "He added: It is two weeks until we play our next league game, we need to stick our heads together and find solutions for that because in the second half of the season there are many points to play for, but as I keep saying, we need to be more resilient.";
const masterMessage2 = "Domestically, he's coming under pressure to condemn the military action, obviously as a leader of a country that respects the international rule of law, On the global stage, the prime minister is aware more than anyone that he needs to keep Donald Trump onside.";
const masterMessage3 = "Sir Keir Starmer is facing ongoing cabinet-level opposition to the business rates increase which is due to come into force on 1 April, Sky News understands. Meanwhile, the PM is heading to Paris later today, for a meeting of the Coalition of the Willing.";
const messages = [masterMessage1, masterMessage2, masterMessage3];

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

function useSpeedType({ masterMessage, message, initialInterval, minCharsPerInterval }: UseSpeedTypeProps) {
    const [speedResult, setSpeedResult] = useState<UseSpeedTypeResult>({ message: "", resultMessage: "Let's Go!!", success: true });
    const lastMessageRef = useRef("");
    const lastIntervalMessageRef = useRef("");
    const messageRef = useRef(message);
    const activeIntervalId = useRef<ReturnType<typeof setInterval>>(0);

    const stringHelperRef = useRef<StringHelper | null>(null);
    if (!stringHelperRef.current) stringHelperRef.current = new StringHelper();

    function success(message: string, extra?: Partial<UseSpeedTypeResult>){
        setSpeedResult({
            message,
            resultMessage: "",
            success: true,
            ...extra
        });
    }

    function fail(resultMessage: string, extra?: Partial<UseSpeedTypeResult>) {
        clearInterval(activeIntervalId.current);
        setSpeedResult({
            message: "FAILED!!",
            resultMessage,
            success: false,
            ...extra
        });
    }

    function handleInvalidDeleteKeyPress() {
        deleteInterval(activeIntervalId.current);
        fail("GAME OVER: No deletes allowed!!");
    }

    function handleBadKeypress(currentMessageLength: number) {
        deleteInterval(activeIntervalId.current);
        const endOfWord = currentMessageLength - 1;
        const goodWord = stringHelperRef.current!.getWordAtPosition(masterMessage, endOfWord);
        const badWord = stringHelperRef.current!.getWordAtPosition(messageRef.current, endOfWord);
        fail(`GAME OVER: You typed a wrong key in the word "${goodWord}" you typed '${badWord}' !!`, {goodWord, goodWordPosition: endOfWord})
    }

    const deleteInterval = (intervalId: number) => {
        if (intervalId !== null && intervalId !== undefined) clearInterval(intervalId);
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
            const deletePressed = currentMessageLength < lastMessageRef.current.length; 
            const badKeyPressed = messageRef.current !== masterMessage.slice(0, currentMessageLength);
            
            if (deletePressed) return handleInvalidDeleteKeyPress();    
            if (badKeyPressed) return handleBadKeypress(currentMessageLength);
            
            success(message);
        }
        else{
            success(message);
        }

        lastMessageRef.current = message;
    }, [message, masterMessage]);

    
    useEffect(() => {       
        activeIntervalId.current = setInterval(() => {            
            const newCharactersCount = messageRef.current.length - lastIntervalMessageRef.current.length;
            lastIntervalMessageRef.current = messageRef.current;
            lastMessageRef.current = messageRef.current;
            
            if (newCharactersCount < minCharsPerInterval) {
                fail(`GAME OVER: BOOOOOM!! Only ${newCharactersCount} chars typed!!!!!!`)
            } else {
                success(messageRef.current, {resultMessage: `Keep going ${newCharactersCount} chars typed`});
            }
        }, initialInterval);

        return () => deleteInterval(activeIntervalId.current);

    }, [masterMessage, initialInterval, minCharsPerInterval]);

    return speedResult;
}


export function SpeedTypeClient(){
    const [message, setMessage] = useState("");
    const [masterMessageIndex, setMasterMessageIndex] = useState(0);

    const result = useSpeedType({masterMessage: messages[masterMessageIndex], 
        message, 
        initialInterval: 10000, 
        minCharsPerInterval: 10} as UseSpeedTypeProps);

    const textAreaRef = useRef<HTMLTextAreaElement | null>(null);

    const updateMessage = (e: React.FormEvent<HTMLTextAreaElement>, val: string) => {
        e.preventDefault();
        setMessage(val);
    }

    const restart = (e: React.FormEvent<HTMLButtonElement>) => {
        setMasterMessageIndex(prev => prev === messages.length - 1 ? 0 : prev + 1);
        setMessage("");
        e.preventDefault();
        textAreaRef.current?.focus();
    }

    return(
        <form>
            <div className="mb-3">
                {
                    result.goodWord && result.goodWordPosition ?
                        <HighlightedSentence sentence={messages[masterMessageIndex]} word={result.goodWord} position={result.goodWordPosition}/> :
                        <p>{messages[masterMessageIndex]}</p> 
                }
                
            </div>
            
            <HighlightedSentence sentence={result.resultMessage} delimeter="&quot;" />
            
            <div className="mb-3">
                <label htmlFor="speed-window" className="form-label" />
                <textarea ref={textAreaRef}
                    className="form-control" 
                    id="speed-window" 
                    value={result.message} 
                    onChange={(e) => updateMessage(e, e.target.value)}  />
            </div>
            <div className="mb-3">
                <button className="btn btn-primary" onClick={(e) => restart(e)}>Restart</button>
            </div>
        </form>
    )
}

interface HighlightedSentenceProps
{
    sentence: string;
    delimeter?: string | null;
    word?: string | null;
    position?: number | null
}

function HighlightedSentence({ sentence, delimeter = null, word = null, position = null } : HighlightedSentenceProps){
    const stringHelperRef = useRef<StringHelper>(new StringHelper());
    let segments: string | Segments = "";
    
    if (delimeter)
        segments = stringHelperRef.current.getDelimitedSegments(sentence, delimeter);
    else if (word && position)   
        segments = stringHelperRef.current.getWordSegments(sentence, word, position)

    return stringHelperRef.current.isSegment(segments) ? (
        <span>
            {segments.parts[0]}
            <strong className="fs-5">{segments.word}&nbsp;</strong>
            {segments.parts[1]}
        </span>
    ) : <span>{segments}</span>
}