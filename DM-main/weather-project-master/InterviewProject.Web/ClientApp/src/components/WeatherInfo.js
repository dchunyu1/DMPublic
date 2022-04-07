import React, { Component } from 'react';

export class WeatherInfo extends Component {
  static displayName = WeatherInfo.name;

    constructor(props) {
        super(props);

        this.state = { forecasts: [], loading: true, id: this.props.woeidNumber, city: this.props.cityName };


    }

    componentDidMount() {
        this.populateWeatherData();
    }
    componentDidUpdate(prevProps) {
        if (this.props.woeidNumber != prevProps.woeidNumber) {
            this.setState({ id: this.props.woeidNumber, city: this.props.cityName }, function () {
                this.populateWeatherData();

            });
        }
    }

    static renderForecastsTable(forecasts, city) {
        return (
            <div>
                <h1 id="tabelLabel" >  Weather for the city {city}</h1>
                <table className='table table-striped' aria-labelledby="tabelLabel">
                    <thead>
                        <tr>
                            <th>Date</th>
                            <th>Temp Min</th>
                            <th>Temp Max</th>
                        </tr>
                    </thead>
                    <tbody>
                        {forecasts.length > 0 ?
                            forecasts.map(forecast =>
                                <tr key={forecast.date}>
                                    <td>{forecast.date}</td>
                                    <td>{forecast.tempMin}</td>
                                    <td>{forecast.tempMax}</td>
                                </tr>
                            )
                            : <tr> No data </tr>
                        }
                    </tbody>
                </table>
            </div>
        );
    }

    render() {
        let contents = this.state.loading
            ? < p ></p>
            : WeatherInfo.renderForecastsTable(this.state.forecasts, this.state.city);

        return (
            <div>
                {contents}
            </div>
        );
    }

    async populateWeatherData() {
        try {
            const id = this.state.id;
            const path = "GetWeatherInfo?id=" + id;
            const response = await fetch(path);
            const data = await response.json();
            this.setState({ forecasts: data, loading: false });
        }
        catch (err) {
            // need implement error log
            console.log(err);
        }
    }
}
