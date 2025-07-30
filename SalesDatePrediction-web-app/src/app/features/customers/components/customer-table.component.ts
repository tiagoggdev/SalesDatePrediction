import { Component, EventEmitter, inject, Input, Output, SimpleChanges } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LiveAnnouncer } from '@angular/cdk/a11y';
import { ViewChild } from '@angular/core';

//Angular Material
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatButtonModule } from '@angular/material/button';
import { MatSort, MatSortModule, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';

//Model
import { Customer } from '../../../shared/models/customer/customer.model';

@Component({
  selector: 'app-customer-table',
  standalone: true,
   imports: [
    CommonModule,
    MatTableModule,
    MatPaginatorModule,
    MatButtonModule,
    MatSortModule
  ],
  templateUrl: './customer-table.component.html',
  styleUrls: ['./customer-table.component.css']
})
export class CustomerTableComponent {
  @Input() customers: Customer[] = [];
  @Input() totalRecords = 0;
  @Input() loading = false;
  @Input() rows = 10;
  @Input() page = 0;

  @Output() pageChange = new EventEmitter<number>();
  @Output() viewOrders = new EventEmitter<Customer>();
  @Output() newOrder = new EventEmitter<Customer>();

  displayedColumns: string[] = ['customerName', 'lastOrderDate', 'nextPredictedOrder', 'actions'];
  dataSource = new MatTableDataSource<Customer>();

  @ViewChild(MatSort) sort!: MatSort;
  private _liveAnnouncer = inject(LiveAnnouncer);

  ngAfterViewInit(): void {
    this.dataSource.sort = this.sort;
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['customers']) {
      this.dataSource.data = this.customers;
    }
  }

  announceSortChange(sortState: Sort): void {
    if (sortState.direction) {
      this._liveAnnouncer.announce(`Sorted ${sortState.direction}ending`);
    } else {
      this._liveAnnouncer.announce('Sorting cleared');
    }
  }

  onPage(event: any) {
    const nextPage = event.pageIndex + 1;
    this.pageChange.emit(nextPage);
  }
}
