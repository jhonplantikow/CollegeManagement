import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { environment } from '../../environments/environment';


@Component({
  selector: 'app-subject',
  templateUrl: './subject.component.html',
  styleUrls: ['./subject.component.css']
})

export class SubjectComponent implements OnInit {

  //#region Variables

  public subjects: Array<Subject>;
  public courses: Array<Course>;
  private subjectPath = environment.apiURL + 'Subject';
  private coursePath = environment.apiURL + 'Courses';
  subjectForm: FormGroup;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Accept': 'application/json'
    })
  };

  //#endregion Variables

  //#region Constructor

  constructor(private http: HttpClient, private fb: FormBuilder) {

    this.subjectForm = this.fb.group({
      'id': 0,
      'courseID': [0],
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
    this.subjectForm.reset({
      'id': 0,
      'courseID': 0,
      'name': ''
    });
  }

  bindForm(subject) {
    this.subjectForm.setValue({
      'id': subject.id,
      'courseID': subject.courseID ,
      'name': subject.name
    });
  }
  //group.setValue({foo: 'foo', bar: 'bar'}); 

  submitForm() {
    var st: Subject = this.subjectForm.value;
    //Check if this request is update or insert
    st.id > 0 ? this.update() : this.insert();
  }

  //#endregion Form

  //#region CRUD

  GetData() {
    this.http.get<Subject[]>(this.subjectPath).subscribe(result => {
      this.subjects = result;
    }, error => console.error(error));

    this.http.get<Course[]>(this.coursePath).subscribe(result => {
      this.courses = result;
    }, error => console.error(error));
  }

  insert() {
    this.http.post<Subject>(this.subjectPath, this.subjectForm.value, this.httpOptions).subscribe(result => {
      this.clearForm();
      this.GetData();
    }, error => console.error(error));
  }

  update() {
    this.http.put<Subject>(this.subjectPath, this.subjectForm.value, this.httpOptions).subscribe(result => {
      this.clearForm();
      this.GetData();
    }, error => console.error(error));
  }

  delete(id) {
    this.http.delete<Subject>(`${this.subjectPath}/${id}`, this.httpOptions).subscribe(result => {
      this.GetData();
    }, error => console.error(error));
  }

  //#endregion CRUD

  // #region Gets

  get id() {
    return this.subjectForm.get('id');
  }

  get courseId() {
    return this.subjectForm.get('courseID');
  }

  get courseName() {
    return this.subjectForm.get('courseName');
  }

  get name() {
    return this.subjectForm.get('name');
  }

  //#endregion Gets
}

interface Subject {
  id: number,
  courseID: number,
  courseName: string,
  name: string
}

interface Course {
  id: number,
  name: string
}
