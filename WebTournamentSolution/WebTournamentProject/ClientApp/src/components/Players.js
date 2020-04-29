import React, { Component } from 'react';
import { Button } from 'reactstrap';
import { withRouter, useParams } from 'react-router-dom';

function refreshPage() {
    window.location.reload(false);
}

function GetTeamFromUrl() {
    return useParams();
}

export class Players extends Component {
    static displayName = Players.name;

    constructor(props)
    {
        super(props);
        this.state = { players: [], loading: true, clicked: false, teamId: 0 };
    }

    componentDidMount()
    {
        this.populatePlayersList();
    }

    createNewTeam() {
        //console.log('CreateNewTeam');
        //fetch('api/teams/create',
        //    {
        //        method: "POST",
        //        headers: { 'Content-Type': 'application/json' }
        //    })
        //    .then(response => {
        //        this.setState({ clicked: true });
        //    });

        refreshPage();
    }

    static renamePlayer(id) {
        console.log("rename" + id)
    }

    static deletePlayer(id) {
        console.log("delete" + id)
    }

    static renderPlayersList(players) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Name</th>
                    </tr>
                </thead>
                <tbody>
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Players.renderPlayersList(this.state.players);

        return (
            <div>
                <h1 id="tabelLabel" >Players</h1>
                <p>The registered players for the team {this.state.players.name}.</p>
                {contents}
                <button className="btn btn-primary" onClick={this.createNewTeam}>Create a new player</button>
            </div>
        );
    }

    async populatePlayersList(teamId) {
        // id = 1; // GetTeamFromUrl();
        const response = await fetch('api/players/1');
        const data = await response.json();
        this.setState({ players: data, loading: false });
    }
}
