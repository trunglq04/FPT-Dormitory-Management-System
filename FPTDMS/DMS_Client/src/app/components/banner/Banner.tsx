import Carousel from 'react-bootstrap/Carousel';
import BgImage1 from '../../assets/bg1.jpg';
import BgImage2 from '../../assets/bg2.jpg';
import '../../assets/landing.css'

function Banner() {

  const bannerStyle = {
    height: '500px',
    overflow: 'hidden'
  };


  return (
    <Carousel className='slideshow-container' style={bannerStyle}>
      <Carousel.Item className="mySlides myFade">
        <Carousel.Caption className="text-slider">
          <div>
            <div className="d-flex justify-content-center">
              <p className="text_KTX">
                KTX ĐẠI HỌC FPT
              </p>
            </div>
            <p className="text2_KTX">
              Không gian sống xanh
            </p>
          </div>
        </Carousel.Caption>
        <img
          src={BgImage1}
          alt="Không gian sống xanh"
          style={{ height: '600px' }}
        />
      </Carousel.Item>
      <Carousel.Item className="mySlides myFade">
        <Carousel.Caption className="text-slider">
          <div>
            <div className="d-flex justify-content-center">
              <p className="text_KTX">
                KTX ĐẠI HỌC FPT
              </p>
            </div>
            <p className="text2_KTX">
              Kiến trúc hiện đại
            </p>
          </div>
        </Carousel.Caption>
        <img
          src={BgImage2}
          alt="Kiến trúc hiện đại"
          style={{ height: '600px' }}
        />
      </Carousel.Item>
    </Carousel>
  );
}

export default Banner;