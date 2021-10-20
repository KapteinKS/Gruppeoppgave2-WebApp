import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';
<<<<<<< Updated upstream
import { AppComponent } from '../app.component';
=======
import { AdministrationComponent } from './administration.component';
import { Modal } from './modal';
>>>>>>> Stashed changes

@NgModule({
  declarations: [
    AdministrationComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AdministrationComponent]
})
export class AppModule {}
