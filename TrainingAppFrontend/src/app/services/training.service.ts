import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Training } from '../models/training.model';
import { Observable } from 'rxjs';
import { environment } from '../../enviroment';

@Injectable({
  providedIn: 'root'
})
export class TrainingService {

  constructor(private http: HttpClient) {}
  
  addTraining(training: Training): Observable<Training> {
    return this.http.post<Training>(`${environment.apiUrl}/training`, training);
  }

  getByMonth(month: number, year: number): Observable<Training[]> {
    return this.http.get<Training[]>(`${environment.apiUrl}/training/overview?month=${month}&year=${year}`);
  }
}
