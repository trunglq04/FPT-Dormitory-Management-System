import { Button, Menu, Image, Container } from "semantic-ui-react";
import { NavLink } from "react-router-dom";
 
const Header = () => {  
  return(
    <Menu inverted fixed='top' >
        <Container inverted >
            <Menu.Item as='a' active>
                <Image src="/assets/logo.png" alt="logo" size="tiny"/>
            </Menu.Item>
            <Menu.Item position='right'>
                <Button inverted={true} as={NavLink} to='/login'>
                    Log in
                </Button>
                <Button inverted={true} primary={true} style={{ marginLeft: '1em' }} as={NavLink} to='/register'>
                    Sign Up
                </Button>
            </Menu.Item>
        </Container>
    </Menu>
  )
}

export default Header

// const [show, setShow] = useState(false);

//   const handleClose = () => setShow(false);
//   const handleShow = () => setShow(true);

//   return (
//     <>
//       <Navbar className="bg-body-tertiary">
//         <Container>
//           <Navbar.Brand href="#home">
//             <img
//               src={MyLogo}
//               width="100"
//               height="30"
//               className="align-top"
//               alt="Logo"
//             />
//           </Navbar.Brand>
         
//           <div className="d-flex align-items-center">
//             <Link style={{ marginRight: "10px", color: "blue" }} to="/about-us">About us</Link>
//             <Button 
//               className="landing-btn-login" 
//               style={{ backgroundColor: "#FFA500", borderColor: "#F28C28" }} 
//               onClick={handleShow}
//             >
//               Login
//             </Button>
//           </div>
//         </Container>
//       </Navbar>

//       <Modal show={show} onHide={handleClose}>
//         <Modal.Header closeButton>
//           <Modal.Title>Login</Modal.Title>
//         </Modal.Header>
//         <Modal.Body>
//           <LoginForm />
//         </Modal.Body>
//       </Modal>
//     </>
//   );