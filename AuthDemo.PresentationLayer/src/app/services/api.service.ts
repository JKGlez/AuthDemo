import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseJWT } from '../views/login/response.interface';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }

  login(email: string, password: string) {
    return this.http.post<ResponseJWT>('/api/Account/Login',{email,password});
  }
}
