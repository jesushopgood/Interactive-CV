import { useContext, type JSX } from "react";
import { LoggedInUserContext } from "./LoggedInUserContext";
import UserTable from "./UserTable";

interface ChildProps
{
    children : JSX.Element[] | JSX.Element;
}

export default function ChildComponent({children}: ChildProps){
    const { loggedInUser } = useContext(LoggedInUserContext); 

    return(
        <div className="card-shadow p-2 text-uppercase">
            <h5 className="card-header text-primary fs-6">Child</h5>
            <div className="card-body p-0">
                {loggedInUser.userName &&
                    <UserTable user={loggedInUser} />
                }
                { children }
            </div>
        </div>                
    )
}