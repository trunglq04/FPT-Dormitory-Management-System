import { Button, Container, Menu, Image } from "semantic-ui-react";
import { NavLink } from "react-router-dom";
 
export default function NavBar() {  
  return(
      <Menu inverted fixed='top' >
          <Menu inverted pointing={true} secondary size='huge'>
                <Container>
                    <Menu.Item as='a' active>
                        <Image src="/assets/logo.png" alt="logo" size="tiny"/>
                    </Menu.Item>
                    <Menu.Item position='right'>
                        <Button inverted={true} as={NavLink} to='/login'>
                            Log in
                        </Button>
                        <Button inverted={true} primary={true} style={{ marginLeft: '0.5em' }} as={NavLink} to='/register'>
                            Sign Up
                        </Button>
                    </Menu.Item>

                </Container>
            </Menu>
      </Menu>
  )
}