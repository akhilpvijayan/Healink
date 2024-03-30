import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.scss']
})
export class SignUpComponent implements OnInit {
  @Input() userForm: FormGroup | any;

  ngOnInit(): void {
  }

  updateUserForm(form: FormGroup) {
    this.userForm = form;
  }
  
}