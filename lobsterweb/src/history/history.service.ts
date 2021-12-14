import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from 'src/environments/environment';
import { Story } from 'src/models/story.model';
import { UserHistory } from 'src/models/userhistory.model';

@Injectable({ providedIn: 'root' })
export class HistoryService {
    constructor(private http: HttpClient) { }

    getStory() {
        return this.http.get<Story>(`${environment.apiUrl}/Story`);
    }

    getHistory() {
        return this.http.get<UserHistory[]>(`${environment.apiUrl}/Story/gethistory`);
    }
}