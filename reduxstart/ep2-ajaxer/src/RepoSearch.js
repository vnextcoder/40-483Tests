import React from 'react';
import constants from './store/constants';
import { connect } from 'react-redux';
import Api from './Api';


//console.log('Api? ', Api);
function RepoSearch(props) {
    return (
        <div>
            <h1> Repo Search</h1>
            <form onSubmit={(evt) => props.onSubmit(evt, props.inputValue)}>
                <input value={props.inputValue} onChange={props.onChange} />
            </form>

            <ul>
                {props.repos.map((repo) => {

                    return (
                        <li key={repo.id}><a href={repo.html_url}>{repo.name}</a></li>
                    );
                }

                )}
            </ul>

        </div>
    )
}

const mapStatetoProps = (state) => {
    return {
        inputValue: state.inputValue,
        repos: state.repos
    }
}

const mapDispatchtoProps = (dispatch) => {
    return {
        onChange: (evt) => {
            console.log('input changed', evt.target.value);
            evt.preventDefault();
            const action = {
                type: constants.CHANGE,
                inputValue: evt.target.value
            };
            dispatch(action);
        },
        onSubmit: (evt, query) => {


            evt.preventDefault();

            Api.getReposAxis(dispatch, query)
           
            console.log('submit is called');

        }


    }


}


export default connect(mapStatetoProps, mapDispatchtoProps)(RepoSearch);