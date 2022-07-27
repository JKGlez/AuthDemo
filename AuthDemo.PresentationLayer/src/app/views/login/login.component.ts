
import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ResponseJWT } from './response.interface';
import { Router } from '@angular/router';
import { AuthService } from '../../auth/auth.service'

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {


  formLogin = this.formBuilder.group({

    email:'',
    password:''
  });

  constructor(
    private formBuilder:FormBuilder,
    private authService:AuthService,
    private router:Router
    ) { }

  ngOnInit() {
    this.formLogin = this.formBuilder.group({
      email:'',
      password:''
    });
  }

  submit(){
    this.authService.login(this.formLogin.getRawValue().email,this.formLogin.getRawValue().password)
    .subscribe((res) => {
      // let JwkToken: ResponseJWT = res;
      // sessionStorage.setItem('User',JwkToken.UserToken);
      // sessionStorage.setItem('Role',JwkToken.UserRole);
      // sessionStorage.setItem('JWT',JwkToken.JwkToken);
      this.router.navigate(['/home']);
    });
  }

}
