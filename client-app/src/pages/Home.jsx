import { useEffect } from "react";
import { useState } from "react";
import axios from "axios";
import ItemsGroup from "../components/ItemsGroup";
import { Container, Row, Col } from "react-bootstrap";
import { Carousel } from "react-bootstrap";

const Home = () => {
  const [message, setMessage] = useState("");

  const exampleData = [
    {
      id: 1,
      image: "barber1.webp",
      title: "Discover the World's Most Popular Brands",
      description: "From clothing to electronics, we've got you covered.",
      link: "#",
      text: "Записаться"
    },
    {
      id: 2,
      image: "barber2.webp",
      title: "Discover the World's Most Popular Brands",
      description: "From clothing to electronics, we've got you covered.",
      link: "#",
      text: "Записаться"
    },
    {
      id: 3,
      image: "barber3.jpg",
      title: "Discover the World's Most Popular Brands",
      description: "From clothing to electronics, we've got you covered.",
      link: "#",
      text: "Записаться"
    }
  ];

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await axios.get("http://localhost:5080/offices"); //5188
        setMessage(JSON.stringify(response.data));
      } catch (error) {
        console.error("Error fetching data:", error);
      }
    };
    fetchData();
  }, []);

  return (
    <>
      <h1>Выберите исполнителя услуги</h1>

      <ItemsGroup exampleData={exampleData}/>

      <p className="text-center">{message}</p>
    </>
  );
};

export default Home;
