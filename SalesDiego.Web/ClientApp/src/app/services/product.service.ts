import { Injectable } from '@angular/core';
import { ProductModel } from '../models/product.model';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { ProductCreateModel } from '../models/product-create.model';

@Injectable()
export class ProductService {

  constructor(private httpClient: HttpClient) { }

  getProductsByCategoryProductName(nameCategory: string){
    return this.httpClient.get<ProductModel[]>(`${environment.ApiUrl}/product/products-by-category-name/${nameCategory}`);
  }

  getProducts(){
    return this.httpClient.get<ProductModel[]>(`${environment.ApiUrl}/product/product`);
  }

  getProductById(idProduct: number){
    return this.httpClient.get<ProductModel>(`${environment.ApiUrl}/product/product/${idProduct}`);
  }

  createProduct(product: ProductCreateModel){
    return this.httpClient.post<number>(`${environment.ApiUrl}/product/create-product`, product);
  }

  updateProduct(product: ProductModel){
    return this.httpClient.post<number>(`${environment.ApiUrl}/product/update-product`, product);
  }

  uploadProductImages(images){
    return this.httpClient.post(`${environment.WebUrl}/api/image/upload`, images);
  }

  deleteProductImages(images){
    return this.httpClient.post(`${environment.WebUrl}/api/image/delete`, images);
  }

  addSecundaryImage(idProduct){
    return this.httpClient.post(`${environment.ApiUrl}/product/add-secundary-image`, idProduct);
  }

  deleteSecundaryImage(imageName){
    return this.httpClient.post(`${environment.ApiUrl}/product/delete-secundary-image`, imageName);
  }
}
