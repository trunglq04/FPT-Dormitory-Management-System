import { Segment } from 'semantic-ui-react'
import NavBar from '../../layout/Header'
import UserList from '../user/UserList'

export default function HomePage() {
  return (
    <Segment inverted textAlign="center" vertical className="masthead">
      <NavBar />
      <UserList />
    </Segment>
  )
}
