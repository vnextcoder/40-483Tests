import React, { Component } from 'react';
import './App.css';
import store from './store';
import Reposearch from './RepoSearch'
class App extends Component {
  render() {
    return (
      <div className="App">
       <Reposearch store={store}/>
      </div>
    );
  }
}

export default App;
