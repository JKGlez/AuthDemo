import { Component, OnInit } from '@angular/core';
import { Emitters } from '../emitters/emitters';

import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  authenticated:boolean = false;

  constructor(private router:Router) { }

  ngOnInit() {
    Emitters.authEmitter.subscribe(
      (auth:boolean) => {
        this.authenticated = auth;
      }
    )
  }

  logout() {
    console.log('logout');
    this.authenticated = false;
    sessionStorage.clear();
    this.router.navigate(['/login']);
    Emitters.authEmitter.emit(false);

  }

}
