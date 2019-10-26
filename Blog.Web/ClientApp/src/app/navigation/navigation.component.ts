import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { Subject, Observable, Subscription } from 'rxjs';
import { debounceTime, distinctUntilChanged, switchMap } from 'rxjs/operators';
import { PostService } from 'src/app/post/post.service';
import { PostModel } from 'src/app/post/models/post.model';

@Component({
  selector: 'app-blog-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss']
})
export class NavigationComponent implements OnInit, OnDestroy {

  public isCollapsed: boolean;


  private search: Subscription;

  constructor(private route: Router, private postService: PostService) {
    this.isCollapsed = true;
  }

  public ngOnInit(): void {
  }

  public ngOnDestroy(): void {

  }

}







