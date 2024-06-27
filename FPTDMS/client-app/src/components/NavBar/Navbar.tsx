import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import './Navbar.css';

class Nav extends Component {
    render() {
        return (
            <>
                <div className="logo">
                    <img src="/path/to/logo.png" alt="DMS Logo"/>
                </div>
                <div className="nav-links">
                    <Link to="/">Home</Link>
                    <Link to="/about">About Us</Link>
                    <Link to="/facilities">Facilities</Link>
                    <Link to="/availability">Room Availability</Link>
                    <Link to="/rules">Rules and Regulations</Link>
                    <Link to="/events">Events</Link>
                    <Link to="/contact">Contact Us</Link>
                    <Link to="/faqs">FAQs</Link>
                </div>
                <div className="right-side">
                    <Link to="/login"><button>Login</button></Link>
                    <Link to="/register"><button>Register</button></Link>
                </div>
            </>
       );
    }
}

export default Nav;