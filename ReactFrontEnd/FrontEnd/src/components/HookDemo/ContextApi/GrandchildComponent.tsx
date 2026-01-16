import { useContext } from "react";
import { LoggedInUserContext } from "./LoggedInUserContext";
import { users, type User } from "./user";
import UserTable from "./UserTable";
import UserLogin from "./UserLogin";

export default function GrandchildComponent(){
    const { loggedInUser, logIn } = useContext(LoggedInUserContext);

    const setLogin = (user: User) => {
        logIn(user);
    }

    return (
        <div id="gc-parent" className="card-shadow b rounded p-2">

            <div className="card-header rounded p-1">
                <div className="d-flex justify-content-between align-items-center ">
                    <h5 className="mb-0 text-uppercase text-primary fs-6">Grandchild</h5>
                    <UserLogin loggedInUser={loggedInUser} users={users} logIn={setLogin} /> 
                </div>
            </div> 
            <div className="card-body row align-items-center justify-content-between text-uppercase small">
                {loggedInUser.userName &&
                    <UserTable user={loggedInUser} />
                 }
            </div>
        </div>       
    )
}