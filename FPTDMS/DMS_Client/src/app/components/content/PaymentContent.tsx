import { Box } from "@mui/material";
import { DataGrid, GridColDef } from "@mui/x-data-grid";
import axios from "axios";
import React, { useEffect, useState } from "react";
import PaymentExportComponent from "./PaymentExportComponent";

const PaymentHistory: React.FC = () => {
  const [users, setUser] = useState([]);

  useEffect(() => {
    const fetchUser = async () => {
      try {
        const response = await axios.get(`https://localhost:7777/api/Orders/${localStorage.getItem("user_id")}`);
        setUser(response.data);
      } catch (error) {
        // setError("Failed to fetch user data");
        console.error(error);
      }
    };

    fetchUser();
  }, []);

  const columns: GridColDef[] = [
    { field: "userName", headerName: "UserName", width: 200 },
    { field: "orderReference", headerName: "Order ID", width: 200 },
    { field: "createdDate", headerName: "Created Date", width: 200 },
    { field: "status", headerName: "Status", width: 150 },
    { field: "amount", headerName: "Amount", width: 150},
    // {
    //   field: "action",
    //   headerName: "Action",
    //   width: 150,
    //   renderCell: (params) => (
    //     <Button
    //       variant="primary"
    //       color="primary"
    //       // onClick={() => handleBooking(params.row.id)}
    //     >
    //       Book
    //     </Button>
    //   ),
    // },
  ];

  return (
    <div>
      <Box sx={{ height: "700px", width: "900px" }}>
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
          pageSizeOptions={[5, 10, 50, 100]}
          disableRowSelectionOnClick
        />
        <PaymentExportComponent />
      </Box>
    </div>
  );
};

export default PaymentHistory;
