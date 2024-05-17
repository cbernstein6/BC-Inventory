import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { ApiService } from '../api.service';
import { User } from '../models/user.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  constructor(private api: ApiService, private router: Router){}

  verifyUser(loginForm: NgForm){
    const username: string = loginForm.value.username;
    const password: string = loginForm.value.password;

    if(username.length == 0) throw new Error("Username cannot be empty");
    else if(password.length == 0) throw new Error("Password cannot be empty");

    const user: User = {
      id: -1,
      Username: username,
      Password: password
    }

    this.api.getUser(user).subscribe(data => {
      localStorage.setItem('user', username);
      this.router.navigate(['/home']);
    },
  error => {
    console.log("error: "+error);
  });
  }
}