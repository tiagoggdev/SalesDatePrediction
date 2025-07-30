import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { map, Observable } from 'rxjs';

//Models
import { Order } from '../../../../shared/models/order/order.model';
import { PaginatedResponse } from '../../../../shared/models/response/paginatedResponse.model';
import { ApiResponse } from '../../../../shared/models/response/apiResponse.model';
import { CreateOrderRequest } from '../../../../shared/models/order/createOrderRequest.model';

//Constants
import { environment } from '../../../../../environments/environment';
import { API_ENDPOINTS } from '../../../../core/constants/api-endpoints';

@Injectable({ providedIn: 'root' })
export class OrderService {
  constructor(private http: HttpClient) {}

  getByCustomerId(customerId: number, page: number, size: number): Observable<{ orders: Order[], total: number }> {
    const params = new HttpParams()
      .set('CustomerId', customerId)
      .set('PageNumber', page)
      .set('PageSize', size);

    return this.http
      .get<ApiResponse<PaginatedResponse<Order>>>(`${environment.apiUrl}${API_ENDPOINTS.GET_ORDERS_BY_CUSTOMER}`, { params })
      .pipe(
        map(response => {
          const items = response.value.items.map((order: Order): Order => ({
            orderId: order.orderId,
            requiredDate: order.requiredDate,
            shipaddress: order.shipaddress,
            shipcity: order.shipcity,
            shipName: order.shipName,
            shippedDate: order.shippedDate
          }));

          return {
            orders: items,
            total: response.value.totalItems
          }
        })
      )
  }

  createOrder(request: CreateOrderRequest): Observable<ApiResponse<string>> {
    return this.http.post<ApiResponse<string>>(`${environment.apiUrl}${API_ENDPOINTS.ADD_ORDER}`, request);
  }
}
