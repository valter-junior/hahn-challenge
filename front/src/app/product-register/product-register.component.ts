import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { ProductService } from '../product/product.service';
import { HelpersService } from '../helpers/helpers.service';


@Component({
  selector: 'app-product-register',
  templateUrl: './product-register.component.html',
  styleUrls: ['./product-register.component.css']
})
export class ProductRegisterComponent {
  hide = true;

  empForm: FormGroup;

  ngOnInit(): void {
    this.empForm.patchValue(this.data);
  }

  constructor(
    private _fb: FormBuilder,
    private _dialogRef: MatDialogRef<ProductRegisterComponent>,
    private _prdService: ProductService,
    private _hpService: HelpersService,
    private router: Router,
    @Inject(MAT_DIALOG_DATA) public data: any,

  ) {
    this.empForm = this._fb.group({
      name: new FormControl('', Validators.required),
      description: new FormControl('', Validators.required),
      value: new FormControl('', Validators.required),
    });
  }

  onFormSubmit() {
    if (this.empForm.valid) {

      if (this.data.id) {

        this.empForm.value.id = this.data.id

        this._prdService
          .updateProduct(this.empForm.value)
          .subscribe({
            next: (val: any) => {
              this._hpService.openSnackBar('Product detail updated!');
              this._dialogRef.close(true);
            },
            error: (err: any) => {
              console.error(err.statusText);
            },
          });
      } else {

        this.empForm.value.managerId = localStorage.getItem('userId')
        this._prdService.addProduct(this.empForm.value).subscribe({
          next: (val: any) => {
            this._hpService.openSnackBar('Product added successfully');
            this.router.navigate(['/dashboard/product']);
          },
          error: (err: any) => {
            console.error(err);
          },
        });
      }
    }
  }

}
