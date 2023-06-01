import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';
import { PurchaseHistory } from '../models/PurchaseHistory.model';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  purchaseHistory!: PurchaseHistory;

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.userService.getPurchaseHistory();
    this.userService.purchaseHistory.subscribe(result => {
      this.purchaseHistory = result;
    })
  }

}
