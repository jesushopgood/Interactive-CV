import { useState } from "react";
import type { User } from "./user";
import type ILoggedInUserProps from "../../Common/ILoggedInUserProps";
import { LoggedInUserContext } from "./LoggedInUserContext";
import { withHighlight } from "../../Highlight/withHighlight";

export const LoggedInUserProvider = ({children}: ILoggedInUserProps) => {
    const [loggedInUser, setLoggedInUser] = useState<User>({} as User);

    const logIn = (user: User) => {
        setLoggedInUser(user);
    }

    return (
        <LoggedInUserContext.Provider value ={{loggedInUser, logIn }}>
            {children}
        </LoggedInUserContext.Provider>
    )
}

export const UseContextClient = withHighlight(LoggedInUserProvider,
  "useContext()",
  `A context allows to provide a state for the container wrapper in the context provider. `,
   
  `export const LoggedInUserProvider = ({children}: ILoggedInUserProps) => {
    const [loggedInUser, setLoggedInUser] = useState<User>({} as User);

    const logIn = (user: User) => {
        setLoggedInUser(user);
    }

    return (
        <LoggedInUserContext.Provider value ={{loggedInUser, logIn }}>
            {children}
        </LoggedInUserContext.Provider>
    )
}

//Consumed from another component 
const { loggedInUser, logIn} = useContext(LoggedInUserContext);`
);