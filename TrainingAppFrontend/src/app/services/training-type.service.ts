import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TrainingType } from '../models/training-type.model';
import { Observable } from 'rxjs';
import { environment } from '../../enviroment';

@Injectable({
  providedIn: 'root'
})
export class TrainingTypeService {

  constructor(private http: HttpClient) {}

    getTrainingTypes(): Observable<TrainingType[]> {
      return this.http.get<TrainingType[]>(`${environment.apiUrl}/trainingtype`);
    }
}
