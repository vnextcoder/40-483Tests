import React, { Component } from 'react';
import store from './store';
import './App.css';
import Lister from './Lister';
class App extends Component {
  render() {
    return (
      <div className="App">
        <Lister store={store}/>
      </div>
    );
  }
}

export default App;
