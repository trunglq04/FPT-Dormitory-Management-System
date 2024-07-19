import { Box } from "@mui/material";
import { DataGrid, GridColDef } from "@mui/x-data-grid";
import axios from "axios";
import React, { useEffect, useState } from "react";
import { Button } from "react-bootstrap";

const BookingManagement: React.FC = () => {
  const [users, setUser] = useState([]);
  const [expiredBookings, setExpiredBookings] = useState([]);
  const [loading, setLoading] = useState(false);
  const [viewExpired, setViewExpired] = useState(false);

  useEffect(() => {
    const fetchUser = async () => {
      try {
        const response = await axios.get(`https://localhost:7777/api/Booking`);
        setUser(response.data);
      } catch (error) {
        console.error(error);
      }
    };

    fetchUser();
    setLoading(false);
  }, [loading]);

  const fetchExpiredBookings = async () => {
    try {
      const response = await axios.get(`https://localhost:7777/api/Booking/expired-bookings`);
      setExpiredBookings(response.data);
      setViewExpired(true);
    } catch (error) {
      console.error(error);
    }
  };

  const notifyExpiringBookings = async () => {
    try {
      const response = await axios.post(`https://localhost:7777/api/Booking/notify-expiring-bookings`);
      alert('Notifications sent to expiring bookings');
    } catch (error) {
      console.error(error);
      alert('Failed to send notifications');
    }
  };

  const handleApprove = async (id: string) => {
    const response = await axios.put(
      `https://localhost:7777/api/Booking/${id}/approve`
    );
    setLoading(true);
  };

  const handleCancel = async (id: string) => {
    const response = await axios.put(
      `https://localhost:7777/api/Booking/${id}/cancel`
    );
    setLoading(true);
  };

  const columns: GridColDef[] = [
    {
      field: "id",
      headerName: "Booking Id",
      headerClassName: "bg-gray-400",
      width: 200,
    },
    {
      field: "houseName",
      headerName: "House Name",
      headerClassName: "bg-gray-400",
    },
    {
      field: "userName",
      headerName: "User Name",
      headerClassName: "bg-gray-400",
      width: 200,
    },
    {
      field: "roomType",
      headerName: "Room Type",
      headerClassName: "bg-gray-400",
      width: 100,
    },
    {
      field: "dormName",
      headerName: "Dorm Name",
      headerClassName: "bg-gray-400",
      width: 150,
    },
    {
      field: "startDate",
      headerName: "Start Date",
      headerClassName: "bg-gray-400",
      width: 150,
    },
    {
      field: "endDate",
      headerName: "End Date",
      headerClassName: "bg-gray-400",
      width: 150,
    },
    {
      field: "totalPrice",
      headerName: "Total Price",
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
              <Button
                variant="danger"
                onClick={() => handleCancel(params.row.id)}
              >
                Cancel
              </Button>
            </>
          )}
        </>
      ),
    },
  ];

  return (
    <div>
      <div className="text-5xl my-10 ml-10 font-bold">Booking Management</div>
      <Button variant="secondary" onClick={fetchExpiredBookings}>
        Load Expired Bookings
      </Button>
      {viewExpired && (
        <Button variant="warning" onClick={notifyExpiringBookings} className="ml-2">
          Notify Expired Bookings
        </Button>
      )}
      <Box sx={{ height: "700px", width: "100%" }}>
        <DataGrid
          rows={viewExpired ? expiredBookings : users}
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
    </div>
  );
};

export default BookingManagement;
