import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { SnotifyModule, SnotifyService, ToastDefaults } from 'ng-snotify';

import { AppComponent } from './app.component';
import { EmployeeComponent } from './employee/employee.component';
import { AppRoutingModule } from './app-routing.module';
import { CarTypeComponent } from './car-type/car-type.component';
import { CarsComponent } from './cars/cars.component';
import { ClientComponent } from './client/client.component';
import { PickupComponent } from './pickup/pickup.component';
import { PaymentComponent } from './payment/payment.component';
import { ReceiveComponent } from './receive/receive.component';

@NgModule({
  declarations: [
    AppComponent,
    EmployeeComponent,
    CarTypeComponent,
    CarsComponent,
    ClientComponent,
    PickupComponent,
    PaymentComponent,
    ReceiveComponent
  ],
  imports: [
    BrowserModule,
    HttpModule,
    FormsModule,
    AppRoutingModule,
    SnotifyModule
  ],
  providers: [
    {provide: 'SnotifyToastConfig', useValue: ToastDefaults}, SnotifyService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
