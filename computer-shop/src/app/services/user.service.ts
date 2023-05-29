import { Injectable } from '@angular/core';
import { ProductsService } from './products.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private productService: ProductsService) {

  }


}
