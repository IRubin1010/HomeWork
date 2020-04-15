import React from "react";

const Project = (props) => {

    console.log(props);

    let {projectId} = props.match.params;

  return(
      <div style={{marginTop: 64, display: 'flex'}}>
          <h1 >
              {projectId}
          </h1>
      </div>

  )
};

export default Project;