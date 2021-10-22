import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, ReactiveFormsModule, FormControl } from "@angular/forms";
import { departure } from "../departure";
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  templateUrl: "update.html"
})
export class Update {
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

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.updateDeparture(params.id)
    })
  }

  onSubmit() {
    this.saveChanges();
  }
  updateDeparture(id: number) {
    this._http.get<departure>("api/Departure/" + id)
      .subscribe(
        dep => {
          this.dep_form.patchValue({ id: dep.id });
          this.dep_form.patchValue({ departure_loc: dep.dep_location });
          this.dep_form.patchValue({ arrival_loc: dep.arr_location });
          this.dep_form.patchValue({ departure_time: dep.dep_time });
          this.dep_form.patchValue({ arrival_time: dep.arr_time });
          this.dep_form.patchValue({ route_price: dep.price });
        },
        error => console.log(error)
      );
  };

  saveChanges() {
    const saveDep = new departure();
    saveDep.id = this.dep_form.value.id;
    saveDep.dep_location = this.dep_form.value.departure_loc;
    saveDep.dep_time = this.dep_form.value.departure_time;
    saveDep.arr_location = this.dep_form.value.arrival_loc;
    saveDep.arr_time = this.dep_form.value.arrival_time;
    saveDep.price = this.dep_form.value.route_price;

    this._http.put("api/Departure/", saveDep)
      .subscribe(
        retur => {
          this.router.navigate(['/administration']);
        },
        error => console.log(error)
      );
  }
}
