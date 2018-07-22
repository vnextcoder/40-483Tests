import { createStore } from 'redux';
import constants from './constants';
const initialState = {
    repos: [],
    inputValue: ''
}

const reducer = (state = initialState, action) => {

    switch (action.type) {
        case constants.CHANGE:
            console.log('change is running in reducer');
            return Object.assign({}, state,

                {
                    inputValue: action.inputValue
                }
            )

        case constants.SUBMIT:
            console.log('submit is running in reducer ');
            
            return Object.assign({}, state,

                {
                    repos: action.repos
                }
            )


        default:
            return state;
    }
}

const store = createStore(reducer, window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__());

export default store;