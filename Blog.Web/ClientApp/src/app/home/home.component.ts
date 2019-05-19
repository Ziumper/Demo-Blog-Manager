import { Component, OnInit } from '@angular/core';
import { PostQueryModel } from '../post/models/post-query.model';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit  {
  public postQuery: PostQueryModel;

  constructor() {
    this.postQuery = new PostQueryModel();
  }

  public ngOnInit(): void {
    this.postQuery.order = true;
    this.postQuery.page = 1;
    this.postQuery.size = 10;
    this.postQuery.filter = 1;
    this.postQuery.searchQuery = '';
  }

}
