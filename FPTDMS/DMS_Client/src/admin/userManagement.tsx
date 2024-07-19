import { Box } from "@mui/material";
import { DataGrid, GridColDef } from "@mui/x-data-grid";
import axios from "axios";
import React, { useEffect, useState } from "react";

const UserManagement: React.FC = () => {
  const [users, setUser] = useState([]);

  useEffect(() => {
    const fetchUser = async () => {
      try {
        const response = await axios.get(`https://localhost:7777/api/User`);
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
      headerName: "User ID",
      headerClassName: "bg-gray-400",
      flex: 1,
    },
    {
      field: "userName",
      headerName: "User Name",
      headerClassName: "bg-gray-400",
      flex: 1,
    },
    {
      field: "email",
      headerName: "Email",
      headerClassName: "bg-gray-400",
      flex: 1,
    },
    {
      field: "firstName",
      headerName: "First Name",
      headerClassName: "bg-gray-400",
      flex: 1,
    },
    {
      field: "lastName",
      headerName: "Last Name",
      headerClassName: "bg-gray-400",
      flex: 1,
    },
    {
      field: "gender",
      headerName: "Gender",
      headerClassName: "bg-gray-400",
      flex: 1,
    },
    {
      field: "dateOfBirth",
      headerName: "Date Of Birth",
      headerClassName: "bg-gray-400",
      flex: 1,
    },
  ];

  return (
    <div>
      <div className="text-5xl my-10 ml-10 font-bold">User Management</div>
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

export default UserManagement;
