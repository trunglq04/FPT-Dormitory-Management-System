import { Container, Row, Col } from 'react-bootstrap';
import '../../assets/landing.css'

const Footer = () => {
  return (
    <footer className="my-footer">
      <Container className="footer-contact-container">
        <Row>
          <Col className="flex-1">
            <p className="address-title">Hà Nội</p>
            <p className="footer-contact">
              Khu Giáo dục và Đào tạo - Khu Công nghệ cao Hòa Lạc - KM29 Đại Lộ Thăng Long, H. Thạch Thất, TP. Hà Nội
              <br />
              <br />
              Điện thoại: 024 7300 1866
              <br />
              <br />
              Email: daihocfpt@fpt.edu.vn
            </p>
          </Col>
          <Col className="flex-1">
            <p className="address-title">Đà Nẵng</p>
            <p className="footer-contact">
              Khu đô thị công nghệ FPT Đà Nẵng, P. Hoà Hải, Q. Ngũ Hành Sơn, TP. Đà Nẵng
              <br />
              <br />
              Điện thoại: 024 7300 1866
              <br />
              <br />
              Email: daihocfpt@fpt.edu.vn
            </p>
          </Col>
          <Col className="flex-1">
            <p className="address-title">Cần Thơ</p>
            <p className="footer-contact">
              Số 600 Đường Nguyễn Văn Cừ (nối dài), P. An Bình, Q. Ninh Kiều, TP. Cần Thơ
              <br />
              <br />
              Điện thoại: 029 2360 1995
              <br />
              <br />
              Email: sro.ct@fe.edu.vn
            </p>
          </Col>
          <Col className="flex-1">
            <p className="address-title">Quy Nhơn</p>
            <p className="footer-contact">
              Khu đô thị mới An Phú Thịnh, Phường Nhơn Bình &amp; Phường Đống Đa, TP. Quy Nhơn, Bình Định
              <br />
              <br />
              Điện thoại: 024 7300 1866 / 0256 7300 999
              <br />
              <br />
              Email: daihocfpt@fpt.edu.vn
            </p>
          </Col>
        </Row>
      </Container>
    </footer>
  );
}

export default Footer;
