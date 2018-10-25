import { CarTypeService } from './../car-type.service';
import { CarType } from './../models/carType';
import { Component, OnInit } from '@angular/core';
import { SnotifyService, SnotifyToastConfig } from 'ng-snotify';
import { SnotifyDefaults } from 'ng-snotify/snotify/interfaces/SnotifyDefaults.interface';

@Component({
  selector: 'app-car-type',
  templateUrl: './car-type.component.html',
  styleUrls: ['./car-type.component.css']
})
export class CarTypeComponent implements OnInit {
  carType: CarType;
  isFind = false;
  isAdd = false;
  isUpdate = false;
  code = '';

  constructor(private carTypeService: CarTypeService, private notify: SnotifyService) {
  }

  ngOnInit() {
    this.carType = new CarType();
  }

  generateCode() {
    const make = this.carType.make;
    const model = this.carType.model;
    const engine = this.carType.engineSize;

    if (make && model && engine) {
      this.carType.code = `${make[0]}${make[1]}${make[2]}-${model[0]}${model[1]}${model[2]}-${engine}`;
    }
  }

  add() {
    if (!this.carType.engineSize) {
      return this.notify.error('Please capture engine size correctly', 'Error', {timeout: 7000});
    }
    if (!this.carType.tarrif) {
      return this.notify.error('Please capture tarrif correctly', 'Error', {timeout: 7000});
    }
    if (!this.carType.make) {
      return this.notify.error('Please capture make', 'Error', {timeout: 7000});
    }
    if (!this.carType.model) {
      return this.notify.error('Please capture model', 'Error', {timeout: 7000});
    }
    if (this.carType.automatic === '') {
      return this.notify.error('Please specify if manual/auto', 'Error', {timeout: 7000});
    }
    if (this.carType.fuelType === '') {
      return this.notify.error('Please specify fuel type', 'Error', {timeout: 7000});
    }
    if (this.carType.conditioner === '') {
      return this.notify.error('Please specify air conditioning', 'Error', {timeout: 7000});
    }

    this.generateCode();

    if (!this.carType.code) {
      return this.notify.error('Car type code not generated', 'Error', {timeout: 7000});
    }
    alert('Car type code is auto generated based on Make, Model & Engine');
    this.carTypeService.add(this.carType).subscribe(ct => {
      this.carType = new CarType();
      this.notify.success('Car type added successfully', 'Success', {timeout: 7000});
    },
      err => {
        this.notify.error(err._body, 'Failed', {timeout: 7000});
      }
    );
  }

  setAdd() {
    this.isFind = false;
    this.isAdd = true;
    this.isUpdate = false;
  }

  setFind() {
    this.carType = new CarType();
    this.isFind = true;
    this.isAdd = false;
    this.isUpdate = false;
  }

  search() {
    if (this.code === '') {
      return this.notify.error('Enter car type code', 'Error', {timeout: 7000});
    }
    this.isUpdate = false;
    this.carTypeService.search(this.code).subscribe(results => {
      this.carType = results.json();
      // this.mapCarType();
      this.isUpdate = true;
      this.isAdd = false;
      this.notify.success('Car Type successfully loaded', {timeout: 7000});
    }, err => this.notify.error(err._body, '404', {timeout: 7000}));
  }

  update() {
    this.carTypeService.update(this.carType).subscribe(res => {
      this.carType = new CarType();
      this.isAdd = false;
      this.isFind = false;
      this.isUpdate = false;
      this.notify.success('Car type was updated', 'Updated', {timeout: 7000});
    }, err => this.notify.error(err._body, 'Error', {timeout: 7000}));
  }

  // mapCarType() {
  //   this.carType.automatic = this.carType.automatic.toLowerCase();
  //   this.carType.conditioner = this.carType.conditioner.toLowerCase();
  //   this.carType.fuelType = this.carType.fuelType.toLowerCase();
  // }

}
