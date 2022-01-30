import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { FetchDataComponent2 } from './fetch-data2/fetch-data2.component'; // FIXME:Vsi zaposleni ki so prisotni /presence endpoint
import { FetchDataComponent3 } from './fetch-data3/fetch-data3.component'; // FIXME:Vsi zaposleni, sortiranje dodajanje /employee endpoint
import { FetchDataComponent4 } from './fetch-data4/fetch-data4.component'; // FIXME:

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    FetchDataComponent2,  // FIXME:Vsi zaposleni ki so prisotni /presence endpoint
    FetchDataComponent3, // FIXME:Vsi zaposleni, sortiranje dodajanje /employee endpoint
    FetchDataComponent4 // FIXME:
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'fetch-data2', component: FetchDataComponent2 },   // FIXME:Vsi zaposleni ki so prisotni /presence endpoint
      { path: 'fetch-data3', component: FetchDataComponent3 },  // FIXME:Vsi zaposleni, sortiranje dodajanje /employee endpoint
      { path: 'fetch-data4', component: FetchDataComponent4 },  // FIXME:
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
