import GrandChild from "./GrandChild";

interface ChildProps
{
     id: string; 
     childDisplay: (msg: string) => void
}

export default function Child({ id, childDisplay } : ChildProps){

    const handleDisplay = (msg:string) => {
        childDisplay(msg);
    }
    
    return (
        <div className="card-shadow border border-dark m-3">
            <div className="card-header">
                <h3 className="fs-5 text-uppercase text-danger">Child Component: {id}</h3>
            </div>
            <div className="card-body">
                <GrandChild id={id} grandChildDisplay={handleDisplay}/>
            </div>
        </div>
    )
}