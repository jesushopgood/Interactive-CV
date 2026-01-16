import type { User } from "./user";

interface UserTableProps
{
    user: User
}

export default function UserTable({user} : UserTableProps){

    return (
        <div className="card-body">
            <table className="table table-bordered">
                <tbody>
                    <tr>
                        <td className="fw-bold">Username</td>
                        <td>{user.userName}</td>
                    </tr>
                    <tr>
                        <td className="fw-bold">Role</td>
                        <td>{user.role}</td>
                    </tr>
                    <tr>
                        <td className="fw-bold">Key</td>
                        <td>{user.sessionKey}</td>
                    </tr>
                    <tr>
                        <td className="fw-bold">Log In Time</td>
                        <td>{user.lastLoggedInAt}</td>
                    </tr>
                </tbody>
            </table> 
        </div>
    )
}