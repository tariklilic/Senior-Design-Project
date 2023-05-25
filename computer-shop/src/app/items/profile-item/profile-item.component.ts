import { Component, Input, OnInit } from '@angular/core';
import { CartItem } from 'src/app/models/CartItem.model';

@Component({
  selector: 'app-profile-item',
  templateUrl: './profile-item.component.html',
  styleUrls: ['./profile-item.component.css']
})
export class ProfileItemComponent implements OnInit {
  @Input() item!: CartItem

  constructor() { }

  ngOnInit(): void {
  }

}
