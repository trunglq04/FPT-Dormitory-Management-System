import React, { useState, useEffect } from 'react';
import axios from 'axios';
import {
  Container,
  Typography,
  FormControl,
  InputLabel,
  Select,
  MenuItem,
  Button,
  Box,
  SelectChangeEvent,
  Tooltip,
} from '@mui/material';
import { toast, ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

interface Service {
  id: string;
  serviceName: string;
  price: number;
  description: string;
}

interface Booking {
  id: string;
  status: string;
}

const ServiceContent: React.FC = () => {
  const [services, setServices] = useState<Service[]>([]);
  const [selectedService, setSelectedService] = useState<string>('');
  const [price, setPrice] = useState<number | string>('');
  const [booking, setBooking] = useState<Booking | null>(null);

  useEffect(() => {
    const fetchServices = async () => {
      try {
        const response = await axios.get<Service[]>('https://localhost:7777/api/Service');
        setServices(response.data);
      } catch (error) {
        console.error('Error fetching services:', error);
      }
    };
  
    fetchServices();
  }, []);
  

  useEffect(() => {
    const fetchBooking = async () => {
      try {
        const userId = localStorage.getItem("user_id");
        if (!userId) throw new Error("User ID not found");
  
        const response = await axios.get<Booking>(`https://localhost:7777/api/Booking/${userId}`);
        setBooking(response.data);
      } catch (error) {
        console.error(error);
      }
    };
  
    fetchBooking();
  }, []);
  

  const handleServiceChange = (event: SelectChangeEvent<string>) => {
    const selected = services.find(service => service.id === event.target.value);
    setSelectedService(selected ? selected.id : '');
    setPrice(selected ? selected.price : '');
  };

  const handleRequestService = async () => {
    if (!booking || booking.status !== 'approved') {
      toast.error("So sorry! Only dorm students can create the requests!");
      return;
    }

    try {
      const userId = localStorage.getItem("user_id");
      if (!userId) throw new Error("User ID not found");

      const response = await axios.post(
        `https://localhost:7777/api/BookingService/${booking.id}/request-service`,
        { serviceId: selectedService }
      );

      toast.success("Service requested successfully!");
    } catch (error) {
      if (error instanceof Error) {
        if (
          axios.isAxiosError(error) &&
          error.response &&
          error.response.data.message === "Insufficient balance to request this service"
        ) {
          toast.error("Insufficient balance to request this service");
        } else {
          toast.error("Insufficient balance to request this service");
        }
        console.error('Error requesting service:', error.message);
      } else {
        console.error('Unexpected error requesting service:', error);
        toast.error("Unexpected error occurred");
      }
    }
  };

  return (
    <Container className="my-container" sx={{ mt: 4 }}>
      <ToastContainer />
      <Typography variant="h1" component="h2" gutterBottom>
        Choose Service
      </Typography>
      <Box sx={{ display: 'flex', flexDirection: 'column', gap: 2 }}>
        <FormControl fullWidth>
          <InputLabel id="service-label">Service</InputLabel>
          <Select
            labelId="service-label"
            id="service"
            name="serviceId"
            value={selectedService}
            onChange={handleServiceChange}
            label="Service"
          >
            {services.map((service) => (
              <MenuItem key={service.id} value={service.id}>
                <Tooltip title={service.description} arrow>
                  <span>{service.serviceName}</span>
                </Tooltip>
              </MenuItem>
            ))}
          </Select>
        </FormControl>
        <Box sx={{ mt: 3 }}>
          <Typography style={{ fontWeight: 'bold' }} variant="body1" component="div">
            Price: {price ? `${price} VND` : 'Please select a service'}
          </Typography>
        </Box>
        <Box sx={{ mt: 3 }}>
          <Button
            variant="contained"
            style={{ backgroundColor: 'Orange', color: 'white' }}
            onClick={handleRequestService}
          >
            Request Service
          </Button>
        </Box>
      </Box>
      <Box sx={{ width: '100%', height: '20px', backgroundColor: 'aliceblue', textAlign: 'center', mt: 4 }}>
        {/* Optional footer or spacer */}
      </Box>
    </Container>
  );
};

export default ServiceContent;
