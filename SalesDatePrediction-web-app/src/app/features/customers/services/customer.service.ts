import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';

//Model
import { Customer } from '../../../shared/models/customer/customer.model';
import { ApiResponse } from '../../../shared/models/response/apiResponse.model';
import { PaginatedResponse } from '../../../shared/models/response/paginatedResponse.model';

//Constants
import { API_ENDPOINTS } from '../../../core/constants/api-endpoints';
import { environment } from '../../../../environments/environment';


@Injectable({ providedIn: 'root' })
export class CustomerService {
  private baseUrl = `${environment.apiUrl}${API_ENDPOINTS.GET_CUSTOMERS}`;

  constructor(private http: HttpClient) {}

  getCustomers(page: number, size: number, search?: string): Observable<{ customers: Customer[], total: number }> {
    let params = new HttpParams()
      .set('pageNumber', page)
      .set('pageSize', size);

    if (search && search.trim().length > 0) {
      params = params.set('CustomerName', search.trim());
    }

    return this.http
      .get<ApiResponse<PaginatedResponse<Customer>>>(this.baseUrl, { params })
      .pipe(
        map((response) => {
          const items = response.value.items.map((cust: Customer): Customer => ({
            customerId: cust.customerId,
            customerName: cust.customerName,
            lastOrderDate: cust.lastOrderDate,
            nextPredictedOrder: cust.nextPredictedOrder
          }));

          return {
            customers: items,
            total: response.value.totalItems
          };
        })
      );

  }
}