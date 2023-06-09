import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public username = '';
  public password = '';

  constructor(private userService: UserService, private router: Router) { }

  ngOnInit(): void {
  }

  login() {
    var user = { username: this.username, password: this.password };
    this.userService.login(user);
  }

}
