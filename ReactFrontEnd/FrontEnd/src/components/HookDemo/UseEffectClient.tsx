/* eslint-disable react-hooks/set-state-in-effect */
import { useEffect, useMemo, useRef, useState } from "react";
import { withHighlight } from "../Highlight/withHighlight";

interface PhraseGameDemoProps
{
    phrase?: string;
    difficulty?: number;
    totalGuesses?: number
}

export default function PhraseGame({ phrase = "THIS IS THE DAY GOD MADE AND I WILL REJOICE IN IT", 
                                      difficulty = 10, 
                                      totalGuesses = 10 }: PhraseGameDemoProps) { 
  const MIN_PHRASE_LENGTH = 30;
  const EMPTY_CHAR_MARKER = "_";
  
  const errorMessage = useMemo(() => {
    const errors = [];
    
    if (phrase.length < MIN_PHRASE_LENGTH)
      errors.push("Phrase must be at least 30 characters");
    
    if (difficulty < 1 || difficulty > 10)
      errors.push("Difficulty must be between 1 and 10");
  
    return errors;
}, [phrase, difficulty]);

  
  const [revealedLetters, setRevealedLetters] = useState<string[]>(Array(phrase.length).fill(EMPTY_CHAR_MARKER));
  const [remainingGuesses, setRemainingGuesses] = useState(totalGuesses);
  const [gameStatus, setGameStatus] = useState("In Play");
  const [guess, setGuess] = useState("");
  const focusRef = useRef<HTMLInputElement | null>(null);
  
  const computeLettersFromDifficulty = (phrase: string, difficulty: number) => {
    const phraseLength = phrase.length;
    const totalInitialLetters = Math.round(phraseLength / difficulty - (difficulty > 1 ? 1 : 0));
    const letters: string[] = Array(phrase.length).fill(EMPTY_CHAR_MARKER);
    
    let count = totalInitialLetters;

    while (count > 0) {
      const nextPosition = Math.round(Math.random() * (phraseLength - 1));
      
      if (letters[nextPosition] === EMPTY_CHAR_MARKER) {
        letters[nextPosition] = phrase[nextPosition];
        count--;
      }
    }

    return letters;
  };

  const allLettersRevealed = (val:string[]) => {
    return (JSON.stringify(val.map(x => x.replace("_", " "))) === JSON.stringify(phrase.split("")));
  }


  // Effect A: auto-reveal based on difficulty
  useEffect(() => {
      const letters = computeLettersFromDifficulty(phrase, difficulty);
      setRevealedLetters(letters);
  }, [phrase, difficulty]);

  // Effect B: detect win/lose
  useEffect(() => {
    if (allLettersRevealed(revealedLetters)) {
      setGameStatus("Congratulations!!!! You've WON!!!!");
    } else if (remainingGuesses <= 0) {
      setGameStatus("Sorry! Not this time !!!");
    }
  // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [revealedLetters, remainingGuesses]);

  useEffect(() => {   
    if (!guess) return;

    const guessUpper = guess.toUpperCase();

    if (phrase.includes(guessUpper))
    {
      setRevealedLetters(prev => {
        const updateableResult = [...prev];
        phrase.split("").forEach((val, idx) => {
          if (val === guessUpper) updateableResult[idx] = val;
        });
        
        return updateableResult;
      });
    }
    else
      setRemainingGuesses(prev => prev - 1);

    const id = setTimeout(() => {
          focusRef.current?.focus();
          setGuess("");
        },250)

    return () => clearTimeout(id);
  }, [guess, phrase])
  
  return (
    <>
      { errorMessage.map(e => <p>{e}</p>) }
      <h5 className="text-center fs-4 mb-3 text-uppercase">{gameStatus}</h5>
      <div className="container-fluid d-flex justify-content-center align-items-center flex-wrap">
        { 
          revealedLetters.map((val, idx) => (
            phrase.at(idx) !== " " ?
            <div className="letters-box d-flex justify-content-center align-items-center p-2" key={idx}>{val === "_" ? " " : val}</div> :
            <div className="letters-box-space d-flex justify-content-center align-items-center p-2" key={idx}> </div>
          ))  
        }
      </div>        
      <div className="d-flex justify-content-center mt-4">
        <form>
          <div className="mb-2">
            <label htmlFor="next-letter" className="form-label">Choose a letter</label>
            <input style={{ textTransform: "uppercase" }} 
                  ref={focusRef} 
                  id="next-letter" 
                  className="form-control mini-width"
                  value={guess} 
                  onChange={(e) => setGuess(e.target.value)} />
          </div>
        </form>
      </div>            
    </>
  );
}

export const UseEffectClient = withHighlight(PhraseGame,
  "useEffect()",
  `useEffect is a React hook that lets you run side effects in a component whenever certain values change. 
  It’s how you synchronize your component with the outside world: fetching data, setting up subscriptions, 
  starting timers, updating the document title, or cleaning things up when the component unmounts. 
  By declaring dependencies, you control exactly when the effect runs, giving you predictable, 
  lifecycle‑like behavior in functional components.`,
  `// runs every time either revealedLetters or remainingGuesses changes
useEffect(() => {
  if (allLettersRevealed(revealedLetters)) {
    setGameStatus("Congratulations!!!! You've WON!!!!");
  } else if (remainingGuesses <= 0) {
    setGameStatus("Sorry! Not this time !!!");
  }
}, [revealedLetters, remainingGuesses]);`
);