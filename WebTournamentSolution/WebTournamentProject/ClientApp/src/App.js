import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Teams } from './components/Teams';
import { Results } from './components/Results';
import { Table } from './components/Table';
import { Play } from './components/Play';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/teams' component={Teams} />
        <Route path='/results' component={Results} />
        <Route path='/table' component={Table} />
        <Route path='/play' component={Play} />
      </Layout>
    );
  }
}
