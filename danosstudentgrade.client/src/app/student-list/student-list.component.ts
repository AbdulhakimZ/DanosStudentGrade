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

    constructor(private apiService: ApiService) { }

    /**
     * Fetches student data from the API
     */
    fetchData() {
        this.apiService.getDashboardData().subscribe(data => {
            this.studentAverages = data.studentAverages;
        });
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
