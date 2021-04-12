import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { environment } from '../../environments/environment';
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css']
})

export class StudentComponent implements OnInit {

  //#region Variables

  public students: Array<Student>;
  private studentPath = environment.apiURL + 'Student';
  studentForm: FormGroup;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Accept': 'application/json'
    })
  };

  //#endregion Variables

  //#region Constructor

  constructor(private http: HttpClient, private fb: FormBuilder) {

    this.studentForm = this.fb.group({
      'id': 0,
      'name': ['', [Validators.required]],
      'birthday': ['', [Validators.required]]
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
    this.studentForm.reset({
      'id': 0,
      'name': '',
      'birthday':''
    });
    //this.studentForm.setValue({
    //  'id': 0,
    //  'name': '',
    //  'birthday': ''
    //});
  }

  bindForm(student) {
    this.studentForm.setValue({
      'id': student.id,
      'name': student.name,
      'birthday': formatDate(student.birthday, "yyyy-MM-dd", "en-US")
    });
  }

  submitForm() {
    var st: Student = this.studentForm.value;
    //Check if this request is update or insert
    st.id > 0 ? this.update() : this.insert();
  }

  //#endregion Form

  //#region CRUD

  GetData() {
    this.http.get<Student[]>(this.studentPath).subscribe(result => {
      this.students = result;
    }, error => console.error(error));
  }

  insert() {
    this.http.post<Student>(this.studentPath, this.studentForm.value, this.httpOptions).subscribe(result => {
      this.clearForm();
      this.GetData();
    }, error => console.error(error));
  }

  update() {
    this.http.put<Student>(this.studentPath, this.studentForm.value, this.httpOptions).subscribe(result => {
      this.clearForm();
      this.GetData();
    }, error => console.error(error));
  }

  delete(id) {
    this.http.delete<Student>(`${this.studentPath}/${id}`, this.httpOptions).subscribe(result => {
      this.GetData();
    }, error => console.error(error));
  }

  //#endregion CRUD

  // #region Gets

  get id() {
    return this.studentForm.get('id');
  }

  get name() {
    return this.studentForm.get('name');
  }

  get birthday() {
    return this.studentForm.get('birthday');
  }

  //#endregion Gets
}

interface Student {
  id: number,
  name: string,
  birthday: Date
}
