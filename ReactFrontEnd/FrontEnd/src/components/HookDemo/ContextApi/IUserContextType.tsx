import type { User } from "./user";

export default interface UserContextType {
    loggedInUser: User;
    logIn: (user:User) => void;
}