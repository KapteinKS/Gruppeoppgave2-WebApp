import { Component } from "@angular/core";
import { departure } from "../departure";
import { ActivatedRoute, Router } from "@angular/router";
import { HttpClient } from "@angular/common/http";
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from "@angular/forms";

@Component({
  templateUrl: "register.html"
})
export class Register {
  dep_form: FormGroup;

  ngOnInit() {
    this._http.get("api/departure/Users")
      .subscribe(retur => { console.log("ok") },
        error => {
          if (error.status == 401) {
            this.router.navigate(['/login'])
          }
        }
    )
  }
  form = {
    id: [""],
    departure_loc: [null, Validators.compose([Validators.required, Validators.pattern("[a-zA-ZøæåØÆÅ\\-. ]{2,30}")])],
    arrival_loc: [null, Validators.compose([Validators.required, Validators.pattern("[a-zA-ZøæåØÆÅ\\-. ]{2,30}")])],
    departure_time: [null, Validators.compose([Validators.required])],
    arrival_time: [null, Validators.compose([Validators.required])],
    route_price: [null, Validators.compose([Validators.required])]
  }
  constructor(private _http: HttpClient,
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private router: Router)
  {
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

    this._http.post("api/departure/New", saveDep)
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
