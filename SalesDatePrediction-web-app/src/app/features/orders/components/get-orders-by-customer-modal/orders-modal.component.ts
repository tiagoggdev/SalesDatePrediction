import { Component, Inject, ViewChild, inject } from '@angular/core';
import { CommonModule } from '@angular/common';

//Angular Material
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginatorModule, PageEvent } from '@angular/material/paginator';
import { MatSort, MatSortModule, Sort } from '@angular/material/sort';
import { MatButtonModule } from '@angular/material/button';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { LiveAnnouncer } from '@angular/cdk/a11y';

//Services
import { OrderService } from '../../services/order/order.service';

//Models
import { Order } from '../../../../shared/models/order/order.model';

@Component({
  selector: 'app-orders-modal',
  standalone: true,
  imports: [CommonModule,
    MatDialogModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatButtonModule,
    MatProgressSpinnerModule
  ],
  templateUrl: './orders-modal.component.html',
  styleUrls: ['./orders-modal.component.css']
})
export class OrdersModalComponent {
  orders: Order[] = [];
  loading = false;
  page = 1;
  rows = 10;
  totalRecords = 0;

  displayedColumns: string[] = ['orderId', 'requiredDate', 'shippedDate', 'shipName', 'shipaddress', 'shipcity'];
  dataSource = new MatTableDataSource<Order>();

  constructor(
    public dialogRef: MatDialogRef<OrdersModalComponent>,
    private orderService: OrderService,
    @Inject(MAT_DIALOG_DATA) public data: { customerId: number; customerName: string }
  ) {}

  @ViewChild(MatSort) sort!: MatSort;
  private _liveAnnouncer = inject(LiveAnnouncer);


  ngOnInit(): void {
    if (this.data?.customerId) {
      this.loadOrders();
    }
  }

  ngAfterViewInit(): void {
    setTimeout(() => {
      this.dataSource.sort = this.sort;
    });
  }

  announceSortChange(sortState: Sort): void {
      if (sortState.direction) {
        this._liveAnnouncer.announce(`Sorted ${sortState.direction}ending`);
      } else {
        this._liveAnnouncer.announce('Sorting cleared');
      }
  }

  loadOrders(): void {
    this.loading = true;
    this.orderService.getByCustomerId(this.data.customerId, this.page, this.rows).subscribe({
      next: res => {
        this.orders = res.orders;
        this.dataSource.data = this.orders;
        this.totalRecords = res.total;
        this.loading = false;
      },
      error: () => this.loading = false
    });
  }

  onPage(event: PageEvent): void {
    this.rows = event.pageSize;
    this.page = event.pageIndex + 1;
    this.loadOrders();
  }

  closeModal(): void {
    this.dialogRef.close();
  }
}
