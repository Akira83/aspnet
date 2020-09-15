import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  registerMode: any;
  values: any;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getValues();
  }

  registerToggle(): void {
    this.registerMode = !this.registerMode;
  }

  getValues() {
    this.http.get('http://localhost:5000/api/values').subscribe(response => {
      this.values = response;
    }, error => {
      console.error(error);
    });
  }

}
