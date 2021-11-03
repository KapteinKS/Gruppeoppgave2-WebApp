import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from '../user';

@Component({
  //selector: 'router-outlet',
  templateUrl: './login.component.html'
})

export class LoginComponent {
  title: 'login';

  Skjema: FormGroup;

  constructor(private _http: HttpClient, private fb: FormBuilder, private router: Router) {
    this.Skjema = fb.group({
      brukernavn: ["", Validators.required],
      passord: ["", Validators.pattern("[0-9]{6,15}")]
    });
  }

  onSubmit() {
    console.log("Modellbasert skjema submitted");
    console.log(this.Skjema);
    console.log(this.Skjema.value.brukernavn);
    console.log(this.Skjema.touched);
    this.logIn();
  }

  ngOnInit() {

  }

  logIn() {
    var user = new User(); 
    user.username = this.Skjema.value.brukernavn;
    user.password = this.Skjema.value.passord;
    this._http.post("api/departure/", user)
      .subscribe(retur => {
        this.router.navigate(['/administration']);
      })
  }
}
