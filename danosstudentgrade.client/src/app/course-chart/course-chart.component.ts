import { Component, OnInit } from '@angular/core';
import { ApiService, CourseAverageDto } from '../services/api.service';
import { ChartConfiguration, ChartOptions } from 'chart.js';

/**
 * Component for displaying course averages in a bar chart
 */
@Component({
    selector: 'app-course-chart',
    templateUrl: './course-chart.component.html',
    styleUrls: ['./course-chart.component.css']
})
export class CourseChartComponent implements OnInit {
    public barChartLegend = true;
    public barChartPlugins = [];

    public barChartData: ChartConfiguration<'bar'>['data'] = {
        labels: [],
        datasets: [
            { data: [], label: 'Average Grade' }
        ]
    };

    public barChartOptions: ChartConfiguration<'bar'>['options'] = {
        responsive: true,
    };

    constructor(private apiService: ApiService) { }

    /**
     * Loads course data on component initialization
     */
    ngOnInit() {
        this.apiService.getDashboardData().subscribe(data => {
            this.updateChart(data.courseAverages);
        });
    }

    /**
     * Updates the chart with course average data
     */
    updateChart(courseAverages: CourseAverageDto[]) {
        this.barChartData = {
            labels: courseAverages.map(c => c.courseName),
            datasets: [
                { data: courseAverages.map(c => c.averageGrade), label: 'Average Grade' }
            ]
        };
    }
}
