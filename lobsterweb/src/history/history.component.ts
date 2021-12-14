import { Component, OnInit } from '@angular/core';
import { HistoryService } from 'src/history/history.service';
import { Story, StoryNode } from 'src/models/story.model';
import { UserHistory } from 'src/models/userhistory.model';
import { StoryService } from 'src/story/story.service';
import { TreeNode } from 'primeng/api';

@Component({
  selector: 'history',
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.scss'],
})
export class HistoryComponent implements OnInit {
  title = 'History';
  history: UserHistory[] = [];
  story: Story;
  histEvent: UserHistory;
  arrTreeNode: TreeNode[] = [];
  arrStoryNode: StoryNode[] = [];

  constructor(
    private histService: HistoryService,
    private storyService: StoryService
  ) {}

  ngOnInit() {
    this.histService.getHistory().subscribe({
      next: (result) => {
        if (result.length) {
          this.history = result;

          //optimization. If story already loaded then use it, else fetch.
          if (
            this.storyService.storyValue &&
            this.storyService.storyValue.StoryId
          ) {
            this.story = this.storyService.storyValue;
            this.arrStoryNode.push(this.story.RootNode);
            // this.mapStoryToTree();
            this.mapHistoryToTree(this.history[0]);
          } 
          else {
            this.histService.getStory().subscribe({
              next: (result) => {
                this.story = result;
                this.arrStoryNode.push(this.story.RootNode);
                // this.mapStoryToTree();
                this.mapHistoryToTree(this.history[0]);
              },
              error: (err) => console.error(err),
              complete: () => console.info('complete hist and story'),
            });
          }
        }
      },
      error: (err) => console.error(err),
      complete: () => console.info('complete history'),
    });
  }

  //doing recursion to map our Story to Tree which Primeng UI understands
  public mapStoryToTree() {
    const treeMap = (inputTree: StoryNode[]): TreeNode[] =>
      inputTree.map((t) => ({
        data: { Id: t.Id, Name: t.Name, Description: t.Description },
        children: treeMap(t.ChildNodes),
      }));

    this.arrTreeNode = treeMap(this.arrStoryNode);
  }

  //showing the history array with the help of mapping it into the story tree
  mapHistoryToTree(hist: UserHistory) {
    this.mapStoryToTree();
    var selectedNodes = [...hist.SelectedNodes];
    selectedNodes.shift();
    this.selectTreeNode(this.arrTreeNode[0], selectedNodes);
  }

  //Recursion again. So much fun!!!
  selectTreeNode(trNode: TreeNode | undefined, selectedNodes: number[]) {
    var selectedId = selectedNodes.shift();
    if (trNode) {
      trNode.type = 'selected';
      var childTrNode = trNode.children?.find((x) => x.data.Id == selectedId);
      this.selectTreeNode(childTrNode, selectedNodes);
    }
  }

  paginate(event: any) {
    //event.page = Index of the new page -> this is zero indexed
    this.mapHistoryToTree(this.history[event.page]);
  }
}
