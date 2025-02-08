import { Component } from '@angular/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button'
import { FormsModule } from '@angular/forms';
import { TrainingTypeSelectComponent } from "../training-type-select/training-type-select.component";
import { TrainingType } from '../../models/training-type.model';
import { Training } from '../../models/training.model';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { TrainingService } from '../../services/training.service';

@Component({
  selector: 'app-training-input',
  imports: [MatCardModule, MatFormFieldModule, MatIconModule, MatInputModule, MatButtonModule, FormsModule,
            MatDatepickerModule, MatNativeDateModule, TrainingTypeSelectComponent, TrainingTypeSelectComponent],
  templateUrl: './training-input.component.html',
  styleUrl: './training-input.component.css'
})
export class TrainingInputComponent {
  selectedTrainingType : TrainingType = {
    id: 1,
    name: ""
  }

  constructor(private trainingService: TrainingService) {}

  training: Training = {
    id : 0,
    typeId: 1,
    type: this.selectedTrainingType,
    duration: "00:00:00",
    difficulty: 5,
    tiredness: 5,
    caloriesBurned: 0,
    note: "",
    created: new Date(),
    userId: 0,
  }

  selectedDate: Date | null = null;
  selectedTime: string = "00:00";

  onTrainingTypeSelected(trainingType: TrainingType) {
    this.selectedTrainingType = trainingType;
    this.training.type = this.selectedTrainingType;
    this.training.typeId = this.selectedTrainingType.id;
  }

  onSubmit() {
    if (this.selectedDate && this.selectedTime) {
      const [hours, minutes] = this.selectedTime.split(":").map(Number);
      this.training.created = new Date(this.selectedDate);
      this.training.created.setHours(hours + 1, minutes, 0);

      this.trainingService.addTraining(this.training).subscribe({
        next: (result) => {

        },

        error: (error) => {
          console.log(error);
        }
      })
    }
  }
}
