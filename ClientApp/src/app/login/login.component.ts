import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
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

  form = {
    brukernavn: [null, Validators.compose([Validators.required])],
    passord: [null, Validators.compose([Validators.required, Validators.pattern("[a-zA-Z0-9]{6,15}")])]
  };

  constructor(private _http: HttpClient, private fb: FormBuilder, private router: Router) {
    this.Skjema = fb.group(this.form);
  }

  onSubmit() {
    console.log("Modellbasert skjema submitted");
    //console.log(this.Skjema);
    //console.log(this.Skjema.value.brukernavn);
    //console.log(this.Skjema.touched);
    this.logIn();
  }

  logIn() {
    var user = new User();
    user.username = this.Skjema.value.brukernavn;
    user.password = this.Skjema.value.passord;
    this._http.post("api/departure/Login", user)
      .subscribe(retur => {
        if (retur) {
          this.router.navigate(['/administration']);
        }
        else {
          alert("Feil brukernavn eller passord");
        }
      },
        error => console.log(error)
      );
  };
}
