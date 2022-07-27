import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  // formRegister: FormGroup = this.formBuilder

  formLogin = this.formBuilder.group({
    name:'',
    email:'',
    password:'',
    roledescription:''
  });

  constructor(private formBuilder:FormBuilder, private httpClient:HttpClient) { }

  ngOnInit() {
    this.formLogin = this.formBuilder.group({
      name:'',
      email:'',
      password:'',
      roledescription:''
    });
  }

  submit(){
    console.log(this.formLogin.getRawValue());
    this.httpClient.post('/api/Account/Register',this.formLogin.getRawValue())
    .subscribe(res => {
      console.log(res);
    });
  }

}
