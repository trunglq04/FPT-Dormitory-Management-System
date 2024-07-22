import { useEffect, useState } from 'react'
import axios from 'axios'
import { Button, Col, Row } from 'react-bootstrap'
import { Link, Outlet, useNavigate } from 'react-router-dom'
import AdminChat from '../features/Chat/AdminChat'

const AdminDashBoard = () => {
  const navigate = useNavigate()
  const [activeButton, setActiveButton] = useState('users')

  useEffect(() => {
    const role = localStorage.getItem('role')
    if (role !== 'Admin') navigate('..')
  }, [])

  const handleLogout = () => {
    localStorage.removeItem('role')
    navigate('/')
  }

  const handleButtonClick = (buttonName: string) => {
    setActiveButton(buttonName)
  }

  const handleExport = () => {
    const fetchUser = async () => {
      try {
        const response = await axios.get(
          'https://localhost:7777/api/Export/export-data',
          {
            responseType: 'blob', // Important to specify the response type
          }
        )
        // Create a Blob from the response data
        const blob = new Blob([response.data], {
          type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet',
        })
        // Create a link element
        const link = document.createElement('a')
        // Create a URL for the Blob
        const url = URL.createObjectURL(blob)
        link.href = url
        // Set the download attribute with a default file name
        link.download = 'exported-file.xlsx'
        // Append the link to the document body
        document.body.appendChild(link)
        // Trigger the download by simulating a click
        link.click()
        // Clean up and remove the link
        document.body.removeChild(link)
        URL.revokeObjectURL(url)
      } catch (error) {
        // Handle the error
        console.error('Failed to fetch user data', error)
      }
    }

    fetchUser()
  }

  return (
    <div className="bg-white" style={{ height: '100vh' }}>
      <div className="h-11 bg-white flex justify-between items-center shadow-xl">
        <span className="text-3xl font-bold">Welcome Admin</span>
        <Link to={'..'}>
          <Button
            className="mx-5 border-none bg-red-500"
            color="danger"
            onClick={handleLogout}
          >
            Logout
          </Button>
        </Link>
      </div>
      <Row>
        <Col xs={2} className="flex justify-center shadow-xl">
          <div
            className="bg-white w-full rounded-lg mt-3"
            style={{ height: '80%' }}
          >
            <Link to="/admin/users">
              <Button
                className={`w-full mt-5 text-2xl font-bold ${
                  activeButton === 'users' ? 'btn-primary' : 'btn-light'
                }`}
                onClick={() => handleButtonClick('users')}
              >
                User Management
              </Button>
            </Link>

            <Link to="/admin/houses">
              <Button
                className={`w-full text-2xl font-bold ${
                  activeButton === 'houses' ? 'btn-primary' : 'btn-light'
                }`}
                onClick={() => handleButtonClick('houses')}
              >
                House Management
              </Button>
            </Link>
            <Link to="/admin/rooms">
              <Button
                className={`w-full text-2xl font-bold ${
                  activeButton === 'rooms' ? 'btn-primary' : 'btn-light'
                }`}
                onClick={() => handleButtonClick('rooms')}
              >
                Room Management
              </Button>
            </Link>
            <Link to="/admin/bookings">
              <Button
                className={`w-full text-2xl font-bold ${
                  activeButton === 'bookings' ? 'btn-primary' : 'btn-light'
                }`}
                onClick={() => handleButtonClick('bookings')}
              >
                Booking Management
              </Button>
            </Link>

            <Link to="/admin/services">
              <Button
                className={`w-full text-2xl font-bold ${
                  activeButton === 'reviews' ? 'btn-primary' : 'btn-light'
                }`}
                onClick={() => handleButtonClick('services')}
              >
                Service Management
              </Button>
            </Link>

            <Link to="/admin/service-request">
              <Button
                className={`w-full text-2xl font-bold ${
                  activeButton === 'reviews' ? 'btn-primary' : 'btn-light'
                }`}
                onClick={() => handleButtonClick('service-request')}
              >
                Service Request
              </Button>
            </Link>

            <Link to="/admin/payments">
              <Button
                className={`w-full text-2xl font-bold ${
                  activeButton === 'payments' ? 'btn-primary' : 'btn-light'
                }`}
                onClick={() => handleButtonClick('payments')}
              >
                Payment History
              </Button>
            </Link>
            <Button
              onClick={() => {
                handleButtonClick('export')
                handleExport()
              }}
              className={`w-full text-2xl font-bold ${
                activeButton === 'export' ? 'btn-primary' : 'btn-light'
              }`}
            >
              Export Excel
            </Button>
          </div>
        </Col>
        <Col className="flex justify-center pr-10" xs={10}>
          <div
            className="bg-white w-full rounded-lg mt-10 shadow-lg p-1"
            style={{ height: '90vh' }}
          >
            <Outlet />
            <AdminChat />
          </div>
        </Col>
      </Row>
    </div>
  )
}

export default AdminDashBoard
