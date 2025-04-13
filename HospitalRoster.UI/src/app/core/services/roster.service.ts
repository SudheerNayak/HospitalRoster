// services/roster.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Roster } from '../models/roster.model';

@Injectable({
  providedIn: 'root'
})
export class RosterService {
  private apiUrl = `${environment.apiUrl}/roster`;

  constructor(private http: HttpClient) { }

  getRosters(): Observable<Roster[]> {
    return this.http.get<Roster[]>(this.apiUrl);
  }

  getRoster(id: number): Observable<Roster> {
    return this.http.get<Roster>(`${this.apiUrl}/${id}`);
  }

  createRoster(roster: Roster): Observable<Roster> {
    return this.http.post<Roster>(this.apiUrl, roster);
  }

  updateRoster(id: number, roster: Roster): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, roster);
  }

  deleteRoster(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

  getRostersByDateRange(startDate: string, endDate: string): Observable<Roster[]> {
    return this.http.get<Roster[]>(`${this.apiUrl}/range?start=${startDate}&end=${endDate}`);
  }
}