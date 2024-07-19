import { useState } from 'react';
import { Drawer, List, ListItem, ListItemIcon, ListItemText, ListItemButton, Box, IconButton } from '@mui/material';
import { Home, Notifications, Bed, Send, History, Help, Menu } from '@mui/icons-material';
import { NavLink } from 'react-router-dom';
import MyLogo from '../../assets/FrogSleep.png';
import { Image } from 'react-bootstrap';

const drawerWidth = 240;
const drawerWidthCollapsed = 60;

const SideBar = () => {
  const [open, setOpen] = useState(true);

  const handleDrawerToggle = () => {
    setOpen(!open);
  };

  const navItems = [
    { text: 'Home', icon: <Home />, to: '/user/dashboard' },
    { text: 'News', icon: <Notifications />, to: '/tables' },
    { text: 'Booking Bed', icon: <Bed />, to: '/user/booking-bed' },
    { text: 'Service', icon: <Send />, to: '/user/service' },
    { text: 'Payment History', icon: <History />, to: '/user/payments' },
    { text: 'Student Guide', icon: <Help />, to: '' },
  ];

  return (
    <>
      <Drawer
        sx={{
          width: open ? drawerWidth : drawerWidthCollapsed,
          flexShrink: 0,
          '& .MuiDrawer-paper': {
            width: open ? drawerWidth : drawerWidthCollapsed,
            boxSizing: 'border-box',
            backgroundColor: '#F36F21',
            color: '#fff',
            transition: 'width 0.3s',
            overflowX: 'hidden'
          },
        }}
        variant="permanent"
        anchor="left"
      >
        <Box
          sx={{
            display: 'flex',
            flexDirection: 'column',
            height: '100vh',
            overflow: 'auto',
          }}
        >
          <Box sx={{ display: 'flex', alignItems: 'center', justifyContent: 'center', p: 2 }}>
            <IconButton onClick={handleDrawerToggle} sx={{ color: '#fff' }}>
              <Menu />
            </IconButton>
            {open && <Image src={MyLogo} style={{ width: '50%' }} />}
          </Box>
          <List>
            {navItems.map((item, index) => (
              <NavLink to={item.to} key={index} style={{ textDecoration: 'none', color: 'inherit' }}>
                <ListItem disablePadding sx={{ display: 'block', textAlign: 'center' }}>
                  <ListItemButton
                    sx={{
                      minHeight: 48,
                      justifyContent: 'center',
                      px: 2.5,
                      '&:hover': {
                        backgroundColor: 'white',
                        color: '#F36F21',
                      },
                    }}
                  >
                    <ListItemIcon sx={{ color: 'inherit', minWidth: 0 }}>
                      {item.icon}
                    </ListItemIcon>
                    {open && <ListItemText primary={item.text} sx={{ opacity: open ? 1 : 0 }} />}
                  </ListItemButton>
                </ListItem>
              </NavLink>
            ))}
          </List>
        </Box>
      </Drawer>
    </>
  );
};

export default SideBar;
