import { Component, OnInit } from '@angular/core';
import { NavMenuModel } from '../models/nav-menu.model';
import { CategoryProductService } from '../services/category-product.service';
import { AuthenticationService } from '../services/authentication.service';
import { Router } from '@angular/router';
import { LoggedInModel } from '../models/logged-in.model';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  isExpanded = false;
  navMenuItems: NavMenuModel[];
  user: LoggedInModel;

  constructor(private categoryProductService: CategoryProductService, private authenticationService: AuthenticationService
    , private router: Router){}

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  ngOnInit() {
    this.getUser();
    this.navMenuItems = [{url:"/", name:"HOME"} ,{url:"/counter", name:"CONTACTENOS"}]
    this.getMenuItems();    
  }
  getMenuItems() {
    this.categoryProductService.getCategoryProducts()
      .subscribe(items => {
        items.forEach(item => {
          this.navMenuItems.splice(1,0,{url: `/categoria-producto/${item.name.split(" ").join("-")}`, name: item.name.toUpperCase()})
        });
      })
  }

  login(){
    this.router.navigate(['admin/login'])
  }

  logout(){
    this.authenticationService.logout();
    this.router.navigate([''])
  }

  getUser(){
    this.user = this.authenticationService.currentUserValue;
  }
  getUser2(){
    return this.authenticationService.currentUserValue;
  }
}
