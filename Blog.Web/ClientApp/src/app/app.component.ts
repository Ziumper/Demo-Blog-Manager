import { Component, OnInit } from '@angular/core';
import { HttpService } from './core/http.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  public hideLoader: boolean;

  constructor(){
    this.hideLoader = false;
}

  ngOnInit(): void {
     
    
  }
}
