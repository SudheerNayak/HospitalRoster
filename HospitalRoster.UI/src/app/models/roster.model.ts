export interface Roster {
  rosterId: number;
  staffId: number;
  staffName?: string;
  shiftId: number;
  shiftName?: string;
  date: Date | string;
  departmentId: number;
  departmentName?: string;
  isApproved: boolean;
  createdDate?: Date | string;
  modifiedDate?: Date | string;
}