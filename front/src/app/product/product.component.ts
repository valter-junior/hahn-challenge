import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ProductService } from './product.service';
import { ProductRegisterComponent } from '../product-register/product-register.component';
import { MatDialog } from '@angular/material/dialog';
import { HelpersService } from '../helpers/helpers.service';
import { ModalsComponent } from '../modals/modals.component';



@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})

export class ProductComponent {

  displayedColumns: string[] = ['id', 'name', 'description', 'value', 'action'];


  dataSource!: MatTableDataSource<any>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;



  ngOnInit(): void {
    this.getProductList();
  }

  constructor(

    private _hpService: HelpersService,
    private _dialog: MatDialog,
    private _prdService: ProductService,


  ) { }

  getProductList() {

    this._prdService.getProductList().subscribe({
      next: (res) => {
        this.dataSource = new MatTableDataSource(res);
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
      },
      error: console.log,
    });

  }
  openEditForm(data: any) {
    const dialogRef = this._dialog.open(ProductRegisterComponent, {
      data,
    });

    dialogRef.afterClosed().subscribe({
      next: (val) => {
        if (val) {
          this.getProductList();
        }
      },
    });
  }

  openDeleteModal(data: any) {
    const dialogRef = this._dialog.open(ModalsComponent, {
      data,
    });

    dialogRef.afterClosed().subscribe({
      next: (val) => {
        if (val) {
          this.getProductList();
        }
      },
    });
  }


  deleteProduct(id: string) {

    if (confirm("Are you sure to delete the product? ")) {
      this._prdService.deleteProduct(id).subscribe({
        next: (res) => {

          this._hpService.openSnackBar('Product deleted!');
          this.getProductList()

        },
        error: console.log,
      });
    }

  }
}






