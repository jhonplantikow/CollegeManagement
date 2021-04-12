import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';

@Component({
  selector: 'app-list-subject',
  templateUrl: './list-subject.component.html',
})

export class ListSubjectComponent {
  public subject: ModelSubject[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<ModelSubject[]>(baseUrl + 'SubjectInfo').subscribe(result => {
      this.subject = result;
    }, error => console.error(error));
  }
}

interface ModelSubject {
  teacherName: string;
  teacherBirthday: string;
  subject: string;
  studentQTY: string;
  gradeSUM: string;
}
