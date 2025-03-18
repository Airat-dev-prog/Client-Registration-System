import "bootstrap/dist/css/bootstrap.css";
//import "./main.css";
import "./App.css"; // comment this line because use Bootstrap

import { Routes, Route, Navigate } from "react-router-dom";
import AppLayout from "./components/Layout";
import Home from "./pages/Home";
import About from "./pages/About";
import Contact from "./pages/Contact";
import NotFound from "./pages/NotFound";
import AppHeader from "./components/Header";
import AppExample from "./components/Example ";

const App = () => {
  return (
    // <div className="App">
    //   <header id="header">
    //     <AppHeader />
    //   </header>
    //   <main id="main">
    //     <AppExample />
    //   </main>
    // </div>
    <Routes>
      <Route path="/" element={<AppLayout />}>
        <Route index element={<Home />} />
        <Route path="example" element={<AppExample />} />
        <Route path="about" element={<About />} />
        <Route path="contact" element={<Contact />} />
        <Route path="/404" element={<NotFound />} />
        <Route path="*" element={<Navigate to="/404" replace />} />
      </Route>
    </Routes>
  );
};

export default App;
