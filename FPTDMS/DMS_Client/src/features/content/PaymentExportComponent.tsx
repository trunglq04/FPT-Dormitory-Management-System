import React, { useState, useEffect } from 'react';
import { Button, CircularProgress } from '@mui/material';
import { SaveAlt as SaveAltIcon } from '@mui/icons-material';
import axios from 'axios';

const PaymentExportComponent: React.FC = () => {
  const [loading, setLoading] = useState(false);
  const [userId, setUserId] = useState<string | null>(null);

  useEffect(() => {
    // Retrieve userId from local storage
    const storedUserId = localStorage.getItem('user_id');
    setUserId(storedUserId);
  }, []);

  const handleExport = async () => {
    if (!userId) {
      console.error('User ID not found');
      return;
    }

    setLoading(true);
    try {
      const response = await axios.get(`https://localhost:7777/api/Export/export-orders-by-user/${userId}`, {
        responseType: 'blob',
      });

      const url = window.URL.createObjectURL(new Blob([response.data]));
      const link = document.createElement('a');
      link.href = url;
      link.setAttribute('download', `Payment_history.xlsx`);
      document.body.appendChild(link);
      link.click();
      link.remove();
    } catch (error) {
      console.error('Error exporting orders:', error);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div>
      <Button
        variant="contained"
        style={{ backgroundColor: '#288854', color: 'white' }}
        startIcon={loading ? <CircularProgress size={20} /> : <SaveAltIcon />}
        onClick={handleExport}
        disabled={loading || !userId}
      >
        Export Orders
      </Button>
    </div>
  );
};

export default PaymentExportComponent;
