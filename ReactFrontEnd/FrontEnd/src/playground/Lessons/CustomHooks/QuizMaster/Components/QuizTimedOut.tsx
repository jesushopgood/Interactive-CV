interface QuizTimedOutProps
{
    score: number;
    totalQuestions: number;
}

export default function QuizTimedOut({score, totalQuestions}: QuizTimedOutProps){
    return (
        <> 
            <h4>Quiz TimedOut</h4>
            <p>Your scored {score}/{totalQuestions}</p>
        </>
    )
}