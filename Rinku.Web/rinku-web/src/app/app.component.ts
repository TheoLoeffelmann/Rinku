import { Component } from '@angular/core';
import { EmployeesComponent } from './employees/employees.component';
imports:[
  EmployeesComponent
]

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'rinku-web';
}
