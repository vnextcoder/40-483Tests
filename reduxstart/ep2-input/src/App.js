import React, { Component } from 'react';
import store from './store';
import './App.css';
import InputMirror from './InputMirror';
class App extends Component {
  render() {
    return (
      <div className="App">
        <InputMirror store={store}/>
      </div>
    );
  }
}

export default App;
