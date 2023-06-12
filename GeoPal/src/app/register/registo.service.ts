import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RegistoService {
  private apiUrl = 'http://localhost/API_WebGeo//api/registar';

  constructor(private http: HttpClient) { }

  registrar(registo: any): Observable<any> {
    return this.http.post(this.apiUrl, registo);
  }
}
