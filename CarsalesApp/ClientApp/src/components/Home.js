import React, { Component } from 'react';
import {DropdownButton,Dropdown } from 'react-bootstrap';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
            <DropdownButton id="dropdown-basic-button" title="Select Create vehicle Type">
                <Dropdown.Item href="/vehicle-Details">Car</Dropdown.Item>
               
            </DropdownButton>
      </div>
    );
  }
}
