import { Component, EventEmitter, Output } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TrainingType } from '../../models/training-type.model';
import { TrainingTypeService } from '../../services/training-type.service';
import { CommonModule } from '@angular/common';
import { MatSelectModule } from '@angular/material/select';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-training-type-select',
  imports: [CommonModule, MatSelectModule, FormsModule],
  templateUrl: './training-type-select.component.html',
  styleUrl: './training-type-select.component.css'
})

export class TrainingTypeSelectComponent {
    trainingTypes: TrainingType[] = [];
    selectedTrainingType: TrainingType = {id:1, name: ""};

    @Output() trainingTypeSelected = new EventEmitter<TrainingType>();

    constructor(private trainingTypeService: TrainingTypeService) {}

    ngOnInit(): void {
      this.trainingTypeService.getTrainingTypes().subscribe({
        next: (result) => {
          this.selectedTrainingType = result[0];
          this.trainingTypes = result;
        },

        error: (error) => {
          console.log(error);
        }
      })
    }

    onSelectionChange(trainingTypeId: number): void {
      this.selectedTrainingType = this.trainingTypes.find(t => t.id === trainingTypeId)!;
      this.trainingTypeSelected.emit(this.selectedTrainingType);
    }
  
}
