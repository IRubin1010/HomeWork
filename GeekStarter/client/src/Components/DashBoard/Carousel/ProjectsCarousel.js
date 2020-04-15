import React from "react";
import Carousel from "react-bootstrap/Carousel";
import useStyles from "./ProjectsCarousel.css";

const ProjectsCarousel = (props) => {

    const classes = useStyles();

    const carouselItems = props.projects.map(p => {
        return(
            <Carousel.Item key={p.id}>
                <img
                    src={p.image}
                    className={classes.image}
                    alt={""}
                />
                <Carousel.Caption className={classes.caption}>
                    <p className={classes.title}>{p.name}</p>
                    <p className={classes.description}>{p.shortDescription}</p>
                </Carousel.Caption>
            </Carousel.Item>
        )
    });

    return(
        <Carousel>
            {carouselItems}
        </Carousel>
    )
};

export default ProjectsCarousel;

