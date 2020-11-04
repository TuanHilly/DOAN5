import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { ProductModule } from './Pages/product/product.module';
import { NotFoundComponent } from './Block/not-found/not-found.component';
import { HomeModule } from './Pages/home/home.module';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { CustomerModule } from './Pages/customer/customer.module';


const routesConfig: Routes = [
//home
{ path:'home', loadChildren:() => import('./Pages/home/home.module').then(m => m.HomeModule)},
//Product
{ path:'product', loadChildren:() => import('./Pages/product/product.module').then(m => m.ProductModule)},

//customer
{ path:'customer', loadChildren:() => import('./Pages/customer/customer.module').then(m => m.CustomerModule)},
//NotFound
  { path:'**', component: NotFoundComponent },
];

@NgModule({
  declarations: [],
  imports:[

    CommonModule,
    ProductModule,CustomerModule,
    HomeModule,
    RouterModule.forRoot(routesConfig)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
