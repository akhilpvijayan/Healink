import { Component, EventEmitter, Output } from '@angular/core';
import { AbstractControl, FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { CountryService } from 'src/app/services/country.service';
import { ImageConversionService } from 'src/app/services/image-conversion.service';
import { OrganizationService } from 'src/app/services/organization.service';
import { StateService } from 'src/app/services/state.service';
import { UserService } from 'src/app/services/user.service';
import { Enums } from 'src/app/shared/enums';

@Component({
  selector: 'app-sign-up-form',
  templateUrl: './sign-up-form.component.html',
  styleUrls: ['./sign-up-form.component.scss']
})
export class SignUpFormComponent {
  @Output() userFormChanged: EventEmitter<FormGroup> = new EventEmitter<FormGroup>();
  profileValue = 1;
  countries: any;
  states: any;
  userForm!: FormGroup;
  formData = new FormData();
  isOrganisationUser = false;
  profileImage: any;
  profileCover: any;
  companies: any;
  educationalOrgs: any;
  currentDate: Date = new Date();
  isUserNameExists = false;

  constructor(
    private countryService: CountryService,
    private stateService: StateService,
    private formBuilder: FormBuilder,
    private userService: UserService,
    private toastr: ToastrService,
    private organizationService: OrganizationService,
    private imgConverter: ImageConversionService) { }

  ngOnInit() {
    this.initializeForm();
    this.countryService.getAllCountries().subscribe((res: any) => {
      this.countries = res;
    });

    const countryControl = this.userForm.get('countryId');
    if (countryControl !== null) {
      countryControl.valueChanges.subscribe((selectedCountry: any) => {
        if (selectedCountry !== null) {
          this.userForm.patchValue({
            stateId: null
          });
          this.getStateByCountryId(selectedCountry);
        }
      });
    }

    //Get selected country name to display in profile preview
    this.userForm.get('countryId')?.valueChanges.subscribe((selectedCountryId) => {
      const selectedCountry = this.countries.find((country: any) => country.countryId === selectedCountryId);
      this.userForm.patchValue({
        countryName: selectedCountry ? selectedCountry.countryName : ''
      });
    });

    //Get selected state name to display in profile preview
    this.userForm.get('stateId')?.valueChanges.subscribe((selectedStateId) => {
      const selectedState = this.states.find((state: any) => state.stateId === selectedStateId);
      this.userForm.patchValue({
        stateName: selectedState ? selectedState.stateName : ''
      });
    });

    this.userForm.valueChanges.subscribe(() => {
      this.userFormChanged.emit(this.userForm);
    });

    this.organizationService.getOrganizationForSignup().subscribe((res: any) => {
      this.companies = res;
      this.companies.forEach((company: any) => {
        if (company.organizationLogo) {
          return this.imgConverter.convertImageToDataURL(company.organizationLogo).then((dataUrl: any) => {
            company.organizationLogo = dataUrl;
          });
        }
        else {
          return company.organizationLogo = null;
        }
      });

      this.companies.push({ organizationDetailId: 0, organizationName: 'Others' });
    });

    this.organizationService.getEducationalOrganizations().subscribe((res: any) => {
      this.educationalOrgs = res;
      this.educationalOrgs.forEach((eduOrg: any) => {
        if (eduOrg.organizationLogo) {
          return this.imgConverter.convertImageToDataURL(eduOrg.organizationLogo).then((dataUrl: any) => {
            eduOrg.organizationLogo = dataUrl;
          });
        }
        else {
          return eduOrg.organizationLogo = null;
        }
      });

      this.educationalOrgs.push({ organizationDetailId: 0, organizationName: 'Others' });
    });
  }

  initializeForm() {
    this.userForm = this.formBuilder.group({
      email: ['', Validators.required, [this.emailExists.bind(this)]],
      userName: ['', Validators.required, [this.userNameExists.bind(this)]],
      password: ['', Validators.required],
      roleId: [this.isOrganisationUser ? Enums.Role.OrganizationalUser : Enums.Role.PersonalUser],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      countryId: [null, Validators.required],
      stateId: [null, Validators.required],
      userBio: ['', Validators.required],
      profileImage: [''],
      profileCover: [''],
      gender: ['', Validators.required],
      region: ['', Validators.required],
      specialization: ['', Validators.required],
      countryName: [''],
      stateName: [''],
      experiences: this.formBuilder.array([]),
      educations: this.formBuilder.array([])
    });
  }

  get experienceForms() {
    return this.userForm.get('experiences') as FormArray;
  }

  get educationForms() {
    return this.userForm.get('educations') as FormArray;
  }

  addExperience() {
    const experience = this.formBuilder.group({
      title: ['', Validators.required],
      company: ['', Validators.required],
      location: ['', Validators.required],
      startDate: [this.currentDate, Validators.required],
      endDate: [this.currentDate],
      description: [''],
      current: [false],
      companyId: []
    });

    this.experienceForms.push(experience);
  }

  addEducation() {
    const education = this.formBuilder.group({
      institution: ['', Validators.required],
      degree: ['', Validators.required],
      fieldOfStudy: ['', Validators.required],
      graduationStartDate: [this.currentDate, Validators.required],
      graduationEndDate: [this.currentDate],
      graduationDescription: [''],
      current: [false],
      orgId: []
    });

    this.educationForms.push(education);
  }

  onCheckboxChange(checked: boolean, index: number) {
    if (checked) {
      this.experienceForms?.at(index)?.get('endDate')?.disable();
    } else {
      this.experienceForms?.at(index)?.get('endDate')?.enable();
    }
  }

  onEducationCheckboxChange(checked: boolean, index: number) {
    if (checked) {
      this.educationForms?.at(index)?.get('graduationEndDate')?.disable();
    } else {
      this.educationForms?.at(index)?.get('graduationEndDate')?.enable();
    }
  }

  isEndDateDisabled(index: number): boolean {
    return this.experienceForms?.at(index)?.get('current')?.value;
  }

  isEducationEndDateDisabled(index: number): boolean {
    return this.educationForms?.at(index)?.get('current')?.value;
  }

  getStateByCountryId(selectedCountry: any) {
    this.stateService.getstateByCountryId(selectedCountry).subscribe((res: any) => {
      this.states = res;
    })
  }

  onProfileImageFileSelected(target: any) {
    const file = target.files[0];
    if (file) {
      this.profileImage = target?.files[0];
      const reader = new FileReader();
      reader.onload = (e) => {
        this.userForm.patchValue({
          profileImage: e.target?.result ?? null
        });
      };
      reader.readAsDataURL(file);
    }
  }

  onProfileCoverFileSelected(target: any) {
    const file = target.files[0];
    if (file) {
      this.profileCover = target?.files[0];
      const reader = new FileReader();
      reader.onload = (e) => {
        this.userForm.patchValue({
          profileCover: e.target?.result ?? null
        });
      };
      reader.readAsDataURL(file);
    }
  }

  setExpOrgName(index: number) {
    const selectedOrg = this.companies.find((org: any) => org.organizationDetailId === this.experienceForms.value[index]?.companyId);
    const experiencesArray = this.userForm.get('experiences') as FormArray;
    if (this.userForm?.value?.experiences[index]?.companyId != 0) {
      if (index >= 0 && index < experiencesArray.length) {
        experiencesArray.at(index).patchValue({
          company: selectedOrg ? selectedOrg.organizationName : ''
        });
      }
    }
    else {
      experiencesArray.at(index).patchValue({
        company: ''
      });
    }
  }

  setOrgName(index: number) {
    const selectedOrg = this.educationalOrgs.find((org: any) => org.organizationDetailId === this.userForm?.value?.educations[index]?.companyId);
    const educationsArray = this.userForm.get('educations') as FormArray;
    if (this.userForm?.value?.educations[index]?.companyId != 0) {
      if (index >= 0 && index < educationsArray.length) {
        educationsArray.at(index).patchValue({
          institution: selectedOrg ? selectedOrg.organizationName : ''
        });
      }
    }
    else {
      educationsArray.at(index).patchValue({
        institution: ''
      });
    }
  }

  removeEducation(index: number) {
    this.educationForms.removeAt(index);
  }

  removeExperience(index: number) {
    this.experienceForms.removeAt(index);
  }

  removeProfileImage() {
    this.userForm.patchValue({
      profileImage: ''
    })
  }

  removeProfileCover() {
    this.userForm.patchValue({
      profileCover: ''
    })
  }

  // Custom validator function to check if username already exists
  userNameExists(control: AbstractControl) {
    return new Promise(resolve => {
      if (!control.value) {
        resolve(false);
      } else {
        this.userService.isDuplicateUsername(control.value).subscribe((res: boolean) => {
          resolve(res ? { userNameExists: true } : false);
        });
      }
    });
  }

  emailExists(control: AbstractControl) {
    return new Promise(resolve => {
      if (!control.value) {
        resolve(false);
      } else {
        this.userService.isDuplicateEmail(control.value).subscribe((res: boolean) => {
          resolve(res ? { emailExists: true } : false);
        });
      }
    });
  }

  saveFileInfo() {
    const formData: FormData = new FormData();
    formData.append('email', this.userForm.value.email);
    formData.append('userName', this.userForm.value.userName);
    formData.append('password', this.userForm.value.password);
    formData.append('roleId', this.userForm.value.roleId);
    formData.append('firstName', this.userForm.value.firstName);
    formData.append('lastName', this.userForm.value.lastName);
    formData.append('countryId', this.userForm.value.countryId);
    formData.append('stateId', this.userForm.value.stateId);
    formData.append('userBio', this.userForm.value.userBio);
    formData.append('gender', this.userForm.value.gender);
    formData.append('region', this.userForm.value.region);
    formData.append('profileImage', this.profileImage);
    formData.append('profileCover', this.profileCover);
    formData.append('specialization', this.userForm.value.specialization);
    return formData;
  }

  onSubmit() {
    if (this.userForm.valid && this.experienceForms.valid) {
      this.userService.addUser(this.saveFileInfo()).subscribe((res: any) => {
        if (res) {
          const userId = res;
          this.userService.addUserExperience(this.experienceForms.value, userId).subscribe((res: any)=>{
            if(res){
              this.userService.addUserEducation(this.educationForms.value, userId).subscribe((res: any)=>{
                if(res){
                  this.toastr.success("User created successfully");
                }
              })
            }
          });
        }
        else{
          this.toastr.error("Create user failed");
        }
      })
    }
  }
}
