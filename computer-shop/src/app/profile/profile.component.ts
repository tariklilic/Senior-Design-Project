import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';
import { CartItem } from '../models/CartItem.model';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  appItems: any[] = Array(10).fill({});

  constructor(private userService: UserService) { }

  ngOnInit(): void {

  }

}
