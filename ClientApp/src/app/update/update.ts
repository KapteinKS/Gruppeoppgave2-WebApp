import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, ReactiveFormsModule, FormControl, Validators } from "@angular/forms";
import { departure } from "../departure";
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  templateUrl: "update.html"
})
export class Update {
  dep_form: FormGroup;

  form = {
    id: [""],
    departure_loc: [null, Validators.compose([Validators.required, Validators.pattern("[a-zA-ZøæåØÆÅ\\-. ]{2,30}")])],
    arrival_loc: [null, Validators.compose([Validators.required, Validators.pattern("[a-zA-ZøæåØÆÅ\\-. ]{2,30}")])],
    departure_time: [null, Validators.compose([Validators.required])],
    arrival_time: [null, Validators.compose([Validators.required])],
    route_price: [null, Validators.compose([Validators.required])]
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
        error => {
          console.log(error)
          if(error.status == 401) {
            this.router.navigate(['/login'])
          }
        }
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
        error => {
          console.log(error)
          if (error.status == 401) {
            this.router.navigate(['/login'])
          }
        }
      );
  }
}
