import { Component } from '@angular/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { WeekData } from "../../models/week-data.model"
import { Training } from '../../models/training.model';
import { TrainingService } from '../../services/training.service';

@Component({
  selector: 'app-training-overview',
  imports: [MatFormFieldModule, MatInputModule, MatSelectModule, MatTableModule, MatIconModule, MatDatepickerModule, MatButtonModule, MatCardModule, MatCheckboxModule, FormsModule, CommonModule],
  templateUrl: './training-overview.component.html',
  styleUrl: './training-overview.component.css'
})
export class TrainingOverviewComponent {
  months = [
    { value: 1, name: 'January' },
    { value: 2, name: 'February' },
    { value: 3, name: 'March' },
    { value: 4, name: 'April' },
    { value: 5, name: 'May' },
    { value: 6, name: 'June' },
    { value: 7, name: 'July' },
    { value: 8, name: 'August' },
    { value: 9, name: 'September' },
    { value: 10, name: 'October' },
    { value: 11, name: 'November' },
    { value: 12, name: 'December' }
  ];

  selectedMonth = 0;
  weekData: WeekData[] = [];
  displayedColumns: string[] = ['startDate', 'endDate', 'totalTrainings', 'totalDuration', 'averageDifficulty', 'averageTiredness'];

  public constructor(private trainingService: TrainingService) {}

  onMonthChange(event: any): void {
    this.selectedMonth = event.value;
    this.getWeeksInMonth(2025, this.selectedMonth);
    
    this.trainingService.getByMonth(this.selectedMonth).subscribe({
      next: (result: Training[]) => {

      },

      error: (error) => {
        console.log(error);
      }
    })
  }

  getWeeksInMonth(year: number, month: number){
    this.weekData = [];

    //U bazi se cuvaju normalno, medjutim u js meseci idu od 0 pa zato -1
    const firstDayOfMonth = new Date(year, month - 1, 1);
    const lastDayOfMonth = new Date(year, month, 0);

    let weeks = [];
    let currentWeekStart = firstDayOfMonth;
    let currentWeekEnd = new Date(currentWeekStart);
    currentWeekEnd.setDate(currentWeekStart.getDate() + 6);

    while (currentWeekStart <= lastDayOfMonth) {

      if (currentWeekEnd > lastDayOfMonth) {
        currentWeekEnd = lastDayOfMonth;
        weeks.push({ startDate: new Date(currentWeekStart), endDate: new Date(currentWeekEnd) });
        break;
      }

      weeks.push({ startDate: new Date(currentWeekStart), endDate: new Date(currentWeekEnd) });

      currentWeekStart.setDate(currentWeekStart.getDate() + 7);
      currentWeekEnd.setDate(currentWeekEnd.getDate() + 7);
    }

      weeks.forEach(w => {
        let newW : WeekData = {
          startDate: w.startDate,
          endDate: w.endDate,
          totalDuration: "",
          totalTrainings: 0,
          averageDifficulty: 0,
          averageTiredness: 0
        }

        this.weekData.push(newW)
      })
  }
}
