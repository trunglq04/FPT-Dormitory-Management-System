export interface Profile {
    firstName:   string;
    lastName:    string;
    gender:      string;
    dateOfBirth: Date;
    address:     string;
    picture:     string;
    phoneNumber: string;
}

export interface Balance {
    id: string;
    amount: number;
  }
  
  export interface User {
    id: string;
    userName: string;
    email: string;
    firstName: string;
    lastName: string;
    gender: string;
    dateOfBirth: string;
    address: string;
    description: string;
    picture: string;
    phoneNumber: string;
    balance: Balance;
  }
  