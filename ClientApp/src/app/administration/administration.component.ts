import { Component, OnInit } from '@angular/core';
import { departure } from './departure';
import { HttpClient } from '@angular/common/http'
import { register } from 'ts-node';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Modal } from './modal';
import { FormGroup } from '@angular/forms';

@Component({
  //selector: 'router-outlet',
  templateUrl: './administration.component.html'
})

//Code monkey see, code monkey do
export class AdministrationComponent {
  public departures: Array<departure>;
  depToDelete: string;
  dep_form: FormGroup;

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

  registerRoute() {
    const dep = new departure();

    dep.dep_location = this.dep_form.value.departure_loc;
    dep.arr_location = this.dep_form.value.arrival_loc;
    dep.dep_time = this.dep_form.value.departure_time;
    dep.arr_time = this.dep_form.value.arrival_time;
    dep.price = this.dep_form.value.route_price;

    this._http.post("api/departure", dep)
      .subscribe
  }
}
