import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { AdministrationComponent } from './administration/administration.component';

const appRoots: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'administration', component: AdministrationComponent },
  { path: '', redirectTo: 'login', pathMatch:'full' }
]


@NgModule({
  imports: [
    RouterModule.forRoot(appRoots)
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
