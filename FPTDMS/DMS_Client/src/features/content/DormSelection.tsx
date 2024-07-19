import React, { useEffect, useState } from "react";
import "../../assets/css/BookingBed.css";
import { Button, Col, Form, Row } from "react-bootstrap";
import { Box, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle } from "@mui/material";
import { DataGrid, GridColDef } from "@mui/x-data-grid";
import axios from "axios";
import { Room } from "../../models/Dorm";
import { toast, ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

const DormSelection: React.FC = () => {
  const [rooms, setRooms] = useState<Room[]>([]);
  const [filteredRooms, setFilteredRooms] = useState<Room[]>([]);
  const [dorm, setDorm] = useState<string>("");
  const [floor, setFloor] = useState<string>("");
  const [house, setHouse] = useState<string>("");
  const [type, setType] = useState<string>("");
  const [showConfirmDialog, setShowConfirmDialog] = useState<boolean>(false);
  const [selectedRoom, setSelectedRoom] = useState<{ roomId: string, roomType: string } | null>(null);

  useEffect(() => {
    const fetchRooms = async () => {
      try {
        const response = await axios.get<Room[]>("https://localhost:7777/api/Room");
        setRooms(response.data);
        setFilteredRooms(response.data);
      } catch (error) {
        console.error("Error fetching rooms:", error);
      }
    };

    fetchRooms();
  }, []);

  const dormNames = Array.from(new Set(rooms.map((room) => room.dormName))).sort();
  const houses = Array.from(new Set(rooms.map((room) => room.houseName))).sort();
  const floors = Array.from(new Set(rooms.map((room) => room.floorName))).sort();
  const types = Array.from(new Set(rooms.map((room) => room.roomType))).sort();

  const columns: GridColDef[] = [
    { field: "name", headerName: "Room Type", width: 200 },
    { field: "status", headerName: "Status", width: 200 },
    { field: "capacity", headerName: "Capacity", width: 200 },
    { field: "houseName", headerName: "House", width: 200 },
    { field: "price", headerName: "Price", width: 150 },
    { field: "floorName", headerName: "Floor", width: 150 },
    { field: "dormName", headerName: "Dorm", width: 150 },
    {
      field: "action",
      headerName: "Action",
      width: 150,
      renderCell: (params) => (
        <Button
          variant="primary"
          color="primary"
          onClick={() => openConfirmDialog(params.row.id, params.row.roomType)}
        >
          Book
        </Button>
      ),
    },
  ];

  const handleChangeDorm = (event: React.ChangeEvent<HTMLSelectElement>) => {
    setDorm(event.target.value);
  };

  const handleChangeFloor = (event: React.ChangeEvent<HTMLSelectElement>) => {
    setFloor(event.target.value);
  };

  const handleChangeHouse = (event: React.ChangeEvent<HTMLSelectElement>) => {
    setHouse(event.target.value);
  };

  const handleChangeType = (event: React.ChangeEvent<HTMLSelectElement>) => {
    setType(event.target.value);
  };

  useEffect(() => {
    let filtered = rooms;
    if (dorm) {
      filtered = filtered.filter((x) => x.dormName === dorm);
    }
    if (floor) {
      filtered = filtered.filter((x) => x.floorName === floor);
    }
    if (house) {
      filtered = filtered.filter((x) => x.houseName === house);
    }
    if (type) {
      filtered = filtered.filter((x) => x.roomType === type);
    }
    setFilteredRooms(filtered);
  }, [dorm, floor, house, type, rooms]);

  const openConfirmDialog = (roomId: string, roomType: string) => {
    setSelectedRoom({ roomId, roomType });
    setShowConfirmDialog(true);
  };

  const closeConfirmDialog = () => {
    setShowConfirmDialog(false);
    setSelectedRoom(null);
  };

  const handleConfirmBooking = async () => {
    if (!selectedRoom) return;
    
    try {
      const userId = localStorage.getItem("user_id"); // Replace with the actual user ID
      const request = {
        userId,
        roomId: selectedRoom.roomId,
        roomType: selectedRoom.roomType,
      };

      const response = await axios.post("https://localhost:7777/api/Booking", request);
      toast.success("Booking request submitted successfully!");
    } catch (error) {
      if (axios.isAxiosError(error)) {
        // Narrowing the error type to AxiosError
        const errorMessage = error.response?.data || "Failed to create booking. Please try again.";
        toast.error(errorMessage);
      } else {
        toast.error("An unexpected error occurred.");
      }
    }
    closeConfirmDialog();
  };

  return (
    <>
      <ToastContainer />
      <h1>Booking Bed</h1>
      <br />
      <Row>
        <Col>
          <Form.Select
            aria-label="Select Dorm"
            value={dorm}
            onChange={handleChangeDorm}
          >
            <option value="">Select Dorm</option>
            {dormNames.map((x, index) => (
              <option key={index} value={x}>
                {x}
              </option>
            ))}
          </Form.Select>
        </Col>
        <Col>
          <Form.Select
            aria-label="Select Floor"
            value={floor}
            onChange={handleChangeFloor}
          >
            <option value="">Select Floor</option>
            {floors.map((x, index) => (
              <option key={index} value={x}>
                {x}
              </option>
            ))}
          </Form.Select>
        </Col>
        <Col>
          <Form.Select
            aria-label="Select House"
            value={house}
            onChange={handleChangeHouse}
          >
            <option value="">Select House</option>
            {houses.map((x, index) => (
              <option key={index} value={x}>
                {x}
              </option>
            ))}
          </Form.Select>
        </Col>
        <Col>
          <Form.Select
            aria-label="Select Room Type"
            value={type}
            onChange={handleChangeType}
          >
            <option value="">Select Room Type</option>
            {types.map((x, index) => (
              <option key={index} value={x}>
                {x}
              </option>
            ))}
          </Form.Select>
        </Col>
      </Row>
      <div className="my-4">
        <Box sx={{ height: "700px", width: "100%" }}>
          <DataGrid
            rows={filteredRooms}
            columns={columns}
            initialState={{
              pagination: {
                paginationModel: {
                  pageSize: 10,
                },
              },
            }}
            pageSizeOptions={[10, 5, 20]}
            disableRowSelectionOnClick
          />
        </Box>
      </div>

      <Dialog
        open={showConfirmDialog}
        onClose={closeConfirmDialog}
        aria-labelledby="confirm-dialog-title"
        aria-describedby="confirm-dialog-description"
      >
        <DialogTitle id="confirm-dialog-title">{"Confirm Booking"}</DialogTitle>
        <DialogContent>
          <DialogContentText id="confirm-dialog-description">
            Are you sure you want to book this room?
          </DialogContentText>
        </DialogContent>
        <DialogActions>
          <Button onClick={closeConfirmDialog} style={{backgroundColor: "red", color: "white"}}>
            Cancel
          </Button>
          <Button onClick={handleConfirmBooking} color="primary" autoFocus>
            Confirm
          </Button>
        </DialogActions>
      </Dialog>
    </>
  );
};

export default DormSelection;
