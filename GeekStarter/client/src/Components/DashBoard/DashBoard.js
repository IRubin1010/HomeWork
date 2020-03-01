import React, {Fragment} from "react";
import Grid from "@material-ui/core/Grid";
import {useStyles, hrCardStyle, topProjectCardStyle} from "./DashBoard.css"
import useMediaQuery from "@material-ui/core/useMediaQuery/useMediaQuery";
import ProjectCard from "./ProjectCard/ProjectCard";
import Divider from "@material-ui/core/Divider";
import {Link} from "react-router-dom"

const DashBoard = () => {

    let topProject = {
        id: "id1",
        name: "project1",
        image: "/picture1.jpg",
        shortDescription: "sort description 1",
        creator: "creator1"
    };

    let projects = [
        {
            id: "id2",
            name: "project2",
            image: "/picture1.jpg",
            shortDescription: "sort description 2",
            creator: "creator2"
        },
        {
            id: "id3",
            name: "project3",
            image: "/picture1.jpg",
            shortDescription: "sort description 3",
            creator: "creator3"
        },
        {
            id: "id4",
            name: "project4",
            image: "/picture1.jpg",
            shortDescription: "sort description 4",
            creator: "creator4"
        },
    ];

    const classes = useStyles();

    const isXSmallScreen = useMediaQuery(theme => theme.breakpoints.down('xs'));
    const isSmallScreen = useMediaQuery(theme => theme.breakpoints.down('sm'));

    let rootPadding = isXSmallScreen ? 0 : '1vw';

    return (

        <div style={{padding: rootPadding}}>
            <h1 style={{paddingBottom: 20}}>
                DashBoard
            </h1>

            <Grid container spacing={0}>
                <Grid item md xs={12} className={classes.topProjectGrid}>
                    <Link to={`projects/${topProject.id}`} style={{textDecoration: 'none'}}>
                        <ProjectCard project={topProject} textDescription={topProjectCardStyle.textDescription}/>
                    </Link>
                </Grid>

                <Grid container item spacing={1} md xs={12} justify="space-between" direction="column">

                    {isSmallScreen ?
                        <Divider className={classes.divider} style={{marginTop: '20px', marginBottom: '20px'}}/> : null}

                    {projects.map(project => {
                        return (
                            <Fragment key={project.id}>
                                <Grid item>
                                    <Link to={`projects/${project.id}`} style={{textDecoration: 'none'}}>
                                        <ProjectCard project={project} cardClass={hrCardStyle.cardClass}
                                                     mediaClass={hrCardStyle.mediaClass}
                                                     contentClass={hrCardStyle.contentClass}
                                                     textDescription={hrCardStyle.textDescription}/>
                                    </Link>
                                </Grid>
                                <Divider className={classes.divider}/>
                            </Fragment>)
                    })}

                    <Grid item style={{flexGrow: 1}}>
                    </Grid>

                </Grid>
            </Grid>
        </div>

    );
};

export default DashBoard;

