import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';

@Component({
  selector: 'app-list-course',
  templateUrl: './list-course.component.html'
})

export class ListCourseComponent {
  //public students: ModelStudent[];



  columnDefs = [
    { field:'courseName', headerName:'Course Name' },
    { field:'qtyStudent', headerName:'QTY Student' },
    { field:'avgStudent', headerName:'AVG Student' },
    { field:'qtyTeacher', headerName:'QTY Teacher' }
  ];

  rowData: any[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<ModelStudent[]>(baseUrl + 'AvgByCourse').subscribe(result => {
      this.rowData = result;
    }, error => console.error(error));
  }
}

interface ModelStudent {
  courseName: string;
  qtyStudent: string;
  avgStudent: string;
  qtyTeacher: string;
}
