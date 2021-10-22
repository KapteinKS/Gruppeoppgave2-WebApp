import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { LoginComponent } from './login/login.component';
import { AdministrationComponent } from './administration/administration';
import { AppRoutingModule } from './app-routing.module';
import { Update } from './update/update';
import { Register } from './register/register';
import { Modal } from './administration/modal'

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    LoginComponent,
    AdministrationComponent,
    Update,
    Register,
    Modal,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
