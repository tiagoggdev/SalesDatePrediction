import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';

//Models
import { Shipper } from '../../../../shared/models/shipper/shipper.model';

//Constants
import { environment } from '../../../../../environments/environment';
import { API_ENDPOINTS } from '../../../../core/constants/api-endpoints';

@Injectable({
  providedIn: 'root'
})
export class ShipperService {
  constructor(private http: HttpClient) {}

  getShippers(): Observable<Shipper[]> {
    return this.http.get<{ isSuccess: boolean; value: Shipper[] }>(`${environment.apiUrl}${API_ENDPOINTS.GET_SHIPPERS}`)
      .pipe(
        map(response => response.value)
      );
  }
}
