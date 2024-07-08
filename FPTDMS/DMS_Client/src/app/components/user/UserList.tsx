import { useEffect, useState } from 'react'
import config from '../../../config'
import { User } from '../../models/user'
import axios from 'axios'

const UserList = () => {
  const [users, setUsers] = useState<User[]>([])

  useEffect(() => {
    const fetchUsers = async () => {
      try {
        const response = await axios.get(`${config.baseApiUrl}/api/User`)
        setUsers(response.data)
      } catch (error) {
        console.error('There was an error fetching the users:', error)
      }
    }
    fetchUsers()
  }, [])

  console.log(users)

  return (
    <div>
      <div className="row mb-2">
        <h5 className="themeFontColor text-center">Users</h5>
      </div>
      <table className="table table-hover">
        <thead>
          <tr>
            <th>Username</th>
            <th>Email</th>
            <th>First Name</th>
            <th>Last Name</th>
            <th>Gender</th>
            <th>Date Of Birth</th>
            <th>Address</th>
            <th>Description</th>
            <th>Picture</th>
            <th>IsCompletedInfo</th>
          </tr>
        </thead>
        <tbody>
          {users.map((u) => (
            <tr key={u.id}>
              <td>{u.userName}</td>
              <td>{u.email}</td>
              <td>{u.firstName}</td>
              <td>{u.lastName}</td>
              <td>{u.gender}</td>
              <td>{u.dateOfBirth}</td>
              <td>{u.address}</td>
              <td>{u.description}</td>
              <td>{u.picture}</td>
              <td>
                {u.isCompletedInfo ? <span>True</span> : <span>False</span>}
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  )
}

export default UserList
