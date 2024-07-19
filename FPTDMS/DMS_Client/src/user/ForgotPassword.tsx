import React, { useState } from 'react';
import {
  MDBContainer,
  MDBRow,
  MDBCol,
  MDBCard,
  MDBCardBody,
  MDBCardImage,
  MDBInput,
  MDBIcon,
} from 'mdb-react-ui-kit';
import { Button } from 'react-bootstrap';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';

const ForgotPassword: React.FC = () => {
  const [email, setEmail] = useState<string>('');
  const [error, setError] = useState<string>('');
  const navigate = useNavigate();

  const handleEmailChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setEmail(e.target.value);
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      await axios.post('https://localhost:7777/api/Auth/forgot-password', { email });
      navigate('/verify', { state: { email } }); // Pass email in state
    } catch (err) {
      setError('Failed to send email. Please try again.');
    }
  };

  return (
    <MDBContainer fluid>
      <MDBCard className='text-black m-5' style={{ borderRadius: '25px' }}>
        <MDBCardBody>
          <MDBRow>
            <MDBCol md='10' lg='6' className='order-2 order-lg-1 d-flex flex-column align-items-center'>
              <p className="text-center h1 fw-bold mb-5 mx-1 mx-md-4 mt-4">Enter your Email</p>
              <form onSubmit={handleSubmit}>
                <div className="d-flex flex-row align-items-center mb-4">
                  <MDBIcon style={{ marginBottom: "30px" }} fas icon="envelope me-3" size='lg' />
                  <MDBInput
                    label='Your Email'
                    placeholder='Enter Email'
                    id='form2'
                    type='email'
                    value={email}
                    onChange={handleEmailChange}
                  />
                </div>
                {error && <p style={{ color: 'red' }}>{error}</p>}
                <Button style={{ backgroundColor: "#FFA500", borderColor: "#F28C28" }} type="submit">Submit</Button>
              </form>
            </MDBCol>
            <MDBCol md='10' lg='6' className='order-1 order-lg-2 d-flex align-items-center'>
              <MDBCardImage style={{ width: '400px', borderRadius: '25px' }} src='https://media.istockphoto.com/id/1306827906/vector/man-forgot-the-password-concept-of-forgotten-password-key-account-access-blocked-access.jpg?s=612x612&w=0&k=20&c=67nYr3ztbOn5uO6-mWBNCSw9mcHD9Z5M-QER-azGQ5w=' fluid />
            </MDBCol>
          </MDBRow>
        </MDBCardBody>
      </MDBCard>
    </MDBContainer>
  );
};

export default ForgotPassword;
