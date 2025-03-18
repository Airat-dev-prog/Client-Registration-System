import { useState } from "react";
import { Link, NavLink } from "react-router-dom";
import { Button, Container, Nav, Navbar } from "react-bootstrap";
import { List } from "react-bootstrap-icons";

const AppHeader = () => {
  const [sidebarOpen, setSidebarOpen] = useState(false);

  // return (
  //   <Navbar expand="lg" className="bg-body-tertiary">
  //     <Container>
  //       <Navbar.Brand href="#home">C-R-S</Navbar.Brand>
  //       <Navbar.Toggle aria-controls="basic-navbar-nav" />
  //       <Navbar.Collapse id="basic-navbar-nav">
  //         <Nav className="me-auto">
  //           <Nav.Link href="#home">Home</Nav.Link>
  //           <Nav.Link href="#link">Link</Nav.Link>
  //         </Nav>
  //       </Navbar.Collapse>
  //     </Container>
  //   </Navbar>
  // );

  return (
    <header className="navbar navbar-dark bg-dark flex-md-nowrap p-3 shadow">
      <nav className="ms-auto">
        <div className="d-flex gap-3">
          <NavLink
            to="/"
            className={({ isActive }) =>
              `nav-link ${isActive ? "active" : ""} text-white`
            }
          >
            Home
          </NavLink>
        </div>
      </nav>
      <Button
        variant="outline-secondary"
        onClick={() => setSidebarOpen(!sidebarOpen)}
        className="me-2"
      >
        <List />
      </Button>
    </header>
  );
};

export default AppHeader;
