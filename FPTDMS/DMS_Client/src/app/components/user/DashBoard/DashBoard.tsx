import React, { useState } from 'react';
import SideBar from '../../sidebar/SideBar';
import UserNav from '../../navbar/UserNav';
import { Container, Row, Col } from 'react-bootstrap';
import '../../assets/DashBoard.css';
import StudentHome from '../../features/content/StudentHome';
import StudentChat from '../../../components/chat/StudentChat';
import { Icon, Button } from 'semantic-ui-react'; // Import Semantic UI components

const DashBoard: React.FC = () => {
  const [showChat, setShowChat] = useState(false);

  const toggleChat = () => {
    setShowChat(!showChat);
  };

  const buttonStyle = {
    position: 'fixed',
    bottom: '20px',
    right: '20px',
    zIndex: 1000,
  };

  return (
    <div className="dashboard-container">
      <UserNav />
      <Container fluid className="dashboard-content">
        <Row>
          <Col xs={2} className="sidebar-col">
            <SideBar />
          </Col>
          <Col xs={10} className="content-col">
            <div className="main-content">
              <StudentHome />
              {showChat && <StudentChat />}
            </div>
          </Col>
        </Row>
      </Container>
      <Button
        circular
        icon
        color="blue"
        style={buttonStyle}
        onClick={toggleChat}
      >
        <Icon name="comment" />
      </Button>
    </div>
  );
};

export default DashBoard;
