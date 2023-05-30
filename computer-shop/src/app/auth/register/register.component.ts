import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  public username = '';
  public email = '';
  public password = '';

  constructor(private userService: UserService, private router: Router) { }

  ngOnInit(): void {
  }

  register() {
    var user = { username: this.username, email: this.email, password: this.password };
    this.userService.register(user);
    this.router.navigate(['/login']);
  }

}
