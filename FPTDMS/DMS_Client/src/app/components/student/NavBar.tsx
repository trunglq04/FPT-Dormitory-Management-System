const NavBar = () => {
  return (
    <>
      <div className="my-navbar">
        <div className="navbar-content flex justify-between items-center">
          <div className="flex items-center">
            <div
              id="navbar-menu-icon"
              className="hamburger"
              onClick={handleToggleSidebar}
            >
              <svg
                xmlns="http://www.w3.org/2000/svg"
                width="25"
                height="24"
                viewBox="0 0 25 24"
                fill="none"
              >
                <line
                  x1="2"
                  y1="2"
                  x2="23"
                  y2="2"
                  stroke="white"
                  stroke-width="4"
                  stroke-linecap="round"
                />
                <line
                  x1="2"
                  y1="12"
                  x2="23"
                  y2="12"
                  stroke="white"
                  stroke-width="4"
                  stroke-linecap="round"
                />
                <line
                  x1="2"
                  y1="22"
                  x2="23"
                  y2="22"
                  stroke="white"
                  stroke-width="4"
                  stroke-linecap="round"
                />
              </svg>
            </div>
            <a href="/Student/Student.html" className="logo">
              <img src="/Content/images/landing/logo.png" alt="logo" />
            </a>
          </div>
          <div className="campus">
            <p>Quy Nhơn</p>
          </div>
        </div>
      </div>
      <script src="./script/MyLayout.ts"></script>
    </>
  )
}
export default NavBar