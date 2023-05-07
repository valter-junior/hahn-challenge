import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { AuthService } from './auth.service';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.css']
})
export class AuthComponent {
  hide = true;
  loginValid = true;

  empForm: FormGroup;



  constructor(
    private _fb: FormBuilder,
    private _authService: AuthService,
    private router: Router,
    @Inject(MAT_DIALOG_DATA) public data: any,

  ) {
    this.empForm = this._fb.group({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('',),
    });
  }

  onFormSubmit() {
    if (this.empForm.valid) {
      this._authService
        .signIn(this.empForm.value)
        .subscribe((usr) => {

          localStorage.setItem('token', usr.token);
          localStorage.setItem('userId', usr.user.id)
          this.router.navigate(['/dashboard/product']);
        }
        )
    }
  }
}



