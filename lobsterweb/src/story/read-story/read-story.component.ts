import { Component, Input, OnInit } from '@angular/core';
import { StoryService } from 'src/story/story.service';
import { Story, StoryNode } from 'src/models/story.model';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';

@Component({
  selector: 'read-story',
  templateUrl: './read-story.component.html',
  styleUrls: ['./read-story.component.scss']
})
export class ReadstoryComponent implements OnInit {
  title = 'Read Story';
  story: Story;
  selectedNode: StoryNode;
  selectedNodePath: number[] = [];

  constructor(private storyService: StoryService, public dynaRef: DynamicDialogRef, public dynaConfig: DynamicDialogConfig) {
  }

  ngOnInit() {
    this.story = this.dynaConfig.data.story;
    this.selectedNode = this.story.RootNode;
    this.selectedNodePath.push(this.selectedNode.Id);
  }

  getNextNode(selectedChildNode: StoryNode){
    this.selectedNode = selectedChildNode;
    this.selectedNodePath.push(this.selectedNode.Id);
  }

  getSelectedPath(){
    this.dynaRef.close(this.selectedNodePath);
  }
}
