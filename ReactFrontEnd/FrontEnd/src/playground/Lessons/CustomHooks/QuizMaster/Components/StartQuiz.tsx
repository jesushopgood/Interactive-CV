interface StartQuizProps
{
    onStartQuiz: () => void 
}

export default function StartQuiz({ onStartQuiz }: StartQuizProps){
    return <p><button className="btn btn-lg btn-primary" onClick={onStartQuiz}>Start Quiz</button></p>
}