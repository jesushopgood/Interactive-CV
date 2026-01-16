import useLocalStorage from "./useLocalStorage"
import type User from "./user"

const users: User[] = [
    { id: 1, name: "Dave", username: "dd1", email: "dave@TextDecoderStream.com" },
    { id: 2, name: "Bill", username: "ba1", email: "bill@TextDecoderStream.com" },
    { id: 3, name: "Nancy", username: "na1", email: "nancy@TextDecoderStream.com" },
    { id: 4, name: "Freya", username: "fd1", email: "freya@TextDecoderStream.com" }
]

export default function LocalStorageClient()
{
    const [userIndex, setUserIndex] = useLocalStorage<number>("userIndex", 0);
    
    return(
        <div className="container border border-primary p-2">
            <button onClick={() => { setUserIndex((userIndex + 1) % users.length); }}>Load Next User</button>
            <p>{users[userIndex].name}</p>
        </div>
    )
}
