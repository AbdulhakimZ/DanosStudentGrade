import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';
import { NgChartsModule } from 'ng2-charts';

import { AppComponent } from './app.component';
import { StudentListComponent } from './student-list/student-list.component';
import { CourseChartComponent } from './course-chart/course-chart.component';

const routes: Routes = [
  { path: '', component: StudentListComponent },
  { path: 'chart', component: CourseChartComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    StudentListComponent,
    CourseChartComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    RouterModule.forRoot(routes),
    NgChartsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
