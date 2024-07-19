import DormSelection from "../../features/content/DormSelection";
import { Container, Row, Col } from "react-bootstrap";
import "../../assets/BookingBed.css";
import "../../assets/DashBoard.css";
import SideBar from '../../sidebar/SideBar';
import UserNav from '../../navbar/UserNav';

const BookingBed: React.FC = () => {
  return (
    <div className="dashboard-container">
      <UserNav />
      <Container fluid className="dashboard-content">
        <Row>
          <Col xs={2} className="sidebar-col">
            <SideBar />
          </Col>
          <Col xs={10} className="content-col">
            <DormSelection />
          </Col>
        </Row>
      </Container>
    </div>
  );
};

export default BookingBed;
