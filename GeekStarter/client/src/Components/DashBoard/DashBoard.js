import React from "react";
import useStyles from "./DashBoard.css"
import useMediaQuery from "@material-ui/core/useMediaQuery/useMediaQuery";
import 'bootstrap/dist/css/bootstrap.min.css';
import ProjectsCarousel from "./Carousel/ProjectsCarousel";
import Grid from "@material-ui/core/Grid";
import {Link} from "react-router-dom"
import ProjectCard from "./ProjectCard/ProjectCard";

const DashBoard = () => {

    let projects = [
        {
            id: "id2",
            name: "project2",
            image: "https://c1.iggcdn.com/indiegogo-media-prod-cld/image/upload/f_auto/v1580949362/onanvy5ta2wewv2r8ijr.png",
            shortDescription: "sort description 2",
            creator: "creator2"
        },
        {
            id: "id3",
            name: "project3",
            image: "https://c1.iggcdn.com/indiegogo-media-prod-cld/image/upload/f_auto/v1580147168/wk0yiaosxx6cdo5bcri4.png",
            shortDescription: "sort description 3",
            creator: "creator3"
        },
        {
            id: "id4",
            name: "project4",
            image: "https://c1.iggcdn.com/indiegogo-media-prod-cld/image/upload/f_auto/v1580497863/ttlalzgbzpa4ndfpzycp.png",
            shortDescription: "sort description 4",
            creator: "creator4"
        },
        {
            id: "id5",
            name: "project2",
            image: "https://c1.iggcdn.com/indiegogo-media-prod-cld/image/upload/f_auto/v1580949362/onanvy5ta2wewv2r8ijr.png",
            shortDescription: "sort description 2",
            creator: "creator2"
        },
        {
            id: "id6",
            name: "project3",
            image: "https://c1.iggcdn.com/indiegogo-media-prod-cld/image/upload/f_auto/v1580147168/wk0yiaosxx6cdo5bcri4.png",
            shortDescription: "sort description 3",
            creator: "creator3"
        },
        {
            id: "id7",
            name: "project4",
            image: "https://c1.iggcdn.com/indiegogo-media-prod-cld/image/upload/f_auto/v1580497863/ttlalzgbzpa4ndfpzycp.png",
            shortDescription: "sort description 4",
            creator: "creator4"
        },
    ];

    const classes = useStyles();

    let cardsSpacing = useMediaQuery(theme => theme.breakpoints.up('md')) ? 4 : 3;

    return (

        <div className={classes.root}>
            <ProjectsCarousel projects={projects}/>
            <div>
                <div style={{marginTop: '70px'}}></div>
                <Grid container spacing={cardsSpacing} item xs={12} className={classes.container} >
                    {projects.map(project => {
                        return (
                                <Grid item xl={3} sm={4} xs={6} key={project.id}>
                                    <Link to={`projects/${project.id}`} style={{textDecoration: 'none'}}>
                                        <ProjectCard project={project} />
                                    </Link>
                                </Grid>)
                    })}

                </Grid>
            </div>
        </div>

    );
};

export default DashBoard;

