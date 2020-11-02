import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ProductsByCategoryComponent } from './products-by-category/products-by-category.component';
import { AdminLoginComponent } from './admin/admin-login/admin-login.component';

import { CategoryProductService } from './services/category-product.service';
import { ProductService } from './services/product.service';
import { AuthenticationService } from './services/authentication.service';
import { AdminProductListComponent } from './admin/admin-product-list/admin-product-list.component';
import { AdminProductCreateComponent } from './admin/admin-product-create/admin-product-create.component';
import { AdminProductUpdateComponent } from './admin/admin-product-update/admin-product-update.component';
import { AuthGuard } from './helpers/auth-guard';
import { JwtInterceptor } from './helpers/jwt-interceptor';
import { ErrorInterceptor } from './helpers/error-interceptor';
@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    ProductsByCategoryComponent,
    AdminLoginComponent,
    AdminProductListComponent,
    AdminProductCreateComponent,
    AdminProductUpdateComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'categoria-producto/:nameCategory', component: ProductsByCategoryComponent},
      { path: 'admin/login', component: AdminLoginComponent},
      { path: 'admin', component: AdminProductListComponent, canActivate: [AuthGuard]},
      { path: 'admin/crear-producto', component: AdminProductCreateComponent, canActivate: [AuthGuard]},
      { path: 'admin/actualizar-producto/:idProduct', component: AdminProductUpdateComponent, canActivate: [AuthGuard]},
      { path: '**', redirectTo: ''}
    ])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    AuthenticationService, CategoryProductService, ProductService],
  bootstrap: [AppComponent]
})
export class AppModule { }
