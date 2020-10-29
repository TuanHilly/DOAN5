import { CUSTOM_ELEMENTS_SCHEMA, NgModule, NO_ERRORS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ChitietComponent } from './chitiet/chitiet.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CartComponent } from './cart/cart.component';


const routesConfig: Routes = [

  { path: 'chitiet/:id', component: ChitietComponent },
  { path: 'cart', component: CartComponent }
];

@NgModule({
  declarations: [
    ChitietComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,ReactiveFormsModule,
    RouterModule.forChild(routesConfig),
  ],
})
export class ProductModule { }
