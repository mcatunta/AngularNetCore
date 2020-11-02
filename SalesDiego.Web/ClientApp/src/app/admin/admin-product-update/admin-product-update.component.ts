import { Component, OnInit } from "@angular/core";
import { ProductCreateModel } from "../../models/product-create.model";
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { ProductService } from "../../services/product.service";

@Component({
    selector: 'app-admin-product-update',
    templateUrl: './admin-product-update.component.html',
    styleUrls: ['./admin-product-update.component.css']
})
export class AdminProductUpdateComponent implements OnInit{

    user: ProductCreateModel;
    updateForm: FormGroup;
    mainImageUrl: string;
    oldImageUrl: string;
    mainImageFile: File;
    listImages: string[];
    secundaryImageFile: File;
    secundaryImageUrl: string;
    date: string;

    constructor(private formBuilder: FormBuilder,private router: Router, private productService: ProductService
        , private route: ActivatedRoute,) { }
  
    ngOnInit() {
      let updateProductId = this.route.snapshot.paramMap.get("idProduct");
      if(!updateProductId) {
        alert("Invalid action.")
        this.router.navigate(['admin']);
        return;
      }
      this.updateForm = this.formBuilder.group({
        idProduct: [''],
        idCategoryProduct: [''],
        productName: ['', Validators.required],
        description: ['', Validators.required],
        categoryProductName: ['', Validators.required],
        price: ['', Validators.required],
        image: [''],
        images: ['']
      });
      this.date = Date.now().toString();
      this.productService.getProductById(+updateProductId)
        .subscribe( product => {
          this.updateForm.setValue(product);
          this.oldImageUrl = this.updateForm.controls.image.value;
          this.listImages = product.images;
        });
    }
  
    onSubmit() {
      if (this.mainImageFile==undefined) {
        this.productService.updateProduct(this.updateForm.value)
        .subscribe(
          data => {
              this.router.navigate(['admin']);
          },
          error => {
            alert(error.error);
          });        
      }
      else {
        const imageFiles = new FormData();
        imageFiles.append('file', this.mainImageFile, `${this.updateForm.controls.image.value}.jpg`);
        this.productService.uploadProductImages(imageFiles)
        .subscribe(dataFile => {
          this.productService.updateProduct(this.updateForm.value)
            .subscribe(
              data => {
                  this.router.navigate(['admin']);
              },
              error => {
                alert("Problemas actualizando datos.");
              });
            },
          error => {
            alert("Problemas actualizando la imagen.");
          }
        )   
      }      
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

    selectSecundaryImage(event){
        const files = event.target.files;
        if (files[0].type.match('image.*')) {
            const reader = new FileReader();
            reader.readAsDataURL(files[0]);
            reader.onload = e => this.secundaryImageUrl = reader.result as string;
            this.secundaryImageFile = files[0];
        } else {
            alert('Formato de image inválido.');
            this.secundaryImageUrl = undefined;
            this.secundaryImageFile = undefined;
        }
    }

    saveSecundaryImage(){
        if(this.secundaryImageFile == undefined){
            alert('Primero debe seleccionar una imagen secundaria.');
        } else {
            this.productService.addSecundaryImage({"idProduct": +this.updateForm.controls.idProduct.value, "imageName": 0})
            .subscribe(
              data => {
                  this.mainImageFile = undefined;
                  this.secundaryImageUrl = undefined;
                  const imageFiles = new FormData();
                  imageFiles.append('file', this.secundaryImageFile
                    , `${this.updateForm.controls.idProduct.value}_${data}.jpg`);
                  this.productService.uploadProductImages(imageFiles)
                    .subscribe(dataFile => {
                        //this.router.navigate(['admin']);
                        this.listImages.push(`${this.updateForm.controls.idProduct.value}_${data}`);
                    },
                    error => {
                        this.productService.deleteSecundaryImage({"idProduct": +this.updateForm.controls.idProduct.value
                            , "imageName": +data});
                        alert(error.error);
                    })                  
              },
              error => {
                alert(error.error);
              });
        }
    }

    deleteSecundaryImage(imageName){        
        this.productService.deleteProductImages([{"nameImage":`${imageName}.jpg`}])
            .subscribe(
                data => {
                    const imageNameParts = imageName.split('_');
                    this.productService.deleteSecundaryImage({"idProduct": +imageNameParts[0]
                        , "imageName": +imageNameParts[1]})
                        .subscribe(
                            data => {
                                const indexImage = this.listImages.indexOf(imageName);
                                if (indexImage !== -1){
                                    this.listImages.splice(indexImage, 1)
                                }                                    
                            },
                            error => {
                                alert('Problemas eliminando la imágen.')
                            }
                        )
                },
                error => {
                    alert(error.error);
                }
            )
    }
}