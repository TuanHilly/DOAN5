import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';

import { HeaderComponent } from './Block/header/header.component';
import { FooterComponent } from './Block/footer/footer.component';
import { NotFoundComponent } from './Block/not-found/not-found.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';




@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    NotFoundComponent,
  ],
  imports: [
    CommonModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule { }
