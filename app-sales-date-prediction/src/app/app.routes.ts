import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: 'home',
    loadChildren: () =>
      import('./components/sales-date-prediction/sales-date-prediction.routes').then((x) => x.SALE_DATE_PREDICTION_ROUTES),
  },
  {
    path: 'orders',
    loadChildren: () =>
      import('./components/order/order.routes').then((x) => x.ORDER_ROUTES),
  },
  {
    path: '**',
    redirectTo: 'home'
  },
];
