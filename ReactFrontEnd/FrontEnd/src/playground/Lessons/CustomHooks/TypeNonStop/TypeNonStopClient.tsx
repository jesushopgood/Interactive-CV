import useTypeNonStop from "./useTypeNonStop";

export default function TypeNonStopClient(){
    const { typed, warning, finalWarning, setTypedValue } = useTypeNonStop(2000, 8000);

    return(
        <div className="container border border-primary">
            <p>Keep Typing</p>
            { finalWarning ? 
                (<h2>GAME OVER PROCRASTINATOR</h2>) :
                (
                    <>
                        {warning && <h2>KEEP TYPING OR DIE!!!!</h2>}
                        <input value={typed} onChange={(e) => setTypedValue(e.target.value) } />
                    </>
                )
            }
        </div>
    )
}