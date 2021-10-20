import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { AdministrationComponent } from './administration.component';
import { Modal } from './modal';


@NgModule({
  declarations: [
    AdministrationComponent,
    Modal
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AdministrationComponent, Modal]
})
export class AppModule {}
