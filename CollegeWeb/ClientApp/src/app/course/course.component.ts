import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { environment } from '../../environments/environment';
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.css']
})
export class CourseComponent implements OnInit {
  //#region Variables

  public courses: Array<Course>;
  private coursesPath = environment.apiURL + 'Courses';
  courseForm: FormGroup;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Accept': 'application/json'
    })
  };

  //#endregion Variables

  //#region Constructor

  constructor(private http: HttpClient, private fb: FormBuilder) {


    this.courseForm = this.fb.group({
      'id': 0,
      'name': ['', [Validators.required]]
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
    this.courseForm.reset({
      'id': 0,
      'name': ''
    });
  }

  bindForm(courses) {
    console.log(courses);
    this.courseForm.setValue({
      'id': courses.id,
      'name': courses.name
    });
  }

  submitForm() {
    var courses: Course = this.courseForm.value;
    courses.id > 0 ? this.update() : this.insert();
  }

  //#endregion Form

  //#region CRUD

  GetData() {
    this.http.get<Course[]>(this.coursesPath).subscribe(result => {
      this.courses = result;
    }, error => console.error(error));
  }

  insert() {
    this.http.post<Course>(this.coursesPath, this.courseForm.value, this.httpOptions).subscribe(result => {
      this.clearForm();
      this.GetData();
    }, error => console.error(error));
  }

  update() {
    this.http.put<Course>(this.coursesPath, this.courseForm.value, this.httpOptions).subscribe(result => {
      this.clearForm();
      this.GetData();
    }, error => console.error(error));
  }

  delete(id) {
    console.log(`${this.coursesPath}/${id}`);

    this.http.delete<Course>(`${this.coursesPath}/${id}`, this.httpOptions).subscribe(result => {
      this.GetData();
    }, error => console.error(error));
  }

  //#endregion CRUD

  // #region Gets

  get id() {
    return this.courseForm.get('id');
  }

  get name() {
    return this.courseForm.get('name');
  }

  get birthday() {
    return this.courseForm.get('birthday');
  }

  get salary() {
    return this.courseForm.get('salary');
  }

  //#endregion Gets
}

interface Course {
  id: number,
  name: string
}

