import { Component, OnInit } from "@angular/core";
import { ProductService } from "../services/product.service";
import { ProductModel } from "../models/product.model";
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: "app-products-by-category",
    templateUrl: "./products-by-category.component.html",
    styleUrls: ["./products-by-category.component.css"]
})
export class ProductsByCategoryComponent implements OnInit {
    categoryName: string
    listProducts: ProductModel[];
    date: string

    constructor(private route: ActivatedRoute, private productService: ProductService) {
        this.route.paramMap.subscribe(params => {
            this.ngOnInit();
        });
    }

    ngOnInit() {
        this.categoryName = this.route.snapshot.paramMap.get("nameCategory");
        this.getProductsByCategoryName();
        this.date = Date.now().toString();
    }

    getProductsByCategoryName() {
        this.productService.getProductsByCategoryProductName(this.categoryName.split("-").join(" "))
            .subscribe(products => {
                this.listProducts =products
            })
    }
}