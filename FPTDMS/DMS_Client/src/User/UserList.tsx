import { useState } from "react";
import { User } from "../types/user";
import config from "../config";

const UserList = () => {
    const [users, setUsers] = useState<User[]>([]);

    const fetchUsers = async () => {
        const response = await fetch(`${config.baseApiUrl}/api/Users`);
        const users = await response.json();
        setUsers(users);
    }
    
    fetchUsers();

    return (
        <div>
            <div className="row mb-2">
                <h5 className="themeFontColor text-center">
                    Users
                </h5>
            </div>
            <table className="table table-hover">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Username</th>
                        <th>Email</th>
                        <th>First Name</th>
                        <th>Last Name</th>
                        <th>Gender</th>
                        <th>Date Of Birth</th>
                        <th>Address</th>
                        <th>Description</th>
                        <th>Picture</th>
                    </tr>
                </thead>
                <tbody>
                    {users.map((u) => (
                        <tr key={u.id}>
                            <td>{u.username}</td>
                            <td>{u.email}</td>
                            <td>{u.firstName}</td>
                            <td>{u.lastName}</td>
                            <td>{u.gender}</td>
                            <td>{u.dateOfBirth}</td>
                            <td>{u.address}</td>
                            <td>{u.description}</td>
                            <td>{u.picture}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    )
}

export default UserList;