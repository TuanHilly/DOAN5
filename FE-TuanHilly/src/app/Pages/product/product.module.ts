import { CUSTOM_ELEMENTS_SCHEMA, NgModule, NO_ERRORS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ChitietComponent } from './chitiet/chitiet.component';


const routesConfig: Routes = [

  { path: 'chitiet', component: ChitietComponent }
];

@NgModule({
  declarations: [
    ChitietComponent,
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routesConfig),
  ],
})
export class ProductModule { }
