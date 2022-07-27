import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from './user.model';
import { Emitters } from '../../emitters/emitters';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  users: Observable<User[]> | any;

  message:string = '';

  user:any;
  role:any;

  admin:boolean = true;

  constructor(
    private httpclient:HttpClient
  ) { }

  ngOnInit(): void {

    this.user = sessionStorage.getItem('user');
    this.role = sessionStorage.getItem('role');

    this.message = 'Welcome '+sessionStorage.getItem('user')+' - Level of access: '+sessionStorage.getItem('role');


    if(this.role == "Administrator"){
      this.admin = false;
    }


    this.httpclient.get('/api/User/GetAll').subscribe((data:any) =>{
      this.users = data;
      console.log(data);

      Emitters.authEmitter.emit(true);
    }
    );



  }

}
