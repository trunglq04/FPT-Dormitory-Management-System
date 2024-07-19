import React, { useEffect, useState } from "react";
import axios from "axios";
import { Pie } from "react-chartjs-2";
import {
  Chart as ChartJS,
  ArcElement,
  Tooltip,
  Legend,
  Title,
} from "chart.js";
import { Box, Modal, Typography, CircularProgress } from "@mui/material";

ChartJS.register(ArcElement, Tooltip, Legend, Title);

const ServiceUsageChart: React.FC<{ open: boolean; handleClose: () => void }> = ({ open, handleClose }) => {
  const [data, setData] = useState<any>(null);
  const [loading, setLoading] = useState<boolean>(true);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await axios.get("https://localhost:7777/api/BookingService/service-usage-percentage");
        const serviceData = response.data;

        if (serviceData && serviceData.length > 0) {
          const labels = serviceData.map((service: any) => service.serviceName);
          const usageData = serviceData.map((service: any) => service.usagePercentage);

          setData({
            labels,
            datasets: [
              {
                label: 'Service Usage Percentage',
                data: usageData,
                backgroundColor: [
                  '#FF6384',
                  '#36A2EB',
                  '#FFCE56',
                  '#4BC0C0',
                  '#9966FF',
                  '#FF9F40'
                ],
                hoverBackgroundColor: [
                  '#FF6384',
                  '#36A2EB',
                  '#FFCE56',
                  '#4BC0C0',
                  '#9966FF',
                  '#FF9F40'
                ],
              },
            ],
          });
        } else {
          setData(null);
        }
      } catch (error) {
        console.error(error);
        setData(null);
      } finally {
        setLoading(false);
      }
    };

    if (open) {
      setLoading(true);
      fetchData();
    }
  }, [open]);

  return (
    <Modal
      open={open}
      onClose={handleClose}
      aria-labelledby="modal-modal-title"
      aria-describedby="modal-modal-description"
    >
      <Box sx={{ 
        position: 'absolute', 
        top: '50%', 
        left: '50%', 
        transform: 'translate(-50%, -50%)', 
        width: 400, 
        bgcolor: 'background.paper', 
        border: '2px solid #000', 
        boxShadow: 24, 
        p: 4 
      }}>
        <Typography id="modal-modal-title" variant="h6" component="h2">
          Service Usage Percentage
        </Typography>
        {loading ? (
          <CircularProgress />
        ) : data ? (
          <Pie data={data} />
        ) : (
          <Typography>No data available</Typography>
        )}
      </Box>
    </Modal>
  );
};

export default ServiceUsageChart;
