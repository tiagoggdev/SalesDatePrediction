import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';

//Models
import { Product } from '../../../../shared/models/product/product.model';

//Constants
import { environment } from '../../../../../environments/environment';
import { API_ENDPOINTS } from '../../../../core/constants/api-endpoints';


@Injectable({
  providedIn: 'root'
})
export class ProductService {
  constructor(private http: HttpClient) {}

  getProducts(): Observable<Product[]> {
    return this.http.get<{ isSuccess: boolean; value: Product[] }>(`${environment.apiUrl}${API_ENDPOINTS.GET_PRODUCTS}`)
      .pipe(
        map(response => response.value)
      );
  }
}
