import { Component, OnInit } from '@angular/core';
import { departure } from './departure';
import { HttpClient } from '@angular/common/http'
import { register } from 'ts-node';


@Component({
  //selector: 'router-outlet',
  templateUrl: './administration.component.html'
})

//Code monkey see, code monkey do
export class AdministrationComponent {
  public departures: Array<departure>;
    depToDelete: string;

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

  updateDeparture(id: number) {
    this._http.put("api/Departure/", id)
      .subscribe(data => {
        this.getAll();
      },
        error => alert(error)
      );
  };

  deleteDeparture(id: number) {
    this._http.get<departure>("api/Departure/" + id)
      .subscribe(dep => {
        this.depToDelete = dep.dep_location + "-" + dep.arr_location;

        this.showModalDelete(id);
      },
        error => console.log(error)
      );
  };

  showModalDelete(id: number) {
    const modalRef = this.modalService.open(Modal);

    modalRef.componentInstance.name = this.depToDelete;

    modalRef.result.then(retur => {
      console.log("Modal closed with " + retur);
      if (retur == "delete") {
        this._http.delete("api/departure/" + id)
          .subscribe(retur => {
            this.getAll();
          },
            error => console.log(error)
          );
      }
      //TODO navigate to home
    });
  }

  registerDeoarture
}

