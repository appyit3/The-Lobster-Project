import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoryRoutingModule } from './story-routing.module';
import { StoryComponent } from './select-story/story.component';
import { ReadstoryComponent } from './read-story/read-story.component';
import { DynamicDialogModule } from 'primeng/dynamicdialog';
import { StoryService } from 'src/story/story.service';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    StoryComponent,
    ReadstoryComponent
  ],
  imports: [
    CommonModule,
    StoryRoutingModule,
    DynamicDialogModule,
    HttpClientModule
  ],
  providers: [ StoryService ],
  entryComponents: [ ReadstoryComponent ]
})
export class StoryModule { }
