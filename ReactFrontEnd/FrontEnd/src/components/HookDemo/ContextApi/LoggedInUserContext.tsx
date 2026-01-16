import { createContext } from "react";
import type UserContextType from "./IUserContextType";

export const LoggedInUserContext = createContext<UserContextType>({} as UserContextType);