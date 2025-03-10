import { LiveAnnouncer } from '@angular/cdk/a11y';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, Inject, inject, ViewChild } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSort, MatSortModule, Sort } from '@angular/material/sort';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatToolbarModule } from '@angular/material/toolbar';
import { GeneralConfig } from '../../../config/general.config';
import { BACKEND_URL } from '../../../injection-tokens';
import { Order } from '../../../models';
import { CreateOrderComponent } from '../create-order/create-order.component';
import { MatButtonModule } from '@angular/material/button';

@Component({
  standalone: true,
  imports: [
    CommonModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatInputModule,
    MatIconModule,
    FormsModule,
    MatToolbarModule,
    MatDialogModule,
    MatButtonModule
  ],
  providers: [],
  selector: 'app-view-order',
  templateUrl: './templates/view-order.component.html',
  styleUrl: './styles/view-order.component.scss',
})
export class ViewOrderComponent {

  public displayedColumns: string[] = [
    'orderId',
    'requiredDate',
    'shippedDate',
    'shipName',
    'shipAddress',
    'shipCity'
  ];
  public name: string = '';
  private orders: Order[] = [];
  public dataSource = new MatTableDataSource(this.orders);

  private _liveAnnouncer = inject(LiveAnnouncer);

  @ViewChild(MatPaginator) paginator?: MatPaginator;
  @ViewChild(MatSort) sort?: MatSort;

  constructor(
    public dialogRef: MatDialogRef<CreateOrderComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) { }

  ngOnInit(): void {
    if (this.data) {
      this.name = this.data.customerName;
      this.orders = this.data.data;
      this.reloadDataSource();
    }
  }

  ngAfterViewInit() {
    this.reloadDataSource();
  }

  public closed(): void {
    this.dialogRef.close();
  }

  public announceSortChange(sortState: Sort) {
    if (sortState.direction) {
      this._liveAnnouncer.announce(`Sorted ${sortState.direction}ending`);
    } else {
      this._liveAnnouncer.announce('Sorting cleared');
    }
  }

  protected reloadDataSource() {
    this.dataSource = new MatTableDataSource(this.orders);
    if (this.paginator)
      this.dataSource.paginator = this.paginator;
    if (this.sort)
      this.dataSource.sort = this.sort;
  }
}
