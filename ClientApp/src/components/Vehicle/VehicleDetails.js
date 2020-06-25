import React, { Component } from 'react';
import { Link } from 'react-router-dom';

export class VehicleDetails extends Component {
    static displayName = VehicleDetails.name;

    constructor(props) {
        super(props);
        this.state = { vehicleDetails: [], loading: true };
    }

    componentDidMount() {
        this.populateVehicleDetailData();
    }

    static renderVehicleDetailsTable(vehicleDetails) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Make</th>
                        <th>Model</th>
                        <th>Engine</th>
                        <th>Doors</th>
                        <th>Vehicle Type</th>
                        <th>Body Type</th>
                        <th>Action</th>
                    </tr>
                </thead>
                <tbody>
                    {vehicleDetails.map(vehicleDetail =>
                        <tr key={vehicleDetail.vehicleDetailsId}>
                            <td>{vehicleDetail.make}</td>
                            <td>{vehicleDetail.model}</td>
                            <td>{vehicleDetail.engine}</td>
                            <td>{vehicleDetail.doors}</td>
                            <td>{vehicleDetail.vehicleType}</td>
                            <td>{vehicleDetail.bodyType}</td>
                            <td>
                                {/*  <Link to={"/edit/" + vehicleDetail.vehicleDetailsId} className="btn btn-success">Edit</Link> <br/>*/}
                                <button type="button" onClick={this.DeleteStudent} className="btn btn-danger">Delete</button>
                            </td>
                           
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : VehicleDetails.renderVehicleDetailsTable(this.state.vehicleDetails);

        return (
            <div>
                <h1 id="tabelLabel" >VehicleDetail</h1>
                <p>
                    <Link to="/addVehicle">Create New</Link>
                </p>  
                {contents}
            </div>
        );
    }

    async populateVehicleDetailData() {
        const response = await fetch('/api/Vehicle/VehicleTypes');
        const data = await response.json();
        this.setState({ vehicleDetails: data, loading: false });
    }
}
