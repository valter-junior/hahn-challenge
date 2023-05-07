import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  constructor(private _http: HttpClient) { }

  addProduct(data: any): Observable<any> {
    return this._http.post(environment.apiUrl + "product/add", data);
  }

  updateProduct(data: any): Observable<any> {
    return this._http.put(environment.apiUrl + "product/update", data);
  }

  getProductList(): Observable<any> {
    return this._http.get(environment.apiUrl + "product/list-all");
  }

  deleteProduct(id: string): Observable<any> {
    return this._http.delete(environment.apiUrl + `product/delete?id=${id}`);
  }
}