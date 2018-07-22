import constants from './store/constants';
import axios from 'axios';

function getRepos(dispatch, query) {
    // let query='Reactive';
    fetch(`https://api.github.com/search/repositories?q=${query}`)
        .then((response) => {
            return response.json();
        }, (reason) => {
            console.log(reason)
        }
        )
        .then((data) => {
            console.log('data is here', data)
            dispatch({ type: constants.SUBMIT, repos: data.items });
        });
}

function getReposAxis(dispatch, query) {

    axios.get(`https://api.github.com/search/repositories?q=${query}`)
        .then(function (response) {
            console.log(response);
            dispatch({ type: constants.SUBMIT, repos: response.data.items });
        });
}
export default {
    getRepos,
    getReposAxis
}