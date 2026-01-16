import { useState } from "react";
import type { QuestionAnswer } from "../questionAnswer";

interface QuestionBodyProps
{
    onSubmitAnswer: (answer: string) => void;
    nextQuestion: QuestionAnswer;
    score: number;
    totalQuestions: number;
    lastResult: boolean | null;
}

export default function QuestionBody({
    nextQuestion, 
    totalQuestions, 
    score, 
    lastResult, 
    onSubmitAnswer}: QuestionBodyProps){

    const [ answer, setAnswer ] = useState("");
    
    const prepareAnswer = (answer: string) => {
        onSubmitAnswer(answer);
        setAnswer("");
    }

    return(
        <div className="container">
            <h5>{nextQuestion?.Question}</h5>
            <div>
                <p>
                    <input type="text" value={answer} onChange={(e) => setAnswer(e.target.value)}/>
                    <button className="btn btn-sm btn-secondary mx-2" onClick={() => prepareAnswer(answer)}>Answer</button>
                </p>
                { lastResult !== null && lastResult && <h5 className="text-success">CORRECT!!</h5> } 
                { lastResult !== null && !lastResult && <h5 className="text-danger">WRONG!!</h5> }
                <p>Score: {score}/{totalQuestions}</p>
            </div> 
        </div>
    )
}