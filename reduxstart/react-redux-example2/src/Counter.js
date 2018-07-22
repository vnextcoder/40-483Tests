import React from 'react';
import {connect} from 'react-redux';
function Counter(props) {
    return (
        <div>
            <h1>I am a counter</h1>
            <p> Count is : {props.count}</p>
            <button> Increment</button>
        </div>  
    )
}


function mapStatetoProps(state) {
    return {
        count: state.count
    }

}


// function mapDispatchtoProps(disptach) {

// }
export default connect(mapStatetoProps)(Counter);