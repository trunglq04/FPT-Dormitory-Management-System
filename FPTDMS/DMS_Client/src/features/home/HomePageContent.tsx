import Banner from '../banner/Banner';
import '../../assets/landing.css'
import TopNav from '../../app/layout/TopNav';
import DormInfo from './DormInfo';
import '../../assets/landing.css'
import Footer from './Footer';
import FAQSection from './FAQSection ';
function HomePageContext() {
  

    return (
      <div>
          <>
          <TopNav />
          </>
          <div className='my-slide '>
          <Banner />
          </div >
          <div className='lading-container'>
          <DormInfo/>
          <FAQSection/>
         <Footer/>  
          </div>
          
      </div>
     
    );
  }
  
  export default HomePageContext;