import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoryRoutingModule } from './story-routing.module';
import { StoryComponent } from './select-story/story.component';
import { ReadstoryComponent } from './read-story/read-story.component';
import { DynamicDialogModule } from 'primeng/dynamicdialog';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { JwtInterceptor } from 'src/helpers/jwt.interceptor';
import { ErrorInterceptor } from 'src/helpers/error.interceptor';

@NgModule({
  declarations: [StoryComponent, ReadstoryComponent],
  imports: [
    CommonModule,
    StoryRoutingModule,
    DynamicDialogModule,
    HttpClientModule,
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
  ],
  entryComponents: [ReadstoryComponent],
})
export class StoryModule {}
