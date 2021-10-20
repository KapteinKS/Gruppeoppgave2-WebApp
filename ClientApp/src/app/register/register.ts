import { Component } from "@angular/core";
import { departure } from "../administration/departure";
import { ActivatedRoute, Router } from "@angular/router";
import { HttpClient } from "@angular/common/http";
import { FormBuilder, FormGroup } from "@angular/forms";

@Component({
  templateUrl: "register.html"
})
export class Register {
  change_form: FormGroup;

  form = {
    departure_loc: [null],
    arrival_loc: [null],
    departure_time: [null],
    arrival_time: [null],
    route_price: [null]
  }
  constructor(private _http: HttpClient, private route: ActivatedRoute, private fb: FormBuilder, private router: Router) {
    this.change_form = fb.group(this.form);
  }

  onSubmit() {
    this.saveNewDeparture();
  }

  saveNewDeparture() {
    const saveDep = new departure();
    saveDep.id = this.change_form.value.id;
    saveDep.dep_location = this.change_form.value.departure_loc;
    saveDep.dep_time = this.change_form.value.departure_time;
    saveDep.arr_location = this.change_form.value.arrival_loc;
    saveDep.arr_time = this.change_form.value.arrival_time;
    saveDep.price = this.change_form.value.route_price;

    this._http.post("api/Departure/", saveDep)
      .subscribe(
        retur => {
          this.router.navigate(['/aministration']);
        },
        error => console.log(error)
      );
  }
}
