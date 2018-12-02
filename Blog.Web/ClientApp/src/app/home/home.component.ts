import { Component, OnInit } from '@angular/core';
import { PostListConfig } from '../core/config/post-list.config';
import { CategoryService } from '../category/category.service';
import { CategoryWithPostModel } from '../category/models/categoryWithPosts.model';
import { CategoryModel } from '../category/models/category.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit  {

  public categories: Array<CategoryWithPostModel>;

  constructor(private categoryService: CategoryService) {
    this.categories = new Array<CategoryWithPostModel>();
  }

  public ngOnInit(): void {

  }

}
