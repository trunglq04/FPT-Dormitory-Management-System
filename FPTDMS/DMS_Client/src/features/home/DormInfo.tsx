import { Container, Row, Col, Image } from 'react-bootstrap';
import "../../assets/Site.css";
import "../../assets/landing.css"
const   DormInfo = () => {
  return (
    <section id="infoKTX" className="info-KTX">
      <div className="relative">
        <div className="landing-line"></div>
        <div className="d-flex justify-content-center">
          <p className="info-KTX-title">Thông tin Ký túc xá Đại Học FPT</p>
        </div>
      </div>
      <Container className="info-1-layout">
        <Row>
          <Col className="info-1-text d-flex flex-column">
            <p style={{ lineHeight: 1.8 }}>
                Trường Đại học FPT là một trong những ngôi trường nổi tiếng đào tạo đa ngành, với chất lượng đào tạo đạt chuẩn quốc tế. Trường không chỉ quan tâm đến chất lượng đào tạo, công tác tuyển sinh mà còn chăm lo cho đời sống sinh viên.
              <br />
                Bằng việc đầu tư, xây dựng khu <b style={{ color: '#F36F21' }}>Ký túc xá</b> xịn sò. Đầy đủ trang thiết bị cần thiết, không gian thoáng mát, sạch sẽ. Để đáp ứng nhu cầu và tạo không gian học tập, sinh hoạt thoải mái nhất cho sinh viên. <b style={{ color: '#F36F21' }}>KTX</b> cũng được xem như ngôi nhà thứ 2 của nhiều sinh viên.
            </p>
          </Col>
          <Col>
            <Image className="landing-info-img" src='src\assets\content1.png' alt="img-1" fluid />
          </Col>
        </Row>
      </Container>
      <Container className="info-2-layout">
        <Row>
          <Col>
            <Image className="landing-info-img-2" src="src\assets\content2.png" alt="img-2" fluid />
          </Col>
          <Col className="info-1-text d-flex flex-column">
            <div style={{ lineHeight: 1.8 }}>
              <p style={{ fontWeight: 'bold', color: '#F36F21' }}>
                  Ký túc xá của trường Đại học FPT là chỗ ở dành riêng cho sinh viên của Đại học FPT.
              </p>
                Hiện nay, một vấn đề các bạn tân sinh viên sau khi biết kết quả trúng tuyển Đại học. Đó là tìm kiếm cho mình một chỗ ở phù hợp, vừa tiết kiệm vừa đảm bảo an ninh, môi trường học tập. Không chỉ các tân sinh viên mà các bạn sinh viên các khóa trước hầu hết cũng đều mong muốn ở tại <b style={{ color: '#F36F21' }}>KTX</b> trường để thuận lợi cho việc di chuyển. Và để tiết kiệm chi phí, có một trường trường để học tập và sinh hoạt.
            </div>
          </Col>
        </Row>
      </Container>
      <Container>
        <Row>
        <Col>
            <Image className="landing-info-img-3" src="src\assets\content3.png" alt="img-3" fluid />
            <div style={{ marginTop: 24, lineHeight: 1.8, textAlign: 'justify' }}>
              <p style={{ fontWeight: 'bold', color: '#F36F21', marginBottom: 8 }}>
                  Ký túc xá trường Đại học FPT được xây dựng với thiết kế hiện đại, thoáng mát và đầy đủ tiện nghi.
              </p>
                Khu <b style={{ color: '#F36F21' }}>KTX</b> gồm các tòa nhà. Mỗi tòa <b style={{ color: '#F36F21' }}>KTX</b> có các tầng rộng rãi, sạch sẽ, có cả wifi, máy bán nước tự động, máy giặt sấy tự động... Xung quanh còn là cây cối xanh mướt trong lành, dễ chịu, thoáng mát. Phòng ở được thiết kế hiện đại, không gian thoải mái, thiết kế phù hợp cho từng loại phòng 3-4-6-8 người. Mỗi phòng sẽ được trang bị các thiết bị cần thiết, đầy đủ phục vụ cho những nhu cầu thiết yếu của sinh viên như giường tầng, bàn học, giá phơi quần áo, bình nóng lạnh, điều hòa, tủ để giày, nhà vệ sinh riêng cho mỗi phòng… giúp sinh viên an tâm học tập trong quãng thời gian gắn bó với đại học FPT, đem đến cho sinh viên cảm giác thoải mái tiện nghi như ở nhà.
            </div>
          </Col>
        </Row>
      </Container>
    </section>
  );
}

export default DormInfo;
