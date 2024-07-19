import React from 'react';
import { MDBTable, MDBTableHead, MDBTableBody } from 'mdb-react-ui-kit';
import { House } from '../../models/Dorm';

interface HouseTableProps {
  houses: House[];
}

const HouseTable: React.FC<HouseTableProps> = ({ houses }) => {
  return (
    <MDBTable>
      <MDBTableHead dark>
        <tr>
          <th scope='col'>#</th>
          <th scope='col'>Name</th>
          <th scope='col'>Description</th>
          <th scope='col'>Status</th>
          <th scope='col'>Capacity</th>
          <th scope='col'>Floor Name</th>
        </tr>
      </MDBTableHead>
      <MDBTableBody>
        {houses.map((house, index) => (
          <tr key={house.id}>
            <th scope='row'>{index + 1}</th>
            <td>{house.name}</td>
            <td>{house.description}</td>
            <td>{house.status}</td>
            <td>{house.capacity}</td>
            <td>{house.floorName}</td>
          </tr>
        ))}
      </MDBTableBody>
    </MDBTable>
  );
};

export default HouseTable;