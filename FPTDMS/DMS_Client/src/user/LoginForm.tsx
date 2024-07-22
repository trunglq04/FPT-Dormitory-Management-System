import React, { useState } from 'react'
import Button from 'react-bootstrap/Button'
import Form from 'react-bootstrap/Form'
import { useNavigate, NavLink } from 'react-router-dom'
import axios, { AxiosError } from 'axios'


// LoginForm component
function LoginForm() {
  const [email, setEmail] = useState<string>('')
  const [password, setPassword] = useState<string>('')
  const [accountRole, setAccountRole] = useState<string>('')
  const [error, setError] = useState<string>('')
  const navigate = useNavigate()

  const handleLogin = async (e: React.FormEvent) => {
    // if (password === "admin@fpt.edu.vn" && email === "admin@fpt.edu.vn") {

    //   localStorage.setItem("admin", "211919237");
    // }
    e.preventDefault()

    // Clear previous error
    setError('')

    // Basic form validation
    if (!email || !password) {
      setError('Email and password are required')
      return
    }

    // Check email suffix
    if (!email.endsWith('@fpt.edu.vn')) {
      setError('You must use an FPT Edu email')
      return
    }

    try {
      const response = await axios.post(
        'https://localhost:7777/api/auth/login',
        {
          email,
          password,
        }
      )
      console.log('Login successful:', response.data)
      // Extract tokens from the response
      const { access_token, refresh_token, user_id, role } = response.data
      localStorage.setItem('role', role[0])
      localStorage.setItem('access_token', access_token)
      localStorage.setItem('refresh_token', refresh_token)
      localStorage.setItem('user_id', user_id)
      // Navigate to the user/admin dashboard base on role

      setAccountRole(role[0] as string)
      if (accountRole == 'Admin') {
        navigate('admin/users')
      } else {
        navigate('user/dashboard')
      }
    } catch (err) {
      if (axios.isAxiosError(err)) {
        const axiosError = err as AxiosError<{ Error: string }>
        if (axiosError.response) {
          console.error('Login failed:', axiosError.response.data)
          setError(
            axiosError.response.data.Error || 'Invalid email or password'
          )
        } else {
          console.error('An unexpected error occurred:', err)
          setError('An unexpected error occurred')
        }
      }
    }
  }

  return (
    <Form onSubmit={handleLogin}>
      <Form.Group className="mb-3" controlId="formBasicEmail">
        <Form.Label>Email address</Form.Label>
        <Form.Control
          type="email"
          placeholder="Enter email"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
        />
        <Form.Text className="text-muted">
          We'll never share your email with anyone else.
        </Form.Text>
      </Form.Group>

      <Form.Group className="mb-3" controlId="formBasicPassword">
        <Form.Label>Password</Form.Label>
        <Form.Control
          type="password"
          placeholder="Password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
        />
      </Form.Group>

      <Form.Group className="mb-3" controlId="formBasicCheckbox">
        <Form.Check type="checkbox" label="Remember me" />
        <NavLink to="forgot-password">Forgot your password?</NavLink>
      </Form.Group>

      {error && <p style={{ color: 'red' }}>{error}</p>}

      <Button
        style={{ backgroundColor: '#FFA500', borderColor: '#F28C28' }}
        type="submit"
      >
        Login
      </Button>
      <Button
        style={{ marginLeft: '10px' }}
        onClick={() => navigate('register')}
      >
        Register
      </Button>
    </Form>
  )
}

export default LoginForm
