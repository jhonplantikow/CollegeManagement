import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';

@Component({
  selector: 'app-list-student',
  templateUrl: './list-student.component.html'
})

export class ListStudentComponent {
  public students: ModelStudent[];


constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<ModelStudent[]>(baseUrl + 'StudentGrade').subscribe(result => {
      this.students = result;
    }, error => console.error(error));
  }
}

interface ModelStudent {
  student: string;
  subject: string;
  studentName: string;
}
