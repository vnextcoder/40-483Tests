import React from 'react';
import { connect } from 'react-redux';

function InputMirror(props) {


    return (
        <div>
            <input value={props.inputValue} onChange={props.inputChanged}  onReset={props.inputChanged}/>
            <p>{props.inputValue}</p>
        </div>
    )
}

const mapStatetoProps = (state) => {

    return {
        inputValue: state.inputValue
    }
}


const mapDispatchtoProps = (dispatch) => {
    return {

        inputChanged: (evt) => {
            console.log('on change happened', evt.target.value);

            const action = { type: 'INPUT_CHANGE', text: evt.target.value };
            dispatch(action);
            // inputValue: state.inputValue
        }
    }
}

export default connect(mapStatetoProps, mapDispatchtoProps)(InputMirror);
