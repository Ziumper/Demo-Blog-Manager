import { Component, OnInit } from '@angular/core';
import { PostQueryModel } from '../post/models/post-query.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  public postQueryModel: PostQueryModel;

  constructor() {
    this.postQueryModel = new PostQueryModel();
    this.postQueryModel.filter = 1; // sort by date
    this.postQueryModel.order = true; // sort descending;
    this.postQueryModel.page = 1;
    this.postQueryModel.size = 10;
  }

  public ngOnInit(): void {
  }

}
