import React, { Component } from 'react';

export class Table extends Component {
    static displayName = Table.name;

    constructor(props) {
        super(props);
        this.state = { standings: [], loading: true };
    }

    componentDidMount() {
        this.populateStandingsData();
    }

    static renderStandingsTable(standings) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Rank</th>
                        <th>Team</th>
                        <th>Games</th>
                        <th>Points</th>
                    </tr>
                </thead>
                <tbody>
                    {standings.map(standing =>
                        <tr key={standing.rank}>
                            <td>{standing.rank}</td>
                            <td>{standing.name}</td>
                            <td>{standing.games}</td>
                            <td>{standing.points}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Table.renderStandingsTable(this.state.standings);

        return (
            <div>
                <h1 id="tabelLabel" >Tournament table</h1>
                <p>Current ranking of the teams.</p>
                {contents}
            </div>
        );
    }

    async populateStandingsData() {
        const response = await fetch('api/table');
        const data = await response.json();
        this.setState({ standings: data, loading: false });
    }
}
