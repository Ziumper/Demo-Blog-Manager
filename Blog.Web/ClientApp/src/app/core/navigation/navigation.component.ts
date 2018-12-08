import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss']
})
export class NavigationComponent implements OnInit {

  public isCollapsed: boolean;

  constructor(private route: Router) {
    this.isCollapsed = true;

  }

  public ngOnInit(): void {

  }


}
