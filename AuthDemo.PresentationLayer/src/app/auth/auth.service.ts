import { Injectable } from '@angular/core';
import { ApiService } from '../services/api.service';
import { ResponseJWT } from '../views/login/response.interface';
import { tap } from 'rxjs/operators';
import { BehaviorSubject } from 'rxjs';
import { UserModel } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private _isLoggedIn$ = new BehaviorSubject<boolean>(false);
  private readonly TOKEN_NAME = 'auth_token';
  isLoggedIn$ = this._isLoggedIn$.asObservable();
  user!: UserModel;

  get token():string{
    return sessionStorage.getItem(this.TOKEN_NAME)!;
  }

  constructor(
    private apiServices:ApiService,
  ) {
    this._isLoggedIn$.next(!!this.token);

    if(this.token!=null)
      this.user = this.getUser(this.token);
  }

  login(email:string,password:string){
    return this.apiServices.login(email,password).pipe(
      tap((response:ResponseJWT) =>{

        this._isLoggedIn$.next(true);

        sessionStorage.setItem('user',response.UserToken);
        sessionStorage.setItem('role',response.UserRole);
        sessionStorage.setItem(this.TOKEN_NAME,response.JwkToken);

        this.user = this.getUser(response.JwkToken);
      })
    );
  }

  private getUser(token:string):UserModel{
    return JSON.parse(atob(token.split('.')[1])) as UserModel;
  }

}
