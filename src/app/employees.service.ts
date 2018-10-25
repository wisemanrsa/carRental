import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Employee } from './models/employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeesService {

  constructor(private http: Http) { }

  addEmployee(emp: any) {
    return this.http.post('/api/employees', emp);
  }

  searchEmployee(staffNumber: string) {
    return this.http.get('/api/employees/' + staffNumber);
  }

  update(emp: Employee) {
    return this.http.put('/api/employee/update', emp);
  }
}
