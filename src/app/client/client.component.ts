import { CommonService } from './../common.service';
import { Component, OnInit } from '@angular/core';
import { Client } from '../models/client';
import { SnotifyService } from 'ng-snotify';
import * as _ from 'lodash';
import { Rental } from '../models/rental';

@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.css']
})
export class ClientComponent implements OnInit {
  first = true;
  second = false;
  third = false;
  client: Client;
  agencies: any[];
  allAgencies = [];
  pickups = [];
  rentalAgencyCode = '';
  rentalAgencyName = '';
  returnLoc = '';
  pickUpLoc = '';
  carSizeCode = '';
  carTypes: any;
  AllCarTypes: any[];
  allCars: any;
  carTypeCode: any;
  cars: any[];
  registrationNumber: string;
  tarrif: number;
  firstDeposit: number;
  rental: Rental;
  fromDate = '';
  toDate = '';
  constructor(private notify: SnotifyService, private commonService: CommonService) { }

  ngOnInit() {
    this.reset();
    this.client = new Client();
    this.rental = new Rental();
    this.pickups = [];
    this.commonService.getAgencies().subscribe(res => {
      const agencies = res.json();
      this.allAgencies = agencies;
      this.carSizeCode = '';
      const names = _.map(agencies, 'name');
      this.agencies = _.uniq(names);
    });

    this.commonService.getCarTypes().subscribe(res => {
      this.AllCarTypes = res.json();
    });

    this.commonService.getCars().subscribe(res => {
      this.allCars = res.json();
    });
  }

  reset() {
    this.first = true;
    this.client = new Client();
    this.rental = new Rental();
    this.second = false;
    this.third = false;
    this.pickups = [];
    this.pickUpLoc = '';
    this.returnLoc = '';
    this.carSizeCode = '';
    this.rentalAgencyName = '';
    this.carTypeCode = '';
    this.registrationNumber = '';
    this.tarrif = 0;
    this.firstDeposit = 0;
    this.fromDate = '';
    this.toDate = '';
  }

  onAgencyChange() {
    this.pickups = [];
    this.pickUpLoc = '';
    this.returnLoc = '';
    this.carSizeCode = '';
    this.pickups = _.filter(this.allAgencies, (a) => a.name === this.rentalAgencyName);
  }

  onCarSizeChange() {
    this.carTypes = _.filter(this.AllCarTypes, (c) => c.carSizeCode.toLowerCase() === this.carSizeCode.toLowerCase());
  }

  onCarTypeChange() {
    this.cars = _.filter(this.allCars, (c) => c.carTypeCode === this.carTypeCode);
    this.tarrif = _.filter(this.AllCarTypes, (a) => a.code === this.carTypeCode)[0].tarrif || 0;
    this.firstDeposit = this.tarrif * 0.25;
  }

  goBack() {
    this.second = false;
    this.first = true;
    this.client = new Client();
  }

  quote() {
    if (this.rentalAgencyName === '') {
      return this.notify.error('Please Select Agency', 'Error', {timeout: 7000});
    }
    if (this.pickUpLoc === '') {
      return this.notify.error('Please Select Pickup Location', 'Error', {timeout: 7000});
    }
    if (this.returnLoc === '') {
      return this.notify.error('Please Select Return Location', 'Error', {timeout: 7000});
    }
    if (this.fromDate === '' ) {
      return this.notify.error('Please Select Pickup Date', 'Error', {timeout: 7000});
    }
    if (this.toDate === '') {
      return this.notify.error('Please Select Return Date', 'Error', {timeout: 7000});
    }
    if (this.carSizeCode === '') {
      return this.notify.error('Please Select Car Size', 'Error', {timeout: 7000});
    }
    if (this.carTypeCode === '') {
      return this.notify.error('Please Select Car Type', 'Error', {timeout: 7000});
    }
    if (this.registrationNumber === '') {
      return this.notify.error('Please Select Car', 'Error', {timeout: 7000});
    }
    const rental = new Rental();
    rental.carRegistrationCode = this.registrationNumber;
    rental.clientNumber = this.client.clientNumber;
    rental.pickUpLoc = this.pickUpLoc;
    rental.returnLoc = this.returnLoc;
    rental.fromDate = this.fromDate;
    rental.toDate = this.toDate;

    this.commonService.rentAcar(rental).subscribe(res => {
      this.notify.success('Rental generated successfully', {timeout: 7000});
      this.reset();
    }, err => this.notify.error(err._body));
  }

  proceed() {
    if (!this.client.clientNumber) {
      return this.notify.error('Please Enter Client Number', 'Error', {timeout: 7000});
    }
    if (!this.client.idNumber || this.client.idNumber.toString().length !== 13) {
      return this.notify.error('Please enter 13 digit SA ID number', 'Error', {timeout: 7000});
    }
    const ex = /^(((\d{2}((0[13578]|1[02])(0[1-9]|[12]\d|3[01])|(0[13456789]|1[012])(0[1-9]|[12]\d|30)|02(0[1-9]|1\d|2[0-8])))|([02468][048]|[13579][26])0229))(( |-)(\d{4})( |-)(\d{3})|(\d{7}))/;

    if (ex.test(this.client.idNumber.toString()) === false) {
      return this.notify.error('Invalid South African ID number', 'Error', {timeout: 7000});
    }
    const id = this.client.idNumber;
    const str = id.toString().substr(0, 6);
    const str2 = `${str[0]}${str[1]}/${str[2]}${str[3]}/${str[4]}${str[5]}`;
    if (new Date().getFullYear() - new Date(str2).getFullYear() < 21) {
      return this.notify.error('Client must be 21 years old or more', 'Error', {timeout: 7000});
    }
    this.first = false;
    this.second = true;
    // }, err => {
    //   this.notify.error(err._body, 'Error');
    // });
  }

  submit() {
    if (!this.client.surname) {
      return this.notify.error('Please Enter Surname', 'Error', {timeout: 7000});
    }
    if (!this.client.initials) {
      return this.notify.error('Please Enter Initials', 'Error', {timeout: 7000});
    }
    if (this.client.sex === '') {
      return this.notify.error('Please Select Gender', 'Error', {timeout: 7000});
    }
    if (!this.client.street) {
      return this.notify.error('Please Enter Street Address', 'Error', {timeout: 7000});
    }
    if (!this.client.suburb) {
      return this.notify.error('Please Enter Suburb', 'Error', {timeout: 7000});
    }
    if (this.client.city === '') {
      return this.notify.error('Please Enter City', 'Error', {timeout: 7000});
    }
    if (!this.client.phone) {
      return this.notify.error('Please Enter Phone number', 'Error', {timeout: 7000});
    }
    this.addClient();
  }

  delete() {
    this.commonService.deleteClient(this.client.clientNumber).subscribe(res => {
      this.notify.success('Client Deleted', 'Success', {timeout: 7000});
      this.reset();
    }, err => this.notify.error(err._body, 'Error', {timeout: 7000}));
  }

  addClient() {
    this.commonService.addClient(this.client).subscribe(res => {
      this.first = false;
      this.second = false;
      this.third = true;
      this.notify.success('Client captured successfully', 'Success', {timeout: 7000});
      this.third = true;
    }, err =>  this.notify.error(err._body, 'Error', {timeout: 7000}));
  }

}
