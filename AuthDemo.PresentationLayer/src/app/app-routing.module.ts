import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LoginComponent } from '../app/views/login/login.component';
import { RegisterComponent } from '../app/views/register/register.component';
import { HomeComponent } from '../app/views/home/home.component';
import { IsAuthenticatedGuard } from './auth/isAuthenticated.guard';
import { HasRoleGuard } from './auth/has-role.guard';

const routes: Routes = [
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'register',
    component: RegisterComponent,
  },
  {
    path: 'home',
    component: HomeComponent,
    // canActivate: [IsAuthenticatedGuard, HasRoleGuard],
    canActivate: [IsAuthenticatedGuard],
    data:{
      role: 'Administrator',
    }
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
