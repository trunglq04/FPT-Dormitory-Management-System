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
  MDBCheckbox
} from 'mdb-react-ui-kit';
import axios, { AxiosError } from 'axios';
import { useNavigate } from 'react-router-dom';
import { Button } from 'react-bootstrap';

const RegisterPage: React.FC = () => {
  const [email, setEmail] = useState<string>('');
  const [password, setPassword] = useState<string>('');
  const [repeatPassword, setRepeatPassword] = useState<string>('');
  const [error, setError] = useState<string>('');
  const navigate = useNavigate();

  const handleRegister = async (e: React.FormEvent) => {
    e.preventDefault();

    setError('');

    if (password !== repeatPassword) {
      setError('Passwords do not match');
      return;
    }

    if (!email.endsWith('@fpt.edu.vn')) {
      setError('You must use FPT Edu email');
      return;
    }

    try {
      const response = await axios.post('https://localhost:7777/api/Auth/register', {
        email,
        password,
      });
      console.log('Register successful:', response.data);
      // Navigate to the profile completion form
      navigate(`/complete-profile/${response.data.userId}`);
    } catch (err) {
      if (axios.isAxiosError(err)) {
        const axiosError = err as AxiosError<{ Error: string }>;
        if (axiosError.response) {
          console.error('Register failed:', axiosError.response.data);
          setError(axiosError.response.data.Error || 'Registration failed');
        }
      } else {
        console.error('An unexpected error occurred:', err);
        setError('An unexpected error occurred');
      }
    }
  };

  return (
    <MDBContainer fluid>
      <MDBCard className='text-black m-5' style={{borderRadius: '25px'}}>
        <MDBCardBody>
          <MDBRow>
            <MDBCol md='10' lg='6' className='order-2 order-lg-1 d-flex flex-column align-items-center'>
              <p className="text-center h1 fw-bold mb-5 mx-1 mx-md-4 mt-4">Sign up</p>
              <div className="d-flex flex-row align-items-center mb-4">
                <MDBIcon fas icon="envelope me-3" size='lg'/>
                <MDBInput 
                  label='Your Email' 
                  id='form2' 
                  type='email'
                  value={email}
                  onChange={(e) => setEmail(e.target.value)}
                />
              </div>

              <div className="d-flex flex-row align-items-center mb-4">
                <MDBIcon fas icon="lock me-3" size='lg'/>
                <MDBInput 
                  label='Password' 
                  id='form3' 
                  type='password'
                  value={password}
                  onChange={(e) => setPassword(e.target.value)}
                />
              </div>

              <div className="d-flex flex-row align-items-center mb-4">
                <MDBIcon fas icon="key me-3" size='lg'/>
                <MDBInput 
                  label='Repeat your password' 
                  id='form4' 
                  type='password'
                  value={repeatPassword}
                  onChange={(e) => setRepeatPassword(e.target.value)}
                />
              </div>

              <div className='mb-4'>
                <MDBCheckbox name='flexCheck' value='' id='flexCheckDefault' label='Subscribe to our newsletter' />
              </div>

              {error && <p style={{ color: 'red' }}>{error}</p>}
              <Button className='mb-4' size='lg' onClick={handleRegister}>Register</Button>
            </MDBCol>

            <MDBCol md='10' lg='6' className='order-1 order-lg-2 d-flex align-items-center'>
              <MDBCardImage style={{width: '400px', borderRadius: '25px'}} src='https://cdn.tuoitre.vn/zoom/700_700/471584752817336320/2023/4/27/fpt1-16825877734451677906524-257-0-1304-2000-crop-16825877941001947209179.jpg' fluid/>
            </MDBCol>
          </MDBRow>
        </MDBCardBody>
      </MDBCard>
    </MDBContainer>
  );
}

export default RegisterPage;
