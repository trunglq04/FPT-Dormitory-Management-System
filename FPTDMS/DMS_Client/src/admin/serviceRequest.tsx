import { Box } from "@mui/material";
import { DataGrid, GridColDef } from "@mui/x-data-grid";
import axios from "axios";
import React, { useEffect, useState } from "react";
import { Button } from "react-bootstrap";

const BookingManagement: React.FC = () => {
  const [services, setServices] = useState([]);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    const fetchServices = async () => {
      try {
        const response = await axios.get(`https://localhost:7777/api/Service/all-service-requests`);
        const dataWithIds = response.data.map((item: { id: any; }, index: number) => ({
          ...item,
          id: item.id || index + 1, // Ensure each row has a unique id
        }));
        setServices(dataWithIds);
      } catch (error) {
        console.error(error);
      } finally {
        setLoading(false);
      }
    };

    fetchServices();
  }, [loading]);

  const handleApprove = async (id: string) => {
    try {
      await axios.post(
        `https://localhost:7777/api/BookingService/service-request/${id}/approve`
      );
      setLoading(true); // Trigger re-fetch after approval
    } catch (error) {
      console.error(error);
    }
  };

  const columns: GridColDef[] = [
    {
      field: "id",
      headerName: "ID",
      headerClassName: "bg-gray-400",
      width: 200,
    },
    {
      field: "serviceName",
      headerName: "Name",
      headerClassName: "bg-gray-400",
      width: 200,
    },
    {
      field: "servicePrice",
      headerName: "Price",
      headerClassName: "bg-gray-400",
    },
    {
      field: "dateRequest",
      headerName: "Date Request",
      headerClassName: "bg-gray-400",
      width: 200,
    },
    {
      field: "usageCount",
      headerName: "Usage Count",
      headerClassName: "bg-gray-400",
      width: 100,
    },
    {
      field: "roomName",
      headerName: "Room Name",
      headerClassName: "bg-gray-400",
      width: 150,
    },
    {
      field: "houseName",
      headerName: "House Name",
      headerClassName: "bg-gray-400",
      width: 150,
    },
    {
      field: "userName",
      headerName: "User Name",
      headerClassName: "bg-gray-400",
      width: 150,
    },
    {
      field: "status",
      headerName: "Status",
      headerClassName: "bg-gray-400",
      width: 150,
    },
    {
      field: "action",
      headerName: "Action",
      headerClassName: "bg-gray-400",
      flex: 1,
      renderCell: (params) => (
        <>
          {params.row.status === "pending" && (
            <>
              <Button
                variant="primary"
                className="mr-4"
                onClick={() => handleApprove(params.row.id)}
              >
                Approve
              </Button>
            </>
          )}
        </>
      ),
    },
  ];

  return (
    <div>
      <div className="text-5xl my-10 ml-10 font-bold">Service Request</div>
      <Box sx={{ height: "700px", width: "100%" }}>
        <DataGrid
          rows={services}
          columns={columns}
          getRowId={(row) => row.id}
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
    </div>
  );
};

export default BookingManagement;
