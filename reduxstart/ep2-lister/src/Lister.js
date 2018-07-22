import React from 'react';
import constants from './store/constants';
import { connect } from 'react-redux';

function Lister(props) {
   // console.log('Lister running');
    return (
        <div>
            <form onSubmit={props.submit}>
                <input value={props.inputText} onChange={props.inputChange} />
            </form>

            <ul>
                {props.items.map((item, index) => {
                    return <li key={index} 
                    onClick={() =>  props.itemDelete(index)}>{item}</li>
                })}
            </ul>
        </div>
    )
}

const mapStatetoProps = (state) => {
    return {
        inputText: state.inputText,
        items: state.items
    }
};

const mapDispatchtoProps = (dispatch) => {

    return {

        inputChange: (evt) => {
            console.log('input changed', evt.target.value);
            evt.preventDefault();
            const action = {
                type: constants.CHANGE_INPUT,
                text: evt.target.value
            };
            dispatch(action);
        },
        submit: (evt) => {

            evt.preventDefault();
            const action = { type: constants.ADD_ITEM };
            dispatch(action);
        },
        itemDelete: (index) => {
            console.log(index);
            const action = { type: constants.DELETE_ITEM, index: index };
            dispatch(action);
        }
    }
};

export default connect(mapStatetoProps, mapDispatchtoProps)(Lister);