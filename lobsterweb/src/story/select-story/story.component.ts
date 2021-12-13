import { Component, OnInit, OnDestroy } from '@angular/core';
import { StoryService } from 'src/story/story.service';
import { Story, StoryNode } from 'src/models/story.model';
import { ReadstoryComponent } from 'src/story/read-story/read-story.component';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { UserHistory } from 'src/models/userhistory.model';

@Component({
  selector: 'story',
  templateUrl: './story.component.html',
  styleUrls: ['./story.component.scss'],
  providers: [DialogService],
})
export class StoryComponent implements OnInit, OnDestroy {
  title = 'Story';
  stories: Story[] = [];
  dynaRef: DynamicDialogRef;

  constructor(
    private storyService: StoryService,
    public dialogService: DialogService
  ) {
  }

  ngOnInit() {
    this.storyService.getStory().subscribe({
      next: (result) => {
        this.stories.push(result);
        console.log(result);
      },
      error: (err) => console.error(err),
      complete: () => console.info('story complete'),
    });
  }

  startStory(selectedStory: Story) {
    const ref = this.dialogService.open(ReadstoryComponent, {
      width: '30%',
      baseZIndex: 10000,
      data: { story: selectedStory }
    });

    ref.onClose.subscribe((selectedNodePath: number[]) => {
      if (selectedNodePath) {
        var userHist: UserHistory = {
          StoryId: 1,
          SelectedNodes: selectedNodePath
        }
        this.storyService.submitStory(userHist).subscribe({
          next: (result) => {
            console.log(result);
          },
          error: (err) => console.error(err),
          complete: () => console.info('hist complete'),
        });
      }
  });
  }

  ngOnDestroy() {
    if (this.dynaRef) {
      this.dynaRef.close();
    }
  }
}
