// ServiceForm.tsx
import { useState, useEffect, FC, FormEvent } from "react";
import { Box, Button, Modal, TextField, Typography } from "@mui/material";

interface ServiceFormProps {
  open: boolean;
  handleClose: () => void;
  handleSave: (data: ServiceData) => Promise<void>;
  initialData?: ServiceData;
}

interface ServiceData {
  id?: number;
  serviceName: string;
  price: number;
  description: string;
}

const ServiceForm: FC<ServiceFormProps> = ({ open, handleClose, handleSave, initialData }) => {
  const [serviceName, setServiceName] = useState<string>("");
  const [price, setPrice] = useState<string>("");
  const [description, setDescription] = useState<string>("");

  useEffect(() => {
    if (initialData) {
      setServiceName(initialData.serviceName || "");
      setPrice(initialData.price ? initialData.price.toString() : "");
      setDescription(initialData.description || "");
    }
  }, [initialData]);

  const onSubmit = async (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    const serviceData: ServiceData = {
      serviceName,
      price: parseFloat(price),
      description,
      id: initialData?.id,
    };
    await handleSave(serviceData);
  };

  return (
    <Modal open={open} onClose={handleClose}>
      <Box
        sx={{
          position: "absolute",
          top: "50%",
          left: "50%",
          transform: "translate(-50%, -50%)",
          width: 400,
          bgcolor: "background.paper",
          borderRadius: 1,
          boxShadow: 24,
          p: 4,
        }}
      >
        <Typography variant="h6" component="h2" mb={2}>
          {initialData ? "Edit Service" : "Add Service"}
        </Typography>
        <form onSubmit={onSubmit}>
          <TextField
            fullWidth
            label="Service Name"
            variant="outlined"
            value={serviceName}
            onChange={(e) => setServiceName(e.target.value)}
            margin="normal"
          />
          <TextField
            fullWidth
            label="Price"
            variant="outlined"
            value={price}
            onChange={(e) => setPrice(e.target.value)}
            margin="normal"
            type="number"
          />
          <TextField
            fullWidth
            label="Description"
            variant="outlined"
            value={description}
            onChange={(e) => setDescription(e.target.value)}
            margin="normal"
            multiline
            rows={4}
          />
          <Box mt={3} display="flex" justifyContent="flex-end">
            <Button onClick={handleClose} sx={{ mr: 2 }}>
              Cancel
            </Button>
            <Button type="submit" variant="contained" color="primary">
              {initialData ? "Save Changes" : "Add Service"}
            </Button>
          </Box>
        </form>
      </Box>
    </Modal>
  );
};

export default ServiceForm;
