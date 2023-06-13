import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProfileServiceService {
  private apiUrl = 'http://localhost/API_WebGeo/api/utilizador';

  constructor(private http: HttpClient) { }

  getUserProfile(): Promise<any> {
    const email = localStorage.getItem('email');
    const password = localStorage.getItem('password');

    const url = `${this.apiUrl}?email=${email}&password=${password}`;
    console.log('URL:', url);

    return this.http.get(url).toPromise();
  }
}
