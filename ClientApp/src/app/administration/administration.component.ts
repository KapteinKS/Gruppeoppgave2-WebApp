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
    
  }

  getAll() {
    this._http.get<departure[]>("api/Departure/")
      .subscribe(data => {
        this.departures = data;
      },
        error => alert(error),
        () => console.log("Get call finished")
      );
  };

  updateDeparture(dep: departure) {
    this._http.put("api/Departure/", dep)
      .subscribe(data => {
        this.getAll();
      },
        error => alert(error)
      );
  };
}
