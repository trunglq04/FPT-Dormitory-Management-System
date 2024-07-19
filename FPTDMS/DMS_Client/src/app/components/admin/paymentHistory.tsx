import { Box } from "@mui/material";
import { DataGrid, GridColDef } from "@mui/x-data-grid";
import axios from "axios";
import React, { useEffect, useState } from "react";

const PaymentHistory: React.FC = () => {
  const [users, setUser] = useState([]);

  useEffect(() => {
    const fetchUser = async () => {
      try {
        const response = await axios.get(`https://localhost:7777/api/Orders`);
        setUser(response.data);
      } catch (error) {
        // setError("Failed to fetch user data");
        console.error(error);
      }
    };

    fetchUser();
  }, []);

  const columns: GridColDef[] = [
    {
      field: "id",
      headerName: "Room ID",
      headerClassName: "bg-gray-400",
      flex: 1,
    },
    {
      field: "userId",
      headerName: "User Id",
      headerClassName: "bg-gray-400",
      flex: 1,
    },
    {
      field: "orderReference",
      headerName: "Order Code",
      headerClassName: "bg-gray-400",
      flex: 1,
    },
    {
      field: "createdDate",
      headerName: "Create Date",
      headerClassName: "bg-gray-400",
      flex: 1,
    },
    {
      field: "status",
      headerName: "Status",
      headerClassName: "bg-gray-400",
      flex: 1,
    },
    {
      field: "amount",
      headerName: "Amount",
      headerClassName: "bg-gray-400",
      flex: 1,
    },
  ];

  return (
    <div>
      <div className="text-5xl my-10 ml-10 font-bold">Payment Management</div>
      <Box sx={{ height: "700px", width: "100%" }}>
        <DataGrid
          rows={users} // Use filteredRooms for displaying data
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

export default PaymentHistory;
