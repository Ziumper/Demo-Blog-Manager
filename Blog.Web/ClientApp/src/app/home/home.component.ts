import { Component, OnInit } from '@angular/core';
import { BaseQueryModel } from '../core/models/base-query.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  public postQuery: BaseQueryModel;

  constructor() {
    this.postQuery = new BaseQueryModel(1, 10, 1, true, '');
  }

  public ngOnInit(): void {
  }

}
