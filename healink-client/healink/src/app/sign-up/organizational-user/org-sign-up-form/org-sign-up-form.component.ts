import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'src/app/Auth/auth.service';
import { CountryService } from 'src/app/services/country.service';
import { ImageConversionService } from 'src/app/services/image-conversion.service';
import { OrganizationService } from 'src/app/services/organization.service';
import { StateService } from 'src/app/services/state.service';
import { UserService } from 'src/app/services/user.service';
import { Enums } from 'src/app/shared/enums';

@Component({
  selector: 'app-org-sign-up-form',
  templateUrl: './org-sign-up-form.component.html',
  styleUrls: ['./org-sign-up-form.component.scss']
})
export class OrgSignUpFormComponent implements OnInit {
  @Output() orgFormChanged: EventEmitter<FormGroup> = new EventEmitter<FormGroup>();
  orgForm!: FormGroup;
  countries: any;
  states: any;
  industryTypes: any;
  organizationLogo: any;
  organizationCover: any;
  organizationSize: any;
  formData = new FormData();
  isProfilePictureUpdated: any = false;
  isProfileCoverUpdated: any = false;

  constructor(private countryService: CountryService,
    private stateService: StateService,
    private formBuilder: FormBuilder,
    private userService: UserService,
    private toastr: ToastrService,
    private organizationService: OrganizationService,
    private imgConverter: ImageConversionService,
    private authService: AuthService,
    private router: Router) { }

  ngOnInit(): void {
    this.initializeForm();
    this.countryService.getAllCountries().subscribe((res: any) => {
      this.countries = res;
    });

    this.organizationService.getOrganizationTypes().subscribe((res: any) => {
      this.industryTypes = res;
    });

    this.organizationService.getOrganizationSizes().subscribe((res: any) => {
      this.organizationSize = res;
    });

    const countryControl = this.orgForm.get('countryId');
    if (countryControl !== null) {
      countryControl.valueChanges.subscribe((selectedCountry: any) => {
        if (selectedCountry !== null) {
          this.orgForm.patchValue({
            stateId: null
          });
          this.getStateByCountryId(selectedCountry);
        }
      });
    }

    this.orgForm.valueChanges.subscribe(() => {
      this.orgFormChanged.emit(this.orgForm);
    });

    //Get selected industry name to display in profile preview
    this.orgForm.get('organizationSize')?.valueChanges.subscribe((selectedOrgSize) => {
      const selectedType = this.organizationSize.find((type: any) => type.organizationSizeId === selectedOrgSize);
      this.orgForm.patchValue({
        industrySize: selectedType ? selectedType.organizationSizeType : ''
      });
    });

    //Get selected industry name to display in profile preview
    this.orgForm.get('organizationType')?.valueChanges.subscribe((selectedOrgType) => {
      const selectedType = this.industryTypes.find((type: any) => type.industryTypeId === selectedOrgType);
      this.orgForm.patchValue({
        industryName: selectedType ? selectedType.industryName : ''
      });
    });

    //Get selected country name to display in profile preview
    this.orgForm.get('countryId')?.valueChanges.subscribe((selectedCountryId) => {
      const selectedCountry = this.countries.find((country: any) => country.countryId === selectedCountryId);
      this.orgForm.patchValue({
        countryName: selectedCountry ? selectedCountry.countryName : ''
      });
    });

    //Get selected state name to display in profile preview
    this.orgForm.get('stateId')?.valueChanges.subscribe((selectedStateId) => {
      const selectedState = this.states.find((state: any) => state.stateId === selectedStateId);
      this.orgForm.patchValue({
        stateName: selectedState ? selectedState.stateName : ''
      });
    });

  }

  initializeForm() {
    this.orgForm = this.formBuilder.group({
      email: ['', Validators.required, [this.emailExists.bind(this)]],
      userName: ['', Validators.required, [this.userNameExists.bind(this)]],
      password: ['', Validators.required],
      roleId: [Enums.Role.OrganizationalUser],
      organizationName: ['', Validators.required],
      countryId: [null, Validators.required],
      stateId: [null, Validators.required],
      organizationWebsite: ['', Validators.required],
      organizationLogo: [''],
      organizationCover: [''],
      organizationBio: ['', Validators.required],
      region: ['', Validators.required],
      organizationSize: [, Validators.required],
      organizationType: [, Validators.required],
      countryName: [''],
      stateName: [''],
      tagline: ['', Validators.required],
      industryName: [''],
      industrySize: ['']
    });
  }

  getStateByCountryId(selectedCountry: any) {
    this.stateService.getstateByCountryId(selectedCountry).subscribe((res: any) => {
      this.states = res;
    })
  }

  userNameExists(control: AbstractControl) {
    return this.userService.userNameExists(control);
  }

  emailExists(control: AbstractControl) {
    return this.userService.emailExists(control);
  }

  onProfileImageFileSelected(target: any) {
    const file = target.files[0];
    if (file) {
      this.organizationLogo = target?.files[0];
      const reader = new FileReader();
      reader.onload = (e) => {
        this.isProfilePictureUpdated = true;
        this.orgForm.patchValue({
          organizationLogo: e.target?.result ?? null
        });
      };
      reader.readAsDataURL(file);
    }
  }

  onProfileCoverFileSelected(target: any) {
    const file = target.files[0];
    if (file) {
      this.organizationCover = target?.files[0];
      const reader = new FileReader();
      reader.onload = (e) => {
        this.isProfileCoverUpdated = true;
        this.orgForm.patchValue({
          organizationCover: e.target?.result ?? null
        });
      };
      reader.readAsDataURL(file);
    }
  }

  removeProfileImage() {
    this.isProfilePictureUpdated = true;
    this.orgForm.patchValue({
      organizationLogo: ''
    })
  }

  removeProfileCover() {
    this.isProfileCoverUpdated = true;
    this.orgForm.patchValue({
      organizationCover: ''
    })
  }

  saveFileInfo() {
    const formData: FormData = new FormData();
    formData.append('email', this.orgForm.value.email);
    formData.append('userName', this.orgForm.value.userName);
    formData.append('password', this.orgForm.value.password);
    formData.append('roleId', this.orgForm.value.roleId);
    formData.append('organizationName', this.orgForm.value.organizationName);
    formData.append('countryId', this.orgForm.value.countryId);
    formData.append('stateId', this.orgForm.value.stateId);
    formData.append('region', this.orgForm.value.region);
    formData.append('organizationWebsite', this.orgForm.value.organizationWebsite);
    formData.append('organizationBio', this.orgForm.value.organizationBio);
    formData.append('organizationSize', this.orgForm.value.organizationSize);
    formData.append('organizationType', this.orgForm.value.organizationType);
    formData.append('tagline', this.orgForm.value.tagline);
    formData.append('organizationLogo', this.organizationLogo);
    formData.append('organizationCover', this.organizationCover);
    formData.append('isProfilePictureUpdated', this.isProfilePictureUpdated);
    formData.append('isProfileCoverUpdated', this.isProfileCoverUpdated);
    return formData;
  }


  onSubmit() {
    if(this.orgForm.valid){
      this.organizationService.addOrganizationr(this.saveFileInfo()).subscribe((res: any)=>{
        if(res){
          this.authService.setToken(res.value.accessToken);
            this.authService.setUser(res.value.userId);
            this.authService.setRefreshToken(res.value.refreshToken);
            this.toastr.success(res.value.message);
            this.orgForm.reset();
            this.router.navigateByUrl('home');
        }
          this.toastr.success("User created successfully");
        })
    }
  }
}
