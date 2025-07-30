import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';

//Models
import { Employee } from '../../../../shared/models/employee/employee.model';

//Constants
import { environment } from '../../../../../environments/environment';
import { API_ENDPOINTS } from '../../../../core/constants/api-endpoints';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  constructor(private http: HttpClient) {}

  getEmployees(): Observable<Employee[]> {
    return this.http.get<{ isSuccess: boolean; value: Employee[] }>(`${environment.apiUrl}${API_ENDPOINTS.GET_EMPLOYEES}`)
      .pipe(
        map(response => response.value)
      );
  }

}
