import { AccountsService } from './_services/accounts.service';
import { User } from './_models/user';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'The Dating App';
  users: any;

  constructor (private http : HttpClient, private accountService: AccountsService){}

    ngOnInit(){
      this.getUsers();
      this.setCurrentUser();
    }

    setCurrentUser(){
      const user: User = JSON.parse(localStorage.getItem('user'));
      this.accountService.setCurrentUser(user);
    }

    //httpcall 
    getUsers(){
      this.http.get('https://localhost:5001/api/users/GetAllUsers')
      .subscribe(response =>{
        this.users = response;
      }, error => {
        console.log(error);
      })
    }

}
