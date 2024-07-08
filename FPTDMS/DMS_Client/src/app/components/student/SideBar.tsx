const Sidebar = () => {
  return (
    <>
      <div id="sidebar-full" className="sidebar-full hidden">
        <div className="sidebar-top">
          <div className="sidebar-infoUser flex">
            <div className="sidebar-avatar">
              <img src="/Content/images/FrogSleep.png" alt="avatar-user" />
            </div>
            <div>
              <p className="sidebar-name" style={{ marginBottom: '8px' }}>
                khainmqe170245
              </p>
              <p
                className="sidebar-prestigeScore"
                style={{ marginBottom: '4px' }}
                hidden
              >
                <span className="sidebar-prestigeScore bold">CFD score:</span>{' '}
                100
              </p>
              <p className="sidebar-prestigeScore">
                <span className="sidebar-prestigeScore bold">Balance:</span> 0
                VND
              </p>
              <p className="sidebar-prestigeScore">
                <span className="sidebar-prestigeScore bold">RollName:</span>
                QE170245
              </p>
            </div>
          </div>

          <div id="sidebarLinkFull" className="sidebar-link">
            <a
              href="/Student/Student.html"
              className="sidebar-linkItem flex items-center sidebar-linkItem-active sidebar-icon-active"
            >
              <div className="sidebar-linkIcon">
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  width="24"
                  height="24"
                  viewBox="0 0 24 24"
                  fill="none"
                >
                  <path
                    d="M12 0L0 8V24H7.5V14.6667H16.5V24H24V8L12 0Z"
                    fill="#034EA2"
                  />
                </svg>
              </div>
              <p>Home</p>
            </a>
            <a
              href="/Student/News.html"
              className="sidebar-linkItem flex items-center"
            >
              <div className="sidebar-linkIcon">
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  width="24"
                  height="24"
                  viewBox="0 0 24 24"
                  fill="none"
                >
                  <path
                    d="M12 24C13.65 24 15 22.8923 15 21.5385H9C9 22.8923 10.335 24 12 24ZM21 16.6154V10.4615C21 6.68308 18.54 3.52 14.25 2.68308V1.84615C14.25 0.824615 13.245 0 12 0C10.755 0 9.75 0.824615 9.75 1.84615V2.68308C5.445 3.52 3 6.67077 3 10.4615V16.6154L0 19.0769V20.3077H24V19.0769L21 16.6154Z"
                    fill="#034EA2"
                  />
                </svg>
              </div>
              <p>News</p>
            </a>
            <a
              href="/Student/Bookings.html"
              className="sidebar-linkItem flex items-center"
            >
              <div className="sidebar-linkIcon">
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  width="20"
                  height="23"
                  viewBox="0 0 20 23"
                  fill="none"
                >
                  <path
                    d="M1.3725 2H0.8525C0.381677 2 0 2.38168 0 2.8525V21.0117C0 21.4825 0.381677 21.8642 0.8525 21.8642H1.3725C1.84332 21.8642 2.225 21.4825 2.225 21.0117V2.8525C2.225 2.38168 1.84332 2 1.3725 2Z"
                    fill="#034EA2"
                  />
                  <path
                    d="M19.1124 4.85352H18.6624C18.1722 4.85352 17.7749 5.25086 17.7749 5.74102V20.9768C17.7749 21.467 18.1722 21.8643 18.6624 21.8643H19.1124C19.6026 21.8643 19.9999 21.467 19.9999 20.9768V5.74102C19.9999 5.25086 19.6026 4.85352 19.1124 4.85352Z"
                    fill="#034EA2"
                  />
                  <path
                    d="M8.98657 1.86426H16.0024C17.0626 1.86426 18.0794 2.28542 18.8291 3.0351C19.5787 3.78477 19.9999 4.80156 19.9999 5.86176V8.20676C19.9999 8.52811 19.8722 8.8363 19.645 9.06354C19.4178 9.29077 19.1096 9.41842 18.7882 9.41842H8.98657C8.66521 9.41842 8.35702 9.29077 8.12979 9.06354C7.90256 8.8363 7.7749 8.52811 7.7749 8.20676V3.07593C7.7749 2.75457 7.90256 2.44638 8.12979 2.21915C8.35702 1.99192 8.66521 1.86426 8.98657 1.86426Z"
                    fill="#034EA2"
                  />
                  <path
                    d="M9.76831 11.8374H16.7837C17.6364 11.8374 18.4543 12.176 19.0574 12.7788C19.6605 13.3816 19.9995 14.1993 20 15.052V17.397C20 17.9255 19.79 18.4324 19.4163 18.8062C19.0425 19.1799 18.5356 19.3899 18.0071 19.3899H9.76831C9.23975 19.3899 8.73285 19.1799 8.3591 18.8062C7.98536 18.4324 7.77539 17.9255 7.77539 17.397V13.8303C7.77539 13.5686 7.82694 13.3095 7.92709 13.0677C8.02725 12.8259 8.17404 12.6062 8.3591 12.4211C8.54416 12.2361 8.76386 12.0893 9.00565 11.9891C9.24744 11.889 9.50659 11.8374 9.76831 11.8374Z"
                    fill="#034EA2"
                  />
                  <path
                    d="M18.6064 8.56573V7.79781C18.6064 7.32699 18.2248 6.94531 17.7539 6.94531L1.58603 6.94531C1.11521 6.94531 0.73353 7.32699 0.73353 7.79781V8.56573C0.73353 9.03655 1.11521 9.41823 1.58603 9.41823H17.7539C18.2248 9.41823 18.6064 9.03655 18.6064 8.56573Z"
                    fill="#034EA2"
                  />
                  <path
                    d="M18.6064 18.5389V17.771C18.6064 17.3001 18.2248 16.9185 17.7539 16.9185H1.58603C1.11521 16.9185 0.733528 17.3001 0.733528 17.771V18.5389C0.733528 19.0097 1.11521 19.3914 1.58603 19.3914H17.7539C18.2248 19.3914 18.6064 19.0097 18.6064 18.5389Z"
                    fill="#034EA2"
                  />
                  <path
                    d="M4.92657 6.02176C5.95957 6.02176 6.79699 5.09107 6.79699 3.94301C6.79699 2.79495 5.95957 1.86426 4.92657 1.86426C3.89357 1.86426 3.05615 2.79495 3.05615 3.94301C3.05615 5.09107 3.89357 6.02176 4.92657 6.02176Z"
                    fill="#034EA2"
                  />
                  <path
                    d="M4.92657 15.9949C5.95957 15.9949 6.79699 15.0642 6.79699 13.9162C6.79699 12.7681 5.95957 11.8374 4.92657 11.8374C3.89357 11.8374 3.05615 12.7681 3.05615 13.9162C3.05615 15.0642 3.89357 15.9949 4.92657 15.9949Z"
                    fill="#034EA2"
                  />
                </svg>
              </div>
              <p>Booking bed</p>
            </a>
            <div></div>
            <a
              href="/Student/ParkingTicket.html"
              className="sidebar-linkItem flex items-center"
            >
              <div className="sidebar-linkIcon">
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  width="20"
                  height="20"
                  viewBox="0 0 20 20"
                  fill="none"
                >
                  <path
                    d="M17.4 0H2.59999C1.16608 0 0 1.00905 0 2.25391V17.7461C0 18.9909 1.16403 20 2.59999 20H17.4C18.8339 20 20 18.9909 20 17.7461V2.25391C20 1.00823 18.836 0 17.4 0ZM2.74748 4.57119C2.74748 4.20576 3.08906 3.90988 3.51053 3.90988H4.73447C5.15594 3.90988 5.49752 4.20576 5.49752 4.57119V5.6321C5.49752 5.99753 5.15594 6.29342 4.73447 6.29342H3.51053C3.08906 6.29342 2.74748 5.99753 2.74748 5.6321V4.57119ZM5.49752 15.051C5.49752 15.416 5.15594 15.7123 4.73447 15.7123H3.51053C3.08906 15.7123 2.74748 15.416 2.74748 15.051V13.9897C2.74748 13.6247 3.08906 13.3284 3.51053 13.3284H4.73447C5.15594 13.3284 5.49752 13.6247 5.49752 13.9897V15.051ZM6.00963 9.60741L4.23516 11.1457C4.18065 11.1945 4.11394 11.2336 4.03938 11.2603C3.96482 11.2871 3.88408 11.3009 3.80243 11.3009C3.72077 11.3009 3.64004 11.2871 3.56548 11.2603C3.49092 11.2336 3.42421 11.1945 3.3697 11.1457L2.93696 10.7704L2.23537 10.1621C2.1201 10.0592 2.05632 9.92555 2.05632 9.78703C2.05632 9.64853 2.1201 9.51491 2.23537 9.41193C2.29013 9.36331 2.35688 9.32437 2.43138 9.29759C2.50588 9.27081 2.58649 9.25678 2.6681 9.25638C2.74972 9.25673 2.83036 9.27074 2.90486 9.29752C2.97937 9.3243 3.04612 9.36327 3.10084 9.41193L3.80243 10.0202L5.14416 8.8572C5.19867 8.80835 5.26539 8.76928 5.33995 8.74253C5.41451 8.71578 5.49524 8.70196 5.57689 8.70196C5.65855 8.70196 5.73928 8.71578 5.81384 8.74253C5.8884 8.76928 5.95511 8.80835 6.00963 8.8572C6.12585 8.95964 6.18984 9.09348 6.18887 9.2321C6.19043 9.37142 6.12641 9.50607 6.00963 9.60905V9.60741ZM16.1689 15.2687H9.429C9.31391 15.2683 9.20021 15.2485 9.09512 15.2109C8.99003 15.1732 8.89585 15.1183 8.81856 15.0498C8.654 14.9053 8.56361 14.7161 8.56558 14.5202C8.56558 14.1086 8.95222 13.7716 9.429 13.7716H16.1689C16.2841 13.7722 16.3978 13.792 16.503 13.8298C16.6082 13.8675 16.7024 13.9224 16.7798 13.9909C16.944 14.1355 17.0341 14.3245 17.0323 14.5202C17.0323 14.9337 16.6457 15.2687 16.1689 15.2687ZM16.1689 10.756H9.429C9.31388 10.7554 9.20017 10.7356 9.09508 10.6979C8.98999 10.6601 8.89582 10.6052 8.81856 10.5366C8.65407 10.3922 8.56369 10.2032 8.56558 10.0074C8.56558 9.59589 8.95222 9.25885 9.429 9.25885H16.1689C16.284 9.25936 16.3978 9.27909 16.503 9.31678C16.6081 9.35446 16.7024 9.40929 16.7798 9.47778C16.944 9.62245 17.0342 9.81161 17.0323 10.0074C17.0323 10.4206 16.6457 10.756 16.1689 10.756ZM16.1689 5.85021H9.429C9.31391 5.84973 9.20021 5.83002 9.09512 5.79233C8.99003 5.75464 8.89585 5.69979 8.81856 5.63127C8.65417 5.48667 8.56381 5.2975 8.56558 5.10164C8.56558 4.69012 8.95222 4.35309 9.429 4.35309H16.1689C16.2841 4.35368 16.3978 4.37348 16.503 4.41124C16.6082 4.449 16.7024 4.50388 16.7798 4.57243C16.944 4.71697 17.0341 4.90598 17.0323 5.10164C17.0323 5.51523 16.6457 5.85021 16.1689 5.85021Z"
                    fill="#034EA2"
                  />
                </svg>
              </div>
              <p>Parking ticket</p>
            </a>
            <a
              href="/Student/EWBedUsages.html"
              className="sidebar-linkItem flex items-center"
            >
              <div className="sidebar-linkIcon">
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  width="24"
                  height="24"
                  viewBox="0 0 24 24"
                  fill="none"
                >
                  <g clip-path="url(#clip0_1275_37006)">
                    <path
                      d="M22.1856 11.4446C22.1856 15.6807 17.6262 19.1143 12.0013 19.1143C6.37646 19.1143 1.81543 15.6807 1.81543 11.4446C1.81543 10.9501 1.87756 10.4676 1.99764 10.001H22.0059C22.1234 10.4676 22.1856 10.9501 22.1856 11.4446Z"
                      fill="#034EA2"
                    />
                    <path
                      d="M22.1015 7.14111H1.89847C0.849736 7.14111 0 7.78105 0 8.57084C0 9.36064 0.849736 10.0006 1.89847 10.0006H22.1015C23.1503 10.0006 24 9.36064 24 8.57084C24 7.78105 23.1503 7.14111 22.1015 7.14111Z"
                      fill="#034EA2"
                    />
                    <path
                      d="M5.7985 0C4.6658 0 3.74805 0.691152 3.74805 1.54419V5.9238H7.84895V1.54419C7.84895 0.691152 6.93036 0 5.7985 0Z"
                      fill="#034EA2"
                    />
                    <path
                      d="M12.0005 24C13.1332 24 14.051 23.3088 14.051 22.4558V18.866C14.051 18.4297 13.5816 18.0762 13.0022 18.0762H10.998C10.4186 18.0762 9.94922 18.4297 9.94922 18.866V22.4558C9.95006 23.3088 10.8678 24 12.0005 24Z"
                      fill="#034EA2"
                    />
                    <path
                      d="M18.2018 0C17.0691 0 16.1514 0.691152 16.1514 1.54419V5.9238H20.2523V1.54419C20.2523 0.691152 19.3337 0 18.2018 0Z"
                      fill="#034EA2"
                    />
                  </g>
                  <defs>
                    <clipPath id="clip0_1275_37006">
                      <rect width="24" height="24" fill="white" />
                    </clipPath>
                  </defs>
                </svg>
              </div>
              <p>Electricity water usage</p>
            </a>
            <a
              href="/Student/Invoices.html"
              className="sidebar-linkItem flex items-center"
            >
              <div className="sidebar-linkIcon">
                <svg
                  className="sidebar-icon"
                  xmlns="http://www.w3.org/2000/svg"
                  width="20"
                  height="20"
                  viewBox="0 0 20 20"
                  fill="none"
                >
                  <path
                    d="M10 0C4.48 0 0 4.48 0 10C0 15.52 4.48 20 10 20C15.52 20 20 15.52 20 10C20 4.48 15.52 0 10 0ZM11.41 16.09V18H8.74V16.07C7.03 15.71 5.58 14.61 5.47 12.67H7.43C7.53 13.72 8.25 14.54 10.08 14.54C12.04 14.54 12.48 13.56 12.48 12.95C12.48 12.12 12.04 11.34 9.81 10.81C7.33 10.21 5.63 9.19 5.63 7.14C5.63 5.42 7.02 4.3 8.74 3.93V2H11.41V3.95C13.27 4.4 14.2 5.81 14.26 7.34H12.3C12.25 6.23 11.66 5.47 10.08 5.47C8.58 5.47 7.68 6.15 7.68 7.11C7.68 7.95 8.33 8.5 10.35 9.02C12.37 9.54 14.53 10.41 14.53 12.93C14.52 14.76 13.15 15.76 11.41 16.09Z"
                    fill="#034EA2"
                  />
                </svg>
              </div>
              <p>Payment history</p>
            </a>
            <a
              href="/Student/BedUsage.html"
              className="sidebar-linkItem flex items-center"
            >
              <div className="sidebar-linkIcon">
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  width="24"
                  height="25"
                  viewBox="0 0 24 25"
                  fill="none"
                >
                  <path
                    d="M22.0645 12.7296C22.0645 7.20651 17.6675 2.729 12.2443 2.729C8.82962 2.729 5.82208 4.5033 4.06248 7.19644C3.90353 7.4399 3.7548 7.69091 3.61628 7.94948C3.55907 8.18903 3.56348 8.43916 3.6291 8.67654C3.69472 8.91393 3.81941 9.13081 3.99154 9.30696C4.12166 9.44058 4.27723 9.54678 4.44906 9.61929C4.6209 9.6918 4.80552 9.72916 4.99202 9.72916C5.17853 9.72916 5.36315 9.6918 5.53498 9.61929C5.70682 9.54678 5.86238 9.44058 5.9925 9.30696L6.20952 9.08575C6.80588 8.06185 7.64849 7.20308 8.66088 6.58738C9.74087 5.93118 10.9806 5.58484 12.2443 5.58626C16.1182 5.58626 19.2588 8.78437 19.2588 12.7296C19.2588 16.6749 16.1182 19.8747 12.2443 19.8747C10.5595 19.8751 8.93247 19.2603 7.669 18.1457C6.69038 17.2865 5.96473 16.1765 5.57023 14.9354L3.09662 14.2605C2.91377 14.2094 2.71918 14.22 2.54297 14.2907C2.88888 16.5501 3.99582 18.6238 5.68063 20.1685C7.46946 21.8158 9.81255 22.7298 12.2443 22.729C17.6675 22.729 22.0645 18.2523 22.0645 12.7296Z"
                    fill="#034EA2"
                  />
                  <path
                    d="M8.24818 15.6823L5.59408 14.9587L3.12047 14.2833C2.93762 14.2322 2.74303 14.2428 2.56682 14.3135C2.36136 14.3971 2.19353 14.5529 2.09489 14.7515C1.99625 14.9502 1.97361 15.1781 2.03121 15.3923L3.40548 20.614C3.44337 20.7665 3.52123 20.9061 3.63104 21.0185C3.74084 21.1308 3.87862 21.2119 4.03017 21.2533C4.18173 21.2947 4.34158 21.2949 4.49326 21.254C4.64494 21.213 4.78295 21.1324 4.89309 21.0203L5.70489 20.1934L7.69285 18.1685L8.64695 17.1972C9.13092 16.7048 8.90929 15.8632 8.24818 15.6823Z"
                    fill="#034EA2"
                  />
                  <path
                    d="M11.849 8.82812H11.478C11.0549 8.82812 10.7119 9.1711 10.7119 9.59418V13.6028C10.7119 14.0259 11.0549 14.3689 11.478 14.3689H11.849C12.2721 14.3689 12.6151 14.0259 12.6151 13.6028V9.59418C12.6151 9.1711 12.2721 8.82812 11.849 8.82812Z"
                    fill="#034EA2"
                  />
                  <path
                    d="M17.104 13.6137V13.2355C17.104 12.8047 16.7548 12.4556 16.3241 12.4556H11.4915C11.0608 12.4556 10.7116 12.8047 10.7116 13.2355V13.6137C10.7116 14.0444 11.0608 14.3936 11.4915 14.3936H16.3241C16.7548 14.3936 17.104 14.0444 17.104 13.6137Z"
                    fill="#034EA2"
                  />
                </svg>
              </div>
              <p>Resident history</p>
            </a>
            <a
              href="/Student/Reward.html"
              className="sidebar-linkItem flex items-center"
            >
              <div className="sidebar-linkIcon">
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  width="24"
                  height="25"
                  viewBox="0 0 24 25"
                  fill="none"
                >
                  <path
                    d="M11.9032 16.1659C11.9037 16.3149 11.8574 16.4602 11.7707 16.5813C11.7577 16.5997 11.7437 16.6172 11.7287 16.6339C11.6762 16.6944 11.6115 16.743 11.5389 16.7766C11.4662 16.8102 11.3873 16.8279 11.3072 16.8287H1.59545C1.32958 16.8287 1.10479 16.6344 1.02816 16.3672C1.00929 16.3014 0.999809 16.2334 1 16.165C1 15.3046 1.31204 14.525 1.81747 13.9614C2.32291 13.3978 3.02037 13.0483 3.7903 13.0483H9.11286C10.6536 13.0493 11.9032 14.4446 11.9032 16.1659Z"
                    fill="#034EA2"
                  />
                  <path
                    d="M15.5603 18.9332V19.3113C15.5603 20.2432 15.1911 21.0801 14.6127 21.6506C14.4423 21.8191 14.2507 21.9646 14.0426 22.0835C14.0131 22.0997 13.9836 22.1159 13.9536 22.1297C13.5893 22.3219 13.1837 22.4224 12.7719 22.4224H3.83834C2.55097 22.4224 1.50732 21.2573 1.50732 19.8195V18.9332C1.50735 18.9044 1.50905 18.8755 1.5124 18.8469C1.55071 18.5201 1.80043 18.2681 2.10323 18.2681H14.964C15.2935 18.2681 15.5603 18.5653 15.5603 18.9332Z"
                    fill="#034EA2"
                  />
                  <path
                    d="M22.0085 16.0318L14.612 21.6521L14.042 22.085C14.0124 22.1012 13.9829 22.1173 13.9529 22.1312C13.5887 22.3234 13.1831 22.4238 12.7712 22.4238H11.9224C11.6206 22.2578 11.3686 22.0143 11.1921 21.7185L10.6101 20.7621C10.461 20.5184 10.5178 20.1861 10.7361 20.0204L13.0468 18.2663L21.564 11.7958C21.7823 11.6301 22.0796 11.6929 22.2282 11.9343L22.603 12.5496C23.2977 13.6971 23.0328 15.254 22.0085 16.0318Z"
                    fill="#034EA2"
                  />
                  <path
                    d="M5.87588 17.644C5.8737 17.8553 5.94965 18.06 6.08913 18.2187C6.10483 18.2362 6.12052 18.2524 6.13529 18.2681H11.7667V18.8465H1.5125L1.02783 16.3682L11.7708 16.166V16.5814C11.7578 16.5998 11.7438 16.6173 11.7288 16.6341C11.6763 16.6945 11.6117 16.7431 11.539 16.7767C11.4664 16.8103 11.3874 16.8281 11.3074 16.8289H6.6038C6.20176 16.8312 5.87588 17.1954 5.87588 17.644Z"
                    fill="#034EA2"
                  />
                  <path
                    d="M12.251 18.2681C12.1253 18.3881 11.9585 18.4556 11.7848 18.4569H6.6039C6.43009 18.4558 6.26328 18.3882 6.1377 18.2681H12.251Z"
                    fill="#034EA2"
                  />
                  <path
                    d="M20.6928 5.84361C20.6928 6.72063 20.3932 7.59395 19.7955 8.26187L18.5884 9.61063L14.2574 14.4481L9.92676 9.61063L14.2574 4.77411L15.4649 3.42536C16.6609 2.08999 18.5995 2.08999 19.7955 3.42536C20.3932 4.09327 20.6928 4.96844 20.6928 5.84361Z"
                    fill="#034EA2"
                  />
                  <path
                    d="M18.5882 9.61068L14.2572 14.4481L8.71813 8.26284C8.11806 7.59493 7.8208 6.71976 7.8208 5.84459C7.8208 4.96942 8.11991 4.09425 8.71813 3.42633C9.9141 2.09096 11.8528 2.09096 13.0487 3.42633L18.5882 9.61068Z"
                    fill="#034EA2"
                  />
                </svg>
              </div>
              <p>CFD score</p>
            </a>
            <a
              href="/Student/Requests.html"
              className="sidebar-linkItem flex items-center"
            >
              <div className="sidebar-linkIcon">
                <svg
                  className="sidebar-icon"
                  xmlns="http://www.w3.org/2000/svg"
                  width="16"
                  height="20"
                  viewBox="0 0 16 20"
                  fill="none"
                >
                  <path
                    d="M10 0H2C0.9 0 0.0100002 0.9 0.0100002 2L0 18C0 19.1 0.89 20 1.99 20H14C15.1 20 16 19.1 16 18V6L10 0ZM12 14H9V17H7V14H4V12H7V9H9V12H12V14ZM9 7V1.5L14.5 7H9Z"
                    fill="#034EA2"
                  />
                </svg>
              </div>
              <p>My request</p>
            </a>
            <a
              href="/Student/Guidelines.html"
              className="sidebar-linkItem flex items-center"
            >
              <div className="sidebar-linkIcon">
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  width="25"
                  height="26"
                  viewBox="0 0 25 26"
                  fill="none"
                >
                  <path
                    d="M0 8.77881V20.8372C0 22.2563 1.07528 23.4066 2.40219 23.4066H13.3082C13.2756 23.2365 13.2831 23.0612 13.33 22.8945L14.4027 19.0393C14.4475 18.8732 14.5323 18.7207 14.6496 18.5949C14.7166 18.4761 14.7976 18.3657 14.8909 18.2662L18.9211 13.9552V8.77933L0 8.77881ZM8.5465 19.1086H5.27742C5.12054 19.108 4.96548 19.0749 4.82201 19.0115C4.67855 18.948 4.54979 18.8555 4.44387 18.7397C4.22007 18.4975 4.09678 18.1792 4.09898 17.8494C4.09898 17.1539 4.62621 16.5902 5.27638 16.5902H8.54546C8.70232 16.5909 8.85734 16.624 9.00078 16.6875C9.14423 16.751 9.273 16.8434 9.37901 16.9591C9.6028 17.2013 9.72609 17.5196 9.72389 17.8494C9.72389 18.5465 9.19667 19.1086 8.5465 19.1086ZM10.9289 14.5459H5.27742C5.12056 14.5452 4.96554 14.5121 4.82209 14.4486C4.67865 14.3852 4.54987 14.2927 4.44387 14.1771C4.22034 13.9347 4.09709 13.6165 4.09898 13.2868C4.09898 12.5913 4.62621 12.0271 5.27638 12.0271H10.9289C11.0858 12.0277 11.2409 12.0609 11.3843 12.1245C11.5278 12.188 11.6565 12.2806 11.7624 12.3964C11.9862 12.6387 12.1095 12.957 12.1073 13.2868C12.1063 13.9833 11.5791 14.5475 10.9289 14.5475V14.5459Z"
                    fill="#034EA2"
                  />
                  <path
                    d="M3.24095 3.40674H15.6812C16.5407 3.40674 17.3651 3.7482 17.9729 4.35599C18.5807 4.96379 18.9221 5.78814 18.9221 6.64769V7.73287H0V6.64769C0 5.78814 0.341459 4.96379 0.949255 4.35599C1.55705 3.7482 2.38139 3.40674 3.24095 3.40674Z"
                    fill="#034EA2"
                  />
                  <path
                    d="M20.6922 13.2173L23.4742 16.1925L18.5375 21.472C18.3616 21.6664 18.147 21.8217 17.9075 21.928C17.668 22.0343 17.4088 22.0892 17.1467 22.0892C16.8847 22.0892 16.6255 22.0343 16.386 21.928C16.1464 21.8217 15.9318 21.6664 15.756 21.472C14.9876 20.6505 14.9876 19.3184 15.756 18.4968L20.6922 13.2173Z"
                    fill="#034EA2"
                  />
                  <path
                    d="M24.3263 12.3061C25.0947 13.1272 25.0947 14.4593 24.3263 15.2809L23.7287 15.9201L20.9473 12.9449L21.5448 12.3061C21.7206 12.1118 21.9352 11.9565 22.1748 11.8502C22.4143 11.7439 22.6735 11.689 22.9355 11.689C23.1976 11.689 23.4568 11.7439 23.6963 11.8502C23.9358 11.9565 24.1504 12.1118 24.3263 12.3061Z"
                    fill="#034EA2"
                  />
                  <path
                    d="M15.3693 23.0794L18.0883 21.9812C18.2317 21.9234 18.359 21.8317 18.4593 21.7139C18.5595 21.5961 18.6298 21.4558 18.664 21.3049C18.6982 21.1541 18.6953 20.9972 18.6557 20.8477C18.616 20.6982 18.5407 20.5605 18.4363 20.4465L16.7905 18.6496C16.6798 18.5286 16.5398 18.438 16.384 18.3866C16.2282 18.3352 16.0619 18.3247 15.9008 18.3561C15.7398 18.3874 15.5895 18.4597 15.4644 18.5658C15.3394 18.6719 15.2436 18.8085 15.1865 18.9622L14.1127 21.8567C13.8236 22.6382 14.5978 23.391 15.3693 23.0794Z"
                    fill="#034EA2"
                  />
                </svg>
              </div>
              <p>User guide</p>
            </a>
            <a
              href="/Student/Policy.html"
              className="sidebar-linkItem flex items-center"
            >
              <div className="sidebar-linkIcon">
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  width="24"
                  height="25"
                  viewBox="0 0 24 25"
                  fill="none"
                >
                  <path
                    d="M21.1354 20.5112H2.8125C2.36377 20.5112 2 20.875 2 21.3237V21.73C2 22.1787 2.36377 22.5425 2.8125 22.5425H21.1354C21.5841 22.5425 21.9479 22.1787 21.9479 21.73V21.3237C21.9479 20.875 21.5841 20.5112 21.1354 20.5112Z"
                    fill="#034EA2"
                  />
                  <path
                    d="M21.1354 3.53223H2.8125C2.36377 3.53223 2 3.896 2 4.34473V4.75098C2 5.19971 2.36377 5.56348 2.8125 5.56348H21.1354C21.5841 5.56348 21.9479 5.19971 21.9479 4.75098V4.34473C21.9479 3.896 21.5841 3.53223 21.1354 3.53223Z"
                    fill="#034EA2"
                  />
                  <path
                    d="M12.9577 2.75498V20.9279H10.9785V2.73707C11.2853 2.60815 11.6149 2.54198 11.9477 2.54248C12.2955 2.54185 12.6396 2.61425 12.9577 2.75498Z"
                    fill="#034EA2"
                  />
                  <path
                    d="M14.4473 5.04248C14.4474 5.52717 14.3066 6.00144 14.0421 6.40757C13.7775 6.8137 13.4006 7.13417 12.9573 7.32998C12.6392 7.47072 12.2951 7.54312 11.9473 7.54248C11.6145 7.54299 11.2849 7.47682 10.9781 7.3479C10.5243 7.15705 10.1369 6.83646 9.86459 6.42633C9.59226 6.0162 9.44709 5.53479 9.44727 5.04248C9.44709 4.55017 9.59226 4.06877 9.86459 3.65864C10.1369 3.24851 10.5243 2.92792 10.9781 2.73707C11.2849 2.60815 11.6145 2.54198 11.9473 2.54248C12.2951 2.54185 12.6392 2.61425 12.9573 2.75498C13.4006 2.9508 13.7775 3.27127 14.0421 3.6774C14.3066 4.08353 14.4474 4.5578 14.4473 5.04248Z"
                    fill="#034EA2"
                  />
                  <path
                    d="M8.29676 12.4382C8.03764 12.532 7.75198 12.52 7.5017 12.4046C7.25141 12.2892 7.05667 12.0799 6.95968 11.822L5.51176 7.90029C5.46508 7.77287 5.44416 7.63744 5.45025 7.50187C5.45633 7.3663 5.48929 7.23329 5.54721 7.11056C5.60512 6.98783 5.68684 6.87783 5.78762 6.78694C5.88839 6.69606 6.00622 6.6261 6.13426 6.58113C6.39338 6.48731 6.67904 6.49938 6.92932 6.61473C7.17961 6.73008 7.37435 6.93942 7.47134 7.19737L8.91926 11.1186C8.96595 11.2461 8.98687 11.3815 8.98079 11.5171C8.97471 11.6527 8.94175 11.7858 8.88384 11.9085C8.82593 12.0313 8.74421 12.1413 8.64343 12.2323C8.54265 12.3232 8.42481 12.3932 8.29676 12.4382Z"
                    fill="#034EA2"
                  />
                  <path
                    d="M4.69098 12.4282C4.94984 12.522 5.23522 12.5101 5.48537 12.3951C5.73552 12.2801 5.93033 12.0712 6.02765 11.8136L7.47223 7.9003C7.51876 7.77296 7.53954 7.63765 7.53336 7.50221C7.52717 7.36677 7.49414 7.23391 7.43619 7.11134C7.37824 6.98877 7.29652 6.87893 7.19577 6.7882C7.09503 6.69747 6.97726 6.62765 6.84932 6.58281C6.59057 6.48891 6.30525 6.50071 6.05515 6.61566C5.80505 6.73061 5.6103 6.93946 5.51307 7.19697L4.06807 11.1103C4.02152 11.2377 4.00074 11.373 4.00692 11.5085C4.01311 11.644 4.04613 11.7769 4.10408 11.8995C4.16203 12.0221 4.24375 12.1319 4.3445 12.2227C4.44525 12.3135 4.56302 12.3833 4.69098 12.4282Z"
                    fill="#034EA2"
                  />
                  <path
                    d="M6.47851 14.5219C7.85923 14.5219 8.97851 13.2976 8.97851 11.7873C8.97851 10.277 7.85923 9.05273 6.47851 9.05273C5.0978 9.05273 3.97852 10.277 3.97852 11.7873C3.97852 13.2976 5.0978 14.5219 6.47851 14.5219Z"
                    fill="#034EA2"
                  />
                  <path
                    d="M19.2867 12.4385C19.0276 12.5323 18.7419 12.5202 18.4916 12.4049C18.2414 12.2895 18.0466 12.0802 17.9496 11.8222L16.5 7.90225C16.4534 7.77482 16.4324 7.63939 16.4385 7.50382C16.4446 7.36825 16.4776 7.23524 16.5355 7.11251C16.5934 6.98978 16.6751 6.87978 16.7759 6.7889C16.8767 6.69801 16.9945 6.62805 17.1225 6.58308C17.3817 6.48926 17.6673 6.50133 17.9176 6.61669C18.1679 6.73204 18.3626 6.94138 18.4596 7.19933L19.9075 11.1206C19.954 11.2478 19.9748 11.383 19.9687 11.5184C19.9626 11.6537 19.9297 11.7865 19.872 11.909C19.8143 12.0316 19.7328 12.1415 19.6324 12.2324C19.5319 12.3232 19.4144 12.3933 19.2867 12.4385Z"
                    fill="#034EA2"
                  />
                  <path
                    d="M15.6812 12.4282C15.9401 12.522 16.2255 12.5101 16.4756 12.3951C16.7258 12.2801 16.9206 12.0712 17.0179 11.8136L18.4625 7.9003C18.509 7.77296 18.5298 7.63765 18.5236 7.50221C18.5174 7.36677 18.4844 7.23391 18.4264 7.11134C18.3685 6.98877 18.2868 6.87893 18.186 6.7882C18.0853 6.69747 17.9675 6.62765 17.8396 6.58281C17.5808 6.48891 17.2955 6.50071 17.0454 6.61566C16.7953 6.73061 16.6005 6.93946 16.5033 7.19697L15.0583 11.1103C15.0118 11.2377 14.991 11.373 14.9972 11.5085C15.0033 11.644 15.0364 11.7769 15.0943 11.8995C15.1523 12.0221 15.234 12.1319 15.3347 12.2227C15.4355 12.3135 15.5533 12.3833 15.6812 12.4282Z"
                    fill="#034EA2"
                  />
                  <path
                    d="M17.4687 14.5219C18.8495 14.5219 19.9687 13.2976 19.9687 11.7873C19.9687 10.277 18.8495 9.05273 17.4687 9.05273C16.088 9.05273 14.9688 10.277 14.9688 11.7873C14.9688 13.2976 16.088 14.5219 17.4687 14.5219Z"
                    fill="#034EA2"
                  />
                </svg>
              </div>
              <p>FU Dormitory Regulations</p>
            </a>
            <a
              href="/Student/FAQ.html"
              className="sidebar-linkItem flex items-center"
            >
              <div className="sidebar-linkIcon">
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  width="24"
                  height="25"
                  viewBox="0 0 24 25"
                  fill="currentColor"
                  className="bi bi-person-lines-fill"
                >
                  <path d="M6 8a3 3 0 1 0 0-6 3 3 0 0 0 0 6zm-5 6s-1 0-1-1 1-4 6-4 6 3 6 4-1 1-1 1H1zM11 3.5a.5.5 0 0 1 .5-.5h4a.5.5 0 0 1 0 1h-4a.5.5 0 0 1-.5-.5zm.5 2.5a.5.5 0 0 0 0 1h4a.5.5 0 0 0 0-1h-4zm2 3a.5.5 0 0 0 0 1h2a.5.5 0 0 0 0-1h-2zm0 3a.5.5 0 0 0 0 1h2a.5.5 0 0 0 0-1h-2z" />
                </svg>
              </div>
              <p>FAQ</p>
            </a>
          </div>
        </div>

        <div className="sidebar-bottom">
          <div className="flex justify-center">
            <a className="btn-logout" href="/Home/Logout?type=Google">
              Logout
            </a>
          </div>
        </div>
      </div>
    </>
  )
}
export default Sidebar
