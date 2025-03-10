import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ViewSalesDatePredictionComponent } from './view-sales-date-prediction/view-sales-date-prediction.component';

export const SALE_DATE_PREDICTION_ROUTES: Routes = [
  {
    path: 'view',
    component: ViewSalesDatePredictionComponent
  },
  {
    path: '**',
    redirectTo: 'view'
  },
];
