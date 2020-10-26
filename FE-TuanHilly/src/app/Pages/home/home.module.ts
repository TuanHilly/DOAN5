import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { RouterModule, Routes } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';



const routesconfig: Routes=[
  { path:'', redirectTo:'home', pathMatch:'full' },
  { path:'home', component: HomeComponent },

];

@NgModule({
  declarations: [HomeComponent
  ],
  imports: [
    CommonModule,BrowserModule,
    RouterModule.forChild(routesconfig),
  ],
})
export class HomeModule { }
