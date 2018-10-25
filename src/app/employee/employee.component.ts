import { Component, OnInit } from '@angular/core';
import { SnotifyService } from 'ng-snotify';
import { EmployeesService } from '../employees.service';
import { Employee } from '../models/employee';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {
  isSearching = false;
  employee: Employee;
  canSave = false;
  isAddEmployee = false;
  isFindEmployee = false;
  isUpdate = false;
  staffNumber: any;

  constructor(private notify: SnotifyService, private empService: EmployeesService) { }

  ngOnInit() {
    this.employee = new Employee();
    this.employee.jobCode = '';
  }

  save() {
    // this.validate();
    this.canSave = true;
    if (this.canSave) {
      this.empService.addEmployee(this.employee).subscribe(emp => {
        this.notify.success('Employee was created successfully', {timeout: 7000});
        this.employee = new Employee();
        this.canSave = false;
      },
      err => this.notify.error(err._body)
      );
    }
  }

  search() {
    if (this.staffNumber == null) {
      return this.notify.error('Enter staff number', {timeout: 7000});
    }
    this.isSearching = true;
    this.employee = new Employee();
    this.empService.searchEmployee(this.staffNumber).subscribe((emp) => {
      this.isSearching = false;
      this.employee = emp.json();
      this.isAddEmployee = false;
      this.isUpdate = true;
      this.notify.success('Employee loaded successfully', {timeout: 7000});
    }, err => {
      this.isSearching = false;
      this.setFindEmployee();
      this.notify.error(err._body);
    });
  }

  setAddEmploye() {
    this.employee = new Employee();
    this.isAddEmployee = true;
    this.isFindEmployee = false;
    this.isUpdate = false;
    this.isSearching = false;
  }

  update() {
    this.empService.update(this.employee).subscribe(emp => {
      this.employee = new Employee();
      this.notify.success('Employee updated', {timeout: 7000});
    }, err => this.notify.error('Failed to update employee', {timeout: 7000}));
  }

  setFindEmployee() {
    this.isAddEmployee = false;
    this.isFindEmployee = true;
    this.isUpdate = false;
    this.isSearching = false;
  }

  validate() {
    if (!this.employee.staffNumber) {
      return this.notify.error('Enter staff number', {timeout: 7000});
    }
    if (!this.employee.firstName) {
      return this.notify.error('Enter Name', {timeout: 7000});
    }
    if (!this.employee.surname) {
      return this.notify.error('Enter Surname', {timeout: 7000});
    }
    if (!this.employee.idNumber) {
      return this.notify.error('Enter ID number');
    } else if (this.employee.idNumber.toString().length !== 13) {
        return this.notify.error('Invalid ID number');
    }
    if (!this.employee.initials) {
      return this.notify.error('Enter Initials', {timeout: 7000});
    }
    if (!this.employee.number) {
      return this.notify.error('Enter cell number', {timeout: 7000});
    } else if (this.employee.number.toString().length !== 10) {
      return this.notify.error('Invalid cell phone number', {timeout: 7000});
    }
    if (!this.employee.email) {
      return this.notify.error('Enter email address', {timeout: 7000});
    } else {
      const filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
      if (!filter.test(this.employee.email)) {
        return this.notify.error('Invalid email format', {timeout: 7000});
      }
    }
    if (!this.employee.jobCode || this.employee.jobCode === '') {
      return this.notify.error('Select job', {timeout: 7000});
    }
    if (!this.employee.address) {
      return this.notify.error('Enter address', {timeout: 7000});
    }
    if (!this.employee.password) {
      return this.notify.error('Enter password', {timeout: 7000});
    }
    if (!this.employee.dateOfAppointment) {
      return this.notify.error('Select date of appointment', {timeout: 7000});
    }

    this.canSave = true;
  }
}
