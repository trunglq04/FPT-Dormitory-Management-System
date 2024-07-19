import SideBar from "../../features/sidebar/SideBar";
import { Container, Row, Col } from "react-bootstrap";
import "../../assets/BookingBed.css";
import "../../assets/DashBoard.css";
import UserNav from "../NavBar/UserNav";
import ServiceContent from "../../features/content/ServiceContent";

const Service: React.FC = () => {
  return (
    <div className="dashboard-container">
      <UserNav />
      <Container fluid className="dashboard-content">
        <Row>
          <Col xs={2} className="sidebar-col">
            <SideBar />
          </Col>
          <Col xs={10} className="content-col">
              <ServiceContent/>
          </Col>
        </Row>
      </Container>
    </div>
  );
};

export default Service;
