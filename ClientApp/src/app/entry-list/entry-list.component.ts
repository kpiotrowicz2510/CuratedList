import { Component, Inject } from '@angular/core';
import {HttpClient, HttpErrorResponse} from '@angular/common/http';
import {NgForm} from "@angular/forms";

@Component({
  selector: 'app-entry-list',
  templateUrl: './entry-list.component.html'
})
export class EntryListComponent {
  public linkEntries: LinkEntry[];
  public tableName: string;
  private httpClient: HttpClient;
  private baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.httpClient = http;
    this.baseUrl = baseUrl;
    this.httpClient.get<LinkEntry[]>(this.baseUrl + 'api').subscribe(result => {
      this.linkEntries = result;
    }, error => console.error(error));
    this.tableName = 'Your entries';
  }

  onSubmit(form: NgForm){
    let tagList: LinkTag[] = [];
    const tagsArray = form.value.tags.split(',');
    for(let tag of tagsArray){
      let newLinkTag = new LinkTag;
      newLinkTag.name = tag;
      tagList.push(newLinkTag);
    }

    const newLinkEntry = {
      targetUrl:form.value.targetUrl,
      imageUrl:form.value.imageUrl,
      userName:form.value.userName,
      name:form.value.name,
      description:form.value.description,
      tags: tagList
    };
    this.httpClient.post<LinkEntry>(this.baseUrl + 'api', newLinkEntry)
      .subscribe(response => {
        this.linkEntries.push(response);
      },(err: HttpErrorResponse) => {
        console.log(err);
      });
  }
}
class LinkTag {
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
