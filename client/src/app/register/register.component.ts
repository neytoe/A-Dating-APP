import { AccountsService } from './../_services/accounts.service';
import { EventEmitter } from '@angular/core';
import { Component, Input, OnInit, Output } from '@angular/core';
import { createWatchCompilerHost } from 'typescript';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
   model: any = {};

  constructor(private accountService: AccountsService) { }

  ngOnInit(): void {
  }

  register(){
    this.accountService.register(this.model).subscribe(response => {
      this.cancel();
    },  error => {
      console.log(error);
    });
  }

  cancel(){
    this.cancelRegister.emit(false);
  }
}
