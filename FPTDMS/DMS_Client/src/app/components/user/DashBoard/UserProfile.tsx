import React, { useState } from "react";
import { Form, Button, Col, Row, Container } from "react-bootstrap";
import axios, { AxiosError } from "axios";
import { useNavigate, useParams } from "react-router-dom";
import { Profile } from "../../../models/Profile";

const UserProfile: React.FC = () => {
  const { id } = useParams<{ id: string }>(); // Ensure id is correctly typed
  const [avatar, setAvatar] = useState<string>(
    "http://ssl.gstatic.com/accounts/ui/avatar_2x.png"
  );
  const [formValues, setFormValues] = useState<Profile>({
    firstName: "",
    lastName: "",
    gender: "",
    dateOfBirth: new Date(),
    address: "",
    picture: "",
    phoneNumber: "",
  });
  const [error, setError] = useState<string>("");
  const navigate = useNavigate();

  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setFormValues({
      ...formValues,
      [name]: name === "dateOfBirth" ? new Date(value) : value,
    });
  };

  const handleFileChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    if (e.target.files && e.target.files[0]) {
      const reader = new FileReader();
      reader.onload = (event) => {
        if (event.target) {
          setAvatar(event.target.result as string);
          setFormValues({
            ...formValues,
            picture: event.target.result as string,
          });
        }
      };
      reader.readAsDataURL(e.target.files[0]);
    }
  };

  const handleProfileCompletion = async (e: React.FormEvent) => {
    e.preventDefault();

    setError("");

    try {
      const response = await axios.post(
        `https://localhost:7777/api/User/${id}/CompleteProfile`,
        formValues
      );
      console.log("Profile completion successful:", response.data);
      navigate("../dashboard");
    } catch (err) {
      if (axios.isAxiosError(err)) {
        const axiosError = err as AxiosError<{ Error: string }>;
        if (axiosError.response) {
          console.error("Profile completion failed:", axiosError.response.data);
          setError(
            axiosError.response.data.Error || "Profile completion failed"
          );
        }
      } else {
        console.error("An unexpected error occurred:", err);
        setError("An unexpected error occurred");
      }
    }
  };

  const imageStyle: React.CSSProperties = {
    borderRadius: "50%",
    width: "100px",
    height: "100px",
    marginBottom: "10px",
  };

  const avatarStyle: React.CSSProperties = {
    borderRadius: "50%",
    width: "150px",
    height: "150px",
    marginBottom: "10px",
  };

  const containerStyle: React.CSSProperties = {
    backgroundColor: "#f5f5f5",
    padding: "20px",
    borderRadius: "10px",
    boxShadow: "0px 0px 10px rgba(0, 0, 0, 0.1)",
    fontFamily: "Arial, sans-serif",
  };

  const formTitleStyle: React.CSSProperties = {
    color: "#333",
    marginBottom: "20px",
    fontFamily: "Arial, sans-serif",
  };

  const buttonStyle: React.CSSProperties = {
    marginTop: "20px",
    marginRight: "10px",
    backgroundColor: "#4CAF50",
    borderColor: "#4CAF50",
  };

  // const resetButtonStyle: React.CSSProperties = {
  //     marginTop: '20px',
  //     backgroundColor: '#f0ad4e',
  //     borderColor: '#f0ad4e',
  // };

  return (
    <Container className="bootstrap snippet" style={containerStyle}>
      <Row>
        <Col sm={10}></Col>
        <Col sm={2}>
          <a href="/users" className="pull-right">
            <img
              title="profile image"
              style={imageStyle}
              src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTiP5OOYYQ-OhLP2M0tapnypGkRBk9la5AmJg&s"
              alt="gravatar"
            />
          </a>
        </Col>
      </Row>
      <Row>
        <Col sm={3} className="text-center">
          <div>
            <img src={avatar} style={avatarStyle} alt="avatar" />
            <h6>Upload a different photo...</h6>
            <input
              type="file"
              className="text-center center-block file-upload"
              onChange={handleFileChange}
            />
          </div>
        </Col>
        <Col sm={9}>
          <Container>
            <h3 style={formTitleStyle}>Complete Your Profile</h3>
            <Form onSubmit={handleProfileCompletion}>
              <Row>
                <Form.Group as={Col} xs={6} controlId="first_name">
                  <Form.Label>First name</Form.Label>
                  <Form.Control
                    type="text"
                    name="firstName"
                    value={formValues.firstName}
                    onChange={handleInputChange}
                    placeholder="First name"
                  />
                </Form.Group>

                <Form.Group as={Col} xs={6} controlId="last_name">
                  <Form.Label>Last name</Form.Label>
                  <Form.Control
                    type="text"
                    name="lastName"
                    value={formValues.lastName}
                    onChange={handleInputChange}
                    placeholder="Last name"
                  />
                </Form.Group>
              </Row>

              <Row>
                <Form.Group as={Col} xs={6} controlId="gender">
                  <Form.Label>Gender</Form.Label>
                  <div>
                    <Form.Check
                      inline
                      type="radio"
                      name="gender"
                      label="Male"
                      value="Male"
                      checked={formValues.gender === "Male"}
                      onChange={handleInputChange}
                    />
                    <Form.Check
                      inline
                      type="radio"
                      name="gender"
                      label="Female"
                      value="Female"
                      checked={formValues.gender === "Female"}
                      onChange={handleInputChange}
                    />
                  </div>
                </Form.Group>

                <Form.Group as={Col} xs={6} controlId="dateOfBirth">
                  <Form.Label>Date of Birth</Form.Label>
                  <Form.Control
                    type="date"
                    name="dateOfBirth"
                    value={formValues.dateOfBirth.toISOString().split("T")[0]}
                    onChange={handleInputChange}
                  />
                </Form.Group>
              </Row>

              <Form.Group controlId="address">
                <Form.Label>Address</Form.Label>
                <Form.Control
                  type="text"
                  name="address"
                  value={formValues.address}
                  onChange={handleInputChange}
                  placeholder="Address"
                />
              </Form.Group>

              <Form.Group controlId="phoneNumber">
                <Form.Label>Phone Number</Form.Label>
                <Form.Control
                  type="text"
                  name="phoneNumber"
                  value={formValues.phoneNumber}
                  onChange={handleInputChange}
                  placeholder="Phone Number"
                />
              </Form.Group>

              <Button type="submit" style={buttonStyle}>
                Complete Profile
              </Button>
            </Form>
            {error && <p style={{ color: "red" }}>{error}</p>}
          </Container>
        </Col>
      </Row>
    </Container>
  );
};

export default UserProfile;
