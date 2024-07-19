import React, { useEffect, useState } from "react";
import axios from "axios";
import {
  Container,
  Row,
  Col,
  Card,
  Image,
  Button,
  Modal,
  Form,
} from "react-bootstrap";
import { Icon } from "semantic-ui-react";
import "../../models/Profile";
import { User } from "../../models/Profile";
import "bootstrap/dist/css/bootstrap.min.css";
import { useNavigate } from "react-router-dom";
import News from "./News";

interface Booking {
  id: string
  roomId: string
  dormName: string
  houseName: string
  roomName: string
  userName: string
  roomType: string
  bookingDate: string
  startDate: string
  endDate: string
  totalPrice: number
  status: string
}

const StudentHome = () => {
  const [user, setUser] = useState<User | null>(null);
  const [booking, setBooking] = useState<Booking | null>(null);
  const [error, setError] = useState<string>("");
  const [showModal, setShowModal] = useState<boolean>(false);
  const [paymentAmount, setPaymentAmount] = useState<string>(""); // Use string to handle input properly
  const [description, setDescription] = useState<string>("");

  const navigate = useNavigate();

  useEffect(() => {
    const fetchUser = async () => {
      try {
        const userId = localStorage.getItem("user_id");
        if (!userId) throw new Error("User ID not found");

        const response = await axios.get<User>(
          `https://localhost:7777/api/User/${userId}`
        );
        if (response.data.firstName === null) {
          navigate(`/complete-profile/${userId}`);
        } else {
          setUser(response.data);
        }
      } catch (error) {
        setError("Failed to fetch user data");
        console.error(error);
      }
    };

    fetchUser();
  }, []);

  useEffect(() => {
    const fetchUser = async () => {
      try {
        const userId = localStorage.getItem("user_id");
        if (!userId) throw new Error("User ID not found");

        const response = await axios.get<Booking[]>(
          `https://localhost:7777/api/Booking/${userId}`
        );

        setBooking(response.data);
      } catch (error) {
        console.error(error);
      }
    };

    fetchUser();
  }, []);

  const handleShowModal = () => setShowModal(true);
  const handleCloseModal = () => setShowModal(false);

  const handlePaymentSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    const amount = parseInt(paymentAmount, 10); // Convert to number

    if (isNaN(amount) || amount <= 0) {
        setError("Invalid amount. Please enter a positive number.");
        return;
    }

    try {
        const userId = localStorage.getItem("user_id");
        if (!userId) throw new Error("User ID not found");

        const response = await axios.post(
            "https://localhost:7777/api/payments/create",
            {
                orderId: userId,
                fullName: `${user?.firstName} ${user?.lastName}`,
                description: description,
                amount: amount,
                createdDate: new Date().toISOString(),
            }
        );

        const paymentUrl = response.data.url.result;
        if (paymentUrl) {
            // Open the payment URL in a new popup window
            const width = 600;
            const height = 700;
            const left = (window.screen.width / 2) - (width / 2);
            const top = (window.screen.height / 2) - (height / 2);
            window.open(paymentUrl, '_blank', `toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,resizable=yes,width=${width},height=${height},top=${top},left=${left}`);
        } else {
            setError("Failed to retrieve payment URL");
            console.error("Invalid URL:", paymentUrl);
        }
    } catch (error) {
        setError("Failed to initiate payment");
        console.error(error);
    }
};

  const handleAmountChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const value = e.target.value;
    if (/^\d*$/.test(value)) {
      // Only allow digits
      setPaymentAmount(value.replace(/^0+/, "")); // Remove leading zeros
    }
  };

  return (
    <Container id="StudentHome" className="d-flex flex-wrap gap-3">
      {/* Modal Component */}
      <Modal show={showModal} onHide={handleCloseModal}>
        <Modal.Header closeButton>
          <Modal.Title>Payment</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Form onSubmit={handlePaymentSubmit}>
            <Form.Group controlId="paymentAmount">
              <Form.Label>Amount</Form.Label>
              <Form.Control
                type="text"
                value={paymentAmount}
                onChange={handleAmountChange}
                required
              />
            </Form.Group>
            <Form.Group controlId="description">
              <Form.Label>Description</Form.Label>
              <Form.Control
                type="text"
                value={description}
                onChange={(e) => setDescription(e.target.value)}
                required
              />
            </Form.Group>
            <Button variant="primary" type="submit">
              Pay
            </Button>
          </Form>
        </Modal.Body>
      </Modal>
    <News/>
      <Row id="StudentHome-info" className="d-flex flex-wrap gap-3">
        <Col className="SHome-right flex-grow-1">
          {error && <p style={{ color: "red" }}>{error}</p>}
          {user ? (
            <>
              <Card className="mb-3">
                <Card.Header
                  style={{ backgroundColor: "#034DA1", color: "white" }}
                  className="SHome-personal-info"
                >
                  Personal Information
                </Card.Header>
                <Card.Body>
                  <div className="d-flex align-items-center">
                    <div
                      style={{
                        width: "120px",
                        height: "120px",
                        borderRadius: "50%",
                        overflow: "hidden",
                      }}
                    >
                      <Image
                        src={`${user.picture}`}
                        height="120"
                        width="120"
                        style={{ objectFit: "cover", borderRadius: "50%" }}
                      />
                    </div>
                    <div className="ml-3">
                      <p
                        style={{
                          fontWeight: "bold",
                          fontSize: "18px",
                          lineHeight: "150%",
                          color: "var(--blue-color)",
                        }}
                      >
                        {`${user.firstName} ${user.lastName} - ${user.gender}`}
                      </p>
                      <p>
                        <span style = {{color: "var(--blue-color)", fontWeight: "bold"}} className="text-gray">
                          Birthday:  
                        </span>
                        {new Date(user.dateOfBirth).toLocaleDateString()} 
                      </p>
                      <p className="text-gray">
                        <span
                          style={{
                            color: "var(--blue-color)",
                            fontWeight: "bold",
                          }}
                        >
                          Balance:{" "}
                        </span>
                        {user.balance.amount} VND{" "}
                        <a href="#" onClick={handleShowModal}>
                          <Icon name="plus" />
                        </a>
                      </p>
                    </div>
                  </div>
                </Card.Body>
              </Card>
              <Card className="mb-3">
                <Card.Header
                  style={{ backgroundColor: "#034DA1", color: "white" }}
                  className="SHome-personal-info"
                >
                  Contact
                </Card.Header>
                <Card.Body>
                  <div className="Shome-info-container">
                    <div className="Shone-info">
                      <a className="text-blue" href="tel:0988122099">
                        <b>Security room:</b>
                        <span className="text-gray">(098) 8122 0 99</span>
                      </a>
                      <br />
                      <a className="text-blue" href="tel:0949197315">
                        <b>Health station:</b>
                        <span className="text-gray">(094) 9197 3 15</span>
                      </a>
                      <br />
                      <a className="text-blue" href="tel:0935103199">
                        <b>Dormitory management:</b>
                        <span className="text-gray">(093) 5103 1 99</span>
                        <br />
                        <i>(Office hours)</i>
                      </a>
                      <br />
                      <a
                        href="/cdn-cgi/l/email-protection#78100d0d161c4e381e080c561d1c0d560e16"
                        className="text-blue"
                      >
                        <b>Email:</b>
                        <span className="text-gray">
                          <span
                            className="__cf_email__"
                            data-cfemail="8be3fefee5efbdcbedfbffa5eeeffea5fde5"
                          >
                            fptdms@fpt.edu.vn
                          </span>
                        </span>
                      </a>
                    </div>
                  </div>
                </Card.Body>
              </Card>
              <Card className="mb-3">
                <Card.Header
                  style={{ backgroundColor: "#034DA1", color: "white" }}
                  className="SHome-personal-info"
                >
                  Room Details
                </Card.Header>
                <Card.Body>
                  <div className="Shome-info-container">
                    <div className="Shone-info">
                    <a className="text-blue">
                        <b>Dorm: </b>
                        <span className="text-gray"> {booking?.dormName}</span>
                      </a>
                      <br />
                      <a className="text-blue">
                        <b>House Name:</b>
                        <span className="text-gray"> {booking?.houseName}</span>
                      </a>
                      <br />
                      <a className="text-blue">
                        <b>Room Type:</b>
                        <span className="text-gray"> {booking?.roomType}</span>
                      </a>
                      <br />
                      <a className="text-blue">
                        <b>Status: </b>
                        <span className="text-gray"> {booking?.status}</span>
                        <br />
                      </a>
                    </div>
                  </div>
                </Card.Body>
              </Card>
            </>
          ) : (
            <p>Loading...</p>
          )}
        </Col>
      </Row>
    </Container>
  );
};

export default StudentHome;
