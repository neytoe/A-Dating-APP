import { logging } from 'protractor';
import { AccountsService } from './../_services/accounts.service';
import { Component, OnInit } from '@angular/core';
import { User } from '../_models/user';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})

export class NavComponent implements OnInit {
  model: any = {}
  currentUser$: Observable<User>;


  constructor(private accountsService: AccountsService) { }

  ngOnInit(): void {
    this.currentUser$ = this.accountsService.currentUser$;
  }

  login() {
    this.accountsService.login(this.model).subscribe( response => {
      console.log(response);
    }, error => {
      console.log(error);
    });
  }

  logout()
  {
    this.accountsService.logout();
  }


}
