import { Component,Injector, OnInit } from '@angular/core';
import { BaseComponent } from 'src/app/Server/base-component';


@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent extends BaseComponent implements OnInit {
  total: any;
  items: any;
  constructor(injector: Injector) {
    super(injector);
  }
  ngOnInit(): void {
    this._cart.items.subscribe((res) => {
      this.items = res;
      this.total = 0;
      for (let x of this.items) {
        x.money = x.quantity_sale * x.unit_price;
        this.total += x.quantity_sale * x.unit_price;
      }
    });
  }
  clearCart() {
    this._cart.clearCart();
    alert('Xóa thành công!');
  }
  addQty(item, quantity_sale) {
    if (item.quantity >= quantity_sale) {
      item.quantity_sale = quantity_sale;
      item.money = Number.parseInt(item.quantity_sale) * item.unit_price;
      this._cart.addQty(item);
    } else {
      alert('Số lượng không đủ!');
    }
  }
}
