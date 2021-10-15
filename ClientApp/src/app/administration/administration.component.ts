import { Component, OnInit } from '@angular/core';
import { departure } from './departure';
import { HttpClient } from '@angular/common/http'

@Component({
  selector: 'router-outlet',
  templateUrl: './administration.component.html'
})

//Code monkey see, code monkey do
export class AdministrationComponent {
  public departures: Array<departure>;

  constructor(private _http: HttpClient) {
    this._http.get<departure[]>("api/Departure/")
      .subscribe(data => {
        this.departures = data;
      },
        error => alert(error),
        () => console.log("Get call finished")
      );
  }
}
