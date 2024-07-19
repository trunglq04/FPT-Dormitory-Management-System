import React from "react";
import ReactDOM from "react-dom/client";
import App from "./app/layout/App";
import "./index.css";
// import './assets/Site.css'
import { BrowserRouter } from "react-router-dom";
import "./assets/logo.png";
import "bootstrap/dist/css/bootstrap.min.css";
import "semantic-ui-css/semantic.min.css";
import "jquery/dist/jquery.min.js";

const rootElement = document.getElementById("root");
if (rootElement) {
  const root = ReactDOM.createRoot(rootElement);
  root.render(
    <React.StrictMode>
      <BrowserRouter>
        <App />
      </BrowserRouter>
    </React.StrictMode>
  );
}
