import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { ProductModule } from './pages/product/product.module';
import { NotFoundComponent } from './Block/not-found/not-found.component';
import { HomeModule } from './Pages/home/home.module';


const routesConfig: Routes = [
//home
{ path:'home', loadChildren:() => import('./Pages/home/home.module').then(m => m.HomeModule)},
//Product
{ path:'product', loadChildren:() => import('./pages/product/product.module').then(m => m.ProductModule)},
//NotFound
  { path:'**', component: NotFoundComponent },
];

@NgModule({
  declarations: [],
  imports:[
    CommonModule,
    ProductModule,
    HomeModule,
    RouterModule.forRoot(routesConfig)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
