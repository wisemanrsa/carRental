import { CarType } from './models/carType';
import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

@Injectable({
  providedIn: 'root'
})
export class CarTypeService {

  constructor(private http: Http) { }

  add(carType: CarType) {
    return this.http.post('/api/cartype', carType);
  }

  search(code: string) {
    return this.http.get('/api/cartype/' + code);
  }

  update(ct: CarType) {
    return this.http.put('/api/cartype', ct);
  }
}
