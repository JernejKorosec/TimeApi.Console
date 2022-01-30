import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-fetch-data4',
  templateUrl: './fetch-data4.component.html'
})


export class FetchDataComponent4 {  // FIXME:
  /*
  employees: Employee[] = [];
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Employee[]>(baseUrl + 'presence').subscribe(result => {
      this.employees = result;
    }, error => console.error(error));
  }*/
}
/*
interface Spica {
  value1: string;
  value2: string;
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
*/
