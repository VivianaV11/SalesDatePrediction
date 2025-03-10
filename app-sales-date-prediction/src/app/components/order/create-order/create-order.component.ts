import { CommonModule } from '@angular/common';
import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatNativeDateModule, MatOptionModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatSelectModule } from '@angular/material/select';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { MatToolbarModule } from '@angular/material/toolbar';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { Employee, Product, Shipper } from '../../../models';
import { CustomService, EmployeeService, ProductService, ShipperService } from '../../../services';
import { CreateOrderRequestMapperService } from './services';

@Component({
  standalone: true,
  imports: [
    CommonModule,
    MatToolbarModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatInputModule,
    MatIconModule,
    FormsModule,
    MatButtonModule,
    MatDialogModule,
    MatProgressSpinnerModule,
    MatSelectModule,
    MatOptionModule,
    MatDatepickerModule, 
    MatNativeDateModule,
    ReactiveFormsModule
  ],
  selector: 'app-create-order',
  templateUrl: './templates/create-order.component.html',
  styleUrl: './styles/create-order.component.scss'
})
export class CreateOrderComponent implements OnInit {
  public name: string = '';
  public employees: Employee[] = [];
  public products: Product[] = [];
  public shippers: Shipper[] = [];
  public orderForm = new FormGroup({
    empId: new FormControl('', [Validators.required]),
    shipName: new FormControl('', [Validators.required]),
    shipperId: new FormControl('', [Validators.required]),
    shipAddress: new FormControl('', [Validators.required]),
    shipCity: new FormControl('', [Validators.required]),
    shipCountry: new FormControl('', [Validators.required]),
    orderDate: new FormControl(new Date()),
    requiredDate: new FormControl(new Date()),
    shippedDate: new FormControl(new Date()),
    freight: new FormControl(0, [Validators.required]),
    productId: new FormControl('', [Validators.required]),
    unitPrice: new FormControl(0, [Validators.required]),
    qty: new FormControl(0, [Validators.required]),
    discount: new FormControl(0, [Validators.required])
  });

  constructor(
    public dialogRef: MatDialogRef<CreateOrderComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private customService: CustomService,
    private employeeService: EmployeeService,
    private shipperService: ShipperService,
    private productService: ProductService,
    private mapperService: CreateOrderRequestMapperService
  ) { }

  ngOnInit(): void {
    if (this.data && this.data.customerName) {
      this.name = this.data.customerName;
    }
    this.employeeService.getEmployees().subscribe(
      (data: Employee[]) => {
        this.employees = data;
      }
    );
    this.shipperService.getShippers().subscribe(
      (data: Shipper[]) => {
        this.shippers = data;
      }
    );
    this.productService.getProducts().subscribe(
      (data: Product[]) => {
        this.products = data;
      }
    );
  }

  public closed(): void {
    this.dialogRef.close();
  }

  public onSubmit() {
    let newOrderModel = this.mapperService.map(this.orderForm.value);
    newOrderModel.custId= this.data.customerId;
    this.customService.createOrder(newOrderModel).subscribe(
      () => {
        this.dialogRef.close();
      }
    );
  }
}
