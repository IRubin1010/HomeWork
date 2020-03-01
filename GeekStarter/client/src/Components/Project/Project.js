import React from "react";

const Project = (props) => {

    console.log(props);

    let {projectId} = props.match.params;

  return(
      <h1>
          {projectId}
      </h1>
  )
};

export default Project;