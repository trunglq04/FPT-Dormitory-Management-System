import { useState } from 'react';
import Container from 'react-bootstrap/Container';
import Navbar from 'react-bootstrap/Navbar';
import MyLogo from '../../assets/logo.png';
import { Button } from 'react-bootstrap';
import '../../assets/landing.css'
import Modal from 'react-bootstrap/Modal';
// import LoginForm from '../../user/LoginForm';
import { Link } from 'react-router-dom';

// TopNav component
const TopNav = () => {
  const [show, setShow] = useState(false);

  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);

  return (
    <>
      <Navbar sticky='top' className="bg-body-tertiary">
        <Container>
          <Navbar.Brand href="#home">
            <img
              src={MyLogo}
              width="100"
              height="30"
              className="align-top"
              alt="Logo"
            />
          </Navbar.Brand>
         
          <div className="d-flex align-items-center">
            <Link style={{ marginRight: "10px", color: "blue" }} to="/about-us">About us</Link>
            <Button 
              className="landing-btn-login" 
              style={{ backgroundColor: "#FFA500", borderColor: "#F28C28" }} 
              onClick={handleShow}
            >
              Login
            </Button>
          </div>
        </Container>
      </Navbar>

      <Modal show={show} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>Login</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <LoginForm />
        </Modal.Body>
      </Modal>
    </>
  );
}

export default TopNav;
