interface GrandChildProps 
{ 
    id: string, 
    grandChildDisplay: (msg:string) => void 
}

export default function GrandChild({id, grandChildDisplay} : GrandChildProps){

    const message = "A note from the bottom...." ;

    return (
        <div className="card-shadow border border-dark">
            <div className="card-header">
                <h4 className="fs-6 text-uppercase text-success">GrandChild {id}</h4>
            </div>
            <div className="card-body">
                <p className="fw-bold">Click to raise event to top level</p>
                <button className="btn btn-secondary btn-sm" onClick={() => grandChildDisplay(message)}>Raise Event</button>
            </div>       
        </div>
    )
}