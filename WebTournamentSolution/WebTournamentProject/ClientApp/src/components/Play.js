import React, { Component } from 'react';

export class Play extends React.Component
{
    static displayName = Play.name;

    constructor(props)
    {
        super(props);
        this.state = { teams: [], loading: true, team1: 1, team2: 1  };

        this.handleChange1 = this.handleChange1.bind(this);
        this.handleChange2 = this.handleChange2.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    componentDidMount() {
        this.populateComboboxTeams();
        //if (this.state.teams.length > 0)
        //{
        //    this.state.team1 = this.state.teams[0].teamId;
        //    this.state.team2 = this.state.teams[0].teamId;
        //}
        //if (this.state.teams.length > 1)
        //{
        //    this.state.team2 = this.state.teams[1].teamId;
        //}
    }

    handleChange1(event)
    {
        this.setState({ team1: event.target.value });
    }

    handleChange2(event) {
        this.setState({ team2: event.target.value });
    }

    handleSubmit(event)
    {
        console.log('Selected teams: ' + this.state.team1 + ' and ' + this.state.team2 );
        event.preventDefault();

        let param1 = "id1=" + this.state.team1;
        let param2 = "id2=" + this.state.team2;

        let url = 'api/play/match/' + this.state.team1 + '/' + this.state.team2;
        fetch(url,
            {
                method: "POST",
                headers: { 'Content-Type': 'application/json' }
                //body: param1 + "&" + param2
            })
            .then((response) => response.text())
            .then((responseText) => {
                alert(responseText);
         });
    }

    renderTeamSelection(teams) {
        return (
            <div>
                <select value={this.state.team1} onChange={this.handleChange1}>
                    {teams.map(team =>
                        <option value={team.teamId}>{team.name}</option>
                    )}
                </select>
                -
                <select value={this.state.team2} onChange={this.handleChange2}>
                 {teams.map(team =>
                        <option value={team.teamId}>{team.name}</option>
                    )}
                </select>
            </div>
        );
    }

    render()
    {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderTeamSelection(this.state.teams);

        return (
            <div>
                <h1>Play a game</h1>
                <p>Select two teams to play a match.</p>
                <form onSubmit={this.handleSubmit}>
                    <label>
                        Pick the teams :
                        {contents}
                    </label>
                    <br/>
                    <input class-name="btn" type="submit" value="Submit" />
                </form>
            </div>
        );
    }

    async populateComboboxTeams() {
        const response = await fetch('api/play');
        const data = await response.json();
        this.setState({ teams: data, loading: false });
    }
}
