import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

// Data transfer objects matching backend models
export interface StudentAverageDto {
  studentId: number;
  studentName: string;
  averageGrade: number;
}

export interface CourseAverageDto {
  courseName: string;
  averageGrade: number;
}

export interface DashboardDataDto {
  studentAverages: StudentAverageDto[];
  courseAverages: CourseAverageDto[];
}

export interface StudentDto {
  Id: number;
  Name: string;
}

export interface GradeItem {
  subject: string;
  gradeValue: number | null;
}

export interface GradeDto {
  studentId: number;
  grades: GradeItem[];
}
/**
 * Service for communicating with the backend API
 */
@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private apiUrl = '/api/grades';

  constructor(private http: HttpClient) { }

  /**
   * Fetches dashboard data from the backend
   */
  getDashboardData(): Observable<DashboardDataDto> {
    return this.http.get<DashboardDataDto>(this.apiUrl);
  }

  saveNewStudent(studentData: StudentDto): Observable<any> {
    return this.http.post(`${this.apiUrl}/student`, studentData)
  }
  SaveGrade(newGrade: GradeDto): Observable<any> {
    return this.http.post(`${this.apiUrl}/submitNewGrade`, newGrade)
  }
}
