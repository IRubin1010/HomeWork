import React from 'react';
import { ThemeProvider } from '@material-ui/core/styles';

import Layout from "./Containers/Layout/Layout";
import theme from "./Theme/Theme";

function App() {


  return (
      <ThemeProvider theme={theme}>
        <Layout/>
      </ThemeProvider>


  )
}

export default App;
