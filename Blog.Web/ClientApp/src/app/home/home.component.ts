import { Component, OnInit } from '@angular/core';
import { PostListConfig } from '../core/config/post-list.config';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent extends PostListConfig {
  public onSearch(searchQuery: string): void {
      console.log('Im searching for posts');
      this.postQueryModel.searchQuery = searchQuery;
      this.getPosts();
  }
}
