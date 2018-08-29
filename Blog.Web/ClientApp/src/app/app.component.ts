import { Component, OnInit } from '@angular/core';
import { HttpService } from './core/http.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  public showLoader: boolean;

  constructor(private http: HttpService){
    this.showLoader = true;

    
    this.http.getLoader().subscribe(isLoading => {
      this.showLoader = isLoading;
  })
  
  }

  ngOnInit(): void {
     
    
  }
}
