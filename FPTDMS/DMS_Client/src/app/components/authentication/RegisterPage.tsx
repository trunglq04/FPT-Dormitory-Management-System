import React, { useState } from 'react';
import { Button, Form, Grid, Header, Message, Segment } from 'semantic-ui-react';

const RegisterPage: React.FC = () => {
    const [password, setPassword] = useState('');
    const [email, setEmail] = useState('');
    const [errorMessage, setErrorMessage] = useState('');
    const [retypePassword, setRetypePassword] = useState('');

    const handleRegister = () => {
        // Regex for checking valid email format
        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

        if (!password || !email || !retypePassword) {
            setErrorMessage('Please fill in all fields');
        } else if (!emailRegex.test(email)) {
            setErrorMessage('Please enter a valid email address');
        } else if (password !== retypePassword) {
            setErrorMessage('Passwords do not match');
        } else {
            // Perform registration logic here
            // ...
        }
    };

    <Form.Input fluid icon='lock' iconPosition='left' placeholder='Retype Password' type='password'
        onChange={(e) => setRetypePassword(e.target.value)}
    />

    return (
        <Grid textAlign='center' style={{ height: '20vh' }} verticalAlign='middle'>
            <Grid.Column style={{ maxWidth: 450 }}>
                <Header as='h2' color='teal' textAlign='center'>
                    Register Account
                </Header>
                {errorMessage && <p>{errorMessage}</p>}
                <Form size='large' onSubmit={handleRegister}>
                    <Segment stacked>
                    <Form.Input fluid icon='user' iconPosition='left' placeholder='E-mail address' 
                        onChange={(e) => setEmail(e.target.value)} 
                    />
                    <Form.Input fluid icon='lock' iconPosition='left' placeholder='Password'type='password'
                        onChange={(e) => setPassword(e.target.value)} 
                    />

                    <Form.Input fluid icon='lock' iconPosition='left' placeholder='Retype Password'type='password'
                        onChange={(e) => setRetypePassword(e.target.value)} 
                    />

                    <Button color='teal' fluid size='large' onClick={handleRegister}>
                        Register
                    </Button>
                    </Segment>
                </Form>
                <Message>
                    Already got account?<a href='/login'> Log In</a>
                </Message>
            </Grid.Column>
        </Grid>
    );
};

export default RegisterPage;