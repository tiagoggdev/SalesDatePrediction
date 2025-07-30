import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

//Angular Material
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBarModule, MatSnackBar } from '@angular/material/snack-bar';

//Services
import { OrderService } from '../../orders/services/order/order.service';
import { CustomerService } from '../services/customer.service';

//Models
import { CreateOrderRequest } from '../../../shared/models/order/createOrderRequest.model';
import { NewOrderModalComponent } from '../../orders/components/new-order-modal/new-order-modal.component';
import { Customer } from '../../../shared/models/customer/customer.model';

//Components
import { OrdersModalComponent } from '../../orders/components/get-orders-by-customer-modal/orders-modal.component';
import { CustomerTableComponent } from '../components/customer-table.component';

@Component({
  selector: 'app-customer-list-page',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    CustomerTableComponent,
    OrdersModalComponent,
    NewOrderModalComponent,
    MatIconModule,
    MatFormFieldModule,
    MatInputModule,
    MatSnackBarModule
  ],
  templateUrl: './customer-list.page.html',
  styleUrls: ['./customer-list.page.css']
})
export class CustomerListPage implements OnInit {
  customers: Customer[] = [];
  totalRecords = 0;
  loading = false;
  page = 1;
  rows = 10;
  search = '';

  constructor(
    private customerService: CustomerService,
    private orderService: OrderService,
    private dialog: MatDialog,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.loadCustomers();
  }

  loadCustomers(): void {
    this.loading = true;
    this.customerService.getCustomers(this.page, this.rows, this.search).subscribe({
      next: (res) => {
        this.customers = res.customers;
        this.totalRecords = res.total;
        this.loading = false;
      },
      error: () => {
        this.loading = false;
      }
    });
  }

  onSearchEnter() {
    this.page = 1;
    this.loadCustomers();
  }

  onPageChange(newPage: number): void {
    if (!isNaN(newPage) && newPage > 0) {
      this.page = newPage;
      this.loadCustomers();
    }
  }

  onViewOrders(customer: Customer): void {
    const dialogRef = this.dialog.open(OrdersModalComponent, {
      width: '900px',
      data: {
        customerId: customer.customerId,
        customerName: customer.customerName
      }
    });

    dialogRef.afterClosed().subscribe(result => {
    });
  }

  onNewOrder(customer: Customer): void {
    const dialogRef = this.dialog.open(NewOrderModalComponent, {
      width: '30vw',
      data: {
        customerId: customer.customerId,
        customerName: customer.customerName
      }
    });

    dialogRef.afterClosed().subscribe((result: CreateOrderRequest | undefined) => {
      if (result) {
        this.onOrderCreated(result);
      }
    });
  }

  onOrderCreated(order: CreateOrderRequest) {
    this.orderService.createOrder(order).subscribe({
      next: (res) => {
        if (res.isSuccess) {
          this.snackBar.open('Orden creada con éxito', 'Cerrar', {
            duration: 4000,
            panelClass: ['snack-success'], 
          });

        } else {
          this.snackBar.open('Orden creada con éxito', 'Cerrar', {
            duration: 4000,
            panelClass: ['snack-error'], 
          });
        }
      },
      error: () => {
        this.snackBar.open('Orden creada con éxito', 'Cerrar', {
          duration: 4000,
          panelClass: ['snack-error'], 
        });
      }
    });
}

}

