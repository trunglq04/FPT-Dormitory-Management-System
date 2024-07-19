import { Card, Col, Row } from 'react-bootstrap';

const News = () => {
    const newsItems = [
        "Welcome to FPT Dormitory Management System! We're excited to have you here. Stay tuned for the latest updates and information.",
        "Upcoming Event: Join us for the Annual Dormitory Sports Day! Participate in exciting sports activities and win amazing prizes. Date: July 20th, Location: Main Campus Ground.",
        "Health Advisory: Ensure you are up to date with your vaccinations. Our on-campus health center offers free consultations and vaccines. Visit us at the Health Department.",
        "Maintenance Notice: Regular maintenance of the dormitory facilities will take place on July 25th. Please be aware of temporary disruptions and plan accordingly.",
        "New Service: We are introducing a laundry service for all residents. Enjoy convenient and affordable laundry solutions. Check the Services section for more details.",
        "Safety Tips: Remember to lock your doors and windows when you leave your room. Report any suspicious activities to the security department immediately.",
        "Cultural Festival: Experience diverse cultures at our Annual Cultural Festival. Enjoy performances, food stalls, and cultural exhibits. Date: August 10th, Location: Student Center.",
        "Electricity and Water Usage: Monitor your electricity and water usage through our online portal. Conserve energy and resources to help our environment."
        
    ];

    return (
        <div>
            <Row className="flex-grow-1">
                <Col className="SHome-left">
                    <Card className="mb-3" style={{ width: "110vh", height: "80vh", overflowY: "scroll" }}>
                        <Card.Header
                            style={{ backgroundColor: "#034DA1", color: "white", position: "sticky", top: 0 }}
                            className="Shome-news-header"
                        >
                            News
                        </Card.Header>
                        {newsItems.map((text, index) => (
                            <Card.Body key={index} style={{ padding: "10px", marginBottom: "10px", backgroundColor: "#f8f9fa", borderRadius: "8px" }}>
                                <div className="Shome-list-news">
                                    <div className="Shome-list-news-inner" style={{ padding: "10px", backgroundColor: "white", borderRadius: "8px", boxShadow: "0px 1px 3px rgba(0, 0, 0, 0.1)" }}>
                                        {text}
                                    </div>
                                </div>
                            </Card.Body>
                        ))}
                    </Card>
                </Col>
            </Row>
        </div>
    );
};

export default News;
