import { useCallback, useEffect, useState } from "react";
import { type QuestionAnswer } from "./questionAnswer";

export default function useQuizMaster(
                          questionsAndAnswers: QuestionAnswer[], 
                          totalQuizTime: number,
                          questionInterval: number)
{
  const [quizCompleted, setQuizCompleted] = useState(false);
  const [quizStarted, setQuizStarted] = useState(false);
  const [questionIndex, setQuestionIndex] = useState<number>(0);
  const [nextQuestion, setNextQuestion] = useState<QuestionAnswer | null>(null);
  const [score, setScore] = useState(0);
  const [totalQuestions, setTotalQuestions] = useState(0);
  const [lastResult, setLastResult] = useState<boolean | null>(null);
  const [quizTimedOut, setQuizTimedOut] = useState(false);

  const startQuiz = useCallback(() => {
    setQuizStarted(true);
    setQuestionIndex(0);
    setNextQuestion(questionsAndAnswers[0]);
    setTotalQuestions(questionsAndAnswers.length);
  },[questionsAndAnswers]);

  const submitAnswer = (answer: string) => {
    if (nextQuestion && nextQuestion?.Answer.toLocaleLowerCase() === answer.toLocaleLowerCase())
    {
      setScore(prev => prev + 1);
      setLastResult(true);
    }
    else{
      setLastResult(false);
    }
  };

  useEffect(() => {
    if (!quizStarted) return;

    const quizTimerId = setTimeout(() =>{
      setQuizTimedOut(true);   
    }, totalQuizTime);

    return () => clearTimeout(quizTimerId);
  }, [quizStarted, totalQuizTime]);

  useEffect(() => {
      if (lastResult !== null)
      {
        const id = setTimeout(() => {
          setQuestionIndex((prevIndex) => {
            const newIndex = prevIndex + 1;
            if (newIndex === questionsAndAnswers.length)
            {
              setQuizCompleted(true);
            }
            else
            {
              setNextQuestion(questionsAndAnswers[newIndex]);
            }
            
            return newIndex;
          });

          setLastResult(null);
        }, questionInterval);

        return () => clearTimeout(id);
      }
    }, [questionsAndAnswers, lastResult, questionInterval])

  return { startQuiz, 
            quizCompleted, 
            nextQuestion, 
            questionIndex,
            score,
            submitAnswer,
            totalQuestions,
            quizStarted,
            lastResult,
            quizTimedOut
          }
}