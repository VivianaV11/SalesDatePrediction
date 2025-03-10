import { Routes } from '@angular/router';
import { CreateOrderComponent } from './create-order/create-order.component';
import { ViewOrderComponent } from './view-order/view-order.component';

export const ORDER_ROUTES: Routes = [
  {
    path: 'view',
    component: ViewOrderComponent
  },
  {
    path: 'create',
    component: CreateOrderComponent
  },
  {
    path: '**',
    redirectTo: 'view'
  },
];
