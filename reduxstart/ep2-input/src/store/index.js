import {createStore} from 'redux';

const initialState =  {

    inputValue:'afaf'
}


const reducer = (state=initialState, action)=> {
    console.log('reducer running', action);
    switch (action.type){
        case 'INPUT_CHANGE':
            return Object.assign({}, state, {inputValue:action.text});
        default:
            return state;
    }
    
}

const store = createStore(reducer);
export default store;