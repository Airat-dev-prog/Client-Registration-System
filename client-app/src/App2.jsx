//import "./App.css"; // comment this line because use Bootstrap
import Home from "./pages/Home";
import About from "./pages/About";
import NotFound from "./pages/NotFound";

import { Navbar, Nav, Button } from "react-bootstrap";
import { List, PersonCircle } from "react-bootstrap-icons";
import { useState } from "react";
import { Routes, Route, Link, Navigate, useLocation } from "react-router-dom";

const App = () => {
  const [sidebarOpen, setSidebarOpen] = useState(false);
  const location = useLocation();

  return (
    <div className="d-flex flex-column min-vh-100">
      <Navbar bg="dark" variant="dark" fixed="top" expand="md">
        <div className="container-fluid">
          <Button
            variant="outline-secondary"
            onClick={() => setSidebarOpen(!sidebarOpen)}
            className="me-2"
          >
            <List />
          </Button>
          <Navbar.Brand as={Link} to="/">
            Menu
          </Navbar.Brand>

          <Nav className="ms-auto">
            <Nav.Link
              as={Link}
              to="/pages/about"
              active={location.pathname === "/pages/about"}
            >
              <PersonCircle className="me-1" />
              About
            </Nav.Link>
          </Nav>
        </div>
      </Navbar>

      <div
        className="container-fluid flex-grow-1"
        style={{ marginTop: "56px" }}
      >
        <div className="row h-100">
          {/* Sidebar */}
          {sidebarOpen && (
            <div className="col-md-3 col-12 bg-light p-3 border-end">
              <h4>Menu</h4>
              <nav className="nav flex-column">
                <Link
                  to="/"
                  className={`nav-link ${
                    location.pathname === "/" ? "active" : ""
                  }`}
                >
                  Home
                </Link>
                <Link
                  to="/pages/about"
                  className={`nav-link ${
                    location.pathname === "/pages/about" ? "active" : ""
                  }`}
                >
                  About too
                </Link>
              </nav>
            </div>
          )}

          {/* Main Content */}
          <div
            className={`col-${sidebarOpen ? "12 md-9" : "12"}`}
            style={{ padding: "20px" }}
          >
            <Routes>
              <Route path="/" element={<Home />} />
              <Route path="/pages/about" element={<About />} />
              <Route path="/404" element={<NotFound />} />
              <Route path="*" element={<Navigate to="/404" replace />} />
            </Routes>
          </div>
        </div>
      </div>

      <footer className="bg-dark text-white mt-auto py-3">
        <div className="container-fluid">
          <div className="row">
            <div className="col-12 text-center">© 2025 tumbleweed</div>
          </div>
        </div>
      </footer>
    </div>
  );
};

export default App;
