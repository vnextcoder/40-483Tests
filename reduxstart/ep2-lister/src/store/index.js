import {createStore} from 'redux';
import constants from './constants';
console.log('what are the constants', constants)

const initialState = {
    inputText:'',
    items:[]
}

const reducer  = (state= initialState,action ) => {

   // console.log('reducer running', action);

    switch (action.type)
    {
        case constants.CHANGE_INPUT:
            return Object.assign({}, state, {inputText:action.text});
        case constants.ADD_ITEM:
            return Object.assign({}, state, {
                items: state.items.concat(state.inputText),
                inputText:''
            });
        case constants.DELETE_ITEM:
            console.log(action.index);
            // return Object.assign({}, state, 
            // {
                
            //     items : state.items.splice(action.indextoRemove,1 )
            // })

            const copyofItems = state.items.slice();
            copyofItems.splice(action.index, 1);
            return Object.assign({} , state, {items: copyofItems});
        default:
            return state;
    }
}

const store= createStore(reducer);

export default store;