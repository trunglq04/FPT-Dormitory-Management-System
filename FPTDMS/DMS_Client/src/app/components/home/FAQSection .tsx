import { Container, Row, Col, Accordion } from 'react-bootstrap';
import '../../assets/landing.css'
import '../../assets/Site.css'

const FAQSection = () => {
  return (
    <section id="QA" className="QA-layout">
      <Container>
        <div className="relative">
          <div className="landing-line"></div>
          <Row className="justify-content-center">
            <Col>
              <p className="QA-title">FAQ</p>
            </Col>
          </Row>
        </div>
        <div id="QA-content" className="QA-content">
          <Accordion>
            <Accordion.Item eventKey="0">
              <Accordion.Header style={{fontWeight:"bolder"}}>1. Khi ở KTX cần lưu ý điều gì?</Accordion.Header>
              <Accordion.Body>
                <p style={{ marginBottom: '8px' }}>
                  <b>Ký túc xá có một số điều cần lưu ý khi ở như sau:</b>
                </p>
                <ul className="Des-QA-list-item">
                  <li>Không được nuôi vật nuôi, thú cưng (chó, mèo,...).</li>
                  <li>Không được uống rượu, bia, chơi cờ bạc, sử dụng các chất kích thích và chất cấm.</li>
                  <li>Không được nấu ăn trong ký túc xá.</li>
                  <li>Không được đưa người lạ không ở trong ký túc xá vào phòng sau giờ giới nghiêm.</li>
                  <li>Giờ giới nghiêm trong ký túc xá là sau 10 giờ 30 phút tối.</li>
                  <li>Giữ gìn vệ sinh chung và đổ rác trước 9 giờ sáng.</li>
                </ul>
                <b style={{ marginTop: '4px' }}>
                  Tất cả các lỗi vi phạm đều bị trừ dựa trên điểm uy tín dựa trên mức độ lỗi vi phạm.
                </b>
              </Accordion.Body>
            </Accordion.Item>
            <Accordion.Item eventKey="1">
              <Accordion.Header>2. Điểm uy tín là gì?</Accordion.Header>
              <Accordion.Body>
                <p style={{ marginBottom: '18px', fontWeight: 'bold' }}>
                  Điểm uy tín (Credibility in FPT Dormitory - CFD score) là một trong những yếu tố để tạo ra môi trường KTX văn minh và lành mạnh hơn
                </p>
                <ul className="Des-QA-list-item">
                  <li>Điểm uy tín là tiêu chí để đánh giá ý thức của sinh viên khi sử dụng dịch vụ ký túc xá.</li>
                  <li>Điểm uy tín thay đổi dựa theo những hành vi, hoạt động và sự đóng góp của sinh viên trong suốt thời gian ở ký túc xá.</li>
                  <li>Điểm uy tín sẽ được tăng, giảm tương ứng theo các quy định đã được đề ra trong nội quy KTX.</li>
                  <li>Điểm uy tín là một trong những tiêu chí được dùng để xét duyệt xem sinh viên có được sử dụng ký túc xá trong kỳ hay không.</li>
                </ul>
              </Accordion.Body>
            </Accordion.Item>
            <Accordion.Item eventKey="2">
              <Accordion.Header>3. Làm thế nào để gửi yêu cầu tới Ban Quản lý KTX?</Accordion.Header>
              <Accordion.Body>
                <p>Bước 1: Vào chức năng <b>My request</b>.</p>
                <p>Bước 2: Bấm vào nút <b>Create new request</b> -&gt; Chọn <b>loại yêu cầu (Type request)</b> thích hợp.</p>
                <p>Bước 3: Điền nội dung của yêu cầu ở phần <b>Content</b>.</p>
                <p>Bước 4: Bấm vào nút <b>Create request</b>.</p>
              </Accordion.Body>
            </Accordion.Item>
            <Accordion.Item eventKey="3">
              <Accordion.Header>4. Làm thế nào để báo cáo sửa chữa đồ dùng trong phòng?</Accordion.Header>
              <Accordion.Body>
                <p>Bước 1: Vào chức năng <b>My request</b></p>
                <p>Bước 2: Bấm vào nút <b>Create new request</b> -&gt; Chọn <b>Báo cáo vấn đề kỹ thuật</b> ở mục <b>Type request</b></p>
                <p>Bước 3: Hệ thống sẽ dẫn tới trang <a href="https://cim.fpt.edu.vn/">https://cim.fpt.edu.vn/</a></p>
                <p>Bước 4: Điền những thông tin cần thiết và gửi ảnh tình trạng thiết bị (trên hệ thống CIM)</p>
                <p>Bước 5: Bấm vào nút <b>Create</b> (trên hệ thống CIM)</p>
              </Accordion.Body>
            </Accordion.Item>
            <Accordion.Item eventKey="4">
              <Accordion.Header>5. Thông tin liên lạc của bảo vệ và y tế là gì?</Accordion.Header>
              <Accordion.Body>
                <b>Thông tin liên lạc của phòng bảo vệ và phòng y tế (24/7):</b>
                <ul className="Des-QA-list-item">
                  <li>
                    <a style={{ color: 'black' }} href="tel:02466805913">
                      <b>Phòng bảo vệ:</b><i> (024) 668 05913</i>
                    </a>
                  </li>
                  <li>
                    <a style={{ color: 'black' }} href="tel:02466805917">
                      <b>Phòng y tế:</b><i> (024) 668 05917</i>
                    </a>
                  </li>
                </ul>
                <p style={{ marginTop: '8px' }}>
                  <i>
                    Thông tin chi tiết và cụ thể hơn, sinh viên cần <b>Đăng nhập</b> và xem thêm ở trang <b>Home</b>
                  </i>
                </p>
              </Accordion.Body>
            </Accordion.Item>
          </Accordion>
        </div>
      </Container>
    </section>
  );
}

export default FAQSection;
