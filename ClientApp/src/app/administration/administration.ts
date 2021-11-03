import { Component, OnInit } from '@angular/core';
import { departure } from '../departure';
import { HttpClient } from '@angular/common/http'
import { register } from 'ts-node';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Modal } from './modal';
import { FormGroup } from '@angular/forms';
import { Router } from '@angular/router'
import { User } from 'oidc-client';

@Component({
  //selector: 'router-outlet',
  templateUrl: './administration.html'
})

//Code monkey see, code monkey do
export class AdministrationComponent {
  public departures: Array<departure>;
  depToDelete: string;
  dep_form: FormGroup;
  loading: boolean;

  constructor(private _http: HttpClient, private modalService: NgbModal, private router: Router) {}

  ngOnInit() {
    this.loading = true;
    this.getAll();
  }

  //Note to do this when i wake up. -K
  getUsers() {
    this._http.get<User[]>("api/Users/")
      .subscribe()
  }

  getAll() {
    this._http.get<departure[]>("api/Departure/")
      .subscribe(data => {
        this.departures = data;
        this.loading = false;
      },
        error => alert("Noe gikk galt"),
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
      this.router.navigate(['/amdinistration'])
    });
  }
}
