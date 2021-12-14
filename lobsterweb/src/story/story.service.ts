import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from 'src/environments/environment';
import { Story } from 'src/models/story.model';
import { UserHistory } from 'src/models/userhistory.model';
import { BehaviorSubject, map, Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class StoryService {
  private storySubject: BehaviorSubject<Story>;
  public story: Observable<Story>;

  constructor(private http: HttpClient) {
    this.storySubject = new BehaviorSubject<Story>(new Story());
    this.story = this.storySubject.asObservable();
  }

  public get storyValue(): Story | null {
    return this.storySubject.value;
  }

  getStory() {
    return this.http.get<Story>(`${environment.apiUrl}/Story`).pipe(
      map((res) => {
        this.storySubject.next(res);
        return res;
      })
    );
  }

  submitStory(params: UserHistory) {
    return this.http.post<any>(
      `${environment.apiUrl}/Story/createhistory`,
      params
    );
  }
}
