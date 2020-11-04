import { Component,Injector, OnInit } from '@angular/core';
import { BaseComponent } from 'src/app/Server/base-component';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent extends BaseComponent implements OnInit {

  constructor(injector: Injector) {
    super(injector);
  }
  items: any;
  total: any;
  public hoadonForm: FormGroup;

  ngOnInit(): void {
    this.hoadonForm = new FormGroup({
      name: new FormControl('', Validators.required),
      address: new FormControl(''),
      phone: new FormControl(''),
      email: new FormControl(''),
    });
    this._cart.items.subscribe((res) => {
      this.items = res;
      this.total = 0;
      for (let x of this.items) {
        x.product_id = this.items.product_id;
        x.quantity_sale = +x.quantity_sale;
        x.money = x.quantity_sale * x.unit_price;
        this.total += x.quantity_sale * x.unit_price;
      }
    });
  }
  onSubmit(value: any) {
    let hoadon = {
      name: value.name,
      address: value.address,
      phone: value.phone,
      email:value.email,
      total: this.total,
      listjson_chitiet: this.items,
    };
    this._api
      .post('api/bill/create-bill',hoadon)
      .takeUntil(this.unsubscribe)
      .subscribe(
        (res) => {
          alert('Đặt hàng thành công!');
        },
        (err) => {}
      );
  }
}
