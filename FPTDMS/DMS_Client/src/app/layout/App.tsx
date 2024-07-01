import { Outlet } from 'react-router-dom'
import 'semantic-ui-css/semantic.min.css'
import { Container } from 'semantic-ui-react';
import HomePage from '../components/home/HomePage';


function App() {
  // const location = useLocation();

  return (
    <>
      {location.pathname === '/' ? <HomePage/> : (
        <div>
          <HomePage/>
          <Container style={{ marginTop: "7em" }}>
            {/* Renders the child route's element, if there is one. */}
            <Outlet /> 
          </Container>
        </div>
      )}
    </>
  );
}

export default App


