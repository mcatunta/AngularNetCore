import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ProductService } from 'src/app/services/product.service';

@Component({
    selector: 'app-admin-product-create',
    templateUrl: './admin-product-create.component.html',
    styleUrls: ['admin-product-create.component.css']
})
export class AdminProductCreateComponent implements OnInit {

    constructor(private formBuilder: FormBuilder,private router: Router, private productService: ProductService) { }

    createForm: FormGroup;
    mainImageFile: File;
    mainImageUrl: string;
  
    ngOnInit() {
      this.createForm = this.formBuilder.group({
        idProduct: [],
        nameProduct: ['', Validators.required],
        description: ['', Validators.required],
        nameCategory: ['', Validators.required],
        price: ['', Validators.required]
      });
  
    }
  
    onSubmit() {
      this.productService.createProduct(this.createForm.value)
        .subscribe( data => {
            const imageFiles = new FormData();
            imageFiles.append('file', this.mainImageFile, `${data}_0.jpg`);
            this.productService.uploadProductImages(imageFiles)
                .subscribe(dataFile => {
                    this.router.navigate([`admin/actualizar-producto/${data}`]);
                },
                error => {
                    alert("Problemas cargando el archivo")
                })
        },
        error => {
            alert(error.error);
        });
    }

    selectImage(event){
        const files = event.target.files;
        if (files[0].type.match('image.*')) {
            const reader = new FileReader();
            reader.readAsDataURL(files[0]);
            reader.onload = e => this.mainImageUrl = reader.result as string;
            this.mainImageFile = files[0];
        } else {
            alert('Formato de image inválido.');
            this.mainImageUrl = undefined;
            this.mainImageFile = undefined;
        }
    }
}