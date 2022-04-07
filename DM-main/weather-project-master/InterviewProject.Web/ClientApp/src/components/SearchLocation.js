import React, { Component, useState } from 'react';
import { WeatherInfo } from './WeatherInfo';
export class SearchLocation extends Component {

    static displayName = SearchLocation.name;

    constructor(props) {
        super(props);
        this.state = { locations: [], loading: false, input: "", woeid: 0, city: "" };
    }


    static renderListLocation(locations, p) {
        return (
            <div>
                <p> Please select city from list to get weather of that city </p>
                <ul>
                    {
                        locations.map((data) => {
                            if (data) {
                                return (
                                    <li key={data.woeID} onClick={(e) => p.MeClick(e, data, p)} >
                                        {data.locationName}
                                    </li>
                                )
                            }
                            return null
                        })
                    }
                </ul>
            </div>
        );
    }

    render() {
        let contents = this.state.loading
            ? SearchLocation.renderListLocation(this.state.locations, this)
            : <p></p>;


        return (
            <>
                <h1>Location for Weather</h1>
                <input type="text" className="form-control"
                    key="weather"
                    value={this.state.input}
                    placeholder={"Enter location"}
                    onChange={(e) => this.setState({ input: e.target.value })}
                />
                <button className="btn btn-primary" onClick={() => this.populateLocationData()}> Search </button>

                {contents}
                <WeatherInfo cityName={this.state.city} woeidNumber={this.state.woeid} />
            </>

        );
    }

    async populateLocationData() {
        try {
            const path = "Search?search=" + this.state.input;
            const response = await fetch(path);
            const data = await response.json();
            this.setState({ locations: data, loading: true });
        }
        catch (err) {
            // need implement error log
            console.log(err);
        }
    }
    MeClick(e, data, p) {
        console.log("here");
        p.setState({ woeid: data.woeID, city: data.locationName });
        p.setState({ woeid: data.woeID }, function () {
            console.log(p.state.woeid);
        });

    }
    
}