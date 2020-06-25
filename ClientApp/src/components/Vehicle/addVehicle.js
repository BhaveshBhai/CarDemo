
import React from 'react';
import { Container, Col, Form, Row, FormGroup, Label, input, Button } from 'reactstrap';
export class AddVehicle extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            VehicleDetailsId: null,
            Model: '',
            Make: '',
            Engine: '',
            Doors: null,
            Wheels: null,
            VehicleId: 0,
            BodyTypeId: 0,
            vehicleTypeList: [],
            bodyTypeList: []
        }
        fetch('/api/Vehicle/GetVevhicleTypes')
            .then(response => response.json())
            .then(data => {
                this.setState({ vehicleTypeList: data });
                console.log(this.state.vehicleTypeList);
            });
        fetch('/api/Vehicle/GetBodyTypes')
            .then(response => response.json())
            .then(data => {
                this.setState({ bodyTypeList: data });
            });

    }

    handleChange = (e) => {
        this.setState({ [e.target.name]: e.target.value });
    }


    AddVehicle = () => {
        const data = {
            Model: this.state.Model, Engine: this.state.Engine,
            Make: this.state.Make,
            Doors: this.state.Doors, Wheels: this.state.Wheels,
            VehicleId: this.state.VehicleId, BodyTypeId: this.state.BodyTypeId,
            VehicleDetailsId: 0
        }
        console.log(data)

        fetch('/api/Vehicle/SaveVehicleDetails', {
            method: 'POST', // or 'PUT'
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data),
        })
            .then(response => response.json())
            .then(data => {
                console.log('Success:', data);
                this.props.history.push('/vehicle-Details')
            })
            .catch((error) => {
                console.error('Error:', error);
            });

    }

    render() {
        return (
            <Container className="App">
                <h4 className="PageHeading">Enter Vehicle Informations</h4>
                <Form className="form" onSubmit={this.AddVehicle}>
                    <Col>
                        <FormGroup row>
                            <Label for="VehicleId" sm={2}>Vehicle Type</Label>
                            <Col sm={10}>
                                <select className="form-control" data-val="true" name="VehicleId" value={this.state.VehicleId} onChange={this.handleChange} required>
                                    <option value="">-- Select Vehicle Type --</option>
                                    {this.state.vehicleTypeList.map(a =>
                                        <option key={a.vehicleId} value={a.vehicleId}>{a.name}</option>
                                    )}
                                </select>
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Label for="BodyTypeId" sm={2}>Vehicle Type</Label>
                            <Col sm={10}>
                                <select className="form-control" data-val="true" name="BodyTypeId" onChange={this.handleChange} value={this.state.BodyTypeId} required>
                                    <option value="">-- Select Vehicle Type --</option>
                                    {this.state.bodyTypeList.map(a =>
                                        <option key={a.bodyId} value={a.bodyId}>{a.bodyName}</option>
                                    )}
                                </select>
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Label for="Model" sm={2}>Model</Label>
                            <Col sm={10}>
                                <input type="text" name="Model" onChange={this.handleChange} value={this.state.Model} placeholder="Enter Model" required />
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Label for="Make" sm={2}>Make</Label>
                            <Col sm={10}>
                                <input type="text" name="Make" onChange={this.handleChange} value={this.state.Make} placeholder="Enter Make" required />
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Label for="Engine" sm={2}>Engine</Label>
                            <Col sm={10}>
                                <input type="text" name="Engine" onChange={this.handleChange} value={this.state.Engine} placeholder="Enter Engine" required />
                            </Col>
                        </FormGroup>

                        <FormGroup row>
                            <Label for="Doors" sm={2}>Doors</Label>
                            <Col sm={10}>
                                <input type="number" name="Doors" onChange={this.handleChange} value={this.state.Doors} placeholder="Enter Doors" required />
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Label for="Wheels" sm={2}>Wheels</Label>
                            <Col sm={10}>
                                <input type="number" name="Wheels" onChange={this.handleChange} value={this.state.Wheels} placeholder="Enter Wheels" required />
                            </Col>
                        </FormGroup>
                    </Col>
                    <Col>
                        <FormGroup row>
                            <Col sm={5}>
                            </Col>
                            <Col sm={1}>
                                <button type="submit" className="btn btn-success">Submit</button>
                            </Col>
                            <Col sm={1}>
                                <Button color="danger">Cancel</Button>{' '}
                            </Col>
                            <Col sm={5}>
                            </Col>
                        </FormGroup>
                    </Col>
                </Form>
            </Container>
        )

    }

}

export default AddVehicle;
