import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-entry-list',
  templateUrl: './entry-list.component.html'
})
export class EntryListComponent {
  public linkEntries: LinkEntry[];
  public tableName: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<LinkEntry[]>(baseUrl + 'api').subscribe(result => {
      this.linkEntries = result;
    }, error => console.error(error));
    this.tableName = 'Your entries';
  }
}
interface LinkTag {
  name: string;
}
interface LinkEntry {
  id: number;
  name: string;
  userName: string;
  description: string;
  targetUrl: string;
  imageUrl: string;
  tags: LinkTag[];
}
