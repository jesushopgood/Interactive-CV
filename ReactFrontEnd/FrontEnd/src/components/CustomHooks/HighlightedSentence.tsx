/* eslint-disable react-hooks/refs */
import { useRef } from "react";
import { StringHelper, type Segments } from "./Libraries/StringHelper";

interface HighlightedSentenceProps
{
    sentence: string;
    delimeter?: string | null;
    word?: string | null;
    position?: number | null
}

export default function HighlightedSentence({ sentence, delimeter = null, word = null, position = null } : HighlightedSentenceProps){
    const stringHelperRef = useRef<StringHelper>(new StringHelper());
    let segments: string | Segments = "";
    
    if (delimeter)
        segments = stringHelperRef.current.getDelimitedSegments(sentence, delimeter);
    else if (word && position)   
        segments = stringHelperRef.current.getWordSegments(sentence, word, position)

    return stringHelperRef.current.isSegment(segments) ? (
        <span>
            {segments.parts[0]}
            <strong>{segments.word}&nbsp;</strong>
            {segments.parts[1]}
        </span>
    ) : <span>{segments}</span>
}