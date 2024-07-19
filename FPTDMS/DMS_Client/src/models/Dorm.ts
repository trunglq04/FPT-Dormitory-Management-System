export interface Dorm {
  id: string;
  name: string;
  description: string;
  floors: Floor[];
}

export interface Floor {
  id: string;
  name: string;
  description: string;
  type: string;
  dormName: string;
  houses: House[];
}

export interface House {
  id: string;
  name: string;
  description: string;
  status: string;
  capacity: number;
  floorName: string;
  rooms: Room[];
}

export interface Room {
  id: string;
  name: string;
  status: string;
  Capacity: number;
  description: string;
  houseName: string;
  roomType: string;
  price: string;
  floorName: string;
  dormName: string;
}

export interface Type {
  id: number;
  type: string;
}
