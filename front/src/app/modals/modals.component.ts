import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ProductService } from '../product/product.service';
import { HelpersService } from '../helpers/helpers.service';

@Component({
  selector: 'app-modals',
  templateUrl: './modals.component.html',
  styleUrls: ['./modals.component.css']
})
export class ModalsComponent {
  hide = true;

  constructor(
    private _fb: FormBuilder,
    private _dialogRef: MatDialogRef<ModalsComponent>,
    private _prdService: ProductService,
    private _hpService: HelpersService,
    @Inject(MAT_DIALOG_DATA) public data: any,

  ) { }

  onDeleteSubmit() {
    if (this.data) {
      this._prdService
        .deleteProduct(this.data)
        .subscribe({
          next: (val: any) => {
            this._hpService.openSnackBar('Product Deleted!');
            this._dialogRef.close(true);
          },
          error: (err: any) => {
            console.error(err);
          },
        });
    }
  }
}




