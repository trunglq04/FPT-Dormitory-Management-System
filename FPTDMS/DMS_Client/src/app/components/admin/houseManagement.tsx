import { Box } from "@mui/material";
import { DataGrid, GridColDef } from "@mui/x-data-grid";
import axios from "axios";
import React, { useEffect, useState } from "react";

const HouseManagement: React.FC = () => {
  const [users, setUser] = useState([]);

  useEffect(() => {
    const fetchUser = async () => {
      try {
        const response = await axios.get(`https://localhost:7777/api/House`);
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
      headerName: "House Id",
      headerClassName: "bg-gray-400",
      flex: 1,
    },
    {
      field: "name",
      headerName: "House Name",
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
      field: "capacity",
      headerName: "Capacity",
      headerClassName: "bg-gray-400",
      flex: 1,
    },
    {
      field: "floorName",
      headerName: "Floor Name",
      headerClassName: "bg-gray-400",
      flex: 1,
    },
  ];

  return (
    <div>
      <div className="text-5xl my-10 ml-10 font-bold">House Management</div>
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

export default HouseManagement;
