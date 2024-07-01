import React, { useState } from 'react';
import { Button, Form, Grid, Header, Message, Segment } from 'semantic-ui-react';

export default function LoginPage() {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [emailError, setEmailError] = useState('');
  const [passwordError, setPasswordError] = useState('');

  const handleEmailChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setEmail(e.target.value);
  };

  const handlePasswordChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setPassword(e.target.value);
  };

  const validateEmail = () => {
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailRegex.test(email)) {
      setEmailError('Please enter a valid email address');
    } else {
      setEmailError('');
    }
  };

  const validatePassword = () => {
    const passwordRegex = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])[0-9a-zA-Z]{8,}$/;
    if (!passwordRegex.test(password)) {
      setPasswordError('Password must contain at least 8 characters, including at least one uppercase letter, one lowercase letter, and one digit');
    } else {
      setPasswordError('');
    }
  };

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    validateEmail();
    validatePassword();

    // Perform login logic here
  };

  return (
    <Grid textAlign='center' style={{ height: '20vh' }} verticalAlign='middle'>
      <Grid.Column style={{ maxWidth: 450 }}>
        <Header as='h2' color='teal' textAlign='center'>
          Log-in to your account
        </Header>
        <Form size='large' onSubmit={handleSubmit}>
            <Segment stacked>
              <Form.Input fluid icon='user' iconPosition='left' placeholder='E-mail address' 
                onChange={handleEmailChange} onBlur={validateEmail} /> {emailError && <span>{emailError}</span>}

              <Form.Input fluid icon='lock' iconPosition='left' placeholder='Password'type='password'
                onChange={handlePasswordChange} onBlur={validatePassword} /> {passwordError && <span>{passwordError}</span>}

              <Button color='teal' fluid size='large'>
                Login
              </Button>
            </Segment>
        </Form>
        <Message>
          New to us?<a href='/register'> Sign Up</a>
        </Message>
      </Grid.Column>
    </Grid>
  );
}