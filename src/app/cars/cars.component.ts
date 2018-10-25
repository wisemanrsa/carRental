import { Component, OnInit } from '@angular/core';
import { CommonService } from '../common.service';
import { SnotifyService } from 'ng-snotify';
import { Car } from '../models/car';

@Component({
  selector: 'app-cars',
  templateUrl: './cars.component.html',
  styleUrls: ['./cars.component.css']
})
export class CarsComponent implements OnInit {
  isAdd = false;
  isFind = false;
  isUpdate = false;
  colors: any[];
  car: Car;
  agencies: any[];
  carTypes: any[];
  registrationNumber = '';
  serviceDate = '';

  constructor(private commonService: CommonService, private notify: SnotifyService) { }

  ngOnInit() {
    this.car = new Car();
    this.commonService.getColors().subscribe(colors =>
      this.colors = colors.json(),
      err => this.notify.error(err._body, 'Error', {timeout: 7000}));

    this.commonService.getAgencies().subscribe(agencies =>
      this.agencies = agencies.json(),
      err => this.notify.error(err._body, 'Error', {timeout: 7000}));

    this.commonService.getCarTypes().subscribe(cts =>
      this.carTypes = cts.json(),
      err => this.notify.error(err._body, 'Error', {timeout: 7000}));
  }

  setAdd() {
    this.isAdd = true;
    this.isFind = false;
    this.isUpdate = false;
  }

  setFind() {
    this.isAdd = false;
    this.isFind = true;
    this.isUpdate = false;
  }

  add() {
    if (!this.car.registrationNumber) {
      return this.notify.error('Please enter registration number', 'Error', {timeout: 7000});
    }
    if (!this.car.lastServiceDate) {
      return this.notify.error('Please select last service date', 'Error', {timeout: 7000});
    }
    if (this.car.colorCode === '') {
      return this.notify.error('Please select color', 'Error', {timeout: 7000});
    }
    if (this.car.rentalAgencyCode === '') {
      return this.notify.error('Please select rental agency', 'Error', {timeout: 7000});
    }
    if (this.car.carTypeCode === '') {
      return this.notify.error('Please select car type', 'Error', {timeout: 7000});
    }
    if (this.car.available === '') {
      return this.notify.error('Please specify if the car is available', 'Error', {timeout: 7000});
    }

    this.commonService.addCar(this.car).subscribe(c => {
      this.isAdd = false;
      this.isFind = false;
      this.isUpdate = false;
      this.car = new Car();
      this.notify.success('Car was added successfully', 'Success', {timeout: 7000});
    }, err => this.notify.error(err._body, 'Failed', {timeout: 7000}));
  }

  search() {
    if (this.registrationNumber === '') {
      return this.notify.error('Please enter the registration number', 'Error', {timeout: 7000});
    }
    this.car = new Car();
    this.commonService.getCar(this.registrationNumber).subscribe(c => {
      this.car = c.json();
      this.serviceDate = new Date(this.car.lastServiceDate).toDateString();
      this.isAdd = false;
      this.isFind = false;
      this.isUpdate =  true;
      this.notify.success('Car loaded successfully', 'Success', {timeout: 7000});
    }, err => this.notify.error(err._body, 'Failed', {timeout: 7000}));
  }

  update() {
    if (this.car.lastServiceDate === '') {
      return this.notify.error('Please select the last service date', {timeout: 7000});
    }
    this.commonService.updateCar(this.car).subscribe(c => {
      this.isAdd = false;
      this.isFind = true;
      this.isUpdate =  false;
      this.car = new Car();
      this.notify.success('Service date updated', 'success', {timeout: 7000});
    }, err => this.notify.error(err._body, 'Error', {timeout: 7000}));
  }
}
