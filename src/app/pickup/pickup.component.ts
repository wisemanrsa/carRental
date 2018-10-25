import { Component, OnInit } from '@angular/core';
import { CommonService } from '../common.service';
import { SnotifyService } from 'ng-snotify';

@Component({
  selector: 'app-pickup',
  templateUrl: './pickup.component.html',
  styleUrls: ['./pickup.component.css']
})
export class PickupComponent implements OnInit {
  clientNumber: number;
  date = '';
  constructor(private commonService: CommonService, private notify: SnotifyService) { }

  ngOnInit() {
  }

  pickup() {
    if (!this.clientNumber) {
      return this.notify.error('Please enter client number', 'Error', {timeout: 7000});
    }
    if (!this.date || this.date === '') {
      return this.notify.error('Please enter pick up date', 'Error', {timeout: 7000});
    }
    this.commonService.pickup({clientNumber: this.clientNumber, date: this.date}).subscribe(res => {
      this.clientNumber = null;
      this.date = '';
      this.notify.success('Pickup successfully', 'Success', {timeout: 7000});
    }, err => this.notify.error(err._body, 'Error', {timeout: 7000}));
  }
}
