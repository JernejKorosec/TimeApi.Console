import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder } from '@angular/forms';
//import { FormControl, FormGroup } from '@angular/forms';
//import { REACTIVE_FORM_DIRECTIVES } from '@angular/forms'

@Component({
  selector: 'app-fetch-data3',
  templateUrl: './fetch-data3.component.html'
})
export class FetchDataComponent3 {  // FIXME:
  
  

  searchForm = this.formBuilder.group({
    firstname: '',
    lastname: ''
  });

    employees: Employee[] = [];
  constructor
  (
    private formBuilder: FormBuilder,
    http: HttpClient,
    @Inject('BASE_URL') baseUrl: string
  )
  {
    // this.items = ["item1", "item2", "item3"]

    

      http.get<Employee[]>(baseUrl + 'employee').subscribe(result => {
        this.employees = result;
      }, error => console.error(error));
  }
  onSubmit(): void {
    // Process checkout data here
    //this.items = this.cartService.clearCart();
    console.warn('test', this.searchForm.value);
    this.searchForm.reset();
  }

}

interface Employee {
  Id: number;
  lastName: string;
  firstName: string;
  MiddleName: string;
  City: string;
  Phone: string;
  Address: string;
  State: string;
  Fax: string;
  ReferenceId: string;
  Birth: string;
  WorkingSchemeType: number;
  Occupation: string;
  Unit3: string;
  Unit2: string;
  Unit1: string;
  email: string;
  Other: string;
  MobilePhone: string;
  OrganizationalUnitId: number;
  additionalField1: string;
  AdditionalField2: string;
  AdditionalField3: string;
  AdditionalField4: string;
  AdditionalField5: string;
  AdditionalField6: string;
  AdditionalField7: string;
  AdditionalField8: string;
  AdditionalField9: string;
  AdditionalField10: string;
  active: boolean;
  InternalField1: object;
  InternalField2: object;
  InternalField3: object;
  InternalField4: object;
  InternalField5: object;
  CurrentWorkingSchemeId: number;
}
