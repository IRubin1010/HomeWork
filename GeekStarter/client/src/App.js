import React from 'react';
import { ThemeProvider } from '@material-ui/core/styles';

import Layout from "./Containers/Layout/Layout";
import theme from "./Theme/Theme";

import extensions from "./Utils/extensions"; // to init DO NOT DELETE

function App() {


  return (
      <ThemeProvider theme={theme}>
        <Layout/>
      </ThemeProvider>


  )
}

export default App;
