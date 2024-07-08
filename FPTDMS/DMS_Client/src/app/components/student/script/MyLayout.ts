let isSidebarFull = false

const sidebarFullTag = document.getElementById('sidebar-full')
const contentBodyTag = document.getElementById('content-body')

if (screen.width > 768) {
  sidebarFullTag?.classList.remove('hidden')
  isSidebarFull = true
  contentBodyTag?.classList.add('pl-328')
}

const handleToggleSidebar = () => {
  if (isSidebarFull) {
    sidebarFullTag?.classList.add('hidden')
    isSidebarFull = false
    contentBodyTag?.classList.remove('pl-328')
  } else {
    sidebarFullTag?.classList.remove('hidden')
    isSidebarFull = true
    contentBodyTag?.classList.add('pl-328')
  }
}

const sidebarLinkFull = document.getElementById('sidebarLinkFull')
const sidebarLinkShorten = document.getElementById('sidebarLinkShorten')

const url = window.location.href

const removeActiveHome = () => {
  sidebarLinkFull.children[0].classList.remove('sidebar-linkItem-active')
  sidebarLinkFull.children[0].classList.remove('sidebar-icon-active')
}

if (url.split('/')[3] === 'Student') {
  try {
    const page = url.split('/')[4]
    if (page.includes('News')) {
      removeActiveHome()

      sidebarLinkFull.children[1].classList.add('sidebar-linkItem-active')
      sidebarLinkFull.children[1].classList.add('sidebar-icon-active')
    }
    if (page.includes('Bookings')) {
      removeActiveHome()

      sidebarLinkFull.children[2].classList.add('sidebar-linkItem-active')
      sidebarLinkFull.children[2].classList.add('sidebar-icon-active')
    }
    if (page.includes('ViewBed')) {
      removeActiveHome()
      sidebarLinkFull.children[3].classList.add('sidebar-linkItem-active')
      sidebarLinkFull.children[3].classList.add('sidebar-icon-active')
    }

    if (page.includes('ParkingTicket')) {
      removeActiveHome()
      sidebarLinkFull.children[4].classList.add('sidebar-linkItem-active')
      sidebarLinkFull.children[4].classList.add('sidebar-icon-active')
    }

    if (page.includes('EWBedUsages')) {
      removeActiveHome()

      sidebarLinkFull.children[5].classList.add('sidebar-linkItem-active')
      sidebarLinkFull.children[5].classList.add('sidebar-icon-active')
    }

    if (page.includes('Invoices')) {
      removeActiveHome()

      sidebarLinkFull.children[6].classList.add('sidebar-linkItem-active')
      sidebarLinkFull.children[6].classList.add('sidebar-icon-active')
    }

    if (page === 'BedUsage') {
      removeActiveHome()

      sidebarLinkFull.children[7].classList.add('sidebar-linkItem-active')
      sidebarLinkFull.children[7].classList.add('sidebar-icon-active')
    }

    if (page.includes('CredibilityScore')) {
      removeActiveHome()

      sidebarLinkFull.children[8].classList.add('sidebar-linkItem-active')
      sidebarLinkFull.children[8].classList.add('sidebar-icon-active')
    }

    if (page.includes('Requests')) {
      removeActiveHome()

      sidebarLinkFull.children[9].classList.add('sidebar-linkItem-active')
      sidebarLinkFull.children[9].classList.add('sidebar-icon-active')
    }

    if (page.includes('Guidelines')) {
      removeActiveHome()

      sidebarLinkFull.children[10].classList.add('sidebar-linkItem-active')
      sidebarLinkFull.children[10].classList.add('sidebar-icon-active')
    }

    if (page.includes('Policy')) {
      removeActiveHome()

      sidebarLinkFull.children[11].classList.add('sidebar-linkItem-active')
      sidebarLinkFull.children[11].classList.add('sidebar-icon-active')
    }

    if (page.includes('FAQ')) {
      removeActiveHome()

      sidebarLinkFull.children[12].classList.add('sidebar-linkItem-active')
      sidebarLinkFull.children[12].classList.add('sidebar-icon-active')
    }
  } catch (error) {}
}

if (url.split('/')[3] === 'Security') {
  try {
    const page = url.split('/')[4]
    if (page.includes('EWUsages')) {
      removeActiveHome()

      sidebarLinkFull.children[1].classList.add('sidebar-linkItem-active')
      sidebarLinkFull.children[1].classList.add('sidebar-icon-active')
    }

    if (page.includes('BedUsages')) {
      removeActiveHome()

      sidebarLinkFull.children[2].classList.add('sidebar-linkItem-active')
      sidebarLinkFull.children[2].classList.add('sidebar-icon-active')
    }

    if (page.includes('Doms')) {
      removeActiveHome()

      sidebarLinkFull.children[3].classList.add('sidebar-linkItem-active')
      sidebarLinkFull.children[3].classList.add('sidebar-icon-active')
    }

    if (page.includes('CredibilityReports')) {
      removeActiveHome()

      sidebarLinkFull.children[4].classList.add('sidebar-linkItem-active')
      sidebarLinkFull.children[4].classList.add('sidebar-icon-active')
    }

    if (page.includes('Requests') || page.includes('CheckoutRecord')) {
      removeActiveHome()

      sidebarLinkFull.children[5].classList.add('sidebar-linkItem-active')
      sidebarLinkFull.children[5].classList.add('sidebar-icon-active')
    }

    if (page.includes('Guidelines')) {
      removeActiveHome()

      sidebarLinkFull.children[6].classList.add('sidebar-linkItem-active')
      sidebarLinkFull.children[6].classList.add('sidebar-icon-active')
    }
  } catch (error) {}
}
