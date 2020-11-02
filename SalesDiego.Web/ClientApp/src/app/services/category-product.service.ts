import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CategoryProductModel } from '../models/category-product.model';
import { environment } from '../../environments/environment';

@Injectable()
export class CategoryProductService {
  constructor(private httpClient: HttpClient) { }

  getCategoryProducts(){
    return this.httpClient.get<CategoryProductModel[]>(`${environment.ApiUrl}/product/category-products`);
  }

}
