import { Client } from './../models/client';
import { CommonService } from './../common.service';
import { SnotifyService } from 'ng-snotify';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-receive',
  templateUrl: './receive.component.html',
  styleUrls: ['./receive.component.css']
})
export class ReceiveComponent implements OnInit {
  first = true;
  clientNumber: number;
  wait = false;
  date = '';
  reading: number;
  invoice: any;
  isFinal = false;
  constructor(private notify: SnotifyService, private commonService: CommonService) { }

  ngOnInit() {
  }

  process() {
    if (!this.clientNumber) {
      return this.notify.error('Please enter client number', 'error', {timeout: 7000});
    }
    this.wait = true;
    this.commonService.findClient(this.clientNumber).subscribe(res => {
      this.first = false;
      this.wait = false;
    });
  }

  process2() {
    if (!this.date) {
      return this.notify.error('Please capture the date', 'Error', {timeout: 7000});
    }
    if (!this.reading) {
      return this.notify.error('Please capture the readings', 'Error', {timeout: 7000});
    }

    this.wait = true;
    this.commonService.receive({date: this.date, clientNumber: this.clientNumber}).subscribe(s => {
       this.invoice = s.json();
       this.wait = false;
       this.isFinal = true;
    }, err => this.notify.error(err._body, 'Error', {timeout: 7000}));
  }

}
