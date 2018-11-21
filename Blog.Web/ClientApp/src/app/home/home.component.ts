import { Component, OnInit } from '@angular/core';
import { BaseQueryModel } from '../core/models/base-query.model';
import { PostQueryModel } from '../post/models/post-query.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  public postQuery: PostQueryModel;

  constructor() {
    this.postQuery = new PostQueryModel(1, 10, 1, true, '',0,0);
  }

  public ngOnInit(): void {
  }

}
