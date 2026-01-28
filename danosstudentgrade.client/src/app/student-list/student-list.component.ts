import { Component } from '@angular/core';
import { ApiService, StudentAverageDto } from '../services/api.service';
import * as XLSX from 'xlsx';

/**
 * Component for displaying student averages in a table with Excel export
 */
@Component({
    selector: 'app-student-list',
    templateUrl: './student-list.component.html',
    styleUrls: ['./student-list.component.css']
})
export class StudentListComponent {
  studentAverages: StudentAverageDto[] = [];
  filteredData = this.studentAverages;
  filterText = "";
  isShowModal = false;
  isShowResultModal = false;

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    // This runs when component is initialized
    this.loadInitialData();
  }

  private loadInitialData(): void {
    this.apiService.getDashboardData().subscribe({
      next: (data) => {
        this.studentAverages = data.studentAverages || [];
        this.filteredData = [...this.studentAverages];
      },
      error: (error) => {
        console.error('Failed to load initial data:', error);
        // Optionally show error message to user
      }
    });
  }

  filter() {
    const text = this.filterText;
    this.filteredData = this.studentAverages.filter((d) =>
      d.studentName.toLowerCase().includes(text.toLowerCase())
    );
  }
  showModal() {
    this.isShowModal = !this.isShowModal;
    console.log(this.isShowModal);
  }
  newData = {
    Id:0,
    Name: ''
  };
  saveNew() {
    this.apiService.saveNewStudent(this.newData).subscribe({
      next: (savedStudent) => {
        console.log("Student Saved Successfully");
        const newStudentAverage: StudentAverageDto = {
          studentId: this.newData.Id,
          studentName: this.newData.Name,
          averageGrade: 0
        };

        this.studentAverages.push(newStudentAverage);
        this.filteredData = [...this.studentAverages];
        this.showModal();
      },
      error: (error) => {
        console.log("Error saving student:", error);

      },
      complete: () => {

      }
    })
    console.log("Save.." + this.newData.Name);
  }
    /**
     * Fetches student data from the API
     */
    fetchData() {
        this.apiService.getDashboardData().subscribe(data => {
            this.studentAverages = data.studentAverages;
        });
        this.filteredData = this.studentAverages;
  }
  studentId = 0;
  newGrade = {
    studentId: this.studentId,
    grades: [
      { subject: 'Math', gradeValue: null },
      { subject: 'Physics', gradeValue: null },
      { subject: 'Chemistry', gradeValue: null }
    ]
  };

  setStudentId(id:number) {
    this.studentId = id;
  }

  showResultModal() {
    this.isShowResultModal = !this.isShowResultModal;
  }

  saveResult() {
    this.apiService.SaveGrade(this.newGrade)
  }
    /**
     * Exports the student data to an Excel file
     */
    exportToExcel(): void {
        const ws: XLSX.WorkSheet = XLSX.utils.json_to_sheet(this.studentAverages);
        const wb: XLSX.WorkBook = XLSX.utils.book_new();
        XLSX.utils.book_append_sheet(wb, ws, 'StudentGrades');
        XLSX.writeFile(wb, 'StudentGrades.xlsx');
    }
}
