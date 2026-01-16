//Proverbs 14:10: The heart knows its own bitterness =>, and no stranger shares its joy

import { useContext, useEffect, useState, type JSX } from "react"
import { LoggedInUserContext} from "./LoggedInUserContext";
import { users, type User } from "./user";
import UserTable from "./UserTable";
import UserLogin from "./UserLogin";
import { useAnnotation } from "../../../annotations-engine/hooks/useAnnotation";
import { AnnotationBubble } from "../../../annotations-engine/components/AnnotationBubble";
import { layoutEvents } from "../../../event-bus/layoutEvents";
import { useStore } from "../../../state";

interface ParentProps
{
    children : JSX.Element[] | JSX.Element;
}
    
export function ParentComponent({children} : ParentProps){

    const { loggedInUser, logIn} = useContext(LoggedInUserContext);
    const showAnnotations = useStore(x => x.showAnnotations);
    const { targetElementRef, targetCentre, recalc } = useAnnotation("right", 30);
    const [dynamicPositioningUpdated, setDynamicPositioningUpdated] = useState(false);
    const [bubbleMessage, setBubbleMessage] = useState("Click here to open the component...");
    
    useEffect(() => {
        layoutEvents.on("recalc:complete", () => setDynamicPositioningUpdated(true));
    },[dynamicPositioningUpdated])
    

    const setLogin = (user: User) => {
        logIn(user);
        setBubbleMessage("Each component in the heirarchy uses a shared context that updates each time the user selects a different user.  No properties have to be passed between components");
        setTimeout(() => recalc(), 0);
    }

    return(
        <>
            <div className="container card-shadow p-0 text-primary">
                {/* flexbox push h3 left and button right vertically lign */}
                <div className="d-flex center-xy mb-2">
                    {/* remove the bottom margin from the h3 to align with the button */}
                    <h5 className="mb-0 text-uppercase fs-6">Parent Component</h5>
                                        
                    <div className={`d-flex 
                        align-items-center badge ${showAnnotations ? "bg-success" : "bg-danger"}`}>
                        <i className="bi bi-check"></i> Annotations { showAnnotations ? "On" : "Off" }
                    </div>
                    <div className="border border-3" ref={targetElementRef}>
                        <UserLogin loggedInUser={loggedInUser} users={users} logIn={setLogin} />
                    </div>
                    {
                        dynamicPositioningUpdated && 
                        <AnnotationBubble centre={targetCentre}>
                            <p>{bubbleMessage}</p>
                        </AnnotationBubble>
                    }
                    
                </div>
                { loggedInUser.userName &&
                <div className="card-body row align-top p-0">
                    <div> 
                        <div className="card-shadow text-uppercase small">
                            <h5 className="card-header rounded text-primary fs-6 mt-2">Current User</h5>
                            <UserTable user={loggedInUser} />
                        </div>
                    </div>
                    <div className="p-0">
                        { loggedInUser.userName && children }
                    </div>    
                </div>    
                }
            </div>
        </>
    )
}