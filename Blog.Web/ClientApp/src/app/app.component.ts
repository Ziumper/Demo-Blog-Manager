import { Component, OnInit } from '@angular/core';
import { HttpService } from './core/services/http.service';
import { LoaderService } from './core/loader/loader.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  public hideLoader: boolean;

  constructor(private loaderService: LoaderService) {
    this.hideLoader = true;
}

  ngOnInit(): void {
    this.subscribeToLoad();
  }

  private subscribeToLoad(): void {
    const loaderObservable = this.loaderService.getLoaderObservable();
    loaderObservable.subscribe((isLoading: boolean) => {
      this.hideLoader = !isLoading;
    });
  }
}
