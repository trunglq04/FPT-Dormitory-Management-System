import { useState } from 'react'
import { BrowserRouter, Route, Routes } from 'react-router-dom'
import { Header } from 'semantic-ui-react'
import Navbar from './components/NavBar/Navbar'

function App() {

  return (
    <>
      <Navbar/>
      <BrowserRouter>
        <div className='container'>
          {<a href="/account/login">Login</a>}
          <Header subtitle="Providing houses all over the world" />
          <Routes>
            {/* <Route path="/" element={<HouseList/>}></Route>
            <Route path="/houses" element={<HouseList/>}></Route>
            <Route path="/house/:id" element={<HouseDetail/>}></Route>
            <Route path="/house/add" element={<HouseAdd/>}></Route>
            <Route path="/house/edit/:id" element={<HouseEdit/>}></Route> */}
          </Routes>
        </div>
      </BrowserRouter>
      </>
  )
}

export default App
