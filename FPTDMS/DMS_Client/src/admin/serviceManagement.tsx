import { Box, Button, IconButton } from "@mui/material";
import { DataGrid, GridColDef } from "@mui/x-data-grid";
import axios from "axios";
import React, { useEffect, useState } from "react";
import ServiceForm from "./ServiceForm";
import DeleteIcon from "@mui/icons-material/Delete";
import EditIcon from "@mui/icons-material/Edit";
import ServiceUsageChart from "./ServiceUsageChart";

const ServiceManagement: React.FC = () => {
  const [services, setServices] = useState([]);
  const [openForm, setOpenForm] = useState(false);
  const [currentService, setCurrentService] = useState(null);
  const [openChart, setOpenChart] = useState(false);

  useEffect(() => {
    const fetchServices = async () => {
      try {
        const response = await axios.get(`https://localhost:7777/api/Service`);
        setServices(response.data);
      } catch (error) {
        console.error(error);
      }
    };

    fetchServices();
  }, []);

  const handleAdd = () => {
    setCurrentService(null);
    setOpenForm(true);
  };

  const handleEdit = (service: React.SetStateAction<null>) => {
    setCurrentService(service);
    setOpenForm(true);
  };

  const handleSave = async (serviceData: any) => {
    if (currentService) {
      // Update service
      await axios.put(
        `https://localhost:7777/api/Service/${currentService.id}`,
        serviceData
      );
    } else {
      // Add new service
      await axios.post(`https://localhost:7777/api/Service`, serviceData);
    }

    const response = await axios.get(`https://localhost:7777/api/Service`);
    setServices(response.data);
    setOpenForm(false);
  };

  const handleDelete = async (id: any) => {
    await axios.delete(`https://localhost:7777/api/Service/${id}`);
    const response = await axios.get(`https://localhost:7777/api/Service`);
    setServices(response.data);
  };

  const columns: GridColDef[] = [
    {
      field: "serviceName",
      headerName: "Name",
      width: 150,
      headerClassName: "bg-gray-400",
    },
    {
      field: "price",
      headerName: "Price",
      width: 150,
      headerClassName: "bg-gray-400",
    },
    {
      field: "description",
      headerName: "Description",
      width: 150,
      headerClassName: "bg-gray-400",
    },
    {
      field: "actions",
      headerName: "Actions",
      width: 150,
      headerClassName: "bg-gray-400",
      renderCell: (params) => (
        <>
          <IconButton
            color="primary"
            onClick={() => handleEdit(params.row)}
          >
            <EditIcon />
          </IconButton>
          <IconButton
            color="secondary"
            onClick={() => handleDelete(params.row.id)}
          >
            <DeleteIcon />
          </IconButton>
        </>
      ),
    },
  ];

  return (
    <div>
      <div className="text-5xl my-10 ml-10 font-bold">Service Management</div>
      <Box mb={2} display="flex" justifyContent="flex-end">
        <Button variant="contained" color="primary" onClick={handleAdd}>
          Add Service
        </Button>
        <Button variant="contained" color="secondary" onClick={() => setOpenChart(true)} style={{ marginLeft: '10px' }}>
          Statistic
        </Button>
      </Box>
      <Box sx={{ height: "700px", width: "100%" }}>
        <DataGrid
          rows={services}
          columns={columns}
          initialState={{
            pagination: {
              paginationModel: {
                pageSize: 10,
              },
            },
          }}
          pageSizeOptions={[10]}
          disableRowSelectionOnClick
        />
      </Box>
      <ServiceForm
        open={openForm}
        handleClose={() => setOpenForm(false)}
        handleSave={handleSave}
        initialData={currentService}
      />
      <ServiceUsageChart open={openChart} handleClose={() => setOpenChart(false)} />
    </div>
  );
};

export default ServiceManagement;
