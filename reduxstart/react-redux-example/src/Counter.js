import React from 'react';
import {connect } from 'react-redux';

function Counter(props)
{

    console.log('render', props);
    return (

        <div>
            <h1>I am a Counter!</h1>
            <p>Count: {props.count}</p>
            <button onClick={props.onIncrementClick}>increment</button>
            <button onClick={props.onDecrementClick}>decrement</button>
        </div>
    )
}


function mapStatetoProps(state){
    console.log('Map state to Props', state);
    return {
        count:state.count
    }

}


function mapDispatchtoProps(dispatch){

    return {
        onIncrementClick: ()=> {
        
            console.log('going to call INCREMENT');
            const action={type:'INCREMENT'};
            dispatch(action);
        },

        onDecrementClick: ()=> {
        
            console.log('going to call DECREMENT');
            const action={type:'DECREMENT'};
            dispatch(action);
        }
    }
}


export default connect(mapStatetoProps, mapDispatchtoProps)(Counter)