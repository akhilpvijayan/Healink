import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTabGroup } from '@angular/material/tabs';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent implements OnInit{
  searchQuery: any
  @ViewChild(MatTabGroup) tabGroup!: MatTabGroup;
  constructor(
    private route: ActivatedRoute
  ){}
  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.searchQuery = params['q'];
    });
  }

  navigateToPeopleTab(tabId: number) {
    const organizationsTabIndex = tabId;
    this.tabGroup.selectedIndex = organizationsTabIndex;
  }

}
