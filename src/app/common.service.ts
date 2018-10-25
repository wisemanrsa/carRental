import { Client } from './models/client';
import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Car } from './models/car';
import { Rental } from './models/rental';

@Injectable({
  providedIn: 'root'
})
export class CommonService {

  constructor(private http: Http) { }

  getColors() {
    return this.http.get('/api/common/colors');
  }

  getAgencies() {
    return this.http.get('/api/common/agencies');
  }

  getCarTypes() {
    return this.http.get('/api/common/cartypes');
  }

  addCar(car: Car) {
    return this.http.post('/api/cars', car);
  }

  getCar(registrationNumber: string) {
    return this.http.get('/api/cars/' + registrationNumber);
  }

  updateCar(car: Car) {
    return this.http.put('/api/cars', car);
  }

  validateDate(dob: string) {
    return this.http.post('/api/validate', {date: dob});
  }

  addClient(client: Client) {
    return this.http.post('/api/client', client);
  }

  getCars() {
    return this.http.get('/api/cars');
  }

  rentAcar(rental: Rental) {
    return this.http.post('/api/rent', rental);
  }

  deleteClient(clientNumber: number) {
    return this.http.post('/api/client/delete/' + clientNumber, null);
  }

  pickup (obj: any) {
    return this.http.post('/api/pickup', obj);
  }

  processPayment(obj: any) {
    return this.http.post('/api/pay', obj);
  }

  findClient(str: number) {
    return this.http.get('/api/client/' + str);
  }

  receive(obj: any) {
    return this.http.post('/api/re', obj);
  }
}
