import { Carousel } from "react-bootstrap";
import Items from "./Items";

const ItemsGroup = () => {
  const imageUrl = 'http://localhost:5173/src/assets/images/';
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

  return (
    <Carousel
      interval={null}
      data-bs-theme="dark"
    >
     {exampleData.map((item) => {
          return (
            <Carousel.Item key={item.id}>
              <img
                className="d-block w-100"
                src={`${imageUrl}${item.image}`}
                alt={"Slide " + item.id}
              />
              <Carousel.Caption>
                <h3>{item.title}</h3>
                <p>{item.description}</p>
                <a className="btn btn-primary" href={item.link}>
                  {item.text}
                </a>
              </Carousel.Caption>
            </Carousel.Item>
          );
        })}
    </Carousel>
  );
};

export default ItemsGroup;
