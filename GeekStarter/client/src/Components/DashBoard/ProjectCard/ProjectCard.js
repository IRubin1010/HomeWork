import React from "react";
import Card from "@material-ui/core/Card";
import CardMedia from "@material-ui/core/CardMedia";
import CardContent from "@material-ui/core/CardContent";
import Typography from "@material-ui/core/Typography";
import useStyles from "./ProjectCard.css";

const ProjectCard = (props) => {

    const classes = useStyles();

    return (
        <Card className={classes.card}>
            <CardMedia
                className={classes.media}
                image={props.project.image}
                title={props.project.name}
            />
            <CardContent className={classes.content}>
                <Typography variant="h6" component="h2" className={classes.textTitle}>
                    {props.project.name}
                </Typography>
                <Typography variant="caption" display="block" color="textSecondary" className={classes.textDescription}>
                    {props.project.shortDescription}
                </Typography>
                <Typography variant="caption" display="block" color="textSecondary" className={classes.textFooter}>
                    {props.project.creator}
                </Typography>
            </CardContent>
        </Card>
    )

};

export default ProjectCard;