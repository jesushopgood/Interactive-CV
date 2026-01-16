interface QuizCompletedProps
{
    score: number;
    totalQuestions: number;
}

export default function QuizCompleted({score, totalQuestions}: QuizCompletedProps){

    return(
        <> 
            <h4>Quiz Complete</h4>
            <p>Your scored {score}/{totalQuestions}</p>
        </>
    )
}