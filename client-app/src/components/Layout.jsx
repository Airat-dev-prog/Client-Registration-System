import { Outlet } from "react-router-dom";
import AppHeader from "./Header";
import AppSidebar from "./Sidebar";
import AppFooter from "./Footer";
import { Container, Row, Col } from "react-bootstrap";

const AppLayout = () => {
  return (
    <div className="d-flex flex-column min-vh-100">
      <AppHeader />

      <Container fluid className="flex-grow-1">
        <Row>
          {/* <Col md={3} lg={2} className="my-border ">
            <AppSidebar  />
          </Col> */}

          <Col >
            <main className="px-4">
              <Outlet />
            </main>
          </Col>
          
        </Row>
      </Container>

      <AppFooter />
    </div>
  );
};

export default AppLayout;
