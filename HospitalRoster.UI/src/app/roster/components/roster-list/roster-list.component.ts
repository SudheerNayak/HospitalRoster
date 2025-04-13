// roster-list.component.ts
import { Component, OnInit } from '@angular/core';
import { Roster } from '../../../models/roster.model';
import { RosterService } from '../../services/roster.service';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-roster-list',  
  standalone:true,
  imports: [CommonModule, RouterModule,],
  templateUrl: './roster-list.component.html',
  styleUrls: ['./roster-list.component.css']
})
export class RosterListComponent implements OnInit {
  rosters: Roster[] = [];
  isLoading = true;
  currentDate = new Date();

  constructor(private rosterService: RosterService) { }

  ngOnInit(): void {
    this.loadRosters();
  }

  loadRosters(): void {
    this.isLoading = true;
    const startDate = this.formatDate(new Date(this.currentDate.getFullYear(), this.currentDate.getMonth(), 1));
    const endDate = this.formatDate(new Date(this.currentDate.getFullYear(), this.currentDate.getMonth() + 1, 0));
    
    this.rosterService.getRostersByDateRange(startDate, endDate).subscribe({
      next: (rosters) => {
        this.rosters = rosters;
        this.isLoading = false;
      },
      error: (err) => {
        console.error('Error loading rosters:', err);
        this.isLoading = false;
      }
    });
  }

  private formatDate(date: Date): string {
    return date.toISOString().split('T')[0];
  }

  changeMonth(offset: number): void {
    this.currentDate = new Date(this.currentDate.getFullYear(), this.currentDate.getMonth() + offset, 1);
    this.loadRosters();
  }
}