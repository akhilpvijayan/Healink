import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.scss']
})
export class SignUpComponent implements OnInit {
  @Input() userForm: FormGroup | any;
  @Input() orgForm: FormGroup | any;
  userType: number = 0;
  constructor(private route: ActivatedRoute){}

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.userType =  params['q'];
    });
  }

  updateUserForm(form: FormGroup) {
    this.userForm = form;
  }

  updateOrgForm(form: FormGroup) {
    this.orgForm = form;
  }
  
}