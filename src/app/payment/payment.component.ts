import { CommonService } from './../common.service';
import { Component, OnInit } from '@angular/core';
import { SnotifyService } from 'ng-snotify';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent implements OnInit {
  clientNumber: string;
  amount: number;

  constructor(private notify: SnotifyService, private commonService: CommonService) { }

  ngOnInit() {
  }

  process() {
    if (!this.clientNumber) {
      return this.notify.error('Please enter client number', 'Error', {timeout: 7000});
    }
    if (!this.amount || this.amount < 0) {
      return this.notify.error('Please capture the payable amount', 'Error', {timeout: 7000});
    }
    this.commonService.processPayment({clientNumber: this.clientNumber, amount: this.amount}).subscribe(res => {
      this.amount = null;
      this.clientNumber = null;
      this.notify.success('Payment captured successfully', 'Success', {timeout: 7000});
    }, err => this.notify.error(err._body, 'Error', {timeout: 7000}));
  }

}
