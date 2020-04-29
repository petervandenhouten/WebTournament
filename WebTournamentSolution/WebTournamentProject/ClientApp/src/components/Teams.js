import React, { Component } from 'react';
import { Button } from 'reactstrap';

function refreshPage()
{
    window.location.reload(false);
}

export class Teams extends Component
{
    static displayName = Teams.name;

    constructor(props)
    {
        super(props);
        this.state = { teams: [], loading: true, clicked: false };
    }

    componentDidMount()
    {
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

        refreshPage();
    }

    static renameTeam(id)
    {
        console.log("rename" + id)
    }

    static editTeam(id)
    {
        console.log("edit" + id)
    }

    static deleteTeam(id)
    {
        console.log("delete" + id)
    }

    static renderTeamsList(teams)
    {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Name</th>
                    </tr>
                </thead>
                <tbody>
                    {teams.map(team =>
                        <tr key={team.teamid}>
                            <td>{team.teamId} / {team.name}</td>
                            <td><Button color="secondary" onClick={() => Teams.renameTeam(team.teamId)} > Rename</Button></td>
                            <td><Button color="secondary" onClick={() => Teams.editTeam(team.teamId)}>EditPlayers</Button></td>
                            <td><Button color="danger" onClick={() => Teams.deleteTeam(team.teamId)}>Delete</Button></td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render()
    {
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

    async populateTeamsList()
    {
        const response = await fetch('api/teams');
        const data = await response.json();
        this.setState({ teams: data, loading: false });
    }
}
