import React, { Component } from 'react';

export class Results extends Component {
    static displayName = Results.name;

    constructor(props) {
        super(props);
        this.state = { results: [], loading: true };
    }

    componentDidMount() {
        this.populateResultsData();
    }

    static renderResultsTable(results) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Team 1</th>
                        <th></th>
                        <th></th>
                        <th>Team 2</th>
                    </tr>
                </thead>
                <tbody>
                    {results.map(result =>
                        <tr>
                            <td>{result.teamName1}</td>
                            <td>{result.score1}</td>
                            <td>{result.score2}</td>
                            <td>{result.teamName2}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Results.renderResultsTable(this.state.results);

        return (
            <div>
                <h1 id="tabelLabel" >Game results</h1>
                <p>The results of the games played in this tournament.</p>
                {contents}
            </div>
        );
    }

    async populateResultsData() {
        const response = await fetch('api/results');
        const data = await response.json();
        this.setState({ results: data, loading: false });
    }
}
