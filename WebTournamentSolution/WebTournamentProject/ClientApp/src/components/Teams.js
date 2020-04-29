import React, { Component } from 'react';

export class Teams extends Component {
    static displayName = Teams.name;

    constructor(props) {
        super(props);
        this.state = { teams: [], loading: true, clicked: false };
    }

    componentDidMount() {
        this.populateTeamsList();
    }

    createNewTeam()
    {
        console.log('CreateNewTeam');
        fetch('api/teams/create',
            {
                method: "POST",
                headers: { 'Content-Type': 'application/json' }
            })
            .then(response => { this.setState({ clicked: true });
            });
    }

    static renderTeamsList(teams) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Name</th>
                    </tr>
                </thead>
                <tbody>
                    {teams.map(team =>
                        <tr>
                            <td>{team.name}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Teams.renderTeamsList(this.state.teams);

        return (
            <div>
                <h1 id="tabelLabel" >Teams</h1>
                <p>The registered teams for the tournament.</p>
                {contents}
                <button className="btn btn-primary" onClick={this.createNewTeam}>Create a new team</button>
            </div>
        );
    }

    async populateTeamsList() {
        const response = await fetch('api/teams');
        const data = await response.json();
        this.setState({ teams: data, loading: false });
    }
}
