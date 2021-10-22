import { Component } from "@angular/core";
import { departure } from "../departure";
import { ActivatedRoute, Router } from "@angular/router";
import { HttpClient } from "@angular/common/http";
import { FormBuilder, FormGroup, ReactiveFormsModule } from "@angular/forms";

@Component({
  templateUrl: "register.html"
})
export class Register {
  dep_form: FormGroup;

  form = {
    departure_loc: [null],
    arrival_loc: [null],
    departure_time: [null],
    arrival_time: [null],
    route_price: [null]
  }
  constructor(private _http: HttpClient, private route: ActivatedRoute, private fb: FormBuilder, private router: Router) {
    this.dep_form = fb.group(this.form);
  }

  onSubmit() {
    this.saveNewDeparture();
  }

  saveNewDeparture() {
    const saveDep = new departure();
    saveDep.dep_location = this.dep_form.value.departure_loc;
    saveDep.dep_time = this.dep_form.value.departure_time;
    saveDep.arr_location = this.dep_form.value.arrival_loc;
    saveDep.arr_time = this.dep_form.value.arrival_time;
    saveDep.price = this.dep_form.value.route_price;
    this._http.post("api/departure/", saveDep)
      .subscribe(
        retur => {
          this.router.navigate(['/administration']);
        },
        error => console.log(error)
      );
  }
}
