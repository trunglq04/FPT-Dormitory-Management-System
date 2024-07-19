import { Box } from "@mui/material";
import { DataGrid, GridColDef } from "@mui/x-data-grid";
import axios from "axios";
import React, { useEffect, useState } from "react";

const RoomManagement: React.FC = () => {
  const [users, setUser] = useState([]);

  useEffect(() => {
    const fetchUser = async () => {
      try {
        const response = await axios.get(`https://localhost:7777/api/Room`);
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
      headerName: "id",
      width: 230,
      headerClassName: "bg-gray-400",
    },
    {
      field: "name",
      headerName: "name",
      width: 150,
      headerClassName: "bg-gray-400",
    },
    {
      field: "status",
      headerName: "status",
      width: 200,
      headerClassName: "bg-gray-400",
    },
    {
      field: "description",
      headerName: "Description",
      width: 150,
      headerClassName: "bg-gray-400",
    },
    {
      field: "capacity",
      headerName: "Capacity",
      width: 80,
      headerClassName: "bg-gray-400",
    },
    {
      field: "houseName",
      headerName: "House Name",
      width: 150,
      headerClassName: "bg-gray-400",
    },
    {
      field: "floorName",
      headerName: "Floor Name",
      width: 150,
      headerClassName: "bg-gray-400",
    },
    {
      field: "dormName",
      headerName: "Dorm Name",
      width: 150,
      headerClassName: "bg-gray-400",
    },
    {
      field: "roomType",
      headerName: "Room Type",
      width: 150,
      headerClassName: "bg-gray-400",
    },
    {
      field: "price",
      headerName: "Price",
      width: 150,
      headerClassName: "bg-gray-400",
    },
  ];

  return (
    <div>
      <div className="text-5xl my-10 ml-10 font-bold">Room Management</div>
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

export default RoomManagement;
