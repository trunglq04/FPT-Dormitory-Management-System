import { Segment } from 'semantic-ui-react'
import Header from '../../layout/Header'
import UserList from '../user/UserList'

export default function HomePage() {
  return (
    <Segment inverted textAlign="center" vertical className="masthead">
        <Header />
        <UserList />
    </Segment>
  )
}
