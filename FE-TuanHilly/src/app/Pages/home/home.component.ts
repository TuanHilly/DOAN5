import { Component, Injector, OnInit } from '@angular/core';
import { BaseComponent } from 'src/app/Server/base-component';
import 'rxjs/add/observable/combineLatest';
import 'rxjs/add/operator/takeUntil';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent extends BaseComponent implements OnInit {
  //HomeComponent
  sp:any;
  constructor(injector: Injector) {
    super(injector);
   }

  ngOnInit(): void {
    this._api.get('/api/Product/get-all').takeUntil(this.unsubscribe).subscribe(res => {this.sp = res;
       setTimeout(() => {
        this.loadScripts();
       }, );
      //console.log(this.sp);
});
  }
  //cart (basecomponen)
  addToCart(it) {
    this._cart.addToCart(it);
    alert('Thêm thành công!');
  }

}
