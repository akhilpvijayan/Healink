import { Component, Inject } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { CountryService } from 'src/app/services/country.service';
import { ImageConversionService } from 'src/app/services/image-conversion.service';
import { OrganizationService } from 'src/app/services/organization.service';
import { StateService } from 'src/app/services/state.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-edit-profile-dialog',
  templateUrl: './edit-profile-dialog.component.html',
  styleUrls: ['./edit-profile-dialog.component.scss']
})
export class EditProfileDialogComponent {
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
  isProfilePictureUpdated: any = false;
  isProfileCoverUpdated: any = false;
  
  constructor(
    private countryService: CountryService,
    private stateService: StateService,
    private userService: UserService,
    private toastr: ToastrService,
    private formBuilder: FormBuilder,
    private organizationService: OrganizationService,
    private imgConverter: ImageConversionService,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private dialogRef: MatDialogRef<EditProfileDialogComponent>,
    private spinner: NgxSpinnerService) { }

  ngOnInit() {
    this.spinner.show();
    this.initializeForm();
    this.profileCover = this.data?.profileDetails?.profileCover ? this.data.profileDetails.profileCover : null;
    this.profileImage = this.data?.profileDetails?.profileImage ? this.data.profileDetails.profileImage : null;
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
          this.getStateByCountryId(selectedCountry, false);
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

    this.organizationService.getOrganizationForSignup().subscribe((res: any) => {
      this.companies = res;
      this.spinner.hide();
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
      this.spinner.hide();
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

  getStateByCountryId(selectedCountry: any, isInit: boolean) {
    this.stateService.getstateByCountryId(selectedCountry).subscribe((res: any) => {
      this.states = res;
      if(isInit){
        this.userForm.patchValue({
          stateId: this.data?.profileDetails?.stateId
        });
      }
    })
  }

  initializeForm() {
    this.userForm = this.formBuilder.group({
      firstName: [this.data?.profileDetails?.firstName, Validators.required],
      lastName: [this.data?.profileDetails?.lastName, Validators.required],
      countryId: [this.data?.profileDetails?.countryId, Validators.required],
      stateId: [this.getStateByCountryId(this.data?.profileDetails?.countryId, true), Validators.required],
      userBio: [this.data?.profileDetails?.userBio ? this.data?.profileDetails?.userBio : '', Validators.required],
      profileImage: [this.data?.profileDetails?.profileImage ? this.data?.profileDetails?.profileImage : ''],
      profileCover: [this.data?.profileDetails?.profileCover ? this.data?.profileDetails?.profileCover : ''],
      region: [this.data?.profileDetails?.region, Validators.required],
      specialization: [this.data?.profileDetails?.specialization, Validators.required],
      countryName: [this.data?.profileDetails?.countryName, Validators.required],
      stateName: [this.data?.profileDetails?.stateName, Validators.required],
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

  onProfileImageFileSelected(target: any) {
    const file = target.files[0];
    if (file) {
      this.profileImage = target?.files[0];
      const reader = new FileReader();
      reader.onload = (e) => {
        this.userForm.patchValue({
          profileImage: e.target?.result ?? null
        });
        this.isProfilePictureUpdated = true;
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
        this.isProfileCoverUpdated = true;
      };
      reader.readAsDataURL(file);
    }
  }

  removeProfileImage() {
    this.profileImage = null;
    this.isProfilePictureUpdated = true;
  }

  removeProfileCover() {
    this.profileCover = null;
    this.isProfileCoverUpdated = true;
  }

  closeDialog(isSaved: boolean){
    this.dialogRef.close(isSaved);
  }

  setFormData(){
    const formData: FormData = new FormData();
    formData.append('firstName', this.userForm.value.firstName);
    formData.append('lastName', this.userForm.value.lastName);
    formData.append('countryId', this.userForm.value.countryId);
    formData.append('stateId', this.userForm.value.stateId);
    formData.append('userBio', this.userForm.value.userBio);
    formData.append('region', this.userForm.value.region);
    formData.append('profileImage', this.profileImage);
    formData.append('profileCover', this.profileCover);
    formData.append('specialization', this.userForm.value.specialization);
    formData.append('isProfilePictureUpdated', this.isProfilePictureUpdated);
    formData.append('isProfileCoverUpdated', this.isProfileCoverUpdated);
    return formData;
  }

  onSubmit(){
    if (this.userForm.valid) {
      this.userService.updateUser(this.setFormData(), this.data?.profileDetails?.userId).subscribe((res: any) => {
        if (res) {
          this.closeDialog(true);
          this.toastr.success("User details updated successfully");
        }
        else{
          this.toastr.error("Update user failed");
        }
      })
    }
  }
}
