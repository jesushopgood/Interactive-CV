import type User from "../LocalStorage/user";
import useFetch from "./_useFetch";

export default function HookClient(){
    const { data, loading, error } = useFetch<User[]>("https://jsonplaceholder.typicode.com/users");
    return(
        loading ? 
            <p>Loading...</p> : error ? 
                <p>error</p> :    
                <ul className="list-group">
                {
                    data && data.map((d, idx) => <li className="list-group-item" key={idx}>{d.id} {d.name} {d.email} {d.username}</li>)
                }
                </ul>
    )
}