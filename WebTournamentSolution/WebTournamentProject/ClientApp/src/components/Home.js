import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>Web Tournament</h1>
        <p>Welcome to the web tournament example created by Peter van den Houten, built with:</p>
        <ul>
            <li><a href='https://get.asp.net/'>ASP.NET Core</a> and <a href='https://msdn.microsoft.com/en-us/library/67ef8sbd.aspx'>C#</a> for cross-platform server-side code</li>
            <li><a href='https://facebook.github.io/react/'>React</a> for client-side application</li>
            <li><a href='https://docs.microsoft.com/en-us/ef/core/providers/sqlite/?tabs=dotnet-core-cli'>Entity Framework for SQLite</a> for code-first and file-based database.</li>
        </ul>
        <p>How to play the tournamement:</p>
          <ul>
            <li><strong>Create and edit teams</strong>. Click on the <a href='teams'>Teams</a> menu to edit the teams and their players.</li>
            <li><strong>Play matches</strong>. Select two teams and play a match in the <a href='play'>Play</a> menu.</li>
            <li><strong>Look at the results and the ranking</strong>. All the match results can be view in <a href='results'>Results</a> and the ranking table is available in <a href='table'>Table</a>.</li>
        </ul>
      </div>
    );
  }
}
