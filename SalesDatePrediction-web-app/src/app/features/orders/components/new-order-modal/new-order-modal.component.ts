import { Component, Inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, Validators } from '@angular/forms';

//Angular Material
import { MatDialogRef, MAT_DIALOG_DATA, MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatButtonModule } from '@angular/material/button';
import { MatNativeDateModule } from '@angular/material/core';

//Models
import { CreateOrderRequest } from '../../../../shared/models/order/createOrderRequest.model';
import { Employee } from '../../../../shared/models/employee/employee.model';
import { Product } from '../../../../shared/models/product/product.model';
import { Shipper } from '../../../../shared/models/shipper/shipper.model';

//Services
import { EmployeeService } from '../../services/employee/employee.service';
import { ShipperService } from '../../services/shipper/shipper.service';
import { ProductService } from '../../services/product/product.service';

@Component({
  selector: 'app-new-order-modal',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatButtonModule,
  ],
  templateUrl: './new-order-modal.component.html',
  styleUrl: './new-order-modal.component.css'
})
export class NewOrderModalComponent {
  orderForm = this.fb.group({
    employeeId: [null, Validators.required],
    shipperId: [null, Validators.required],
    shipName: ['', Validators.required],
    shipAddress: ['', Validators.required],
    shipCity: ['', Validators.required],
    shipCountry: ['', Validators.required],
    orderDate: [null, Validators.required],
    requiredDate: [null, Validators.required],
    shippedDate: [null, Validators.required],
    freight: [null, Validators.required],
    productId: [null, Validators.required],
    unitPrice: [null, Validators.required],
    quantity: [null, Validators.required],
    discount: [0, Validators.required]
  });

  employees: Employee[] = [];
  shippers: Shipper[] = [];
  products: Product[] = [];

  constructor(
    private fb: FormBuilder,
    public dialogRef: MatDialogRef<NewOrderModalComponent>,
    private employeeService: EmployeeService,
    private shipperService: ShipperService,
    private productService: ProductService,
    @Inject(MAT_DIALOG_DATA) public data: { customerId: number; customerName: string }
  ) {}

  ngOnInit() {
    this.employeeService.getEmployees().subscribe({
      next: (data) => {
        this.employees = data;
      },
      error: (err) => {
        console.error('Error al obtener empleados', err);
      }
    });

    this.shipperService.getShippers().subscribe({
      next: (data) => {
        this.shippers = data;
      },
      error: (err) => {
        console.error('Error al obtener transportistas', err);
      }
    });

    this.productService.getProducts().subscribe({
      next: (data) => {
        this.products = data;
      },
      error: (err) => {
        console.error('Error al obtener productos', err);
      }
    });
  }


  submit(): void {
    if (this.orderForm.invalid) {
      this.orderForm.markAllAsTouched();
      return;
    }

    const formValue = this.orderForm.value;

    const payload: CreateOrderRequest = {
      custid: this.data.customerId,
      empid: formValue.employeeId!,
      shipperid: formValue.shipperId!,
      shipname: formValue.shipName!,
      shipaddress: formValue.shipAddress!,
      shipcity: formValue.shipCity!,
      orderdate: formValue.orderDate!,
      requireddate: formValue.requiredDate!,
      shippeddate: formValue.shippedDate!,
      freight: formValue.freight!,
      shipcountry: formValue.shipCountry!,
      productid: formValue.productId!,
      unitprice: formValue.unitPrice!,
      qty: formValue.quantity!,
      discount: formValue.discount!
    };

    this.dialogRef.close(payload);
  }

  onClose(): void {
    this.dialogRef.close();
  }

}
