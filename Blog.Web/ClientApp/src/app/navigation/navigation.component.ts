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

  // public searchTerm: Subject<string>;
  public isCollapsed: boolean;
  // public posts: Array<PostModel>;

  private search: Subscription;

  constructor(private route: Router, private postService: PostService) {
    this.isCollapsed = true;
    // this.posts = new Array<PostModel>();
    // this.searchTerm = new Subject<string>();
  }

  public ngOnInit(): void {
    // this.search = this.onSearch(this.searchTerm).subscribe(response => {
    //   this.posts = response;
    // });
  }

  public ngOnDestroy(): void {
    // this.search.unsubscribe();
  }

  // private onSearch(searchTerm: Observable<string>): Observable<Array<PostModel>> {
  //   // return searchTerm.pipe(
  //   //     debounceTime(400),
  //   //     distinctUntilChanged(),
  //   //     switchMap((query: string) => {
  //   //       if (query.length > 0) {
  //   //         return this.postService.getPostsByContentOrTitle(query);
  //   //       } else {
  //   //         this.posts = new Array<PostModel>();
  //   //       }
  //   //       return new Observable<any> ();
  //   //     })
  //   // );
}







