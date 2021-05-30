import { logging } from 'protractor';
import { AccountsService } from './../_services/accounts.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {}
  loggedIn: boolean ;
  constructor(private accountsService: AccountsService) { }

  ngOnInit(): void {
  }

  login() {
    this.accountsService.login(this.model).subscribe( response => {
      console.log(response);
      this.loggedIn = true;
      console.log(this.loggedIn);
    }, error => {
      console.log(error);
    });
  }

  logout()
  {
    this.loggedIn = false;
  }
}
