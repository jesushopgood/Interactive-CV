import type { User } from "./user"

interface UserLoginProps
{
    loggedInUser: User;
    users: User[];
    logIn: (user: User) => void;
}

export default function UserLogin({loggedInUser, users, logIn}: UserLoginProps)
{
    return(
        <div className="dropdown">
            <button className="btn btn-secondary dropdown-toggle" data-bs-toggle="dropdown">
                {loggedInUser.name ?? "Select User"}
            </button>
            
            <ul className="dropdown-menu">
            { 
                users.map((user, idx) => <li key={idx}><button onClick={() => logIn(user)} className="dropdown-item">{user.name}</button></li>) 
            }
            </ul>
        </div>
    )   
}