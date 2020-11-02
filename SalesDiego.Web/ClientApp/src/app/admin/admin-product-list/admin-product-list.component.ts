import { Component, OnInit } from "@angular/core";
import { ProductModel } from "../../models/product.model";
import { ProductService } from "../../services/product.service";
import { Router } from "@angular/router";

@Component({
    selector: 'app-admin-product-list',
    templateUrl: './admin-product-list.component.html',
    styleUrls: ['./admin-product-list.component.css']
})
export class AdminProductListComponent implements OnInit {

    listProducts: ProductModel[]

    constructor(private router: Router, private productService: ProductService) {}

    ngOnInit() {
        this.getProducts();
    }

    getProducts(){
        this.productService.getProducts()
            .subscribe(items =>
                {
                    this.listProducts = items
                });
    }

    createProduct(){
        this.router.navigate(['admin/crear-producto']);
    }

    updateProduct(product: ProductModel){
        this.router.navigate([`admin/actualizar-producto/${product.idProduct.toString()}`]);
    }
}