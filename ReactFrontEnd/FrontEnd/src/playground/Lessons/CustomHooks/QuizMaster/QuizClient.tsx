import { questionsAndAnswer } from "./questionAnswer";
import useQuizMaster from "./useQuizMaster";
import StartQuiz from "./Components/StartQuiz";
import QuestionBody from "./Components/QuestionBody";
import QuizCompleted from "./Components/QuizCompleted";
import QuizTimedOut from "./Components/QuizTimedOut";

export default function QuizClient(){

    const { startQuiz, 
        nextQuestion, 
        submitAnswer, 
        score, 
        totalQuestions,
        quizStarted,
        lastResult,
        quizCompleted,
        quizTimedOut } = useQuizMaster(questionsAndAnswer, 40000, 2000);
    
    const showStartQuiz = !quizStarted && ! quizCompleted && !quizTimedOut;
    const showQuizBody = quizStarted && !quizCompleted && !quizTimedOut
    const showQuizCompleted = quizCompleted && !quizTimedOut;
    const showQuizTimedOut = quizTimedOut && !quizCompleted; 

    return(
        <div className="container border border-5">`
            
            <h2 className="mb-5">Quiz Master</h2>
            { showStartQuiz && <StartQuiz onStartQuiz={startQuiz} /> }
            { showQuizBody && nextQuestion && <QuestionBody nextQuestion={nextQuestion} 
                                            lastResult={lastResult}
                                            score={score}
                                            onSubmitAnswer={submitAnswer}
                                            totalQuestions={totalQuestions}/>}
            { showQuizCompleted && <QuizCompleted score={score} totalQuestions={totalQuestions} /> }
            { showQuizTimedOut && <QuizTimedOut score={score} totalQuestions={totalQuestions} />}    
        </div>
    )
}