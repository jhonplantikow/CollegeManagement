import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { environment } from '../../environments/environment';
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-teacher',
  templateUrl: './teacher.component.html',
  styleUrls: ['./teacher.component.css']
})
export class TeacherComponent implements OnInit {

  //#region Variables

  public teachers: Array<Teacher>;
  private teacherPath = environment.apiURL + 'Teacher';
  teacherForm: FormGroup;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Accept': 'application/json'
    })
  };

  //#endregion Variables

  //#region Constructor

  constructor(private http: HttpClient, private fb: FormBuilder) {


    this.teacherForm = this.fb.group({
      'id': 0,
      'name': ['', [Validators.required]],
      'birthday': ['', [Validators.required]],
      'salary': ['', [Validators.required]]
    });
  }

  //#endregion Constructor

  //#region Init

  ngOnInit(): void {
    this.GetData();
  }

  //#endregion Init

  //#region Form

  clearForm() {
    this.teacherForm.reset({
      'id': 0,
      'name': '',
      'birthday': '',
      'salary': ''
    });
  }

  bindForm(teachaer) {
    this.teacherForm.setValue({
      'id': teachaer.id,
      'name': teachaer.name,
      'birthday': formatDate(teachaer.birthday, "yyyy-MM-dd", "en-US"),
      'salary': teachaer.salary,

    });
  }

  submitForm() {
    var teacher: Teacher = this.teacherForm.value;
    teacher.id > 0 ? this.update() : this.insert();
  }

  //#endregion Form

  //#region CRUD

  GetData() {
    this.http.get<Teacher[]>(this.teacherPath).subscribe(result => {
      this.teachers = result;
    }, error => console.error(error));
  }

  insert() {
    this.http.post<Teacher>(this.teacherPath, this.teacherForm.value, this.httpOptions).subscribe(result => {
      this.clearForm();
      this.GetData();
    }, error => console.error(error));
  }

  update() {
    this.http.put<Teacher>(this.teacherPath, this.teacherForm.value, this.httpOptions).subscribe(result => {
      this.clearForm();
      this.GetData();
    }, error => console.error(error));
  }

  delete(id) {
    this.http.delete<Teacher>(`${this.teacherPath}/${id}`, this.httpOptions).subscribe(result => {
      this.GetData();
    }, error => console.error(error));
  }

  //#endregion CRUD

  // #region Gets

  get id() {
    return this.teacherForm.get('id');
  }

  get name() {
    return this.teacherForm.get('name');
  }

  get birthday() {
    return this.teacherForm.get('birthday');
  }

  get salary() {
    return this.teacherForm.get('salary');
  }

  //#endregion Gets

}

interface Teacher {
  id: number,
  name: string,
  birthday: Date,
  salary: number
}
