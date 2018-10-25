import { PaymentComponent } from './payment/payment.component';
import { ClientComponent } from './client/client.component';
import { AppComponent } from './app.component';
import { CarsComponent } from './cars/cars.component';
import { CarTypeComponent } from './car-type/car-type.component';
import { EmployeeComponent } from './employee/employee.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PickupComponent } from './pickup/pickup.component';
import { ReceiveComponent } from './receive/receive.component';


const routes: Routes = [
  {
    path: 'employees',
    component: EmployeeComponent
  },
  {
    path: 'carTypes',
    component: CarTypeComponent
  },
  {
    path: 'cars',
    component: CarsComponent
  },
  {
    path: 'clients',
    component: ClientComponent
  },
  {
    path: 'pickup',
    component: PickupComponent
  },
  {
    path: 'pay',
    component: PaymentComponent
  },
  {
    path: 're',
    component: ReceiveComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
