import { Component, OnInit } from '@angular/core';
import { departure } from './departure';
import { HttpClient } from '@angular/common/http'
import { register } from 'ts-node';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Modal } from './modal';


@Component({
  selector: 'router-outlet',
  templateUrl: './administration.component.html'
})

//Code monkey see, code monkey do
export class AdministrationComponent {
  public departures: Array<departure>;
    depToDelete: string;

  constructor(private _http: HttpClient, private modalService: NgbModal) {
    
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
    const modalRef = this.modalService.open(Modal, {
      backdrop: 'static',
      keyboard: false
    });

    modalRef.componentInstance.route = this.depToDelete;

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

  registerDeparture(departure: departure) {
    this._http.post("api/departure/" + departure)
      .subscribe
  }
}
