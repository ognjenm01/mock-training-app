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
import { MatNativeDateModule } from '@angular/material/core';

@Component({
  selector: 'app-training-overview',
  imports: [MatFormFieldModule, MatInputModule, MatSelectModule, MatTableModule, MatIconModule, MatDatepickerModule, MatButtonModule, MatCardModule, MatCheckboxModule, FormsModule, MatNativeDateModule, CommonModule],
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
  selectedYear: number = new Date().getFullYear();
  weekData: WeekData[] = [];
  monthlyTraining: Training[] = [];
  displayedColumns: string[] = ['startDate', 'endDate', 'totalTrainings', 'totalDuration', 'averageDifficulty', 'averageTiredness'];

  public constructor(private trainingService: TrainingService) {}

  onMonthChange(event: any): void {
    this.selectedMonth = event.value;
    this.getWeeksInMonth(this.selectedYear, this.selectedMonth);
    
    this.trainingService.getByMonth(this.selectedMonth, this.selectedYear).subscribe({
      next: (result: Training[]) => {
        this.monthlyTraining = result;
        this.updateWeekdata();
      },

      error: (error) => {
        console.log(error);
      }
    })
  }

  onYearChange() {
    if(this.selectedMonth != 0) {
      this.getWeeksInMonth(this.selectedYear, this.selectedMonth);
      
      this.trainingService.getByMonth(this.selectedMonth, this.selectedYear).subscribe({
        next: (result: Training[]) => {
          this.monthlyTraining = result;
          this.updateWeekdata();
        },

        error: (error) => {
          console.log(error);
        }
      })
    }
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
          totalDuration: "00:00:00",
          totalTrainings: 0,
          averageDifficulty: 0,
          averageTiredness: 0
        }

        this.weekData.push(newW)
      })
  }

  updateWeekdata() {
    this.weekData.forEach(w => {
      this.monthlyTraining.forEach(t => {
        if(new Date(t.created) >= w.startDate && new Date(t.created) <= w.endDate)
        {
            w.totalTrainings++;
            w.averageTiredness += t.tiredness;
            w.averageDifficulty += t.difficulty;
            w.totalDuration = this.addTime(w.totalDuration, t.duration);
        }
      })

      w.averageDifficulty /= w.totalTrainings;
      w.averageDifficulty = Number(w.averageDifficulty.toFixed(2));
      
      w.averageTiredness /= w.totalTrainings;
      w.averageTiredness = Number(w.averageTiredness.toFixed(2));

      if(w.totalTrainings == 0)
      {
        w.averageDifficulty = 0;
        w.averageTiredness = 0;
      }
    })
  }

  addTime(timeSum: string, newTime: string) {
    const timeSumParts = timeSum.split(":").map(Number);
    const newTimeParts = newTime.split(":").map(Number);

    let hoursSum: number = timeSumParts[0];
    let minutesSum: number = timeSumParts[1];
    let secondsSum: number = timeSumParts[2];

    let hourNew: number = newTimeParts[0];
    let minuteNew: number = newTimeParts[1];
    let secondsNew: number = newTimeParts[2];

    hoursSum += hourNew;
    minutesSum += minuteNew;
    secondsSum += secondsNew;

    while(secondsSum >= 60) {
      secondsSum -= 60;
      minutesSum++;
    }

    while(minutesSum >= 60) {
      minutesSum -= 60
      hoursSum++;
    }

      return `${hoursSum.toString().padStart(2, '0')}:${minutesSum.toString().padStart(2, '0')}:${secondsSum.toString().padStart(2, '0')}`;
  }
}
