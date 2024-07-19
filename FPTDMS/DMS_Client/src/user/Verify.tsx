import React, { useState, useEffect, useRef, ChangeEvent, ClipboardEvent } from 'react';
import { Container, Grid, Card, Button, TextField, Typography, Link } from '@mui/material';
import axios from 'axios';
import { useLocation, useNavigate } from 'react-router-dom';

const Verify: React.FC = () => {
  const [otp, setOtp] = useState<string[]>(Array(6).fill(''));
  const [disabled, setDisabled] = useState<boolean[]>(Array(6).fill(true));
  const [buttonDisabled, setButtonDisabled] = useState<boolean>(true);
  const [error, setError] = useState<string>('');
  const inputsRef = useRef<(HTMLInputElement | null)[]>([]);
  const location = useLocation();
  const email = location.state?.email;
  const navigate = useNavigate();

  useEffect(() => {
    if (inputsRef.current[0]) {
      inputsRef.current[0].focus();
    }
    setDisabled([false, ...Array(5).fill(true)]);
  }, []);

  const handlePaste = (event: ClipboardEvent<HTMLInputElement>) => {
    event.preventDefault();
    const pastedValue = (event.clipboardData || window.Clipboard).getData('text').slice(0, 6);
    const newOtp = Array(6).fill('');
    const newDisabled = Array(6).fill(true);

    for (let i = 0; i < newOtp.length; i++) {
      if (i < pastedValue.length) {
        newOtp[i] = pastedValue[i];
        newDisabled[i] = false;
      }
    }

    setOtp(newOtp);
    setDisabled(newDisabled);
    if (inputsRef.current[Math.min(pastedValue.length, 5)]) {
      inputsRef.current[Math.min(pastedValue.length, 5)]!.focus();
    }
  };

  const handleChange = (index: number, value: string) => {
    if (value.length > 1) return;

    const newOtp = [...otp];
    newOtp[index] = value;
    setOtp(newOtp);

    if (value !== '' && index < 5) {
      const newDisabled = [...disabled];
      newDisabled[index + 1] = false;
      setDisabled(newDisabled);
      if (inputsRef.current[index + 1]) {
        inputsRef.current[index + 1]!.focus();
      }
    }

    if (value === '' && index > 0) {
      const newDisabled = [...disabled];
      for (let i = index; i < 6; i++) {
        newDisabled[i] = true;
        newOtp[i] = '';
      }
      setDisabled(newDisabled);
      setOtp(newOtp);
      if (inputsRef.current[index - 1]) {
        inputsRef.current[index - 1]!.focus();
      }
    }

    setButtonDisabled(!newOtp.every((val) => val !== ''));
  };

  const handleVerify = async () => {
    try {
      const response = await axios.post('https://localhost:7777/api/Auth/verify-otp', {
        otp: otp.join(''),
        email: email // Include email in the request
      });
      console.log('Verification successful:', response.data);
      // Navigate to ResetPassword with token
      navigate('/reset-password', { state: { email, token: response.data.token } });
    } catch (error) {
      console.error('Verification failed:', error);
      setError('Verification failed. Please try again.');
    }
  };

  return (
    <Container component="main" maxWidth="xs">
      <Card sx={{ mt: 8, p: 4, boxShadow: 3 }}>
        <Typography variant="h4" component="h1" align="center" gutterBottom>
          Verify
        </Typography>
        <Typography variant="body2" align="center" gutterBottom>
          Your code was sent to you via email
        </Typography>

        <Grid container spacing={2} justifyContent="center">
          {otp.map((val, index) => (
            <Grid item xs={2} key={index}>
              <TextField
                type="text"
                value={val}
                onChange={(e: ChangeEvent<HTMLInputElement>) => handleChange(index, e.target.value)}
                onPaste={index === 0 ? handlePaste : undefined}
                inputRef={(el: HTMLInputElement | null) => (inputsRef.current[index] = el)}
                disabled={disabled[index]}
                inputProps={{ maxLength: 1, style: { textAlign: 'center' } }}
              />
            </Grid>
          ))}
        </Grid>

        {error && (
          <Typography variant="body2" color="error" align="center" gutterBottom>
            {error}
          </Typography>
        )}

        <Button
          variant="contained"
          color="primary"
          fullWidth
          sx={{ mt: 3, mb: 2 }}
          disabled={buttonDisabled}
          onClick={handleVerify}
        >
          Verify
        </Button>

        <Typography variant="body2" align="center">
          Didn't receive code? <Link href="#">Request again</Link>
        </Typography>
      </Card>
    </Container>
  );
};

export default Verify;
