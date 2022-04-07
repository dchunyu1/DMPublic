import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Weather } from './components/Weather';
import { Counter } from './components/Counter';
import { SearchLocation } from './components/SearchLocation';


export default [
    <Route exact path='/' component={Home} />,
    <Route path='/counter' component={Counter} />,
    <Route path='/weather' component={Weather} />,
    <Route path='/searchLocation' component={SearchLocation} />
]
