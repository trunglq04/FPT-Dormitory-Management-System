import axios, { AxiosResponse } from "axios";
import { User } from "../models/user";

// Define fake delay function
const sleep = (delay: number) => {
    return new Promise( (resolve) => {
        setTimeout(resolve, delay);
    });
} 

axios.defaults.baseURL = "http://localhost:7777/api";

axios.interceptors.response.use( async response => {
    try {
        await sleep(500);
        return response;
    } catch (error) {
        console.log(error);
        return await Promise.reject(error);
    }
});

const responseBody = <T> (response: AxiosResponse<T>) => response.data;

const requests = {
    get: <T> (url: string) => axios.get<T>(url).then(responseBody), 
    post: <T> (url: string, body: object) => axios.post<T>(url, body).then(responseBody), 
    put: <T> (url: string, body: object) => axios.put<T>(url, body).then(responseBody), 
    del: <T> (url: string) => axios.delete<T>(url).then(responseBody), 
}

// const Activities = {
//     list: () => requests.get<Activity[]>("/activities"),
//     details: (id: string) => requests.get<Activity>(`/activities/${id}`),
//     create: (activity: Activity) => requests.post<void>("/activities", activity),
//     update: (activity: Activity) => requests.put<void>(`/activities/${activity.id}`, activity),
//     delete: (id: string) => requests.del<void>(`/activities/${id}`),
// }



const Users = {
    list: () => requests.get<User[]>("/users"),
    details: (id: string) => requests.get<User>(`/users/${id}`),
}

const agent =  {
    Users,

}

export default agent;