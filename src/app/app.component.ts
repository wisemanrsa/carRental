import { SnotifyService } from 'ng-snotify';
import { Employee } from './models/employee';
import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  oldPassword: any;
  newPassword: any;
  loggedIn = false;
  title = 'Car Rental Franchise';
  password = '';
  username = '';
  user: Employee;
  isChange = false;
  newPassword2: any;

  constructor(private http: Http, private notify: SnotifyService) {}

  ngOnInit(): void {
    // this.user = new Employee();
  }

  login() {
    if (this.username === '') {
      return this.notify.error('Please Enter Username', 'Error', {timeout: 7000});
    }
    if (this.password === '') {
      return this.notify.error('Please Enter Password', 'Error', {timeout: 7000});
    }
    this.http.post('/api/login', {username: this.username, password: this.password})
      .subscribe(res => {
        this.user = res.json();
        this.loggedIn = true;
        this.notify.success('Logged In', 'Success', {timeout: 7000});
      }, err => {
        this.notify.error(err._body, 'Failed', {timeout: 7000});
      });
  }

  changePassword() {
    if (this.newPassword !== this.newPassword2) {
      return this.notify.error('New Passwords don\'t match', 'Error', {timeout: 7000});
    }
    this.http.post('/api/change', {staffNumber: this.user.staffNumber, oldPassword: this.oldPassword, newPassword: this.newPassword})
      .subscribe(res => {
        this.oldPassword = '';
        this.newPassword = '';
        this.newPassword2 = '';
        this.isChange = false;
        this.loggedIn = false;
        this.notify.success('Password was changed, re-login', 'success', {timeout: 7000});
      }, err => this.notify.error(err._body, 'Error', {timeout: 7000}));
  }

  change() {
    this.oldPassword = '';
    this.newPassword = '';
    this.newPassword2 = '';
    this.password = '';
    this.isChange = true;
    this.loggedIn = false;
  }

  cancel() {
    this.loggedIn = true;
    this.isChange = false;
    this.oldPassword = '';
    this.newPassword = '';
    this.newPassword2 = '';
    this.password = '';
  }

  logout() {
    this.isChange = false;
    this.loggedIn = false;
    this.password = '';
  }

}
