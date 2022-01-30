import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data2.component.html'
})
export class FetchDataComponent2 {  // FIXME:
  spicavalues: Spica[] = [];
  employeevalues: Employee[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Spica[]>(baseUrl + 'spica').subscribe(result => {
      this.spicavalues = result;
    }, error => console.error(error));
  }




}

interface Spica {
  value1: string;
  value2: string;
}


interface Employee {
  Id: number;
  LastName: string;
  FirstName: string;
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
  Email: string;
  Other: string;
  MobilePhone: string;
  OrganizationalUnitId: number;
  AdditionalField1: string;
  AdditionalField2: string;
  AdditionalField3: string;
  AdditionalField4: string;
  AdditionalField5: string;
  AdditionalField6: string;
  AdditionalField7: string;
  AdditionalField8: string;
  AdditionalField9: string;
  AdditionalField10: string;
  Active: boolean;
  InternalField1: object;
  InternalField2: object;
  InternalField3: object;
  InternalField4: object;
  InternalField5: object;
  CurrentWorkingSchemeId: number;
}
